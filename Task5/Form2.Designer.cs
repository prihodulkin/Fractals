
namespace Task5
{
    partial class Form2
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
            this.label1 = new System.Windows.Forms.Label();
            this.roughness_box = new System.Windows.Forms.TextBox();
            this.plus_btn = new System.Windows.Forms.Button();
            this.minus_btn = new System.Windows.Forms.Button();
            this.next_step_btn = new System.Windows.Forms.Button();
            this.clear_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(8, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(140, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Шероховатость";
            // 
            // roughness_box
            // 
            this.roughness_box.Location = new System.Drawing.Point(12, 57);
            this.roughness_box.Name = "roughness_box";
            this.roughness_box.Size = new System.Drawing.Size(69, 22);
            this.roughness_box.TabIndex = 2;
            this.roughness_box.TextChanged += new System.EventHandler(this.roughness_box_TextChanged);
            // 
            // plus_btn
            // 
            this.plus_btn.Location = new System.Drawing.Point(115, 57);
            this.plus_btn.Name = "plus_btn";
            this.plus_btn.Size = new System.Drawing.Size(22, 22);
            this.plus_btn.TabIndex = 3;
            this.plus_btn.Text = "+";
            this.plus_btn.UseVisualStyleBackColor = true;
            this.plus_btn.Click += new System.EventHandler(this.plus_btn_Click);
            // 
            // minus_btn
            // 
            this.minus_btn.Location = new System.Drawing.Point(87, 57);
            this.minus_btn.Name = "minus_btn";
            this.minus_btn.Size = new System.Drawing.Size(22, 22);
            this.minus_btn.TabIndex = 4;
            this.minus_btn.Text = "-";
            this.minus_btn.UseVisualStyleBackColor = true;
            this.minus_btn.Click += new System.EventHandler(this.minus_btn_Click);
            // 
            // next_step_btn
            // 
            this.next_step_btn.Enabled = false;
            this.next_step_btn.Location = new System.Drawing.Point(12, 94);
            this.next_step_btn.Name = "next_step_btn";
            this.next_step_btn.Size = new System.Drawing.Size(125, 27);
            this.next_step_btn.TabIndex = 5;
            this.next_step_btn.Text = "Следующий шаг";
            this.next_step_btn.UseVisualStyleBackColor = true;
            this.next_step_btn.Click += new System.EventHandler(this.next_step_btn_Click);
            // 
            // clear_btn
            // 
            this.clear_btn.Location = new System.Drawing.Point(12, 127);
            this.clear_btn.Name = "clear_btn";
            this.clear_btn.Size = new System.Drawing.Size(125, 27);
            this.clear_btn.TabIndex = 6;
            this.clear_btn.Text = "Очистить";
            this.clear_btn.UseVisualStyleBackColor = true;
            this.clear_btn.Click += new System.EventHandler(this.clear_btn_Click);
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1473, 838);
            this.Controls.Add(this.clear_btn);
            this.Controls.Add(this.next_step_btn);
            this.Controls.Add(this.minus_btn);
            this.Controls.Add(this.plus_btn);
            this.Controls.Add(this.roughness_box);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Form2";
            this.MouseClick += Form2_MouseClick;
            this.ResumeLayout(false);
            this.PerformLayout();

        }








        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox roughness_box;
        private System.Windows.Forms.Button plus_btn;
        private System.Windows.Forms.Button minus_btn;
        private System.Windows.Forms.Button next_step_btn;
        private System.Windows.Forms.Button clear_btn;
    }
}