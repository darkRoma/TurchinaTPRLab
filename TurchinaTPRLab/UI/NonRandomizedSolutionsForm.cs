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
using TurchinaTPRLab.UI;

namespace TurchinaTPRLab
{
    public partial class NonRandomizedSolutionsForm : Form
    {
        private Controller controller = new Controller();
        private Solution solution;
        private SolutionView solutionView;
        private LossesMatrixView lossesMatrixView;
        private RegretMatrixView regretMatrixView;
        TextBox[] propabilityArrayTextBoxes;
        Model model;

        int statesCount;


        /// <summary>
        /// Constructor, that initializes this form component
        /// </summary>
        public NonRandomizedSolutionsForm()
        {
            InitializeComponent();
            this.backButtonPictureBox.BackColor = Color.Transparent;
            label2.BackColor = Color.Transparent;

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
                    groupBox1.Enabled = true;
                    solveWithCreterionButton.Enabled = true;
                    label2.Visible = false;
                    model = controller.getModel();
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
                criterion.probability = new double[statesCount];
                for (var i = 0; i < statesCount; i++)
                {

                    criterion.probability[i] = Convert.ToDouble( propabilityArrayTextBoxes[i].Text);
                }
                
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
            label1.Visible = !label1.Visible;
        }

        private void backButtonPictureBox_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.Show();
        }

        private void bayesianCriterionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            statesCount = model.colums;
            if (bayesianCriterionRadioButton.Checked)
            {
                propabilityArrayTextBoxes = new TextBox[statesCount];
                for (var i = 0; i < statesCount; i++)
                {
                    var tbox = new TextBox();
                    tbox.Location = new System.Drawing.Point((i % 6 * 100) + 344, 160 + 40 * (i / 6));
                    tbox.Text = "Propability " + Convert.ToString(i + 1);
                    this.Controls.Add(tbox);
                    propabilityArrayTextBoxes[i] = tbox;
                }
            }
            else
            {
                for (var i = 0; i < statesCount; i++)
                {
                    this.Controls.Remove(propabilityArrayTextBoxes[i]);
                }
            }

        }

        private void guidePictureBox_Click(object sender, EventArgs e)
        {
            GuideForm guideForm = new GuideForm();
            guideForm.Show();
        }

    }
}
