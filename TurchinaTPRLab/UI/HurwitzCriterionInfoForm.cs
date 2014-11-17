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
    public partial class HurwitzCriterionInfoForm : Form
    {
        public HurwitzCriterionInfoForm(bool randomized)
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
                fileName = myPath + @"/GurvicRandom.htm";
            }
            else
            {
                fileName = myPath + @"/GurvicNotRandom.htm";
            }
            webBrowser1.Navigate(fileName);
        }
    }
}
