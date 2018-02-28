namespace VISAP商科应用
{
    partial class ANOVA_OneWay
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
            this.textBox_Cols = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_VarNames = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_Anova = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_Cols
            // 
            this.textBox_Cols.Location = new System.Drawing.Point(112, 12);
            this.textBox_Cols.Name = "textBox_Cols";
            this.textBox_Cols.Size = new System.Drawing.Size(344, 21);
            this.textBox_Cols.TabIndex = 15;
            this.textBox_Cols.TextChanged += new System.EventHandler(this.textBox_Cols_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(10, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(96, 16);
            this.label1.TabIndex = 18;
            this.label1.Text = "变量所在列:";
            // 
            // textBox_VarNames
            // 
            this.textBox_VarNames.Location = new System.Drawing.Point(112, 39);
            this.textBox_VarNames.Multiline = true;
            this.textBox_VarNames.Name = "textBox_VarNames";
            this.textBox_VarNames.ReadOnly = true;
            this.textBox_VarNames.Size = new System.Drawing.Size(344, 111);
            this.textBox_VarNames.TabIndex = 19;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(10, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 16);
            this.label2.TabIndex = 20;
            this.label2.Text = "所选变量名:";
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(12, 64);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(94, 23);
            this.button_refresh.TabIndex = 21;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_Anova
            // 
            this.button_Anova.Location = new System.Drawing.Point(12, 97);
            this.button_Anova.Name = "button_Anova";
            this.button_Anova.Size = new System.Drawing.Size(94, 23);
            this.button_Anova.TabIndex = 22;
            this.button_Anova.Text = "方差分析";
            this.button_Anova.UseVisualStyleBackColor = true;
            this.button_Anova.Click += new System.EventHandler(this.button_Anova_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 128);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 21;
            this.button1.Text = "导入报告";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // ANOVA_OneWay
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(479, 160);
            this.Controls.Add(this.button_Anova);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_VarNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_Cols);
            this.Name = "ANOVA_OneWay";
            this.Text = "ANOVA_OneWay";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_Cols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_VarNames;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_Anova;
        private System.Windows.Forms.Button button1;
    }
}