namespace VISAP商科应用
{
    partial class Correlation
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
            this.button_refresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_VarNames = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_ImportReport = new System.Windows.Forms.Button();
            this.button_Correlation = new System.Windows.Forms.Button();
            this.textBox_Cols = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(385, 48);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 13;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(6, 50);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 12;
            this.label2.Text = "变量名：";
            // 
            // textBox_VarNames
            // 
            this.textBox_VarNames.Location = new System.Drawing.Point(80, 50);
            this.textBox_VarNames.Multiline = true;
            this.textBox_VarNames.Name = "textBox_VarNames";
            this.textBox_VarNames.ReadOnly = true;
            this.textBox_VarNames.Size = new System.Drawing.Size(299, 91);
            this.textBox_VarNames.TabIndex = 11;
            this.textBox_VarNames.TextChanged += new System.EventHandler(this.textBox_VarNames_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(6, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "列数：";
            // 
            // button_ImportReport
            // 
            this.button_ImportReport.Location = new System.Drawing.Point(385, 118);
            this.button_ImportReport.Name = "button_ImportReport";
            this.button_ImportReport.Size = new System.Drawing.Size(75, 23);
            this.button_ImportReport.TabIndex = 9;
            this.button_ImportReport.Text = "导入报告";
            this.button_ImportReport.UseVisualStyleBackColor = true;
            // 
            // button_Correlation
            // 
            this.button_Correlation.Location = new System.Drawing.Point(385, 83);
            this.button_Correlation.Name = "button_Correlation";
            this.button_Correlation.Size = new System.Drawing.Size(75, 23);
            this.button_Correlation.TabIndex = 8;
            this.button_Correlation.Text = "相关系数";
            this.button_Correlation.UseVisualStyleBackColor = true;
            this.button_Correlation.Click += new System.EventHandler(this.button_Correlation_Click);
            // 
            // textBox_Cols
            // 
            this.textBox_Cols.Location = new System.Drawing.Point(80, 12);
            this.textBox_Cols.Name = "textBox_Cols";
            this.textBox_Cols.Size = new System.Drawing.Size(380, 21);
            this.textBox_Cols.TabIndex = 7;
            this.textBox_Cols.TextChanged += new System.EventHandler(this.textBox_Cols_TextChanged);
            // 
            // Correlation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 153);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_VarNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ImportReport);
            this.Controls.Add(this.button_Correlation);
            this.Controls.Add(this.textBox_Cols);
            this.Name = "Correlation";
            this.Text = "Correlation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_VarNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ImportReport;
        private System.Windows.Forms.Button button_Correlation;
        private System.Windows.Forms.TextBox textBox_Cols;
    }
}