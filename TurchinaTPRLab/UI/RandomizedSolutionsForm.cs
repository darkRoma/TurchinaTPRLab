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
    public partial class RandomizedSolutionsForm : Form
    {
        private Controller controller = new Controller();
        private Solution solution;
        private Graphics graphics;
        private SolutionView solutionView;
        private LossesMatrixView lossesMatrixView;
        private RegretMatrixView regretMatrixView;

        private int scaleX = 20;
        private int scaleY = 20;
        private double[,] linearMembrane;
        private double[,] array;
        private bool IsShowLosses = false;

        /// <summary>
        /// Constructor, that initializes this form component
        /// </summary>
        public RandomizedSolutionsForm()
        {
            InitializeComponent();

            lossesMatrixView = new LossesMatrixView(layout1, controller);
            regretMatrixView = new RegretMatrixView(layout1);
            solutionView = new SolutionView(layout1);

            controller.addView(lossesMatrixView,
                regretMatrixView,
                solutionView);

           // OpenFileDialog open; 

            var menu = new ContextMenuStrip();
            menu.Items.Add("загрузить матрицу потерь", null, delegate {
                openFileDialog1.InitialDirectory = Application.StartupPath;
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = openFileDialog1.FileName;
                    controller.loadModel(file);
                }
            });

            menu.Items.Add("сохранить матрицу потерь", null, delegate
            {
                saveFileDialog1.InitialDirectory = Application.StartupPath;
                if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    string file = saveFileDialog1.FileName;
                    controller.saveModel(file);
                }
            });

            menu.Items.Add(new ToolStripSeparator());
            menu.Items.Add("выход", null, delegate { this.Close(); });

            this.ContextMenuStrip = menu;
            this.FormClosed += delegate { Application.Exit(); };
     
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

        private void solveWithCreterionButton_Click(object sender, EventArgs e)
        {            
            pictureBox1.Refresh();            
            var factory = CriterionFactory.getFactory();
            int factoriesCount = factory.Count();
            Model model = controller.getModel();                        
            array = model.getLossesArray();
            linearMembrane = Core.Service.Criterions.Randomized_criterions.ConvexHull.JarvisMethod(model.getLossesArray());
            DrawingGraphic();
            DrawingSet();
            var criterion = factory.ElementAt(5);
            IsShowLosses = true;
            if (miniMaxCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(5);
                DrawingWedge(5);
                solution = criterion.makeDecision(model);
                ShowSolution(model);
            }
            else if (hurwitzCriterionRadioButton.Checked)
            {
                MessageBox.Show("Приносим свои извинения. Раздел находится в стадии разработки.");
                /*criterion = factory.ElementAt(6);
                solution = criterion.makeDecision(model);
                ShowSolution(model);*/                
            }
            else if (neymanPearsonCriterionRadioButton.Checked)
            {
                model.ControledStateNumber = Convert.ToInt32(textBoxNumControlState.Text);
                model.LossestRate = Convert.ToDouble(textBoxLossesRate.Text);
                criterion = factory.ElementAt(7);
                IsShowLosses = false;
                solution = criterion.makeDecision(model);
                ShowSolution(model);
            }
            else if (bayesianCriterionRadioButton.Checked)
            {
                IsShowLosses = false;
                criterion = factory.ElementAt(8);
                if (textBoxGradientX.Text == "" || textBoxGradientY.Text == "")
                {
                    MessageBox.Show("Вы не ввели координаты вектора - градиента!!!");
                }
                else if ((Convert.ToDouble(textBoxGradientX.Text) > 1) ||
                    (Convert.ToDouble(textBoxGradientX.Text) < 0) ||
                    (Convert.ToDouble(textBoxGradientY.Text) > 1) ||
                    (Convert.ToDouble(textBoxGradientY.Text) < 0))
                {
                    MessageBox.Show("Некорректное задание вероятностей!!!");
                }
                else if ((Convert.ToDouble(textBoxGradientX.Text) + Convert.ToDouble(textBoxGradientY.Text)) > 1)
                {
                    MessageBox.Show("Сумма вероятностей не должна превышать 1!!!");
                }
                else if ((Convert.ToDouble(textBoxGradientX.Text) + Convert.ToDouble(textBoxGradientY.Text)) != 1)
                {
                    MessageBox.Show("Сумма вероятностей должна быть равна 1!!!");
                }
                else
                {
                    model.GradientX = Convert.ToDouble(textBoxGradientX.Text);
                    model.GradientY = Convert.ToDouble(textBoxGradientY.Text);
                    DrawingGraphic();
                    DrawingSet();
                    if (bayesianCriterionRadioButton.Checked)
                    {
                        DrawingGradient();
                    }
                    solution = criterion.makeDecision(model);
                    ShowSolution(model);
                }
            }
            else if (savageCriterionRadioButton.Checked)
            {
                criterion = factory.ElementAt(9);
                PointF pointAxis = DrawingAxisForSavage();
                DrawingWedgeForSavage(9, pointAxis);
                solution = criterion.makeDecision(model);
                ShowSolution(model);
            }            
        }

        private Model ShowSolution(Model model)
        {
            string solutionToDisplay = "";
            double[] solutionVector = solution.getSolution();
            foreach (var x in solutionVector)
            {
                solutionToDisplay += x.ToString() + " ";
            }
            if (IsShowLosses)
            {
                MessageBox.Show("Решение: " + solutionToDisplay + " Потери: " + solution.getLoss().ToString());
            }
            else
            {
                MessageBox.Show("Решение: " + solutionToDisplay);
            }

            solutionView.setModel(model);
            solutionView.setSolution(solution);
            solutionView.update();
            return model;
        }

        private void hurwitzCriterionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            labelOptimismFactor.Visible = !labelOptimismFactor.Visible;
            textBoxOptimismFactor.Visible = !textBoxOptimismFactor.Visible;
        }

        private void neymanPearsonCriterionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            labelLossesRate.Visible = !labelLossesRate.Visible;
            labelNumControlState.Visible = !labelNumControlState.Visible;
            textBoxLossesRate.Visible = !textBoxLossesRate.Visible;
            textBoxNumControlState.Visible = !textBoxNumControlState.Visible;
        }

        private void bayesianCriterionRadioButton_CheckedChanged(object sender, EventArgs e)
        {
            labelGradientX.Visible = !labelGradientX.Visible;
            labelGradientY.Visible = !labelGradientY.Visible;
            textBoxGradientX.Visible = !textBoxGradientX.Visible;
            textBoxGradientY.Visible = !textBoxGradientY.Visible;            
        }

        private PointF convertToScreenPointF(PointF point)
        {
            return new System.Drawing.PointF((float)(point.X * scaleX), (float)(pictureBox1.Height - 1 - point.Y * scaleY));
        }

        private PointF DrawingAxisForSavage()
        {            
            Model model = controller.getModel();
            array = model.getLossesArray();
            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();
            double min1 = 0, min2 = 0;
            int number1 = 0, number2 = 0;
            for (int j = 0; j < cols; ++j)
            {                
                int imin = 0;
                for (int i = 0; i < rows; ++i)
                    if (array[imin, j] > array[i, j])
                        imin = i;

                if (j == 0) { min1 = array[imin, j]; number1 = imin; }
                else { min2 = array[imin, j]; number2 = imin; }
                
            }
            PointF pointAxis = new PointF((float)min1, (float)min2);
            
            PointF point = new PointF((float)min1, (float)min2);
            Pen pen = new Pen(Color.Black, 2);
            graphics.DrawLine(pen, convertToScreenPointF(point), convertToScreenPointF(new PointF(point.X, pictureBox1.Height)));
            graphics.DrawLine(pen, convertToScreenPointF(point), convertToScreenPointF(new PointF(pictureBox1.Width, point.Y)));
            return pointAxis;
        }

        private PointF convertToScreenForSavagePointF(PointF point, float param1, float param2)
        {
            return new System.Drawing.PointF((float)((point.X + param1) * scaleX), (float)(pictureBox1.Height - 1 - (param2 + point.Y) * scaleY));
        }

        private void DrawingAxis(PaintEventArgs e)
        {            
            for (int i = 1; i < 10000; i++)
            {
                if (i < 20) e.Graphics.DrawString(i.ToString(), labelGradientX.Font, new SolidBrush(Color.Red), convertToScreenPointF(new PointF(0, (float)(i+0.5))));
                e.Graphics.DrawLine(System.Drawing.Pens.LightGray, new System.Drawing.Point(scaleX * i, pictureBox1.Height - 1), new System.Drawing.Point(scaleX * i, 0));
            }            
            for (int i = 1; i < (int)pictureBox1.Width/scaleY + 1; i++)
            {
                if (i < 21) e.Graphics.DrawString(i.ToString(), labelGradientX.Font, new SolidBrush(Color.Red), convertToScreenPointF(new PointF(i, (float)0.6)));
                e.Graphics.DrawLine(System.Drawing.Pens.LightGray, new System.Drawing.Point(0, pictureBox1.Height - scaleY*i), new System.Drawing.Point(pictureBox1.Width, pictureBox1.Height - scaleY*i));
            }
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new System.Drawing.Point(0, pictureBox1.Height - 1), new System.Drawing.Point(pictureBox1.Width, pictureBox1.Height - 1));
            e.Graphics.DrawLine(new Pen(Color.Black, 3), new System.Drawing.Point(0, 0), new System.Drawing.Point(0, pictureBox1.Height));
        }

        private void pictureBox1_Paint(object sender, PaintEventArgs e)
        {
            DrawingAxis(e);
            graphics = pictureBox1.CreateGraphics();
            pictureBox1.BackColor = Color.White;
        }

        private Graphics DrawingGraphic()
        {            
            int arrayColumns = 2;
            Pen redPen = new Pen(Color.Red, 3);
            //float start = 0;
            PointF[] pointF = new PointF[linearMembrane.Length / arrayColumns];
            for (int i = 0; i < linearMembrane.Length / arrayColumns; i++)
            {
                pointF[i] = new PointF((float)linearMembrane[i, 0], (float)linearMembrane[i, 1]);
                pointF[i] = convertToScreenPointF(pointF[i]);
                //g.DrawLine(redPen, convertToScreenPointF(p1), convertToScreenPointF(p2));
                //start = next;                
            }
            for (int i = 0; i < pointF.Length; i++)
            {
                PointF start = pointF[i];
                PointF next;
                if (i == pointF.Length - 1) next = pointF[0];
                else next = pointF[i + 1];
                graphics.DrawLine(redPen, start, next);
                next = start;
            }
            return graphics;
        }

        private Graphics DrawingGradient()
        {

            PointF point = new PointF((float)Convert.ToDouble(textBoxGradientX.Text), (float)Convert.ToDouble(textBoxGradientY.Text));
            Pen bluePen = new Pen(Color.Blue, 4);
            graphics.DrawLine(bluePen, new Point(0, pictureBox1.Height - 1), convertToScreenPointF(point));
            //isGradient = true;
            double[] tempArray = new double[linearMembrane.Length / 2];
            for (int i = 0; i < tempArray.Length; i++)
            {
                tempArray[i] = linearMembrane[i, 0] * point.X + linearMembrane[i, 1] * point.Y;
            }

            double min = tempArray[0];
            int imin = 0;
            for (int i = 1; i < tempArray.Length; i++)
            {
                if (tempArray[i] <= min)
                {
                    min = tempArray[i];
                    imin = i;
                }
            }
            if (point.X == 0)
            {
                graphics.DrawLine(new Pen(Color.Blue, 1),
                    convertToScreenPointF(new PointF(0, (float)linearMembrane[imin, 1])),
                    convertToScreenPointF(new PointF(1000, (float)linearMembrane[imin, 1])));
            }
            else if (point.Y == 0)
            {
                graphics.DrawLine(new Pen(Color.Blue, 1),
                    convertToScreenPointF(new PointF((float)linearMembrane[imin, 0], 0)),
                    convertToScreenPointF(new PointF((float)linearMembrane[imin, 0], 1000)));
            }
            else
            {
                double k = -Convert.ToDouble(textBoxGradientX.Text) / (Convert.ToDouble(textBoxGradientY.Text));

                PointF pointLine = new PointF((float)linearMembrane[imin, 0], (float)linearMembrane[imin, 1]);
                double b = pointLine.Y - k * pointLine.X;

                graphics.DrawLine(new Pen(Color.Blue, 2), convertToScreenPointF(new PointF(0, (float)b)),
                    convertToScreenPointF(new PointF((float)(-b / k), 0)));
            }

            return graphics;
        }

        private Graphics DrawingSet()
        {
            int arrayRows = array.Length / 2;
            PointF[] pointF = new PointF[arrayRows];

            for (int i = 0; i < pointF.Length; i++)
            {
                pointF[i] = new PointF((float)array[i, 0], (float)array[i, 1]);
                pointF[i] = convertToScreenPointF(pointF[i]);
                graphics.DrawString("A" + (i+1), labelGradientX.Font, new SolidBrush(Color.Black), 
                    new PointF(pointF[i].X + 2, pointF[i].Y + 2));
                graphics.FillEllipse(new SolidBrush(Color.Black), pointF[i].X, pointF[i].Y, 4, 4);

            }
            return graphics;
        }       

        private void backButtonPictureBox_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            this.Hide();
            mainForm.Show();
        }

        private void DrawingWedgeForSavage(int number, PointF pointAxis)
        {
            var factory = CriterionFactory.getFactory();
            var criterion = factory.ElementAt(number);
            Model model = controller.getModel();
            
            

            var rows = model.getDecisionsCount();
            var cols = model.getStatesCount();

            var regret = (Model)model.Clone();
            for (int j = 0; j < cols; ++j)
            {
                int imin = 0;
                for (int i = 0; i < rows; ++i)
                    if (regret.getData(imin, j) > regret.getData(i, j))
                        imin = i;

                var min = regret.getData(imin, j);

                for (int i = 0; i < rows; ++i)
                {
                    var value = regret.getData(i, j) - min;
                    regret.setData(i, j, value);
                }
            }
            solution = criterion.makeDecision(regret);
            double[,] tempArray = new double[linearMembrane.Length / 2, 2];
            for (int i = 0; i < linearMembrane.Length / 2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tempArray[i, j] = regret.getData(i, j);
                }
            }
            double[] solutionVector = solution.getSolution();

            int countOfPoints = 0;
            for (int i = 0; i < solutionVector.Length; i++)
            {
                if (solutionVector[i] != 0)
                {
                    countOfPoints++;
                }
            }

            if (countOfPoints < 2)
            {
                int tempNumber = 0;
                for (int i = 0; i < solutionVector.Length; i++)
                {
                    if (solutionVector[i] != 0)
                    {
                        tempNumber = i;
                        break;
                    }
                }
                PointF point1 = new PointF((float)tempArray[tempNumber, 0], (float)tempArray[tempNumber, 1]);
                graphics.DrawLine(new Pen(Color.Blue, 2),
                    convertToScreenForSavagePointF(new PointF(0, point1.Y),pointAxis.X, pointAxis.Y), 
                    convertToScreenForSavagePointF(point1, pointAxis.X, pointAxis.Y));
                graphics.DrawLine(new Pen(Color.Blue, 2), convertToScreenForSavagePointF(new PointF(point1.X, 0), pointAxis.X, pointAxis.Y),
                    convertToScreenForSavagePointF(point1, pointAxis.X, pointAxis.Y));
            }
            else
            {
                int number1 = 0, number2 = 0;
                for (int i = 0; i < solutionVector.Length; i++)
                {
                    if (solutionVector[i] != 0)
                    {
                        number1 = i;
                        break;
                    }
                }
                for (int i = number1 + 1; i < solutionVector.Length; i++)
                {
                    if (solutionVector[i] != 0)
                    {
                        number2 = i;
                        break;
                    }
                }



                double k = (tempArray[number1, 1] - tempArray[number2, 1]) /
                    (tempArray[number1, 0] - tempArray[number2, 0]);
                double b = tempArray[number2, 1] - tempArray[number2, 0] *
                    (tempArray[number1, 1] - tempArray[number2, 1]) /
                    (tempArray[number1, 0] - tempArray[number2, 0]);
                float tempX = (float)(b / (1 - k));
                PointF point2 = new PointF(tempX, tempX);
                graphics.DrawLine(new Pen(Color.Blue, 2),
                    convertToScreenForSavagePointF(new PointF(0, point2.Y), pointAxis.X, pointAxis.Y), 
                    convertToScreenForSavagePointF(point2, pointAxis.X, pointAxis.Y));
                graphics.DrawLine(new Pen(Color.Blue, 2), convertToScreenForSavagePointF(new PointF(point2.X, 0), pointAxis.X, pointAxis.Y),
                    convertToScreenForSavagePointF(point2, pointAxis.X, pointAxis.Y));
            }
        }

        private void DrawingWedge(int number)
        {
            var factory = CriterionFactory.getFactory();
            var criterion = factory.ElementAt(number);
            Model model = controller.getModel();
            solution = criterion.makeDecision(model);
            double[] solutionVector = solution.getSolution();
            int countOfPoints = 0;            
            for (int i = 0; i < solutionVector.Length; i++)
            {
                if (solutionVector[i] != 0)
                {
                    countOfPoints++;
                }
            }


            double[,] tempArray = new double[linearMembrane.Length/2, 2];
            for (int i = 0; i < linearMembrane.Length/2; i++)
            {
                for (int j = 0; j < 2; j++)
                {
                    tempArray[i, j] = model.getData(i, j);
                }
            }

            if (countOfPoints < 2)
            {
                int tempNumber = 0;
                for (int i = 0; i < solutionVector.Length; i++)
                {
                    if (solutionVector[i] != 0)
                    {
                        tempNumber = i;
                        break;
                    }
                }
                PointF point1 = new PointF((float)tempArray[tempNumber, 0], (float)tempArray[tempNumber, 1]);
                graphics.DrawLine(new Pen(Color.Blue, 2),
                    convertToScreenPointF(new PointF(0, point1.Y)), convertToScreenPointF(point1));
                graphics.DrawLine(new Pen(Color.Blue, 2), convertToScreenPointF(new PointF(point1.X, 0)),
                    convertToScreenPointF(point1));
            }
            else
            {
                int number1 = 0, number2 = 0;
                for (int i = 0; i < solutionVector.Length; i++)
                {
                    if (solutionVector[i] != 0)
                    {
                        number1 = i;
                        break;
                    }
                }
                for (int i = number1 + 1; i < solutionVector.Length; i++)
                {
                    if (solutionVector[i] != 0)
                    {
                        number2 = i;
                        break;
                    }
                }



                double k = (tempArray[number1, 1] - tempArray[number2, 1]) /
                    (tempArray[number1, 0] - tempArray[number2, 0]);
                double b = tempArray[number2, 1] - tempArray[number2, 0] *
                    (tempArray[number1, 1] - tempArray[number2, 1]) /
                    (tempArray[number1, 0] - tempArray[number2, 0]);
                float tempX = (float)(b / (1 - k));
                PointF point2 = new PointF(tempX, tempX);
                graphics.DrawLine(new Pen(Color.Blue, 2),
                    convertToScreenPointF(new PointF(0, point2.Y)), convertToScreenPointF(point2));
                graphics.DrawLine(new Pen(Color.Blue, 2), convertToScreenPointF(new PointF(point2.X, 0)),
                    convertToScreenPointF(point2));
            }
        }

    }
}
