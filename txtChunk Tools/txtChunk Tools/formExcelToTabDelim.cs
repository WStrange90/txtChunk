using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Reflection;
using System.IO;
using System.Text.RegularExpressions;
using OfficeOpenXml;
using WebUI.Infrastructure;

namespace txtChunk
{

    public partial class formExcelToTabDelim : Form
    {
        string inputFolderLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/excelTabDelimInput";
        string outputFolderLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/excelTabDelimOutput";


        public formExcelToTabDelim()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            bool trimRows = endOfLineCheckbox.Checked;
            string endOfLineString = endOfLineIdent.Text;

            ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;

            string[] inputFiles = Directory.GetFiles(inputFolderLocation, "*.xlsx");

            foreach (var file in inputFiles)
            {
                try
                {
                    Console.WriteLine("Messages for " + Path.GetFileName(file) + ":");
                    Console.ForegroundColor = ConsoleColor.Red;
                    saveAsDelimited(file, trimRows, endOfLineString);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("File " + file + " has been succesfully saved to output.");
                    Console.ResetColor();
                }
                catch (Exception ex)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERROR on file " + file + " : " + ex);

                    DialogResult option = MessageBox.Show("ERROR on file " + file + " : " + ex, "Close", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    if (option == DialogResult.Yes)
                    {
                        this.Close();
                    }

                    Console.ResetColor();
                }

            }//End of foreach file

            DialogResult done = MessageBox.Show("All files have been processed.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Hand);
        }

        private void btnOpenInput_Click(object sender, EventArgs e)
        {
            //open input folder in file explorer
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/excelTabDelimInput");
        }

        private void btnOpenOutput_Click(object sender, EventArgs e)
        {
            //open output folder in file explorer
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/excelTabDelimOutput");
        }



        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Button to close the textChunk window
            DialogResult option = MessageBox.Show("Are you sure you would like close the page?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (option == DialogResult.Yes)
            {
                this.Hide();
            }
        }

        public static void saveAsDelimited(string file, bool trimRows, string endOfLineString)
        {
            string outputFolderLocation = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/excelTabDelimOutput";

            //create a new XLSX doc to write ouput to and set up vars for writing to it
            FileInfo existingFile = new FileInfo(file);
            var package = new ExcelPackage(existingFile);   //declare the excel package, this contains an excel workbook
            ExcelWorksheet currentWorksheet = package.Workbook.Worksheets[0];
            int fileRowCount = currentWorksheet.Dimension.End.Row;
            int fileColCount = currentWorksheet.Dimension.End.Column;

            if (package != null && currentWorksheet != null)
            {
                //look for "\" characters and escape them for model n.
                for (int o = 1; o <= fileRowCount; o++)
                {
                    for (int p = 1; p <= fileColCount; p++)
                    {
                        currentWorksheet.Cells[o, p].Value = currentWorksheet.Cells[o, p].Text.Replace("\\", "\\\\");
                    }
                    //end cell for loop
                }
                //end row for loop

                //make delimited file. this returns a byte[] and writes it to the output folder
                byte[] delimitedFile = package.ConvertToCsv(trimRows, endOfLineString);
                File.WriteAllBytes(outputFolderLocation + "/" + Path.GetFileNameWithoutExtension(file) + ".txt", delimitedFile);
            }
            else
            {
                Console.WriteLine("\t-A worksheet could not be found in this file! Please check this file and make sure it doesn't need to be reprocessed!");
            }

        }//END method saveAsDelimited

    }// END formExcelToTabDelim

}//END namespace txtChunk

namespace WebUI.Infrastructure
{
    public static class StringUtils
    {
        private static string DuplicateTicksForSql(this string s)
        {
            return s.Replace("'", "''");
        }

