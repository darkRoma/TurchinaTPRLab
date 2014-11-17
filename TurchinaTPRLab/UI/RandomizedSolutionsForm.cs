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
    public partial class RandomizedSolutionsForm : Form
    {
        public RandomizedSolutionsForm()
        {
            InitializeComponent();
        }

        private void RandomizedSolutionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void RandomizedSolutionsForm_Load(object sender, EventArgs e)
        {

        }

        private void miniMaxCriterionPictureBox_Click(object sender, EventArgs e)
        {
            MiniMaxCriterionInfoForm miniMaxCriterionInfoForm = new MiniMaxCriterionInfoForm(true);
            miniMaxCriterionInfoForm.Show();
        }

        private void savageCriterionPictureBox_Click(object sender, EventArgs e)
        {
            SavageCriterionInfoForm savageCriterionInfoForm = new SavageCriterionInfoForm(true);
            savageCriterionInfoForm.Show();
        }

        private void bayesianCriterionPictureBox_Click(object sender, EventArgs e)
        {
            BayesianCriterionInfoForm bayesianCriterionInfoForm = new BayesianCriterionInfoForm(true);
            bayesianCriterionInfoForm.Show();
        }

        private void hurwitzCriterionPictureBox_Click(object sender, EventArgs e)
        {
            HurwitzCriterionInfoForm hurwitzCriterionInfoForm = new HurwitzCriterionInfoForm(true);
            hurwitzCriterionInfoForm.Show();
        }

        private void neymanPearsonCriterionPictureBox_Click(object sender, EventArgs e)
        {
            NeymanPearsonCriterionInfoForm neymanPearsonCriterionInfoForm = new NeymanPearsonCriterionInfoForm(true);
            neymanPearsonCriterionInfoForm.Show();
        }
    }
}
