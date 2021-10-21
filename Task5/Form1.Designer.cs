
namespace Task5
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
            this.KochKurveButton = new System.Windows.Forms.RadioButton();
            this.KochSnowflakeButton = new System.Windows.Forms.RadioButton();
            this.SierpinskiGasketButton = new System.Windows.Forms.RadioButton();
            this.HilbertCurveButton = new System.Windows.Forms.RadioButton();
            this.HosperCurveButton = new System.Windows.Forms.RadioButton();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.GenerationLabel = new System.Windows.Forms.Label();
            this.IncGenerationButton1 = new System.Windows.Forms.Button();
            this.DecGenerationButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // KochKurveButton
            // 
            this.KochKurveButton.AutoSize = true;
            this.KochKurveButton.Location = new System.Drawing.Point(12, 21);
            this.KochKurveButton.Name = "KochKurveButton";
            this.KochKurveButton.Size = new System.Drawing.Size(128, 24);
            this.KochKurveButton.TabIndex = 0;
            this.KochKurveButton.TabStop = true;
            this.KochKurveButton.Text = "Кривая Коха";
            this.KochKurveButton.UseVisualStyleBackColor = true;
            this.KochKurveButton.CheckedChanged += new System.EventHandler(this.KochKurveButton_CheckedChanged);
            // 
            // KochSnowflakeButton
            // 
            this.KochSnowflakeButton.AutoSize = true;
            this.KochSnowflakeButton.CheckAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.KochSnowflakeButton.Location = new System.Drawing.Point(12, 51);
            this.KochSnowflakeButton.Name = "KochSnowflakeButton";
            this.KochSnowflakeButton.Size = new System.Drawing.Size(148, 24);
            this.KochSnowflakeButton.TabIndex = 1;
            this.KochSnowflakeButton.TabStop = true;
            this.KochSnowflakeButton.Text = "Снежинка Коха";
            this.KochSnowflakeButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.KochSnowflakeButton.UseVisualStyleBackColor = true;
            this.KochSnowflakeButton.CheckedChanged += new System.EventHandler(this.KochSnow_CheckedChanged);
            // 
            // SierpinskiGasketButton
            // 
            this.SierpinskiGasketButton.AutoSize = true;
            this.SierpinskiGasketButton.Location = new System.Drawing.Point(12, 81);
            this.SierpinskiGasketButton.Name = "SierpinskiGasketButton";
            this.SierpinskiGasketButton.Size = new System.Drawing.Size(181, 24);
            this.SierpinskiGasketButton.TabIndex = 2;
            this.SierpinskiGasketButton.TabStop = true;
            this.SierpinskiGasketButton.Text = "Ковёр Серпинского";
            this.SierpinskiGasketButton.UseVisualStyleBackColor = true;
            this.SierpinskiGasketButton.CheckedChanged += new System.EventHandler(this.SierpinskiGasketButton_CheckedChanged);
            // 
            // HilbertCurveButton
            // 
            this.HilbertCurveButton.AutoSize = true;
            this.HilbertCurveButton.Location = new System.Drawing.Point(12, 111);
            this.HilbertCurveButton.Name = "HilbertCurveButton";
            this.HilbertCurveButton.Size = new System.Drawing.Size(175, 24);
            this.HilbertCurveButton.TabIndex = 3;
            this.HilbertCurveButton.TabStop = true;
            this.HilbertCurveButton.Text = "Кривая Гильберта";
            this.HilbertCurveButton.UseVisualStyleBackColor = true;
            this.HilbertCurveButton.CheckedChanged += new System.EventHandler(this.HilbertButton_CheckedChanged);
            // 
            // HosperCurveButton
            // 
            this.HosperCurveButton.AutoSize = true;
            this.HosperCurveButton.Location = new System.Drawing.Point(12, 141);
            this.HosperCurveButton.Name = "HosperCurveButton";
            this.HosperCurveButton.Size = new System.Drawing.Size(155, 24);
            this.HosperCurveButton.TabIndex = 4;
            this.HosperCurveButton.TabStop = true;
            this.HosperCurveButton.Text = "Кривая Госпера";
            this.HosperCurveButton.UseVisualStyleBackColor = true;
            this.HosperCurveButton.CheckedChanged += new System.EventHandler(this.HosperCurveButton_CheckedChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(193, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(710, 660);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // GenerationLabel
            // 
            this.GenerationLabel.AutoSize = true;
            this.GenerationLabel.Location = new System.Drawing.Point(922, 67);
            this.GenerationLabel.Name = "GenerationLabel";
            this.GenerationLabel.Padding = new System.Windows.Forms.Padding(4);
            this.GenerationLabel.Size = new System.Drawing.Size(26, 28);
            this.GenerationLabel.TabIndex = 6;
            this.GenerationLabel.Text = "0";
            this.GenerationLabel.Click += new System.EventHandler(this.GenerationLabel_Click);
            // 
            // IncGenerationButton1
            // 
            this.IncGenerationButton1.Location = new System.Drawing.Point(919, 21);
            this.IncGenerationButton1.Name = "IncGenerationButton1";
            this.IncGenerationButton1.Size = new System.Drawing.Size(33, 26);
            this.IncGenerationButton1.TabIndex = 7;
            this.IncGenerationButton1.Text = "+";
            this.IncGenerationButton1.UseVisualStyleBackColor = true;
            this.IncGenerationButton1.Click += new System.EventHandler(this.IncGenerationButton_Click);
            // 
            // DecGenerationButton
            // 
            this.DecGenerationButton.Location = new System.Drawing.Point(918, 109);
            this.DecGenerationButton.Name = "DecGenerationButton";
            this.DecGenerationButton.Size = new System.Drawing.Size(33, 26);
            this.DecGenerationButton.TabIndex = 8;
            this.DecGenerationButton.Text = "-";
            this.DecGenerationButton.UseVisualStyleBackColor = true;
            this.DecGenerationButton.Click += new System.EventHandler(this.DecGenerationButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(987, 684);
            this.Controls.Add(this.DecGenerationButton);
            this.Controls.Add(this.IncGenerationButton1);
            this.Controls.Add(this.GenerationLabel);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.HosperCurveButton);
            this.Controls.Add(this.HilbertCurveButton);
            this.Controls.Add(this.SierpinskiGasketButton);
            this.Controls.Add(this.KochSnowflakeButton);
            this.Controls.Add(this.KochKurveButton);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton KochKurveButton;
        private System.Windows.Forms.RadioButton KochSnowflakeButton;
        private System.Windows.Forms.RadioButton SierpinskiGasketButton;
        private System.Windows.Forms.RadioButton HilbertCurveButton;
        private System.Windows.Forms.RadioButton HosperCurveButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label GenerationLabel;
        private System.Windows.Forms.Button IncGenerationButton1;
        private System.Windows.Forms.Button DecGenerationButton;
    }
}

