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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.txtExcelFile = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.lstItem = new System.Windows.Forms.ListBox();
            this.lstItemDetail = new System.Windows.Forms.ListBox();
            this.lstDepItem = new System.Windows.Forms.ListBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grbDepItem = new System.Windows.Forms.GroupBox();
            this.grbSubItem = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grbDepItem.SuspendLayout();
            this.grbSubItem.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtExcelFile
            // 
            this.txtExcelFile.Location = new System.Drawing.Point(79, 19);
            this.txtExcelFile.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtExcelFile.Name = "txtExcelFile";
            this.txtExcelFile.Size = new System.Drawing.Size(491, 22);
            this.txtExcelFile.TabIndex = 5;
            this.txtExcelFile.DoubleClick += new System.EventHandler(this.txtExcelFile_DoubleClick);
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(576, 13);
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
            this.dataGridView1.Location = new System.Drawing.Point(1167, 239);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(627, 249);
            this.dataGridView1.TabIndex = 7;
            this.dataGridView1.Visible = false;
            // 
            // lstItem
            // 
            this.lstItem.FormattingEnabled = true;
            this.lstItem.ItemHeight = 14;
            this.lstItem.Location = new System.Drawing.Point(6, 21);
            this.lstItem.Name = "lstItem";
            this.lstItem.Size = new System.Drawing.Size(559, 200);
            this.lstItem.TabIndex = 8;
            // 
            // lstItemDetail
            // 
            this.lstItemDetail.FormattingEnabled = true;
            this.lstItemDetail.ItemHeight = 14;
            this.lstItemDetail.Location = new System.Drawing.Point(6, 21);
            this.lstItemDetail.Name = "lstItemDetail";
            this.lstItemDetail.Size = new System.Drawing.Size(744, 298);
            this.lstItemDetail.TabIndex = 9;
            // 
            // lstDepItem
            // 
            this.lstDepItem.FormattingEnabled = true;
            this.lstDepItem.ItemHeight = 14;
            this.lstDepItem.Location = new System.Drawing.Point(6, 21);
            this.lstDepItem.Name = "lstDepItem";
            this.lstDepItem.Size = new System.Drawing.Size(165, 200);
            this.lstDepItem.TabIndex = 10;
            this.lstDepItem.SelectedIndexChanged += new System.EventHandler(this.lstDepItem_SelectedIndexChanged);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(666, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(84, 32);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.txtExcelFile);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(761, 52);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 14);
            this.label1.TabIndex = 12;
            this.label1.Text = "ExcelFile";
            // 
            // grbDepItem
            // 
            this.grbDepItem.Controls.Add(this.lstDepItem);
            this.grbDepItem.Location = new System.Drawing.Point(12, 70);
            this.grbDepItem.Name = "grbDepItem";
            this.grbDepItem.Size = new System.Drawing.Size(179, 227);
            this.grbDepItem.TabIndex = 13;
            this.grbDepItem.TabStop = false;
            // 
            // grbSubItem
            // 
            this.grbSubItem.Controls.Add(this.lstItem);
            this.grbSubItem.Location = new System.Drawing.Point(197, 70);
            this.grbSubItem.Name = "grbSubItem";
            this.grbSubItem.Size = new System.Drawing.Size(576, 227);
            this.grbSubItem.TabIndex = 14;
            this.grbSubItem.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lstItemDetail);
            this.groupBox4.Location = new System.Drawing.Point(12, 303);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(761, 330);
            this.groupBox4.TabIndex = 15;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "All Details";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(789, 647);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.grbSubItem);
            this.Controls.Add(this.grbDepItem);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Calc Items";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grbDepItem.ResumeLayout(false);
            this.grbSubItem.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtExcelFile;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ListBox lstItem;
        private System.Windows.Forms.ListBox lstItemDetail;
        private System.Windows.Forms.ListBox lstDepItem;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grbDepItem;
        private System.Windows.Forms.GroupBox grbSubItem;
        private System.Windows.Forms.GroupBox groupBox4;
    }
}

