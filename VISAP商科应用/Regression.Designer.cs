namespace VISAP商科应用
{
    partial class Regression
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
            this.button_Regression = new System.Windows.Forms.Button();
            this.textBox_Cols = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_y = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(467, 45);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 20;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(4, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 16);
            this.label2.TabIndex = 19;
            this.label2.Text = "自变量(x)的变量名:";
            // 
            // textBox_VarNames
            // 
            this.textBox_VarNames.Location = new System.Drawing.Point(162, 47);
            this.textBox_VarNames.Multiline = true;
            this.textBox_VarNames.Name = "textBox_VarNames";
            this.textBox_VarNames.ReadOnly = true;
            this.textBox_VarNames.Size = new System.Drawing.Size(299, 91);
            this.textBox_VarNames.TabIndex = 18;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(4, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 16);
            this.label1.TabIndex = 17;
            this.label1.Text = "自变量(x)所在列:";
            // 
            // button_ImportReport
            // 
            this.button_ImportReport.Location = new System.Drawing.Point(467, 149);
            this.button_ImportReport.Name = "button_ImportReport";
            this.button_ImportReport.Size = new System.Drawing.Size(75, 23);
            this.button_ImportReport.TabIndex = 16;
            this.button_ImportReport.Text = "导入报告";
            this.button_ImportReport.UseVisualStyleBackColor = true;
            // 
            // button_Regression
            // 
            this.button_Regression.Location = new System.Drawing.Point(467, 80);
            this.button_Regression.Name = "button_Regression";
            this.button_Regression.Size = new System.Drawing.Size(75, 23);
            this.button_Regression.TabIndex = 15;
            this.button_Regression.Text = "回归";
            this.button_Regression.UseVisualStyleBackColor = true;
            this.button_Regression.Click += new System.EventHandler(this.button_Regression_Click);
            // 
            // textBox_Cols
            // 
            this.textBox_Cols.Location = new System.Drawing.Point(162, 9);
            this.textBox_Cols.Name = "textBox_Cols";
            this.textBox_Cols.Size = new System.Drawing.Size(380, 21);
            this.textBox_Cols.TabIndex = 14;
            this.textBox_Cols.TextChanged += new System.EventHandler(this.textBox_Cols_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(4, 145);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(152, 16);
            this.label3.TabIndex = 21;
            this.label3.Text = "因变量(y)的变量名:";
            // 
            // comboBox_y
            // 
            this.comboBox_y.FormattingEnabled = true;
            this.comboBox_y.Location = new System.Drawing.Point(163, 145);
            this.comboBox_y.Name = "comboBox_y";
            this.comboBox_y.Size = new System.Drawing.Size(121, 20);
            this.comboBox_y.TabIndex = 22;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(467, 115);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 23;
            this.button1.Text = "回归诊断";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Regression
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 184);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBox_y);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_VarNames);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_ImportReport);
            this.Controls.Add(this.button_Regression);
            this.Controls.Add(this.textBox_Cols);
            this.Name = "Regression";
            this.Text = "Regression";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_VarNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_ImportReport;
        private System.Windows.Forms.Button button_Regression;
        private System.Windows.Forms.TextBox textBox_Cols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_y;
        private System.Windows.Forms.Button button1;
    }
}