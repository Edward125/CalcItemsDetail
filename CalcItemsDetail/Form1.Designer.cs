namespace CalcItemsDetail
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lstItem = new System.Windows.Forms.ListBox();
            this.lstItemDetail = new System.Windows.Forms.ListBox();
            this.lstDepItem = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Location = new System.Drawing.Point(39, 26);
            this.txtExcelFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(494, 22);
            this.txtExcelFile.TabIndex = 5;
            this.txtExcelFile.DoubleClick += new System.EventHandler(this.txtExcelFile_DoubleClick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(539, 20);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(84, 32);
            this.btnOK.TabIndex = 6;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(916, 58);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(627, 249);
            this.dataGridView1.TabIndex = 7;
            // 
            // lstItem
            // 
            this.lstItem.FormattingEnabled = true;
            this.lstItem.ItemHeight = 14;
            this.lstItem.Location = new System.Drawing.Point(116, 75);
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(195, 200);
            this.lstItem.TabIndex = 8;
            // 
            // lstItemDetail
            // 
            this.lstItemDetail.FormattingEnabled = true;
            this.lstItemDetail.ItemHeight = 14;
            this.lstItemDetail.Location = new System.Drawing.Point(317, 75);
            this.lstItemDetail.Name = "lstItemDetail";
            this.lstItemDetail.Size = new System.Drawing.Size(432, 200);
            this.lstItemDetail.TabIndex = 9;
            // 
            // lstDepItem
            // 
            this.lstDepItem.FormattingEnabled = true;
            this.lstDepItem.ItemHeight = 14;
            this.lstDepItem.Location = new System.Drawing.Point(12, 75);
            this.lstDepItem.Name = "lstDepItem";
            this.lstDepItem.Size = new System.Drawing.Size(98, 200);
            this.lstDepItem.TabIndex = 10;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(629, 20);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 284);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lstDepItem);
            this.Controls.Add(this.lstItemDetail);
            this.Controls.Add(this.lstItem);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.txtExcelFile);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "Form1";
            this.Text = "Calc Items";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcelFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstItem;
        private System.Windows.Forms.ListBox lstItemDetail;
        private System.Windows.Forms.ListBox lstDepItem;
        private System.Windows.Forms.Button btnSave;
    }
}

