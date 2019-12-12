using System;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using System.IO;
using System.Text.RegularExpressions;
using System.Text;

namespace txtChunk
{
    public partial class formFileSplitter : Form
    {
        //create an error provider for each control that requires validation
        ErrorProvider lineOptionErrorProvider = new ErrorProvider();

        

        public formFileSplitter()
        {
            InitializeComponent();
        }

        private void btnRun_Click(object sender, EventArgs e)
        {
            //use string builder output and message box to replace console window.
            var outputMessage = new StringBuilder();


            //perform validation of input before processing files
            if (ValidateChildren(ValidationConstraints.Enabled))
            {
                //setup based on input options
                int desiredFileLength;

                bool headerExists = chkbxFileHeaders.Checked;

                bool delimiterChoice = chkbxDelimiter.Checked;
                string newCharacter, oldCharacter;
                if (delimiterChoice)
                {
                    newCharacter = Regex.Unescape(txtbxNewDelim.Text);
                    oldCharacter = Regex.Unescape(txtbxOldDelim.Text);
                }
                else
                {
                    newCharacter = "";
                    oldCharacter = "";
                }

                
                string newDocPath = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/fileSplitOutput"; //Prod Value
                string dropZone = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/fileSplitInput"; //Prod Value
                //newDocPath = newDocPath.Replace("\\", "/");
                //dropZone = dropZone.Replace("\\", "/");

                //loop through files from input folder
                string[] dropZoneFiles = Directory.GetFiles(dropZone, "*.txt");
                foreach (var file in dropZoneFiles)
                {
                    string[] fileContents = System.IO.File.ReadAllLines(file);

                    string currentFileHeader = "";

                    if (headerExists)
                    {
                        currentFileHeader = fileContents[0];
                    }

                    //set the new file length based on input
                    if (chkbxFileSplit.Checked)
                    {
                        desiredFileLength = int.Parse(lineOptionInput.Text);
                    }
                    else
                    {
                        desiredFileLength = fileContents.Length;
                    }

                    int currentFileLine = 0;
                    int NumOfFilesMade = 0;

                    while (currentFileLine < fileContents.Length)
                    {
                        using (StreamWriter outputFile = new StreamWriter(Path.Combine(newDocPath, Path.GetFileNameWithoutExtension(file) + NumOfFilesMade + ".txt")))
                        {
                            

                            for (int i = 0; i < desiredFileLength; i++)
                            {
                                //If the files being processed have headers, write the header at the beggining of every new output file
                                if (headerExists && i == 0 && currentFileLine == 0)
                                {
                                    outputFile.WriteLine(currentFileHeader);
                                    currentFileLine++;
                                    if (currentFileLine == fileContents.Length)
                                    {
                                        break;
                                    }
                                    continue;
                                }
                                else if (headerExists && i == 0)
                                {
                                    outputFile.WriteLine(currentFileHeader);
                                }

                                //Change delimiter from tabs to pipes
                                if (delimiterChoice)
                                {

                                    fileContents[currentFileLine] = fileContents[currentFileLine].Replace(oldCharacter, newCharacter);

                                    //Removes blank lines from the output if they consist of only delimiters
                                    if (Regex.Matches(fileContents[currentFileLine], @"[a-zA-Z\d]").Count == 0)
                                    {
                                        currentFileLine++;
                                        if (currentFileLine == fileContents.Length)
                                        {
                                            break;
                                        }
                                        continue;
                                    }
                                }

                                outputFile.WriteLine(fileContents[currentFileLine]);
                                currentFileLine++;

                                if (currentFileLine == fileContents.Length)
                                {
                                    break;
                                }
                            }

                            NumOfFilesMade++;
                        }
                    }//END While

                    outputMessage.AppendLine("");
                    outputMessage.AppendLine("The file '" + Path.GetFileName(file) + "' has been proccessed and it can be found in the Output folder.");
                }
                //END foreach file

                outputMessage.AppendLine("");
                outputMessage.AppendLine("All files from the DropZone folder have been proccessed.");

                MessageBox.Show(outputMessage.ToString());

            }//END VALIDATE IF BLOCK
        }//END btnRun_Click

        private void btnQuit_Click(object sender, EventArgs e)
        {
            //Button to close the textChunk window
            DialogResult option = MessageBox.Show("Are you sure you would like close the file splitter?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (option == DialogResult.Yes)
            {
                this.Hide();
            }

            
        }




        private void chkbxFileSplit_CheckedChanged(object sender, EventArgs e)
        {
            //handle input changes when checking or unchecking the file split options box
            if (chkbxFileSplit.Checked)
            {
                lineOptionInput.Enabled = true;
            }
            else
            {
                lineOptionInput.Text = "";
                lineOptionInput.Enabled = false;
            }
        }

        private void chkbxDelimiter_CheckedChanged(object sender, EventArgs e)
        {
            //handle input changes when checking or unchecking the delimiter options box
            if (chkbxDelimiter.Checked)
            {
                txtbxOldDelim.Enabled = true;
                txtbxNewDelim.Enabled = true;
            }
            else
            {
                txtbxOldDelim.Text = "";
                txtbxNewDelim.Text = "";
                txtbxOldDelim.Enabled = false;
                txtbxNewDelim.Enabled = false;
            }
        }



        private void btnOpenInput_Click(object sender, EventArgs e)
        {
            //open input folder in file explorer
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/fileSplitInput");
        }

        private void btnOpenOutput_Click(object sender, EventArgs e)
        {
            //open output folder in file explorer
            System.Diagnostics.Process.Start(System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "/fileSplitOutput");
        }



        private void lineOptionInput_Validating(object sender, CancelEventArgs e)
        {
            //validate the input for file splitting
            int result;
            bool parseSuccess = int.TryParse(lineOptionInput.Text, out result);

            if (chkbxFileSplit.Checked && String.IsNullOrEmpty(lineOptionInput.Text))
            {
                e.Cancel = true;
                lineOptionInput.Focus();
                lineOptionErrorProvider.SetError(lineOptionInput, "This cannot be blank! Enter a number or deselect the option.");
            }
            else if (chkbxFileSplit.Checked && parseSuccess == false)
            {
                e.Cancel = true;
                lineOptionInput.Focus();
                lineOptionErrorProvider.SetError(lineOptionInput, "What you entered was not recognized as a number!");
            }
            else if (chkbxFileSplit.Checked && parseSuccess == true && result < 1)
            {
                e.Cancel = true;
                lineOptionInput.Focus();
                lineOptionErrorProvider.SetError(lineOptionInput, "Desired file length must be 1 or greater!");
            }
            else
            {
                e.Cancel = false;
                lineOptionErrorProvider.SetError(this.lineOptionInput, string.Empty);
                
            }
        }

        private void lineOptionInput_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
