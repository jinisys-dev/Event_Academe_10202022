namespace Jinisys.Hotel.Services.Presentation
{
    partial class HouseKeepingLogUI
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HouseKeepingLogUI));
            this.mnuContext = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuAddRemarks = new System.Windows.Forms.ToolStripMenuItem();
            this.viewUpdateRemarksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrLog = new System.Windows.Forms.Timer(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.hkGrid = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.mnuContext.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hkGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // mnuContext
            // 
            this.mnuContext.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddRemarks,
            this.viewUpdateRemarksToolStripMenuItem});
            this.mnuContext.Name = "mnuStatus";
            this.mnuContext.Size = new System.Drawing.Size(197, 48);
            this.mnuContext.Opening += new System.ComponentModel.CancelEventHandler(this.mnuContext_Opening);
            // 
            // mnuAddRemarks
            // 
            this.mnuAddRemarks.Name = "mnuAddRemarks";
            this.mnuAddRemarks.Size = new System.Drawing.Size(196, 22);
            this.mnuAddRemarks.Text = "Add Remarks";
            this.mnuAddRemarks.Click += new System.EventHandler(this.mnuAddRemarks_Click);
            // 
            // viewUpdateRemarksToolStripMenuItem
            // 
            this.viewUpdateRemarksToolStripMenuItem.Name = "viewUpdateRemarksToolStripMenuItem";
            this.viewUpdateRemarksToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.viewUpdateRemarksToolStripMenuItem.Text = "View / Update Remarks";
            this.viewUpdateRemarksToolStripMenuItem.Click += new System.EventHandler(this.viewUpdateRemarksToolStripMenuItem_Click);
            // 
            // tmrLog
            // 
            this.tmrLog.Interval = 30000;
            this.tmrLog.Tick += new System.EventHandler(this.tmrLog_Tick);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnVerify);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpDate);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(829, 97);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(180, 22);
            this.label1.TabIndex = 12;
            this.label1.Text = "Housekeeping Logs";
            // 
            // btnVerify
            // 
            this.btnVerify.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnVerify.Enabled = false;
            this.btnVerify.Location = new System.Drawing.Point(668, 53);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(66, 31);
            this.btnVerify.TabIndex = 11;
            this.btnVerify.Text = "&Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // btnClose
            // 
            this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnClose.Location = new System.Drawing.Point(740, 53);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 10;
            this.btnClose.Text = "&Close";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Cursor = System.Windows.Forms.Cursors.Default;
            this.btnRefresh.Location = new System.Drawing.Point(596, 53);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(66, 31);
            this.btnRefresh.TabIndex = 4;
            this.btnRefresh.Text = "Re&fresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8F);
            this.label2.Location = new System.Drawing.Point(18, 64);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(32, 14);
            this.label2.TabIndex = 3;
            this.label2.Text = "Date:";
            // 
            // dtpDate
            // 
            this.dtpDate.CustomFormat = "dd-MMM-yyyy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(56, 61);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(113, 20);
            this.dtpDate.TabIndex = 2;
            this.dtpDate.ValueChanged += new System.EventHandler(this.dtpDate_ValueChanged);
            // 
            // hkGrid
            // 
            this.hkGrid.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.hkGrid.AllowEditing = false;
            this.hkGrid.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.hkGrid.ColumnInfo = resources.GetString("hkGrid.ColumnInfo");
            this.hkGrid.ContextMenuStrip = this.mnuContext;
            this.hkGrid.ExtendLastCol = true;
            this.hkGrid.Location = new System.Drawing.Point(12, 116);
            this.hkGrid.Name = "hkGrid";
            this.hkGrid.Rows.DefaultSize = 17;
            this.hkGrid.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
            this.hkGrid.Size = new System.Drawing.Size(829, 407);
            this.hkGrid.StyleInfo = resources.GetString("hkGrid.StyleInfo");
            this.hkGrid.TabIndex = 2;
            this.hkGrid.RowColChange += new System.EventHandler(this.hkGrid_RowColChange);
            // 
            // HouseKeepingLogUI
            // 
            this.AcceptButton = this.btnRefresh;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(856, 535);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.hkGrid);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.Name = "HouseKeepingLogUI";
            this.Text = "Housekeeping Logs";
            this.Activated += new System.EventHandler(this.HouseKeepingLogUI_Activated);
            this.Load += new System.EventHandler(this.HouseKeepingLogUI_Load);
            this.mnuContext.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.hkGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip mnuContext;
        private System.Windows.Forms.ToolStripMenuItem mnuAddRemarks;
		private System.Windows.Forms.Timer tmrLog;
        private System.Windows.Forms.GroupBox groupBox1;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.ToolStripMenuItem viewUpdateRemarksToolStripMenuItem;
		private System.Windows.Forms.Label label1;
		private C1.Win.C1FlexGrid.C1FlexGrid hkGrid;
    }
}