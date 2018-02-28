namespace VISAP商科应用
{
    partial class NAOperation
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
            this.listBox_Methods = new System.Windows.Forms.ListBox();
            this.textBox_ChosenCols = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button_refresh = new System.Windows.Forms.Button();
            this.button_import = new System.Windows.Forms.Button();
            this.comboBox_user_defined = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_user_defined = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // listBox_Methods
            // 
            this.listBox_Methods.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.listBox_Methods.FormattingEnabled = true;
            this.listBox_Methods.ItemHeight = 19;
            this.listBox_Methods.Items.AddRange(new object[] {
            "计算缺失值个数",
            "删除整行",
            "替换为特定值"});
            this.listBox_Methods.Location = new System.Drawing.Point(20, 13);
            this.listBox_Methods.Name = "listBox_Methods";
            this.listBox_Methods.Size = new System.Drawing.Size(143, 80);
            this.listBox_Methods.TabIndex = 0;
            // 
            // textBox_ChosenCols
            // 
            this.textBox_ChosenCols.Location = new System.Drawing.Point(279, 15);
            this.textBox_ChosenCols.Name = "textBox_ChosenCols";
            this.textBox_ChosenCols.Size = new System.Drawing.Size(296, 21);
            this.textBox_ChosenCols.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(169, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "待处理列：";
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(408, 42);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 25;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(502, 42);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 23);
            this.button_import.TabIndex = 24;
            this.button_import.Text = "处理";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // comboBox_user_defined
            // 
            this.comboBox_user_defined.FormattingEnabled = true;
            this.comboBox_user_defined.Items.AddRange(new object[] {
            "自定义值",
            "平均值"});
            this.comboBox_user_defined.Location = new System.Drawing.Point(279, 44);
            this.comboBox_user_defined.Name = "comboBox_user_defined";
            this.comboBox_user_defined.Size = new System.Drawing.Size(121, 20);
            this.comboBox_user_defined.TabIndex = 26;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(169, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 19);
            this.label2.TabIndex = 27;
            this.label2.Text = "待替换值：";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(169, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(104, 19);
            this.label3.TabIndex = 28;
            this.label3.Text = "自定义值：";
            // 
            // textBox_user_defined
            // 
            this.textBox_user_defined.Location = new System.Drawing.Point(279, 74);
            this.textBox_user_defined.Name = "textBox_user_defined";
            this.textBox_user_defined.Size = new System.Drawing.Size(121, 21);
            this.textBox_user_defined.TabIndex = 29;
            // 
            // NAOperation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(604, 103);
            this.Controls.Add(this.textBox_user_defined);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox_user_defined);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_ChosenCols);
            this.Controls.Add(this.listBox_Methods);
            this.Name = "NAOperation";
            this.Text = "NAOperation";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox_Methods;
        private System.Windows.Forms.TextBox textBox_ChosenCols;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.ComboBox comboBox_user_defined;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_user_defined;
    }
}