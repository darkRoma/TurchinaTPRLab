using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using TurchinaTPRLab.UI;

namespace TurchinaTPRLab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            LoadDocument();
        }

        public void LoadDocument()
        {
            string myPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Theory");
            string fileName = myPath + @"/MainForm.htm";
            webBrowser1.Navigate(fileName);
        }

        private void randomizedSolutionsButton_Click(object sender, EventArgs e)
        {
            RandomizedSolutionsForm randomizedSolutionsForm = new RandomizedSolutionsForm();
            this.Hide();
            randomizedSolutionsForm.Show();
        }

        private void nonRandomizedSolutionsButton_Click(object sender, EventArgs e)
        {
            NonRandomizedSolutionsForm nonRandomizedSolutionsForm = new NonRandomizedSolutionsForm();
            this.Hide();
            nonRandomizedSolutionsForm.Show();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            GuideForm guideForm = new GuideForm();
            guideForm.Show();
        }
    }
}
