namespace VISAP商科应用
{
    partial class MultipleChoice
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
            this.comboBox_Cols = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_Choices = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Split = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Cols
            // 
            this.comboBox_Cols.FormattingEnabled = true;
            this.comboBox_Cols.Location = new System.Drawing.Point(126, 12);
            this.comboBox_Cols.Name = "comboBox_Cols";
            this.comboBox_Cols.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Cols.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(13, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "待处理的列:";
            // 
            // textBox_Choices
            // 
            this.textBox_Choices.Location = new System.Drawing.Point(16, 76);
            this.textBox_Choices.Multiline = true;
            this.textBox_Choices.Name = "textBox_Choices";
            this.textBox_Choices.Size = new System.Drawing.Size(231, 133);
            this.textBox_Choices.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(192, 16);
            this.label2.TabIndex = 3;
            this.label2.Text = "输入所有选项(每行一个):";
            // 
            // button_Split
            // 
            this.button_Split.Location = new System.Drawing.Point(172, 227);
            this.button_Split.Name = "button_Split";
            this.button_Split.Size = new System.Drawing.Size(75, 23);
            this.button_Split.TabIndex = 4;
            this.button_Split.Text = "拆分";
            this.button_Split.UseVisualStyleBackColor = true;
            this.button_Split.Click += new System.EventHandler(this.button_Split_Click);
            // 
            // MultipleChoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(259, 262);
            this.Controls.Add(this.button_Split);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_Choices);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Cols);
            this.Name = "MultipleChoice";
            this.Text = "MultipleChoice";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Cols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_Choices;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Split;
    }
}