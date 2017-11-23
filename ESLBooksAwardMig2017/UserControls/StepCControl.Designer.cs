namespace ESLBooksAwardMig2017.UserControls
{
    partial class StepCControl
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
            this.label2 = new System.Windows.Forms.Label();
            this.btnTransHtml = new System.Windows.Forms.Button();
            this.numTrialCount = new System.Windows.Forms.NumericUpDown();
            this.chkTrial = new System.Windows.Forms.CheckBox();
            this.btnTransJson = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTargetBaseFolder = new System.Windows.Forms.TextBox();
            this.lblStepMsg = new System.Windows.Forms.Label();
            this.prgBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.numTrialCount)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.label2.Font = new System.Drawing.Font("微軟正黑體", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.label2.ForeColor = System.Drawing.SystemColors.MenuHighlight;
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(610, 30);
            this.label2.TabIndex = 2;
            this.label2.Text = "產生 left.html, right.html ＆ json";
            // 
            // btnTransHtml
            // 
            this.btnTransHtml.Location = new System.Drawing.Point(88, 109);
            this.btnTransHtml.Name = "btnTransHtml";
            this.btnTransHtml.Size = new System.Drawing.Size(133, 23);
            this.btnTransHtml.TabIndex = 14;
            this.btnTransHtml.Text = "轉 left.html right.html";
            this.btnTransHtml.UseVisualStyleBackColor = true;
            this.btnTransHtml.Click += new System.EventHandler(this.btnTransHtml_Click);
            // 
            // numTrialCount
            // 
            this.numTrialCount.Location = new System.Drawing.Point(88, 81);
            this.numTrialCount.Name = "numTrialCount";
            this.numTrialCount.Size = new System.Drawing.Size(75, 22);
            this.numTrialCount.TabIndex = 13;
            this.numTrialCount.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // chkTrial
            // 
            this.chkTrial.AutoSize = true;
            this.chkTrial.Checked = true;
            this.chkTrial.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrial.Location = new System.Drawing.Point(10, 82);
            this.chkTrial.Name = "chkTrial";
            this.chkTrial.Size = new System.Drawing.Size(72, 16);
            this.chkTrial.TabIndex = 12;
            this.chkTrial.Text = "試轉筆數";
            this.chkTrial.UseVisualStyleBackColor = true;
            // 
            // btnTransJson
            // 
            this.btnTransJson.Location = new System.Drawing.Point(278, 109);
            this.btnTransJson.Name = "btnTransJson";
            this.btnTransJson.Size = new System.Drawing.Size(133, 23);
            this.btnTransJson.TabIndex = 15;
            this.btnTransJson.Text = "轉 json";
            this.btnTransJson.UseVisualStyleBackColor = true;
            this.btnTransJson.Click += new System.EventHandler(this.btnTransJson_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 56);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 12);
            this.label3.TabIndex = 17;
            this.label3.Text = "目標目錄";
            // 
            // txtTargetBaseFolder
            // 
            this.txtTargetBaseFolder.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTargetBaseFolder.DataBindings.Add(new System.Windows.Forms.Binding("Text", global::ESLBooksAwardMig2017.Properties.Settings.Default, "TargetBaseFolder", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.txtTargetBaseFolder.Location = new System.Drawing.Point(86, 53);
            this.txtTargetBaseFolder.Name = "txtTargetBaseFolder";
            this.txtTargetBaseFolder.Size = new System.Drawing.Size(512, 22);
            this.txtTargetBaseFolder.TabIndex = 16;
            this.txtTargetBaseFolder.Text = global::ESLBooksAwardMig2017.Properties.Settings.Default.TargetBaseFolder;
            this.txtTargetBaseFolder.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.txtTargetBaseFolder_MouseDoubleClick);
            // 
            // lblStepMsg
            // 
            this.lblStepMsg.AutoSize = true;
            this.lblStepMsg.Location = new System.Drawing.Point(86, 171);
            this.lblStepMsg.Name = "lblStepMsg";
            this.lblStepMsg.Size = new System.Drawing.Size(57, 12);
            this.lblStepMsg.TabIndex = 19;
            this.lblStepMsg.Text = "lblStepMsg";
            // 
            // prgBar
            // 
            this.prgBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prgBar.Location = new System.Drawing.Point(86, 189);
            this.prgBar.Name = "prgBar";
            this.prgBar.Size = new System.Drawing.Size(454, 23);
            this.prgBar.Step = 1;
            this.prgBar.TabIndex = 18;
            // 
            // StepCControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.lblStepMsg);
            this.Controls.Add(this.prgBar);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtTargetBaseFolder);
            this.Controls.Add(this.btnTransJson);
            this.Controls.Add(this.btnTransHtml);
            this.Controls.Add(this.numTrialCount);
            this.Controls.Add(this.chkTrial);
            this.Controls.Add(this.label2);
            this.Name = "StepCControl";
            this.Size = new System.Drawing.Size(610, 316);
            ((System.ComponentModel.ISupportInitialize)(this.numTrialCount)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnTransHtml;
        private System.Windows.Forms.NumericUpDown numTrialCount;
        private System.Windows.Forms.CheckBox chkTrial;
        private System.Windows.Forms.Button btnTransJson;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtTargetBaseFolder;
        private System.Windows.Forms.Label lblStepMsg;
        private System.Windows.Forms.ProgressBar prgBar;
    }
}
