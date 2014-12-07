namespace TurchinaTPRLab
{
    partial class RandomizedSolutionsForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RandomizedSolutionsForm));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.neymanPearsonCriterionPictureBox = new System.Windows.Forms.PictureBox();
            this.hurwitzCriterionPictureBox = new System.Windows.Forms.PictureBox();
            this.bayesianCriterionPictureBox = new System.Windows.Forms.PictureBox();
            this.savageCriterionPictureBox = new System.Windows.Forms.PictureBox();
            this.miniMaxCriterionPictureBox = new System.Windows.Forms.PictureBox();
            this.neymanPearsonCriterionRadioButton = new System.Windows.Forms.RadioButton();
            this.hurwitzCriterionRadioButton = new System.Windows.Forms.RadioButton();
            this.bayesianCriterionRadioButton = new System.Windows.Forms.RadioButton();
            this.savageCriterionRadioButton = new System.Windows.Forms.RadioButton();
            this.miniMaxCriterionRadioButton = new System.Windows.Forms.RadioButton();
            this.solveWithCreterionButton = new System.Windows.Forms.Button();
            this.layout1 = new System.Windows.Forms.TableLayoutPanel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.labelOptimismFactor = new System.Windows.Forms.Label();
            this.textBoxOptimismFactor = new System.Windows.Forms.TextBox();
            this.labelNumControlState = new System.Windows.Forms.Label();
            this.textBoxNumControlState = new System.Windows.Forms.TextBox();
            this.textBoxLossesRate = new System.Windows.Forms.TextBox();
            this.labelLossesRate = new System.Windows.Forms.Label();
            this.textBoxGradientX = new System.Windows.Forms.TextBox();
            this.textBoxGradientY = new System.Windows.Forms.TextBox();
            this.labelGradientX = new System.Windows.Forms.Label();
            this.labelGradientY = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.backButtonPictureBox = new System.Windows.Forms.PictureBox();
            this.warningLabel = new System.Windows.Forms.Label();
            this.buttonDownScale = new System.Windows.Forms.Button();
            this.buttonUpScale = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neymanPearsonCriterionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurwitzCriterionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayesianCriterionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.savageCriterionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniMaxCriterionPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.neymanPearsonCriterionPictureBox);
            this.groupBox1.Controls.Add(this.hurwitzCriterionPictureBox);
            this.groupBox1.Controls.Add(this.bayesianCriterionPictureBox);
            this.groupBox1.Controls.Add(this.savageCriterionPictureBox);
            this.groupBox1.Controls.Add(this.miniMaxCriterionPictureBox);
            this.groupBox1.Controls.Add(this.neymanPearsonCriterionRadioButton);
            this.groupBox1.Controls.Add(this.hurwitzCriterionRadioButton);
            this.groupBox1.Controls.Add(this.bayesianCriterionRadioButton);
            this.groupBox1.Controls.Add(this.savageCriterionRadioButton);
            this.groupBox1.Controls.Add(this.miniMaxCriterionRadioButton);
            this.groupBox1.Enabled = false;
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(16, 84);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(432, 250);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Критерии";
            // 
            // neymanPearsonCriterionPictureBox
            // 
            this.neymanPearsonCriterionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.neymanPearsonCriterionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("neymanPearsonCriterionPictureBox.Image")));
            this.neymanPearsonCriterionPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("neymanPearsonCriterionPictureBox.InitialImage")));
            this.neymanPearsonCriterionPictureBox.Location = new System.Drawing.Point(373, 199);
            this.neymanPearsonCriterionPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.neymanPearsonCriterionPictureBox.Name = "neymanPearsonCriterionPictureBox";
            this.neymanPearsonCriterionPictureBox.Size = new System.Drawing.Size(44, 37);
            this.neymanPearsonCriterionPictureBox.TabIndex = 9;
            this.neymanPearsonCriterionPictureBox.TabStop = false;
            this.neymanPearsonCriterionPictureBox.Click += new System.EventHandler(this.neymanPearsonCriterionPictureBox_Click);
            // 
            // hurwitzCriterionPictureBox
            // 
            this.hurwitzCriterionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.hurwitzCriterionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("hurwitzCriterionPictureBox.Image")));
            this.hurwitzCriterionPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("hurwitzCriterionPictureBox.InitialImage")));
            this.hurwitzCriterionPictureBox.Location = new System.Drawing.Point(373, 155);
            this.hurwitzCriterionPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hurwitzCriterionPictureBox.Name = "hurwitzCriterionPictureBox";
            this.hurwitzCriterionPictureBox.Size = new System.Drawing.Size(44, 37);
            this.hurwitzCriterionPictureBox.TabIndex = 8;
            this.hurwitzCriterionPictureBox.TabStop = false;
            this.hurwitzCriterionPictureBox.Click += new System.EventHandler(this.hurwitzCriterionPictureBox_Click);
            // 
            // bayesianCriterionPictureBox
            // 
            this.bayesianCriterionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.bayesianCriterionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("bayesianCriterionPictureBox.Image")));
            this.bayesianCriterionPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("bayesianCriterionPictureBox.InitialImage")));
            this.bayesianCriterionPictureBox.Location = new System.Drawing.Point(373, 111);
            this.bayesianCriterionPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bayesianCriterionPictureBox.Name = "bayesianCriterionPictureBox";
            this.bayesianCriterionPictureBox.Size = new System.Drawing.Size(44, 37);
            this.bayesianCriterionPictureBox.TabIndex = 7;
            this.bayesianCriterionPictureBox.TabStop = false;
            this.bayesianCriterionPictureBox.Click += new System.EventHandler(this.bayesianCriterionPictureBox_Click);
            // 
            // savageCriterionPictureBox
            // 
            this.savageCriterionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.savageCriterionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("savageCriterionPictureBox.Image")));
            this.savageCriterionPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("savageCriterionPictureBox.InitialImage")));
            this.savageCriterionPictureBox.Location = new System.Drawing.Point(373, 68);
            this.savageCriterionPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.savageCriterionPictureBox.Name = "savageCriterionPictureBox";
            this.savageCriterionPictureBox.Size = new System.Drawing.Size(44, 37);
            this.savageCriterionPictureBox.TabIndex = 6;
            this.savageCriterionPictureBox.TabStop = false;
            this.savageCriterionPictureBox.Click += new System.EventHandler(this.savageCriterionPictureBox_Click);
            // 
            // miniMaxCriterionPictureBox
            // 
            this.miniMaxCriterionPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.miniMaxCriterionPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("miniMaxCriterionPictureBox.Image")));
            this.miniMaxCriterionPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("miniMaxCriterionPictureBox.InitialImage")));
            this.miniMaxCriterionPictureBox.Location = new System.Drawing.Point(373, 23);
            this.miniMaxCriterionPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.miniMaxCriterionPictureBox.Name = "miniMaxCriterionPictureBox";
            this.miniMaxCriterionPictureBox.Size = new System.Drawing.Size(44, 37);
            this.miniMaxCriterionPictureBox.TabIndex = 5;
            this.miniMaxCriterionPictureBox.TabStop = false;
            this.miniMaxCriterionPictureBox.Click += new System.EventHandler(this.miniMaxCriterionPictureBox_Click);
            // 
            // neymanPearsonCriterionRadioButton
            // 
            this.neymanPearsonCriterionRadioButton.AutoSize = true;
            this.neymanPearsonCriterionRadioButton.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.neymanPearsonCriterionRadioButton.Location = new System.Drawing.Point(8, 209);
            this.neymanPearsonCriterionRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.neymanPearsonCriterionRadioButton.Name = "neymanPearsonCriterionRadioButton";
            this.neymanPearsonCriterionRadioButton.Size = new System.Drawing.Size(249, 26);
            this.neymanPearsonCriterionRadioButton.TabIndex = 4;
            this.neymanPearsonCriterionRadioButton.TabStop = true;
            this.neymanPearsonCriterionRadioButton.Text = "Критерий Неймана-Пирсона";
            this.neymanPearsonCriterionRadioButton.UseVisualStyleBackColor = true;
            this.neymanPearsonCriterionRadioButton.CheckedChanged += new System.EventHandler(this.neymanPearsonCriterionRadioButton_CheckedChanged);
            // 
            // hurwitzCriterionRadioButton
            // 
            this.hurwitzCriterionRadioButton.AutoSize = true;
            this.hurwitzCriterionRadioButton.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hurwitzCriterionRadioButton.Location = new System.Drawing.Point(8, 165);
            this.hurwitzCriterionRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.hurwitzCriterionRadioButton.Name = "hurwitzCriterionRadioButton";
            this.hurwitzCriterionRadioButton.Size = new System.Drawing.Size(170, 26);
            this.hurwitzCriterionRadioButton.TabIndex = 3;
            this.hurwitzCriterionRadioButton.TabStop = true;
            this.hurwitzCriterionRadioButton.Text = "Критерий Гурвица";
            this.hurwitzCriterionRadioButton.UseVisualStyleBackColor = true;
            this.hurwitzCriterionRadioButton.CheckedChanged += new System.EventHandler(this.hurwitzCriterionRadioButton_CheckedChanged);
            // 
            // bayesianCriterionRadioButton
            // 
            this.bayesianCriterionRadioButton.AutoSize = true;
            this.bayesianCriterionRadioButton.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bayesianCriterionRadioButton.Location = new System.Drawing.Point(8, 121);
            this.bayesianCriterionRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.bayesianCriterionRadioButton.Name = "bayesianCriterionRadioButton";
            this.bayesianCriterionRadioButton.Size = new System.Drawing.Size(164, 26);
            this.bayesianCriterionRadioButton.TabIndex = 2;
            this.bayesianCriterionRadioButton.TabStop = true;
            this.bayesianCriterionRadioButton.Text = "Критерий Байеса";
            this.bayesianCriterionRadioButton.UseVisualStyleBackColor = true;
            this.bayesianCriterionRadioButton.CheckedChanged += new System.EventHandler(this.bayesianCriterionRadioButton_CheckedChanged);
            // 
            // savageCriterionRadioButton
            // 
            this.savageCriterionRadioButton.AutoSize = true;
            this.savageCriterionRadioButton.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.savageCriterionRadioButton.Location = new System.Drawing.Point(8, 78);
            this.savageCriterionRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.savageCriterionRadioButton.Name = "savageCriterionRadioButton";
            this.savageCriterionRadioButton.Size = new System.Drawing.Size(178, 26);
            this.savageCriterionRadioButton.TabIndex = 1;
            this.savageCriterionRadioButton.TabStop = true;
            this.savageCriterionRadioButton.Text = "Критерий Сэвиджа";
            this.savageCriterionRadioButton.UseVisualStyleBackColor = true;
            // 
            // miniMaxCriterionRadioButton
            // 
            this.miniMaxCriterionRadioButton.AutoSize = true;
            this.miniMaxCriterionRadioButton.Font = new System.Drawing.Font("Modern No. 20", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.miniMaxCriterionRadioButton.Location = new System.Drawing.Point(8, 33);
            this.miniMaxCriterionRadioButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.miniMaxCriterionRadioButton.Name = "miniMaxCriterionRadioButton";
            this.miniMaxCriterionRadioButton.Size = new System.Drawing.Size(216, 26);
            this.miniMaxCriterionRadioButton.TabIndex = 0;
            this.miniMaxCriterionRadioButton.TabStop = true;
            this.miniMaxCriterionRadioButton.Text = "МиниМаксный Критерий";
            this.miniMaxCriterionRadioButton.UseVisualStyleBackColor = true;
            // 
            // solveWithCreterionButton
            // 
            this.solveWithCreterionButton.Enabled = false;
            this.solveWithCreterionButton.Location = new System.Drawing.Point(139, 341);
            this.solveWithCreterionButton.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.solveWithCreterionButton.Name = "solveWithCreterionButton";
            this.solveWithCreterionButton.Size = new System.Drawing.Size(100, 28);
            this.solveWithCreterionButton.TabIndex = 3;
            this.solveWithCreterionButton.Text = "Решить";
            this.solveWithCreterionButton.UseVisualStyleBackColor = true;
            this.solveWithCreterionButton.Click += new System.EventHandler(this.solveWithCreterionButton_Click);
            // 
            // layout1
            // 
            this.layout1.ColumnCount = 3;
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 35F));
            this.layout1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.layout1.Location = new System.Drawing.Point(207, 465);
            this.layout1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.layout1.Name = "layout1";
            this.layout1.RowCount = 1;
            this.layout1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.layout1.Size = new System.Drawing.Size(987, 217);
            this.layout1.TabIndex = 4;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // labelOptimismFactor
            // 
            this.labelOptimismFactor.AutoSize = true;
            this.labelOptimismFactor.Location = new System.Drawing.Point(456, 260);
            this.labelOptimismFactor.Name = "labelOptimismFactor";
            this.labelOptimismFactor.Size = new System.Drawing.Size(177, 17);
            this.labelOptimismFactor.TabIndex = 10;
            this.labelOptimismFactor.Text = "Коэффициент оптимизма";
            this.labelOptimismFactor.Visible = false;
            // 
            // textBoxOptimismFactor
            // 
            this.textBoxOptimismFactor.Location = new System.Drawing.Point(644, 252);
            this.textBoxOptimismFactor.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxOptimismFactor.Name = "textBoxOptimismFactor";
            this.textBoxOptimismFactor.Size = new System.Drawing.Size(100, 22);
            this.textBoxOptimismFactor.TabIndex = 11;
            this.textBoxOptimismFactor.Visible = false;
            // 
            // labelNumControlState
            // 
            this.labelNumControlState.AutoSize = true;
            this.labelNumControlState.Location = new System.Drawing.Point(456, 293);
            this.labelNumControlState.Name = "labelNumControlState";
            this.labelNumControlState.Size = new System.Drawing.Size(214, 17);
            this.labelNumControlState.TabIndex = 12;
            this.labelNumControlState.Text = "№ контролируемого состояния";
            this.labelNumControlState.Visible = false;
            // 
            // textBoxNumControlState
            // 
            this.textBoxNumControlState.Location = new System.Drawing.Point(676, 290);
            this.textBoxNumControlState.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxNumControlState.Name = "textBoxNumControlState";
            this.textBoxNumControlState.Size = new System.Drawing.Size(100, 22);
            this.textBoxNumControlState.TabIndex = 13;
            this.textBoxNumControlState.Visible = false;
            // 
            // textBoxLossesRate
            // 
            this.textBoxLossesRate.Location = new System.Drawing.Point(676, 321);
            this.textBoxLossesRate.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxLossesRate.Name = "textBoxLossesRate";
            this.textBoxLossesRate.Size = new System.Drawing.Size(100, 22);
            this.textBoxLossesRate.TabIndex = 14;
            this.textBoxLossesRate.Visible = false;
            // 
            // labelLossesRate
            // 
            this.labelLossesRate.AutoSize = true;
            this.labelLossesRate.Location = new System.Drawing.Point(456, 321);
            this.labelLossesRate.Name = "labelLossesRate";
            this.labelLossesRate.Size = new System.Drawing.Size(195, 17);
            this.labelLossesRate.TabIndex = 15;
            this.labelLossesRate.Text = "Пороговое значение потерь";
            this.labelLossesRate.Visible = false;
            // 
            // textBoxGradientX
            // 
            this.textBoxGradientX.Location = new System.Drawing.Point(500, 210);
            this.textBoxGradientX.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGradientX.Name = "textBoxGradientX";
            this.textBoxGradientX.Size = new System.Drawing.Size(43, 22);
            this.textBoxGradientX.TabIndex = 16;
            this.textBoxGradientX.Visible = false;
            // 
            // textBoxGradientY
            // 
            this.textBoxGradientY.Location = new System.Drawing.Point(595, 212);
            this.textBoxGradientY.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBoxGradientY.Name = "textBoxGradientY";
            this.textBoxGradientY.Size = new System.Drawing.Size(57, 22);
            this.textBoxGradientY.TabIndex = 17;
            this.textBoxGradientY.Visible = false;
            // 
            // labelGradientX
            // 
            this.labelGradientX.AutoSize = true;
            this.labelGradientX.Location = new System.Drawing.Point(473, 214);
            this.labelGradientX.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradientX.Name = "labelGradientX";
            this.labelGradientX.Size = new System.Drawing.Size(25, 17);
            this.labelGradientX.TabIndex = 18;
            this.labelGradientX.Text = "P1";
            this.labelGradientX.Visible = false;
            // 
            // labelGradientY
            // 
            this.labelGradientY.AutoSize = true;
            this.labelGradientY.Location = new System.Drawing.Point(568, 215);
            this.labelGradientY.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelGradientY.Name = "labelGradientY";
            this.labelGradientY.Size = new System.Drawing.Size(25, 17);
            this.labelGradientY.TabIndex = 19;
            this.labelGradientY.Text = "P2";
            this.labelGradientY.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(795, 46);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(563, 412);
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // backButtonPictureBox
            // 
            this.backButtonPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("backButtonPictureBox.Image")));
            this.backButtonPictureBox.InitialImage = null;
            this.backButtonPictureBox.Location = new System.Drawing.Point(24, 4);
            this.backButtonPictureBox.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.backButtonPictureBox.Name = "backButtonPictureBox";
            this.backButtonPictureBox.Size = new System.Drawing.Size(88, 81);
            this.backButtonPictureBox.TabIndex = 24;
            this.backButtonPictureBox.TabStop = false;
            this.backButtonPictureBox.Click += new System.EventHandler(this.backButtonPictureBox_Click);
            // 
            // warningLabel
            // 
            this.warningLabel.Font = new System.Drawing.Font("Monotype Corsiva", 21.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.warningLabel.ForeColor = System.Drawing.Color.Coral;
            this.warningLabel.Location = new System.Drawing.Point(601, 84);
            this.warningLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.warningLabel.Name = "warningLabel";
            this.warningLabel.Size = new System.Drawing.Size(675, 286);
            this.warningLabel.TabIndex = 28;
            this.warningLabel.Text = "Для начала работы загрузите матрицу потерь (нажмите правой кнопкой мыши на таблиц" +
    "е, вызвав соответствующее контекстное меню)";
            this.warningLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.warningLabel.UseCompatibleTextRendering = true;
            // 
            // buttonDownScale
            // 
            this.buttonDownScale.Location = new System.Drawing.Point(659, 399);
            this.buttonDownScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDownScale.Name = "buttonDownScale";
            this.buttonDownScale.Size = new System.Drawing.Size(57, 52);
            this.buttonDownScale.TabIndex = 29;
            this.buttonDownScale.Text = "-";
            this.buttonDownScale.UseVisualStyleBackColor = true;
            this.buttonDownScale.Click += new System.EventHandler(this.buttonDownScale_Click);
            // 
            // buttonUpScale
            // 
            this.buttonUpScale.Location = new System.Drawing.Point(724, 399);
            this.buttonUpScale.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonUpScale.Name = "buttonUpScale";
            this.buttonUpScale.Size = new System.Drawing.Size(57, 52);
            this.buttonUpScale.TabIndex = 30;
            this.buttonUpScale.Text = "+";
            this.buttonUpScale.UseVisualStyleBackColor = true;
            this.buttonUpScale.Click += new System.EventHandler(this.buttonUpScale_Click);
            // 
            // RandomizedSolutionsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(1365, 698);
            this.Controls.Add(this.buttonUpScale);
            this.Controls.Add(this.buttonDownScale);
            this.Controls.Add(this.warningLabel);
            this.Controls.Add(this.backButtonPictureBox);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labelGradientY);
            this.Controls.Add(this.labelGradientX);
            this.Controls.Add(this.textBoxGradientY);
            this.Controls.Add(this.textBoxGradientX);
            this.Controls.Add(this.labelLossesRate);
            this.Controls.Add(this.textBoxLossesRate);
            this.Controls.Add(this.textBoxNumControlState);
            this.Controls.Add(this.labelNumControlState);
            this.Controls.Add(this.textBoxOptimismFactor);
            this.Controls.Add(this.labelOptimismFactor);
            this.Controls.Add(this.layout1);
            this.Controls.Add(this.solveWithCreterionButton);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "RandomizedSolutionsForm";
            this.Text = "Рандомизированные решения";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.RandomizedSolutionsForm_FormClosed);
            this.Load += new System.EventHandler(this.RandomizedSolutionsForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.neymanPearsonCriterionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hurwitzCriterionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bayesianCriterionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.savageCriterionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.miniMaxCriterionPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.backButtonPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton neymanPearsonCriterionRadioButton;
        private System.Windows.Forms.RadioButton hurwitzCriterionRadioButton;
        private System.Windows.Forms.RadioButton bayesianCriterionRadioButton;
        private System.Windows.Forms.RadioButton savageCriterionRadioButton;
        private System.Windows.Forms.RadioButton miniMaxCriterionRadioButton;
        private System.Windows.Forms.PictureBox miniMaxCriterionPictureBox;
        private System.Windows.Forms.PictureBox neymanPearsonCriterionPictureBox;
        private System.Windows.Forms.PictureBox hurwitzCriterionPictureBox;
        private System.Windows.Forms.PictureBox bayesianCriterionPictureBox;
        private System.Windows.Forms.PictureBox savageCriterionPictureBox;
        private System.Windows.Forms.Button solveWithCreterionButton;
        private System.Windows.Forms.TableLayoutPanel layout1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Label labelOptimismFactor;
        private System.Windows.Forms.TextBox textBoxOptimismFactor;
        private System.Windows.Forms.Label labelNumControlState;
        private System.Windows.Forms.TextBox textBoxNumControlState;
        private System.Windows.Forms.TextBox textBoxLossesRate;
        private System.Windows.Forms.Label labelLossesRate;
        private System.Windows.Forms.TextBox textBoxGradientX;
        private System.Windows.Forms.TextBox textBoxGradientY;
        private System.Windows.Forms.Label labelGradientX;
        private System.Windows.Forms.Label labelGradientY;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox backButtonPictureBox;
        private System.Windows.Forms.Label warningLabel;
        private System.Windows.Forms.Button buttonDownScale;
        private System.Windows.Forms.Button buttonUpScale;
    }
}