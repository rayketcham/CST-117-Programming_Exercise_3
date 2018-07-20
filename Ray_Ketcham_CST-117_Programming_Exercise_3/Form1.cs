using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace Ray_Ketcham_CST_117_Programming_Exercise_3
{
    public partial class Form1 : Form
    {
        //Speciy variable dialog for entire app
        OpenFileDialog dialog = new OpenFileDialog();
        SaveFileDialog saver = new SaveFileDialog();
        public Form1()
        {
            InitializeComponent();
        }

        string firstA = " ";
        string lastA = " ";
        string longestW = " ";
        string totalV = " ";
        char[] vowelArray;
        int vowelCount;

        private void button3_Click(object sender, EventArgs e)
        {
            //Button Closes Application
            this.Close();
        }

        private async void button4_Click(object sender, EventArgs e)
        {
            //Specifies requirements for the dialog, only allows files to be saved as txt files, and sets starting directory of C:\
            saver.Title = "Save Text File";
            saver.Filter = "TXT | *.txt";
            saver.InitialDirectory = @"C:\";
            saver.ValidateNames = true;

            {
                if (saver.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter swriter = new StreamWriter(saver.FileName))
                    {
                        await swriter.WriteLineAsync(textBox1.Text);
                        MessageBox.Show("File Saved", " ", MessageBoxButtons.OK);
                        swriter.Close();

                    }
                }


            }

        }
        private void button2_Click(object sender, EventArgs e)
        {
            //Empty contents of the text box before open
            textBox1.Clear();
        }
        private async void button1_Click(object sender, EventArgs e)
        {
            //Specifies requirements for the dialog, only allows txt files, and sets starting directory of C:\
            dialog.Title = "Open Text File";
            dialog.Filter = "TXT | *.txt";
            dialog.InitialDirectory = @"C:\";
            dialog.Multiselect = false;
            dialog.ValidateNames = true;

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<string> wordsTest = new List<string>();
                using (StreamReader sreader = new StreamReader(dialog.FileName))
                {

                    while (!sreader.EndOfStream)
                    {
                        textBox1.Text = await sreader.ReadToEndAsync();

                        string sread = sreader.ReadLine();
                        string[] wordz = sread.Split();
                        foreach (string abc in wordz)
                        {
                            if (abc.Length > 0)
                            {
                                string abcLower = abc.ToLower();
                                if (firstA == "")
                                    firstA = abcLower;
                                if (abc.CompareTo(firstA) < 0)
                                    firstA = abcLower;
                                if (lastA == "")
                                    lastA = abcLower;
                                if (abc.CompareTo(lastA) < 0)
                                    lastA = abcLower;
                                if (longestW == "")
                                    longestW = abcLower;
                                if (abc.Length > longestW.Length)
                                    longestW = abcLower;

                                //Locate Vowels and Count Them
                                //for (int j = 0; j < vowelArray.Length; j++)
                                //{
                                //    if (vowelArray[j] == 'a' ||
                                //        vowelArray[j] == 'e' ||
                                //        vowelArray[j] == 'i' ||
                                //        vowelArray[j] == 'o' ||
                                //        vowelArray[j] == 'u')
                                //    {
                                //        vowelCount++;
                                //    }
                                }
                            }
                        }

                    }
                }
            textBox1.Text = "First Alphabet: " + firstA + "\nLast Alaphabet: " + lastA + "\nLongestWord " + longestW + "\nVowel Count: "; //+ vowelCount;
                //sreader.Close();

                // catch (Exception ex)
                //   {
                //        MessageBox.Show(ex.ToString());
                //    }
                //}


        }
            
        }


    }

