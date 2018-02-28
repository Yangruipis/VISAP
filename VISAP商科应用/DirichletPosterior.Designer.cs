namespace VISAP商科应用
{
    partial class DirichletPosterior
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
            this.button_predict = new System.Windows.Forms.Button();
            this.textBox_successes = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button_predict
            // 
            this.button_predict.Location = new System.Drawing.Point(292, 189);
            this.button_predict.Name = "button_predict";
            this.button_predict.Size = new System.Drawing.Size(75, 23);
            this.button_predict.TabIndex = 15;
            this.button_predict.Text = "预测报告";
            this.button_predict.UseVisualStyleBackColor = true;
            this.button_predict.Click += new System.EventHandler(this.button_predict_Click);
            // 
            // textBox_successes
            // 
            this.textBox_successes.Location = new System.Drawing.Point(15, 55);
            this.textBox_successes.Multiline = true;
            this.textBox_successes.Name = "textBox_successes";
            this.textBox_successes.Size = new System.Drawing.Size(352, 128);
            this.textBox_successes.TabIndex = 14;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label4.Location = new System.Drawing.Point(12, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(368, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "输入想要预测的次数结果(用逗号分隔，每行一组):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 10;
            this.label2.Text = "预测:";
            // 
            // DirichletPosterior
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 221);
            this.Controls.Add(this.button_predict);
            this.Controls.Add(this.textBox_successes);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Name = "DirichletPosterior";
            this.Text = "DirichletPosterior";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_predict;
        private System.Windows.Forms.TextBox textBox_successes;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
    }
}