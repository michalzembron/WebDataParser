using System;
using System.IO;
using System.Windows.Forms;

namespace WebDataParser
{
    public partial class ViewDataWindow : Form
    {
        public ViewDataWindow(string strTextBox)
        {
            InitializeComponent();

            Text = "Parsed Data";
            richTextBox_CovidData.Text = strTextBox;
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Stream myStream;
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|json files (*.json)|*.json|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 1;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //if ((myStream = saveFileDialog1.OpenFile()) != null)
                //{
                    // Code to write the stream goes here.

                    string textToBeSaved = richTextBox_CovidData.Text.Replace("},\n", "},");

                    //Zapis do pliku
                    //string destPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Output.txt");
                    //destPath = destPath.Replace("WebDataParser\\bin\\Debug\\netcoreapp3.1\\", "");
                    //File.WriteAllText(destPath, dataToBeSaved.ToString());
                    System.IO.StreamWriter file = new System.IO.StreamWriter(saveFileDialog1.FileName.ToString());
                    file.WriteLine(textToBeSaved);
                    file.Close();

                //    myStream.Close();
                //}
            }
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
