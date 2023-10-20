namespace CCcode1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
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
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.nTextBox = new System.Windows.Forms.TextBox();
            this.FuncLabel = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.solutionLabel = new System.Windows.Forms.Label();
            this.kTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.operationComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // nTextBox
            // 
            this.nTextBox.Location = new System.Drawing.Point(103, 51);
            this.nTextBox.Name = "nTextBox";
            this.nTextBox.Size = new System.Drawing.Size(100, 20);
            this.nTextBox.TabIndex = 0;
            this.nTextBox.TextChanged += new System.EventHandler(this.nTextBox_TextChanged);
            // 
            // FuncLabel
            // 
            this.FuncLabel.AutoSize = true;
            this.FuncLabel.Location = new System.Drawing.Point(100, 35);
            this.FuncLabel.Name = "FuncLabel";
            this.FuncLabel.Size = new System.Drawing.Size(35, 13);
            this.FuncLabel.TabIndex = 1;
            this.FuncLabel.Text = "C(n,k)";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(231, 51);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Решить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // solutionLabel
            // 
            this.solutionLabel.AutoSize = true;
            this.solutionLabel.Location = new System.Drawing.Point(312, 135);
            this.solutionLabel.Name = "solutionLabel";
            this.solutionLabel.Size = new System.Drawing.Size(59, 13);
            this.solutionLabel.TabIndex = 3;
            this.solutionLabel.Text = "Результат";
            // 
            // kTextBox
            // 
            this.kTextBox.Location = new System.Drawing.Point(103, 86);
            this.kTextBox.Name = "kTextBox";
            this.kTextBox.Size = new System.Drawing.Size(100, 20);
            this.kTextBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(68, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "N";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(68, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(14, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "K";
            // 
            // operationComboBox
            // 
            this.operationComboBox.FormattingEnabled = true;
            this.operationComboBox.Items.AddRange(new object[] {
            "Сочетания",
            "Перестановки",
            "Разложения"});
            this.operationComboBox.Location = new System.Drawing.Point(71, 132);
            this.operationComboBox.Name = "operationComboBox";
            this.operationComboBox.Size = new System.Drawing.Size(121, 21);
            this.operationComboBox.TabIndex = 8;
            this.operationComboBox.SelectedIndexChanged += new System.EventHandler(this.operationComboBox_SelectedIndexChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.operationComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.kTextBox);
            this.Controls.Add(this.solutionLabel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.FuncLabel);
            this.Controls.Add(this.nTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox nTextBox;
        private System.Windows.Forms.Label FuncLabel;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label solutionLabel;
        private System.Windows.Forms.TextBox kTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox operationComboBox;
    }
}

