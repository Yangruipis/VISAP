namespace VISAP商科应用
{
    partial class Multinomial
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
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_Cols = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.listBox_MultiChoices = new System.Windows.Forms.ListBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label_SampleSize = new System.Windows.Forms.Label();
            this.textBox_Times = new System.Windows.Forms.TextBox();
            this.textBox_Likihood = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.button_PosteriorDensity = new System.Windows.Forms.Button();
            this.button_Generate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label5.Location = new System.Drawing.Point(12, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(176, 16);
            this.label5.TabIndex = 10;
            this.label5.Text = "您想要研究的变量名称:";
            // 
            // comboBox_Cols
            // 
            this.comboBox_Cols.FormattingEnabled = true;
            this.comboBox_Cols.Location = new System.Drawing.Point(205, 9);
            this.comboBox_Cols.Name = "comboBox_Cols";
            this.comboBox_Cols.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Cols.TabIndex = 9;
            this.comboBox_Cols.TextChanged += new System.EventHandler(this.comboBox_Cols_TextChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(12, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(352, 16);
            this.label2.TabIndex = 8;
            this.label2.Text = "在这次调研之前，您对这个变量有着怎样的了解?";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 7;
            this.label1.Text = "先验信息:";
            // 
            // listBox_MultiChoices
            // 
            this.listBox_MultiChoices.FormattingEnabled = true;
            this.listBox_MultiChoices.ItemHeight = 12;
            this.listBox_MultiChoices.Location = new System.Drawing.Point(15, 106);
            this.listBox_MultiChoices.Name = "listBox_MultiChoices";
            this.listBox_MultiChoices.Size = new System.Drawing.Size(201, 88);
            this.listBox_MultiChoices.TabIndex = 11;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label7.Location = new System.Drawing.Point(12, 87);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 15;
            this.label7.Text = "选项:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(222, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 16);
            this.label3.TabIndex = 17;
            this.label3.Text = "次数(每行一个):";
            // 
            // label_SampleSize
            // 
            this.label_SampleSize.AutoSize = true;
            this.label_SampleSize.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label_SampleSize.Location = new System.Drawing.Point(12, 207);
            this.label_SampleSize.Name = "label_SampleSize";
            this.label_SampleSize.Size = new System.Drawing.Size(208, 16);
            this.label_SampleSize.TabIndex = 18;
            this.label_SampleSize.Text = "您的先验信息相当于0个样本";
            // 
            // textBox_Times
            // 
            this.textBox_Times.Location = new System.Drawing.Point(225, 107);
            this.textBox_Times.Multiline = true;
            this.textBox_Times.Name = "textBox_Times";
            this.textBox_Times.Size = new System.Drawing.Size(139, 87);
            this.textBox_Times.TabIndex = 19;
            this.textBox_Times.TextChanged += new System.EventHandler(this.textBox_Times_TextChanged);
            // 
            // textBox_Likihood
            // 
            this.textBox_Likihood.Location = new System.Drawing.Point(15, 255);
            this.textBox_Likihood.Multiline = true;
            this.textBox_Likihood.Name = "textBox_Likihood";
            this.textBox_Likihood.Size = new System.Drawing.Size(311, 109);
            this.textBox_Likihood.TabIndex = 21;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label6.Location = new System.Drawing.Point(12, 235);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 20;
            this.label6.Text = "调研信息:";
            // 
            // button_PosteriorDensity
            // 
            this.button_PosteriorDensity.Location = new System.Drawing.Point(152, 370);
            this.button_PosteriorDensity.Name = "button_PosteriorDensity";
            this.button_PosteriorDensity.Size = new System.Drawing.Size(122, 23);
            this.button_PosteriorDensity.TabIndex = 23;
            this.button_PosteriorDensity.Text = "查看后验分布";
            this.button_PosteriorDensity.UseVisualStyleBackColor = true;
            this.button_PosteriorDensity.Click += new System.EventHandler(this.button_PosteriorDensity_Click);
            // 
            // button_Generate
            // 
            this.button_Generate.Location = new System.Drawing.Point(15, 370);
            this.button_Generate.Name = "button_Generate";
            this.button_Generate.Size = new System.Drawing.Size(122, 23);
            this.button_Generate.TabIndex = 22;
            this.button_Generate.Text = "生成后验分析结果";
            this.button_Generate.UseVisualStyleBackColor = true;
            this.button_Generate.Click += new System.EventHandler(this.button_Generate_Click);
            // 
            // Multinomial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 403);
            this.Controls.Add(this.button_PosteriorDensity);
            this.Controls.Add(this.button_Generate);
            this.Controls.Add(this.textBox_Likihood);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_Times);
            this.Controls.Add(this.label_SampleSize);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.listBox_MultiChoices);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox_Cols);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Multinomial";
            this.Text = "Multinomial";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_Cols;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox_MultiChoices;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label_SampleSize;
        private System.Windows.Forms.TextBox textBox_Times;
        private System.Windows.Forms.TextBox textBox_Likihood;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button button_PosteriorDensity;
        private System.Windows.Forms.Button button_Generate;
    }
}