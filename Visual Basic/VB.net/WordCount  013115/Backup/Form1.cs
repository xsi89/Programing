using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace WordCount
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            txtCount.Text = CountWords(txtContent.Text, chkStripTags.Checked).ToString();
        }

        public static int CountWords(string strText, bool stripTags)
        {
            // Declare and initialize the variable holding the number of counted words
            int countedWords = 0;

            // If the stripTags argument was passed as false
            if (stripTags == false)
            {
                // Simply count the words in the string by splitting them wherever a space is found
                countedWords = strText.Split(' ').Length;
            }
            else
            {
                // If the user wants to strip tags, first define the tag form
                Regex tagMatch = new Regex("<[^>]+>");
                // Replace the tags with an empty string so they are not considered in count
                strText = tagMatch.Replace(strText, "");
                // Count the words in the string by splitting them wherever a space is found
                countedWords = strText.Split(' ').Length;
            }
            // Return the number of words that were counted
            return countedWords;
        }
    }
}