namespace VISAP商科应用
{
    partial class ImportCSV
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
            this.textBox_SplitChar = new System.Windows.Forms.TextBox();
            this.checkBox_OtherChar = new System.Windows.Forms.CheckBox();
            this.checkBox_comma = new System.Windows.Forms.CheckBox();
            this.checkBox_semicolon = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_Tab = new System.Windows.Forms.CheckBox();
            this.comboBox_method = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox_path = new System.Windows.Forms.TextBox();
            this.button_select = new System.Windows.Forms.Button();
            this.Import = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox_SplitChar
            // 
            this.textBox_SplitChar.Location = new System.Drawing.Point(114, 178);
            this.textBox_SplitChar.MaxLength = 1;
            this.textBox_SplitChar.Name = "textBox_SplitChar";
            this.textBox_SplitChar.Size = new System.Drawing.Size(44, 21);
            this.textBox_SplitChar.TabIndex = 13;
            // 
            // checkBox_OtherChar
            // 
            this.checkBox_OtherChar.AutoSize = true;
            this.checkBox_OtherChar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_OtherChar.Location = new System.Drawing.Point(16, 180);
            this.checkBox_OtherChar.Name = "checkBox_OtherChar";
            this.checkBox_OtherChar.Size = new System.Drawing.Size(91, 20);
            this.checkBox_OtherChar.TabIndex = 12;
            this.checkBox_OtherChar.Text = "其他字符";
            this.checkBox_OtherChar.UseVisualStyleBackColor = true;
            // 
            // checkBox_comma
            // 
            this.checkBox_comma.AutoSize = true;
            this.checkBox_comma.Checked = true;
            this.checkBox_comma.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox_comma.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_comma.Location = new System.Drawing.Point(15, 154);
            this.checkBox_comma.Name = "checkBox_comma";
            this.checkBox_comma.Size = new System.Drawing.Size(59, 20);
            this.checkBox_comma.TabIndex = 10;
            this.checkBox_comma.Text = "逗号";
            this.checkBox_comma.UseVisualStyleBackColor = true;
            // 
            // checkBox_semicolon
            // 
            this.checkBox_semicolon.AutoSize = true;
            this.checkBox_semicolon.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_semicolon.Location = new System.Drawing.Point(15, 128);
            this.checkBox_semicolon.Name = "checkBox_semicolon";
            this.checkBox_semicolon.Size = new System.Drawing.Size(59, 20);
            this.checkBox_semicolon.TabIndex = 9;
            this.checkBox_semicolon.Text = "分号";
            this.checkBox_semicolon.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 8;
            this.label1.Text = "分隔符号:";
            // 
            // checkBox_Tab
            // 
            this.checkBox_Tab.AutoSize = true;
            this.checkBox_Tab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Tab.Location = new System.Drawing.Point(15, 102);
            this.checkBox_Tab.Name = "checkBox_Tab";
            this.checkBox_Tab.Size = new System.Drawing.Size(51, 20);
            this.checkBox_Tab.TabIndex = 7;
            this.checkBox_Tab.Text = "Tab";
            this.checkBox_Tab.UseVisualStyleBackColor = true;
            // 
            // comboBox_method
            // 
            this.comboBox_method.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBox_method.FormattingEnabled = true;
            this.comboBox_method.Items.AddRange(new object[] {
            "单个导入",
            "批量导入"});
            this.comboBox_method.Location = new System.Drawing.Point(12, 9);
            this.comboBox_method.Name = "comboBox_method";
            this.comboBox_method.Size = new System.Drawing.Size(121, 24);
            this.comboBox_method.TabIndex = 14;
            this.comboBox_method.Text = "单个导入";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(13, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "文件路径";
            // 
            // textBox_path
            // 
            this.textBox_path.Location = new System.Drawing.Point(91, 39);
            this.textBox_path.Name = "textBox_path";
            this.textBox_path.Size = new System.Drawing.Size(269, 21);
            this.textBox_path.TabIndex = 16;
            this.textBox_path.TextChanged += new System.EventHandler(this.textBox_path_TextChanged);
            // 
            // button_select
            // 
            this.button_select.Location = new System.Drawing.Point(376, 39);
            this.button_select.Name = "button_select";
            this.button_select.Size = new System.Drawing.Size(75, 23);
            this.button_select.TabIndex = 15;
            this.button_select.Text = "选择文件";
            this.button_select.UseVisualStyleBackColor = true;
            this.button_select.Click += new System.EventHandler(this.button_select_Click);
            // 
            // Import
            // 
            this.Import.Location = new System.Drawing.Point(376, 74);
            this.Import.Name = "Import";
            this.Import.Size = new System.Drawing.Size(75, 23);
            this.Import.TabIndex = 18;
            this.Import.Text = "导入";
            this.Import.UseVisualStyleBackColor = true;
            this.Import.Click += new System.EventHandler(this.Import_Click);
            // 
            // ImportCSV
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(459, 205);
            this.Controls.Add(this.Import);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_path);
            this.Controls.Add(this.button_select);
            this.Controls.Add(this.comboBox_method);
            this.Controls.Add(this.textBox_SplitChar);
            this.Controls.Add(this.checkBox_OtherChar);
            this.Controls.Add(this.checkBox_comma);
            this.Controls.Add(this.checkBox_semicolon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Tab);
            this.Name = "ImportCSV";
            this.Text = "ImportCSV";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox_SplitChar;
        private System.Windows.Forms.CheckBox checkBox_OtherChar;
        private System.Windows.Forms.CheckBox checkBox_comma;
        private System.Windows.Forms.CheckBox checkBox_semicolon;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_Tab;
        private System.Windows.Forms.ComboBox comboBox_method;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox_path;
        private System.Windows.Forms.Button button_select;
        private System.Windows.Forms.Button Import;
    }
}