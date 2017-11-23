namespace ESLBooksAwardMig2017.UserControls
{
    partial class StepAControl
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.txtBookListFilepath = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.項次DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.大分類DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.中分類DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.獨立編號DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.圖檔名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.productGuidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.順序DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.屬性DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.推薦書籍DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iSBNDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mCHDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.分類DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出版日期DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.出版社DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.推薦單位DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.推薦總編DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職銜DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.總編推薦文DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.推薦職人店別DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職人姓名DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.職人推薦文DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.推薦作者DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tagDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.書落DataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bsBOOKLIST = new System.Windows.Forms.BindingSource(this.components);
            this.btnCheck = new System.Windows.Forms.Button();
            this.btnClear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBOOKLIST)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label1.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(828, 30);
            this.label1.TabIndex = 0;
            this.label1.Text = "匯入書封清單";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "書單統整檔";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(91, 80);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(75, 23);
            this.btnImport.TabIndex = 3;
            this.btnImport.Text = "匯入";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // txtBookListFilepath
            // 
            this.txtBookListFilepath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookListFilepath.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ESLBooksAwardMig2017.Properties.Settings.Default, "BookListFilepath", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtBookListFilepath.Location = new System.Drawing.Point(91, 51);
            this.txtBookListFilepath.Name = "txtBookListFilepath";
            this.txtBookListFilepath.Size = new System.Drawing.Size(719, 22);
            this.txtBookListFilepath.TabIndex = 2;
            this.txtBookListFilepath.Text = global::ESLBooksAwardMig2017.Properties.Settings.Default.BookListFilepath;
            this.toolTip1.SetToolTip(this.txtBookListFilepath, "雙擊可選檔。");
            this.txtBookListFilepath.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtBookListFilepath_MouseDoubleClick);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.項次DataGridViewTextBoxColumn,
            this.大分類DataGridViewTextBoxColumn,
            this.中分類DataGridViewTextBoxColumn,
            this.獨立編號DataGridViewTextBoxColumn,
            this.圖檔名DataGridViewTextBoxColumn,
            this.productGuidDataGridViewTextBoxColumn,
            this.順序DataGridViewTextBoxColumn,
            this.屬性DataGridViewTextBoxColumn,
            this.推薦書籍DataGridViewTextBoxColumn,
            this.iSBNDataGridViewTextBoxColumn,
            this.mCHDataGridViewTextBoxColumn,
            this.分類DataGridViewTextBoxColumn,
            this.出版日期DataGridViewTextBoxColumn,
            this.出版社DataGridViewTextBoxColumn,
            this.推薦單位DataGridViewTextBoxColumn,
            this.推薦總編DataGridViewTextBoxColumn,
            this.職銜DataGridViewTextBoxColumn,
            this.總編推薦文DataGridViewTextBoxColumn,
            this.推薦職人店別DataGridViewTextBoxColumn,
            this.職人姓名DataGridViewTextBoxColumn,
            this.職人推薦文DataGridViewTextBoxColumn,
            this.推薦作者DataGridViewTextBoxColumn,
            this.tagDataGridViewTextBoxColumn,
            this.書落DataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.bsBOOKLIST;
            this.dataGridView1.Location = new System.Drawing.Point(22, 109);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(788, 361);
            this.dataGridView1.TabIndex = 4;
            // 
            // 項次DataGridViewTextBoxColumn
            // 
            this.項次DataGridViewTextBoxColumn.DataPropertyName = "項次";
            this.項次DataGridViewTextBoxColumn.Frozen = true;
            this.項次DataGridViewTextBoxColumn.HeaderText = "項次";
            this.項次DataGridViewTextBoxColumn.Name = "項次DataGridViewTextBoxColumn";
            this.項次DataGridViewTextBoxColumn.ReadOnly = true;
            this.項次DataGridViewTextBoxColumn.Width = 50;
            // 
            // 大分類DataGridViewTextBoxColumn
            // 
            this.大分類DataGridViewTextBoxColumn.DataPropertyName = "大分類";
            this.大分類DataGridViewTextBoxColumn.HeaderText = "大分類";
            this.大分類DataGridViewTextBoxColumn.Name = "大分類DataGridViewTextBoxColumn";
            this.大分類DataGridViewTextBoxColumn.ReadOnly = true;
            this.大分類DataGridViewTextBoxColumn.Width = 60;
            // 
            // 中分類DataGridViewTextBoxColumn
            // 
            this.中分類DataGridViewTextBoxColumn.DataPropertyName = "中分類";
            this.中分類DataGridViewTextBoxColumn.HeaderText = "中分類";
            this.中分類DataGridViewTextBoxColumn.Name = "中分類DataGridViewTextBoxColumn";
            this.中分類DataGridViewTextBoxColumn.ReadOnly = true;
            this.中分類DataGridViewTextBoxColumn.Width = 60;
            // 
            // 獨立編號DataGridViewTextBoxColumn
            // 
            this.獨立編號DataGridViewTextBoxColumn.DataPropertyName = "獨立編號";
            this.獨立編號DataGridViewTextBoxColumn.HeaderText = "獨立編號";
            this.獨立編號DataGridViewTextBoxColumn.Name = "獨立編號DataGridViewTextBoxColumn";
            this.獨立編號DataGridViewTextBoxColumn.ReadOnly = true;
            this.獨立編號DataGridViewTextBoxColumn.Width = 60;
            // 
            // 圖檔名DataGridViewTextBoxColumn
            // 
            this.圖檔名DataGridViewTextBoxColumn.DataPropertyName = "圖檔名";
            this.圖檔名DataGridViewTextBoxColumn.HeaderText = "圖檔名";
            this.圖檔名DataGridViewTextBoxColumn.Name = "圖檔名DataGridViewTextBoxColumn";
            this.圖檔名DataGridViewTextBoxColumn.ReadOnly = true;
            this.圖檔名DataGridViewTextBoxColumn.Width = 80;
            // 
            // productGuidDataGridViewTextBoxColumn
            // 
            this.productGuidDataGridViewTextBoxColumn.DataPropertyName = "ProductGuid";
            this.productGuidDataGridViewTextBoxColumn.HeaderText = "ProductGuid";
            this.productGuidDataGridViewTextBoxColumn.Name = "productGuidDataGridViewTextBoxColumn";
            this.productGuidDataGridViewTextBoxColumn.ReadOnly = true;
            this.productGuidDataGridViewTextBoxColumn.Width = 120;
            // 
            // 順序DataGridViewTextBoxColumn
            // 
            this.順序DataGridViewTextBoxColumn.DataPropertyName = "順序";
            this.順序DataGridViewTextBoxColumn.HeaderText = "順序";
            this.順序DataGridViewTextBoxColumn.Name = "順序DataGridViewTextBoxColumn";
            this.順序DataGridViewTextBoxColumn.ReadOnly = true;
            this.順序DataGridViewTextBoxColumn.Width = 60;
            // 
            // 屬性DataGridViewTextBoxColumn
            // 
            this.屬性DataGridViewTextBoxColumn.DataPropertyName = "屬性";
            this.屬性DataGridViewTextBoxColumn.HeaderText = "屬性";
            this.屬性DataGridViewTextBoxColumn.Name = "屬性DataGridViewTextBoxColumn";
            this.屬性DataGridViewTextBoxColumn.ReadOnly = true;
            this.屬性DataGridViewTextBoxColumn.Width = 60;
            // 
            // 推薦書籍DataGridViewTextBoxColumn
            // 
            this.推薦書籍DataGridViewTextBoxColumn.DataPropertyName = "推薦書籍";
            this.推薦書籍DataGridViewTextBoxColumn.HeaderText = "推薦書籍";
            this.推薦書籍DataGridViewTextBoxColumn.Name = "推薦書籍DataGridViewTextBoxColumn";
            this.推薦書籍DataGridViewTextBoxColumn.ReadOnly = true;
            this.推薦書籍DataGridViewTextBoxColumn.Width = 200;
            // 
            // iSBNDataGridViewTextBoxColumn
            // 
            this.iSBNDataGridViewTextBoxColumn.DataPropertyName = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.HeaderText = "ISBN";
            this.iSBNDataGridViewTextBoxColumn.Name = "iSBNDataGridViewTextBoxColumn";
            this.iSBNDataGridViewTextBoxColumn.ReadOnly = true;
            this.iSBNDataGridViewTextBoxColumn.Width = 120;
            // 
            // mCHDataGridViewTextBoxColumn
            // 
            this.mCHDataGridViewTextBoxColumn.DataPropertyName = "MCH";
            this.mCHDataGridViewTextBoxColumn.HeaderText = "MCH";
            this.mCHDataGridViewTextBoxColumn.Name = "mCHDataGridViewTextBoxColumn";
            this.mCHDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 分類DataGridViewTextBoxColumn
            // 
            this.分類DataGridViewTextBoxColumn.DataPropertyName = "分類";
            this.分類DataGridViewTextBoxColumn.HeaderText = "分類";
            this.分類DataGridViewTextBoxColumn.Name = "分類DataGridViewTextBoxColumn";
            this.分類DataGridViewTextBoxColumn.ReadOnly = true;
            this.分類DataGridViewTextBoxColumn.Width = 60;
            // 
            // 出版日期DataGridViewTextBoxColumn
            // 
            this.出版日期DataGridViewTextBoxColumn.DataPropertyName = "出版日期";
            this.出版日期DataGridViewTextBoxColumn.HeaderText = "出版日期";
            this.出版日期DataGridViewTextBoxColumn.Name = "出版日期DataGridViewTextBoxColumn";
            this.出版日期DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 出版社DataGridViewTextBoxColumn
            // 
            this.出版社DataGridViewTextBoxColumn.DataPropertyName = "出版社";
            this.出版社DataGridViewTextBoxColumn.HeaderText = "出版社";
            this.出版社DataGridViewTextBoxColumn.Name = "出版社DataGridViewTextBoxColumn";
            this.出版社DataGridViewTextBoxColumn.ReadOnly = true;
            this.出版社DataGridViewTextBoxColumn.Width = 200;
            // 
            // 推薦單位DataGridViewTextBoxColumn
            // 
            this.推薦單位DataGridViewTextBoxColumn.DataPropertyName = "推薦單位";
            this.推薦單位DataGridViewTextBoxColumn.HeaderText = "推薦單位";
            this.推薦單位DataGridViewTextBoxColumn.Name = "推薦單位DataGridViewTextBoxColumn";
            this.推薦單位DataGridViewTextBoxColumn.ReadOnly = true;
            this.推薦單位DataGridViewTextBoxColumn.Width = 200;
            // 
            // 推薦總編DataGridViewTextBoxColumn
            // 
            this.推薦總編DataGridViewTextBoxColumn.DataPropertyName = "推薦總編";
            this.推薦總編DataGridViewTextBoxColumn.HeaderText = "推薦總編";
            this.推薦總編DataGridViewTextBoxColumn.Name = "推薦總編DataGridViewTextBoxColumn";
            this.推薦總編DataGridViewTextBoxColumn.ReadOnly = true;
            this.推薦總編DataGridViewTextBoxColumn.Width = 80;
            // 
            // 職銜DataGridViewTextBoxColumn
            // 
            this.職銜DataGridViewTextBoxColumn.DataPropertyName = "職銜";
            this.職銜DataGridViewTextBoxColumn.HeaderText = "職銜";
            this.職銜DataGridViewTextBoxColumn.Name = "職銜DataGridViewTextBoxColumn";
            this.職銜DataGridViewTextBoxColumn.ReadOnly = true;
            this.職銜DataGridViewTextBoxColumn.Width = 80;
            // 
            // 總編推薦文DataGridViewTextBoxColumn
            // 
            this.總編推薦文DataGridViewTextBoxColumn.DataPropertyName = "總編推薦文";
            this.總編推薦文DataGridViewTextBoxColumn.HeaderText = "總編推薦文";
            this.總編推薦文DataGridViewTextBoxColumn.Name = "總編推薦文DataGridViewTextBoxColumn";
            this.總編推薦文DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 推薦職人店別DataGridViewTextBoxColumn
            // 
            this.推薦職人店別DataGridViewTextBoxColumn.DataPropertyName = "推薦職人店別";
            this.推薦職人店別DataGridViewTextBoxColumn.HeaderText = "推薦職人店別";
            this.推薦職人店別DataGridViewTextBoxColumn.Name = "推薦職人店別DataGridViewTextBoxColumn";
            this.推薦職人店別DataGridViewTextBoxColumn.ReadOnly = true;
            this.推薦職人店別DataGridViewTextBoxColumn.Width = 200;
            // 
            // 職人姓名DataGridViewTextBoxColumn
            // 
            this.職人姓名DataGridViewTextBoxColumn.DataPropertyName = "職人姓名";
            this.職人姓名DataGridViewTextBoxColumn.HeaderText = "職人姓名";
            this.職人姓名DataGridViewTextBoxColumn.Name = "職人姓名DataGridViewTextBoxColumn";
            this.職人姓名DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 職人推薦文DataGridViewTextBoxColumn
            // 
            this.職人推薦文DataGridViewTextBoxColumn.DataPropertyName = "職人推薦文";
            this.職人推薦文DataGridViewTextBoxColumn.HeaderText = "職人推薦文";
            this.職人推薦文DataGridViewTextBoxColumn.Name = "職人推薦文DataGridViewTextBoxColumn";
            this.職人推薦文DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // 推薦作者DataGridViewTextBoxColumn
            // 
            this.推薦作者DataGridViewTextBoxColumn.DataPropertyName = "推薦作者";
            this.推薦作者DataGridViewTextBoxColumn.HeaderText = "推薦作者";
            this.推薦作者DataGridViewTextBoxColumn.Name = "推薦作者DataGridViewTextBoxColumn";
            this.推薦作者DataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // tagDataGridViewTextBoxColumn
            // 
            this.tagDataGridViewTextBoxColumn.DataPropertyName = "Tag";
            this.tagDataGridViewTextBoxColumn.HeaderText = "Tag";
            this.tagDataGridViewTextBoxColumn.Name = "tagDataGridViewTextBoxColumn";
            this.tagDataGridViewTextBoxColumn.ReadOnly = true;
            this.tagDataGridViewTextBoxColumn.Width = 50;
            // 
            // 書落DataGridViewTextBoxColumn
            // 
            this.書落DataGridViewTextBoxColumn.DataPropertyName = "書落";
            this.書落DataGridViewTextBoxColumn.HeaderText = "書落";
            this.書落DataGridViewTextBoxColumn.Name = "書落DataGridViewTextBoxColumn";
            this.書落DataGridViewTextBoxColumn.ReadOnly = true;
            this.書落DataGridViewTextBoxColumn.Width = 60;
            // 
            // bsBOOKLIST
            // 
            this.bsBOOKLIST.DataSource = typeof(ESLBooksAwardMig2017.BOOKLIST);
            // 
            // btnCheck
            // 
            this.btnCheck.Location = new System.Drawing.Point(172, 80);
            this.btnCheck.Name = "btnCheck";
            this.btnCheck.Size = new System.Drawing.Size(180, 23);
            this.btnCheck.TabIndex = 5;
            this.btnCheck.Text = "檢查「屬性」與推薦欄位";
            this.btnCheck.UseVisualStyleBackColor = true;
            this.btnCheck.Click += new System.EventHandler(this.btnCheck_Click);
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(358, 80);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(75, 23);
            this.btnClear.TabIndex = 6;
            this.btnClear.Text = "清除";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // StepAControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnCheck);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.txtBookListFilepath);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StepAControl";
            this.Size = new System.Drawing.Size(828, 486);
            this.Load += new System.EventHandler(this.StepAControl_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bsBOOKLIST)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtBookListFilepath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.BindingSource bsBOOKLIST;
        private System.Windows.Forms.DataGridViewTextBoxColumn 項次DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 大分類DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 中分類DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 獨立編號DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 圖檔名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn productGuidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 順序DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 屬性DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 推薦書籍DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iSBNDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mCHDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 分類DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出版日期DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 出版社DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 推薦單位DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 推薦總編DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 職銜DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 總編推薦文DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 推薦職人店別DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 職人姓名DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 職人推薦文DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 推薦作者DataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn tagDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn 書落DataGridViewTextBoxColumn;
        private System.Windows.Forms.Button btnCheck;
        private System.Windows.Forms.Button btnClear;
    }
}