        /// <summary>
        /// Takes a List collection of string and returns a delimited string.  Note that it's easy to create a huge list that won't turn into a huge string because
        /// the string needs contiguous memory.
        /// </summary>
        /// <param name="list">The input List collection of string objects</param>
        /// <param name="qualifier">
        /// The default delimiter. Using a colon in case the List of string are file names,
        /// since it is an illegal file name character on Windows machines and therefore should not be in the file name anywhere.
        /// </param>
        /// <param name="insertSpaces">Whether to insert a space after each separator</param>
        /// <returns>A delimited string</returns>
        /// <remarks>This was implemented pre-linq</remarks>
        public static string ToDelimitedString(this List<string> list, string delimiter = ":", bool insertSpaces = false, string qualifier = "", bool duplicateTicksForSQL = false)
        {
            var result = new StringBuilder();
            for (int i = 0; i < list.Count; i++)
            {
                string initialStr = duplicateTicksForSQL ? list[i].DuplicateTicksForSql() : list[i];
                result.Append((qualifier == string.Empty) ? initialStr : string.Format("{1}{0}{1}", initialStr, qualifier));
                if (i < list.Count - 1)
                {
                    result.Append(delimiter);
                    if (insertSpaces)
                    {
                        result.Append(' ');
                    }
                }
            }
            return result.ToString();
        }
    }

    public static class EpplusCsvConverter
    {
        public static byte[] ConvertToCsv(this ExcelPackage package, bool trimRows, string endOfLineString)
        {
            var worksheet = package.Workbook.Worksheets[0];

            var maxColumnNumber = worksheet.Dimension.End.Column;
            var currentRow = new List<string>(maxColumnNumber);
            var totalRowCount = worksheet.Dimension.End.Row;
            var currentRowNum = 1;

            var memory = new MemoryStream();

            using (var writer = new StreamWriter(memory, Encoding.ASCII))
            {
                while (currentRowNum <= totalRowCount)
                {
                    BuildRow(worksheet, currentRow, currentRowNum, maxColumnNumber, trimRows, endOfLineString);
                    WriteRecordToFile(currentRow, writer, currentRowNum, totalRowCount);
                    currentRow.Clear();
                    currentRowNum++;
                }
            }

            return memory.ToArray();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="record">List of cell values</param>
        /// <param name="sw">Open Writer to file</param>
        /// <param name="rowNumber">Current row num</param>
        /// <param name="totalRowCount"></param>
        /// <remarks>Avoiding writing final empty line so bulk import processes can work.</remarks>
        private static void WriteRecordToFile(List<string> record, StreamWriter sw, int rowNumber, int totalRowCount)
        {
            //var commaDelimitedRecord = record.ToDelimitedString(","); WS MODIFIED 11/7/2019
            var commaDelimitedRecord = record.ToDelimitedString("|");


            if (rowNumber == totalRowCount)
            {
                sw.Write(commaDelimitedRecord);
            }
            else
            {
                sw.WriteLine(commaDelimitedRecord);
            }
        }

        private static void BuildRow(ExcelWorksheet worksheet, List<string> currentRow, int currentRowNum, int maxColumnNumber, bool trimRows, string endOfLineString)
        {


            for (int i = 1; i <= maxColumnNumber; i++)
            {
                var cell = worksheet.Cells[currentRowNum, i];

                //If the user is using custom row lengths and a string to identify line endings
                if (trimRows & GetCellText(cell).Equals(endOfLineString))
                {
                    //Add row ending, then exit loop to not include blanks for rest of line
                    //AddCellValue(GetCellText(cell), currentRow);
                    return;
                }

                if (cell == null)
                {
                    // add a cell value for empty cells to keep data aligned.
                    AddCellValue(string.Empty, currentRow);
                }
                else
                {
                    AddCellValue(GetCellText(cell), currentRow);
                }
            }
        }

        /// <summary>
        /// Can't use .Text: http://epplus.codeplex.com/discussions/349696
        /// </summary>
        /// <param name="cell"></param>
        /// <returns></returns>
        private static string GetCellText(ExcelRangeBase cell)
        {
            return cell.Value == null ? string.Empty : cell.Value.ToString();
        }

        private static void AddCellValue(string s, List<string> record)
        {
            //record.Add(string.Format("{0}{1}{0}", '"', s));  WS modified 11/7/2019
            record.Add(s);
        }
    }
}//END namespace webUI.Infrastructure
