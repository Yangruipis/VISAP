namespace VISAP商科应用
{
    partial class Split
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
            this.checkBox_Tab = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox_semicolon = new System.Windows.Forms.CheckBox();
            this.checkBox_comma = new System.Windows.Forms.CheckBox();
            this.checkBox_space = new System.Windows.Forms.CheckBox();
            this.checkBox_OtherChar = new System.Windows.Forms.CheckBox();
            this.textBox_SplitChar = new System.Windows.Forms.TextBox();
            this.button_StartSplit = new System.Windows.Forms.Button();
            this.textBox_ChosenCols = new System.Windows.Forms.TextBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // checkBox_Tab
            // 
            this.checkBox_Tab.AutoSize = true;
            this.checkBox_Tab.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_Tab.Location = new System.Drawing.Point(15, 37);
            this.checkBox_Tab.Name = "checkBox_Tab";
            this.checkBox_Tab.Size = new System.Drawing.Size(51, 20);
            this.checkBox_Tab.TabIndex = 0;
            this.checkBox_Tab.Text = "Tab";
            this.checkBox_Tab.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "分隔符号:";
            // 
            // checkBox_semicolon
            // 
            this.checkBox_semicolon.AutoSize = true;
            this.checkBox_semicolon.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_semicolon.Location = new System.Drawing.Point(15, 63);
            this.checkBox_semicolon.Name = "checkBox_semicolon";
            this.checkBox_semicolon.Size = new System.Drawing.Size(59, 20);
            this.checkBox_semicolon.TabIndex = 2;
            this.checkBox_semicolon.Text = "分号";
            this.checkBox_semicolon.UseVisualStyleBackColor = true;
            // 
            // checkBox_comma
            // 
            this.checkBox_comma.AutoSize = true;
            this.checkBox_comma.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_comma.Location = new System.Drawing.Point(15, 89);
            this.checkBox_comma.Name = "checkBox_comma";
            this.checkBox_comma.Size = new System.Drawing.Size(59, 20);
            this.checkBox_comma.TabIndex = 3;
            this.checkBox_comma.Text = "逗号";
            this.checkBox_comma.UseVisualStyleBackColor = true;
            // 
            // checkBox_space
            // 
            this.checkBox_space.AutoSize = true;
            this.checkBox_space.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_space.Location = new System.Drawing.Point(15, 113);
            this.checkBox_space.Name = "checkBox_space";
            this.checkBox_space.Size = new System.Drawing.Size(59, 20);
            this.checkBox_space.TabIndex = 4;
            this.checkBox_space.Text = "空格";
            this.checkBox_space.UseVisualStyleBackColor = true;
            // 
            // checkBox_OtherChar
            // 
            this.checkBox_OtherChar.AutoSize = true;
            this.checkBox_OtherChar.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.checkBox_OtherChar.Location = new System.Drawing.Point(15, 139);
            this.checkBox_OtherChar.Name = "checkBox_OtherChar";
            this.checkBox_OtherChar.Size = new System.Drawing.Size(91, 20);
            this.checkBox_OtherChar.TabIndex = 5;
            this.checkBox_OtherChar.Text = "其他字符";
            this.checkBox_OtherChar.UseVisualStyleBackColor = true;
            // 
            // textBox_SplitChar
            // 
            this.textBox_SplitChar.Location = new System.Drawing.Point(113, 137);
            this.textBox_SplitChar.MaxLength = 1;
            this.textBox_SplitChar.Name = "textBox_SplitChar";
            this.textBox_SplitChar.Size = new System.Drawing.Size(44, 21);
            this.textBox_SplitChar.TabIndex = 6;
            // 
            // button_StartSplit
            // 
            this.button_StartSplit.Location = new System.Drawing.Point(262, 37);
            this.button_StartSplit.Name = "button_StartSplit";
            this.button_StartSplit.Size = new System.Drawing.Size(75, 23);
            this.button_StartSplit.TabIndex = 7;
            this.button_StartSplit.Text = "分列";
            this.button_StartSplit.UseVisualStyleBackColor = true;
            this.button_StartSplit.Click += new System.EventHandler(this.button_StartSplit_Click);
            // 
            // textBox_ChosenCols
            // 
            this.textBox_ChosenCols.Location = new System.Drawing.Point(172, 9);
            this.textBox_ChosenCols.Name = "textBox_ChosenCols";
            this.textBox_ChosenCols.Size = new System.Drawing.Size(165, 21);
            this.textBox_ChosenCols.TabIndex = 20;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(172, 37);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 24;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // Split
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(349, 166);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.textBox_ChosenCols);
            this.Controls.Add(this.button_StartSplit);
            this.Controls.Add(this.textBox_SplitChar);
            this.Controls.Add(this.checkBox_OtherChar);
            this.Controls.Add(this.checkBox_space);
            this.Controls.Add(this.checkBox_comma);
            this.Controls.Add(this.checkBox_semicolon);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.checkBox_Tab);
            this.Name = "Split";
            this.Text = "Split";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox checkBox_Tab;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox_semicolon;
        private System.Windows.Forms.CheckBox checkBox_comma;
        private System.Windows.Forms.CheckBox checkBox_space;
        private System.Windows.Forms.CheckBox checkBox_OtherChar;
        private System.Windows.Forms.TextBox textBox_SplitChar;
        private System.Windows.Forms.Button button_StartSplit;
        private System.Windows.Forms.TextBox textBox_ChosenCols;
        private System.Windows.Forms.Button button_refresh;
    }
}