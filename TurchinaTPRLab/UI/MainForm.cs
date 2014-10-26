using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace TurchinaTPRLab
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
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
    }
}
