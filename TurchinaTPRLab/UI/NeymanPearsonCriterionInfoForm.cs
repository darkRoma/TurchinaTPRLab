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
    public partial class NeymanPearsonCriterionInfoForm : Form
    {
        public NeymanPearsonCriterionInfoForm(bool randomized)
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
                fileName = myPath + @"/NeymanPearsonCriterionInfoFormRand.htm";
            }
            else
            {
                fileName = myPath + @"/NeymanPearsonCriterionInfoFormNotRand.htm";
            }
            webBrowser1.Navigate(fileName);
        }
    }
}
