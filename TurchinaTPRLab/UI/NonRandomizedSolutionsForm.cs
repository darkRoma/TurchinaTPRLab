using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using DecisionTheory.Core.MVCController;
using DecisionTheory.Core.MVCView.Table;
using DecisionTheory.Core.MVCModel;
using DecisionTheory.Core.Service.Criterions;

namespace TurchinaTPRLab
{
    public partial class NonRandomizedSolutionsForm : Form
    {
        private Controller controller = new Controller();
        private Solution solution;
        private SolutionView solutionView;
        private LossesMatrixView lossesMatrixView;
        private RegretMatrixView regretMatrixView;


        /// <summary>
        /// Constructor, that initializes this form component
        /// </summary>
        public NonRandomizedSolutionsForm()
        {
            InitializeComponent();
            lossesMatrixView = new LossesMatrixView(layout1, controller);
            regretMatrixView = new RegretMatrixView(layout1);
            solutionView = new SolutionView(layout1);

            controller.addView(lossesMatrixView,
                regretMatrixView,
                solutionView);

            var menu = new ContextMenuStrip();
            menu.Items.Add("загрузить матрицу потерь", null, delegate {
                open.InitialDirectory = Application.StartupPath;
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string file = open.FileName;
                    controller.loadModel(file);
                }
            });

            menu.Items.Add("сохранить матрицу потерь", null, delegate
            {
                save.InitialDirectory = Application.StartupPath;
                if (save.ShowDialog() == DialogResult.OK)
                {
                    string file = save.FileName;
                    controller.saveModel(file);
                }
            });

            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("выход", null, delegate { this.Close(); });

            this.ContextMenuStrip = menu;
            this.FormClosed += delegate { Application.Exit(); };
        }

        private void NonRandomizedSolutionsForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void miniMaxCriterionPictureBox_Click(object sender, EventArgs e)
        {
            MiniMaxCriterionInfoForm miniMaxCriterionInfoForm = new MiniMaxCriterionInfoForm(false);
            miniMaxCriterionInfoForm.Show();
        }

        private void savageCriterionPictureBox_Click(object sender, EventArgs e)
        {
            SavageCriterionInfoForm savageCriterionInfoForm = new SavageCriterionInfoForm(false);
            savageCriterionInfoForm.Show();
        }

        private void bayesianCriterionPictureBox_Click(object sender, EventArgs e)
        {
            BayesianCriterionInfoForm bayesianCriterionInfoForm = new BayesianCriterionInfoForm(false);
            bayesianCriterionInfoForm.Show();
        }

        private void hurwitzCriterionPictureBox_Click(object sender, EventArgs e)
        {
            HurwitzCriterionInfoForm hurwitzCriterionInfoForm = new HurwitzCriterionInfoForm(false);
            hurwitzCriterionInfoForm.Show();
        }

        private void neymanPearsonCriterionPictureBox_Click(object sender, EventArgs e)
        {
            NeymanPearsonCriterionInfoForm neymanPearsonCriterionInfoForm = new NeymanPearsonCriterionInfoForm(false);
            neymanPearsonCriterionInfoForm.Show();
        }

        private void solveWithCreterionButton_Click(object sender, EventArgs e)
        {
            var factory = CriterionFactory.getFactory();
            int factoriesCount = factory.Count();
            Model model = controller.getModel();
            var criterion = factory.ElementAt(0);
            if (miniMaxCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(0);
            }
            if (savageCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(1);
            }
            if (bayesianCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(2);
            }
            if (hurwitzCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(3);
                criterion.rate = Convert.ToDouble(lyambdaTextBox.Text);
            }
            if (neymanPearsonCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(4);
            }
            solution = criterion.makeDecision(model);
            MessageBox.Show("Лучшее решение: " + (solution.getBestId() + 1).ToString());
            solutionView.setModel(model);
            solutionView.setSolution(solution);
            solutionView.update();
        }

        private void hurwitzCriterionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            lyambdaTextBox.Visible = !lyambdaTextBox.Visible;
        }

        private void backButtonPictureBox_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.Show();
        }

    }
}
