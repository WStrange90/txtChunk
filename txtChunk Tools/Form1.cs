using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace txtChunk
{
    public partial class Form1 : Form
    {
        formFileSplitter fileSplitForm = new formFileSplitter();
        formExcelToTabDelim excelToTabDelimForm = new formExcelToTabDelim();

        public Form1()
        {
            InitializeComponent();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //Button to open txtChunk tool
            fileSplitForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Button to exit program
            DialogResult option = MessageBox.Show("Are you sure you would like to quit the application?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (option == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void btnExcelTabDelimited_Click(object sender, EventArgs e)
        {
            excelToTabDelimForm.Show();
        }
    }
}
