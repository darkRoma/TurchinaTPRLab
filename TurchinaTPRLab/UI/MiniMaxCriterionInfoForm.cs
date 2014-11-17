using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace TurchinaTPRLab
{
    public partial class MiniMaxCriterionInfoForm : Form
    {
        public MiniMaxCriterionInfoForm(bool randomized)
        {
            InitializeComponent();
            LoadDocument(randomized);
        }

        public void LoadDocument(bool randomized)
        {
            string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Theory");
            string fileName;
            if (randomized)
            {
                fileName = myPath + @"/MiniMaxCriterionInfoFormRand.htm";
            }
            else
            {
                fileName = myPath + @"/MiniMaxCriterionInfoFormNotRand.htm";
            }
            webBrowser1.Navigate(fileName);
        }
    }
}
