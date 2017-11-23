namespace ESLBooksAwardMig2017.UserControls
{
    partial class StepBControl
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtBookPhotoFolder = new System.Windows.Forms.TextBox();
            this.txtTargetBaseFolder = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.chkTrial = new System.Windows.Forms.CheckBox();
            this.numTrialCount = new System.Windows.Forms.NumericUpDown();
            this.btnTransImg = new System.Windows.Forms.Button();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            this.lblStepMsg = new System.Windows.Forms.Label();
            this.btnTransImgPrecheck = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numTrialCount)).BeginInit();
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
            this.label1.Size = new System.Drawing.Size(776, 30);
            this.label1.TabIndex = 1;
            this.label1.Text = "複製與轉換圖檔";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(77, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "書單照片目錄";
            // 
            // txtBookPhotoFolder
            // 
            this.txtBookPhotoFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBookPhotoFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ESLBooksAwardMig2017.Properties.Settings.Default, "BookPhotoFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtBookPhotoFolder.Location = new System.Drawing.Point(100, 48);
            this.txtBookPhotoFolder.Name = "txtBookPhotoFolder";
            this.txtBookPhotoFolder.Size = new System.Drawing.Size(661, 22);
            this.txtBookPhotoFolder.TabIndex = 4;
            this.txtBookPhotoFolder.Text = global::ESLBooksAwardMig2017.Properties.Settings.Default.BookPhotoFolder;
            this.txtBookPhotoFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtBookPhotoFolder_MouseDoubleClick);
            // 
            // txtTargetBaseFolder
            // 
            this.txtTargetBaseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetBaseFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ESLBooksAwardMig2017.Properties.Settings.Default, "TargetBaseFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTargetBaseFolder.Location = new System.Drawing.Point(100, 76);
            this.txtTargetBaseFolder.Name = "txtTargetBaseFolder";
            this.txtTargetBaseFolder.Size = new System.Drawing.Size(661, 22);
            this.txtTargetBaseFolder.TabIndex = 6;
            this.txtTargetBaseFolder.Text = global::ESLBooksAwardMig2017.Properties.Settings.Default.TargetBaseFolder;
            this.txtTargetBaseFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtTargetBaseFolder_MouseDoubleClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 7;
            this.label3.Text = "目標目錄";
            // 
            // chkTrial
            // 
            this.chkTrial.AutoSize = true;
            this.chkTrial.Checked = true;
            this.chkTrial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrial.Location = new System.Drawing.Point(22, 105);
            this.chkTrial.Name = "chkTrial";
            this.chkTrial.Size = new System.Drawing.Size(72, 16);
            this.chkTrial.TabIndex = 8;
            this.chkTrial.Text = "試轉筆數";
            this.chkTrial.UseVisualStyleBackColor = true;
            // 
            // numTrialCount
            // 
            this.numTrialCount.Location = new System.Drawing.Point(100, 104);
            this.numTrialCount.Name = "numTrialCount";
            this.numTrialCount.Size = new System.Drawing.Size(75, 22);
            this.numTrialCount.TabIndex = 10;
            this.numTrialCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // btnTransImg
            // 
            this.btnTransImg.Location = new System.Drawing.Point(248, 132);
            this.btnTransImg.Name = "btnTransImg";
            this.btnTransImg.Size = new System.Drawing.Size(167, 23);
            this.btnTransImg.TabIndex = 11;
            this.btnTransImg.Text = "轉圖 01 02 03 books && c";
            this.btnTransImg.UseVisualStyleBackColor = true;
            this.btnTransImg.Click += new System.EventHandler(this.btnTransImg_Click);
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.Location = new System.Drawing.Point(100, 215);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(477, 23);
            this.prgBar.Step = 1;
            this.prgBar.TabIndex = 12;
            // 
            // lblStepMsg
            // 
            this.lblStepMsg.AutoSize = true;
            this.lblStepMsg.Location = new System.Drawing.Point(100, 197);
            this.lblStepMsg.Name = "lblStepMsg";
            this.lblStepMsg.Size = new System.Drawing.Size(57, 12);
            this.lblStepMsg.TabIndex = 14;
            this.lblStepMsg.Text = "lblStepMsg";
            // 
            // btnTransImgPrecheck
            // 
            this.btnTransImgPrecheck.Location = new System.Drawing.Point(100, 132);
            this.btnTransImgPrecheck.Name = "btnTransImgPrecheck";
            this.btnTransImgPrecheck.Size = new System.Drawing.Size(142, 23);
            this.btnTransImgPrecheck.TabIndex = 15;
            this.btnTransImgPrecheck.Text = "檢查圖檔來源不存在";
            this.btnTransImgPrecheck.UseVisualStyleBackColor = true;
            this.btnTransImgPrecheck.Click += new System.EventHandler(this.btnTransImgPrecheck_Click);
            // 
            // StepBControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTransImgPrecheck);
            this.Controls.Add(this.lblStepMsg);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.btnTransImg);
            this.Controls.Add(this.numTrialCount);
            this.Controls.Add(this.chkTrial);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTargetBaseFolder);
            this.Controls.Add(this.txtBookPhotoFolder);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "StepBControl";
            this.Size = new System.Drawing.Size(776, 485);
            ((System.ComponentModel.ISupportInitialize)(this.numTrialCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBookPhotoFolder;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtTargetBaseFolder;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox chkTrial;
        private System.Windows.Forms.NumericUpDown numTrialCount;
        private System.Windows.Forms.Button btnTransImg;
        private System.Windows.Forms.ProgressBar prgBar;
        private System.Windows.Forms.Label lblStepMsg;
        private System.Windows.Forms.Button btnTransImgPrecheck;
    }
}
