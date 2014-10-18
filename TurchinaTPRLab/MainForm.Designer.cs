namespace TurchinaTPRLab
{
    partial class MainForm
    {
        /// <summary>
        /// Требуется переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.randomizedSolutionsButton = new System.Windows.Forms.Button();
            this.nonRandomizedSolutionsButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // randomizedSolutionsButton
            // 
            this.randomizedSolutionsButton.Location = new System.Drawing.Point(94, 229);
            this.randomizedSolutionsButton.Name = "randomizedSolutionsButton";
            this.randomizedSolutionsButton.Size = new System.Drawing.Size(127, 52);
            this.randomizedSolutionsButton.TabIndex = 0;
            this.randomizedSolutionsButton.Text = "Рандомизированные решения";
            this.randomizedSolutionsButton.UseVisualStyleBackColor = true;
            this.randomizedSolutionsButton.Click += new System.EventHandler(this.randomizedSolutionsButton_Click);
            // 
            // nonRandomizedSolutionsButton
            // 
            this.nonRandomizedSolutionsButton.Location = new System.Drawing.Point(262, 229);
            this.nonRandomizedSolutionsButton.Name = "nonRandomizedSolutionsButton";
            this.nonRandomizedSolutionsButton.Size = new System.Drawing.Size(127, 52);
            this.nonRandomizedSolutionsButton.TabIndex = 1;
            this.nonRandomizedSolutionsButton.Text = "Не рандомизированные решения";
            this.nonRandomizedSolutionsButton.UseVisualStyleBackColor = true;
            this.nonRandomizedSolutionsButton.Click += new System.EventHandler(this.nonRandomizedSolutionsButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(151, 194);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(179, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Выберите тип решения";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(463, 104);
            this.label2.TabIndex = 4;
            this.label2.Text = resources.GetString("label2.Text");
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(485, 369);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.nonRandomizedSolutionsButton);
            this.Controls.Add(this.randomizedSolutionsButton);
            this.Name = "MainForm";
            this.Text = "ТПР. Критерии Оптимальности";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button randomizedSolutionsButton;
        private System.Windows.Forms.Button nonRandomizedSolutionsButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}

