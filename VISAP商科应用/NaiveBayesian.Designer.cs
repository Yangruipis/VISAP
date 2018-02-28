namespace VISAP商科应用
{
    partial class NaiveBayesian
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
            this.button_refresh_predict = new System.Windows.Forms.Button();
            this.comboBox_Class = new System.Windows.Forms.ComboBox();
            this.textBox_cols = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.button_import = new System.Windows.Forms.Button();
            this.dataGridView_subset = new System.Windows.Forms.DataGridView();
            this.button_predict = new System.Windows.Forms.Button();
            this.button_GenrateRules = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_result = new System.Windows.Forms.TextBox();
            this.button_refresh = new System.Windows.Forms.Button();
            this.textBox_ChosenCols = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subset)).BeginInit();
            this.SuspendLayout();
            // 
            // button_refresh_predict
            // 
            this.button_refresh_predict.Location = new System.Drawing.Point(112, 359);
            this.button_refresh_predict.Name = "button_refresh_predict";
            this.button_refresh_predict.Size = new System.Drawing.Size(75, 23);
            this.button_refresh_predict.TabIndex = 50;
            this.button_refresh_predict.Text = "刷新列数";
            this.button_refresh_predict.UseVisualStyleBackColor = true;
            this.button_refresh_predict.Click += new System.EventHandler(this.button_refresh_predict_Click);
            // 
            // comboBox_Class
            // 
            this.comboBox_Class.FormattingEnabled = true;
            this.comboBox_Class.Location = new System.Drawing.Point(405, 9);
            this.comboBox_Class.Name = "comboBox_Class";
            this.comboBox_Class.Size = new System.Drawing.Size(121, 20);
            this.comboBox_Class.TabIndex = 48;
            // 
            // textBox_cols
            // 
            this.textBox_cols.Location = new System.Drawing.Point(112, 324);
            this.textBox_cols.Name = "textBox_cols";
            this.textBox_cols.Size = new System.Drawing.Size(214, 21);
            this.textBox_cols.TabIndex = 46;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(40, 324);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(66, 19);
            this.label3.TabIndex = 45;
            this.label3.Text = "列数：";
            // 
            // button_import
            // 
            this.button_import.Location = new System.Drawing.Point(195, 36);
            this.button_import.Name = "button_import";
            this.button_import.Size = new System.Drawing.Size(75, 23);
            this.button_import.TabIndex = 44;
            this.button_import.Text = "导入数据";
            this.button_import.UseVisualStyleBackColor = true;
            this.button_import.Click += new System.EventHandler(this.button_import_Click);
            // 
            // dataGridView_subset
            // 
            this.dataGridView_subset.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_subset.Location = new System.Drawing.Point(17, 76);
            this.dataGridView_subset.Name = "dataGridView_subset";
            this.dataGridView_subset.RowTemplate.Height = 23;
            this.dataGridView_subset.Size = new System.Drawing.Size(296, 212);
            this.dataGridView_subset.TabIndex = 43;
            this.dataGridView_subset.VirtualMode = true;
            this.dataGridView_subset.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_subset_CellValueChanged);
            // 
            // button_predict
            // 
            this.button_predict.Location = new System.Drawing.Point(619, 317);
            this.button_predict.Name = "button_predict";
            this.button_predict.Size = new System.Drawing.Size(97, 38);
            this.button_predict.TabIndex = 42;
            this.button_predict.Text = "预测";
            this.button_predict.UseVisualStyleBackColor = true;
            this.button_predict.Click += new System.EventHandler(this.button_predict_Click);
            // 
            // button_GenrateRules
            // 
            this.button_GenrateRules.Location = new System.Drawing.Point(557, 9);
            this.button_GenrateRules.Name = "button_GenrateRules";
            this.button_GenrateRules.Size = new System.Drawing.Size(97, 23);
            this.button_GenrateRules.TabIndex = 41;
            this.button_GenrateRules.Text = "生成分类规则";
            this.button_GenrateRules.UseVisualStyleBackColor = true;
            this.button_GenrateRules.Click += new System.EventHandler(this.button_GenrateRules_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label2.Location = new System.Drawing.Point(332, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 19);
            this.label2.TabIndex = 40;
            this.label2.Text = "类别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(27, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(66, 19);
            this.label1.TabIndex = 39;
            this.label1.Text = "特征：";
            // 
            // textBox_result
            // 
            this.textBox_result.Location = new System.Drawing.Point(320, 76);
            this.textBox_result.Multiline = true;
            this.textBox_result.Name = "textBox_result";
            this.textBox_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBox_result.Size = new System.Drawing.Size(396, 212);
            this.textBox_result.TabIndex = 38;
            // 
            // button_refresh
            // 
            this.button_refresh.Location = new System.Drawing.Point(99, 36);
            this.button_refresh.Name = "button_refresh";
            this.button_refresh.Size = new System.Drawing.Size(75, 23);
            this.button_refresh.TabIndex = 37;
            this.button_refresh.Text = "刷新列数";
            this.button_refresh.UseVisualStyleBackColor = true;
            this.button_refresh.Click += new System.EventHandler(this.button_refresh_Click);
            // 
            // textBox_ChosenCols
            // 
            this.textBox_ChosenCols.Location = new System.Drawing.Point(99, 9);
            this.textBox_ChosenCols.Name = "textBox_ChosenCols";
            this.textBox_ChosenCols.Size = new System.Drawing.Size(214, 21);
            this.textBox_ChosenCols.TabIndex = 36;
            // 
            // NaiveBayesian
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 386);
            this.Controls.Add(this.button_refresh_predict);
            this.Controls.Add(this.comboBox_Class);
            this.Controls.Add(this.textBox_cols);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_import);
            this.Controls.Add(this.dataGridView_subset);
            this.Controls.Add(this.button_predict);
            this.Controls.Add(this.button_GenrateRules);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox_result);
            this.Controls.Add(this.button_refresh);
            this.Controls.Add(this.textBox_ChosenCols);
            this.Name = "NaiveBayesian";
            this.Text = "NaiveBayesian";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_subset)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_refresh_predict;
        private System.Windows.Forms.ComboBox comboBox_Class;
        private System.Windows.Forms.TextBox textBox_cols;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button_import;
        private System.Windows.Forms.DataGridView dataGridView_subset;
        private System.Windows.Forms.Button button_predict;
        private System.Windows.Forms.Button button_GenrateRules;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_result;
        private System.Windows.Forms.Button button_refresh;
        private System.Windows.Forms.TextBox textBox_ChosenCols;
    }
}