namespace Jinisys.Hotel.Reports.Presentation
{
    partial class NumberOfEventsAndRevenue
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NumberOfEventsAndRevenue));
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grdRevenue = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.chkIncludeHeader = new System.Windows.Forms.CheckBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.pnlPrint = new System.Windows.Forms.Panel();
            this.cboPrintType = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.txtFooter = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtHeader = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExport = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnRecompute = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.grdRevenue)).BeginInit();
            this.pnlPrint.SuspendLayout();
            this.SuspendLayout();
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(106, 65);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.ShowUpDown = true;
            this.dtpEndDate.Size = new System.Drawing.Size(94, 20);
            this.dtpEndDate.TabIndex = 8;
            this.dtpEndDate.Value = new System.DateTime(2001, 9, 1, 0, 0, 0, 0);
            this.dtpEndDate.ValueChanged += new System.EventHandler(this.dtpEndDate_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(33, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 14);
            this.label3.TabIndex = 10;
            this.label3.Text = "Select Year :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(28, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(374, 29);
            this.label1.TabIndex = 9;
            this.label1.Text = "Number of Events and Revenue";
            // 
            // grdRevenue
            // 
            this.grdRevenue.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None;
            this.grdRevenue.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.Spill;
            this.grdRevenue.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None;
            this.grdRevenue.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grdRevenue.BackColor = System.Drawing.Color.White;
            this.grdRevenue.ColumnInfo = resources.GetString("grdRevenue.ColumnInfo");
            this.grdRevenue.ExtendLastCol = true;
            this.grdRevenue.Location = new System.Drawing.Point(28, 112);
            this.grdRevenue.Name = "grdRevenue";
            this.grdRevenue.Rows.Count = 2;
            this.grdRevenue.Rows.DefaultSize = 17;
            this.grdRevenue.Rows.Fixed = 2;
            this.grdRevenue.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdRevenue.Size = new System.Drawing.Size(754, 357);
            this.grdRevenue.StyleInfo = resources.GetString("grdRevenue.StyleInfo");
            this.grdRevenue.TabIndex = 11;
            this.grdRevenue.EnterCell += new System.EventHandler(this.grdRevenue_EnterCell);
            this.grdRevenue.AfterEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdRevenue_AfterEdit);
            // 
            // chkIncludeHeader
            // 
            this.chkIncludeHeader.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.chkIncludeHeader.AutoSize = true;
            this.chkIncludeHeader.Location = new System.Drawing.Point(330, 68);
            this.chkIncludeHeader.Name = "chkIncludeHeader";
            this.chkIncludeHeader.Size = new System.Drawing.Size(99, 17);
            this.chkIncludeHeader.TabIndex = 13;
            this.chkIncludeHeader.Text = "Include Header";
            this.chkIncludeHeader.UseVisualStyleBackColor = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnPrint.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnPrint.Location = new System.Drawing.Point(509, 55);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(65, 38);
            this.btnPrint.TabIndex = 14;
            this.btnPrint.Text = "&Print";
            this.btnPrint.UseVisualStyleBackColor = false;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // pnlPrint
            // 
            this.pnlPrint.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlPrint.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlPrint.Controls.Add(this.cboPrintType);
            this.pnlPrint.Controls.Add(this.label5);
            this.pnlPrint.Controls.Add(this.btnCancel);
            this.pnlPrint.Controls.Add(this.btnOK);
            this.pnlPrint.Controls.Add(this.txtFooter);
            this.pnlPrint.Controls.Add(this.label4);
            this.pnlPrint.Controls.Add(this.txtHeader);
            this.pnlPrint.Controls.Add(this.label2);
            this.pnlPrint.Location = new System.Drawing.Point(234, 167);
            this.pnlPrint.Name = "pnlPrint";
            this.pnlPrint.Size = new System.Drawing.Size(397, 302);
            this.pnlPrint.TabIndex = 15;
            this.pnlPrint.Visible = false;
            this.pnlPrint.VisibleChanged += new System.EventHandler(this.pnlPrint_VisibleChanged);
            // 
            // cboPrintType
            // 
            this.cboPrintType.FormattingEnabled = true;
            this.cboPrintType.Items.AddRange(new object[] {
            "Actual Size",
            "Extend Last Column",
            "Fit to Page",
            "Fit to Page Width",
            "Show Highlight",
            "Show Page Setup Dialog",
            "Show Page Preview Dialog",
            "Show Print Dialog"});
            this.cboPrintType.Location = new System.Drawing.Point(105, 17);
            this.cboPrintType.Name = "cboPrintType";
            this.cboPrintType.Size = new System.Drawing.Size(147, 21);
            this.cboPrintType.TabIndex = 26;
            this.cboPrintType.Text = "Fit to Page";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(16, 21);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 14);
            this.label5.TabIndex = 25;
            this.label5.Text = "Type of Printing :";
            // 
            // btnCancel
            // 
            this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCancel.Location = new System.Drawing.Point(220, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 28);
            this.btnCancel.TabIndex = 24;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnOK.Location = new System.Drawing.Point(301, 256);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 23;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // txtFooter
            // 
            this.txtFooter.Location = new System.Drawing.Point(55, 175);
            this.txtFooter.Multiline = true;
            this.txtFooter.Name = "txtFooter";
            this.txtFooter.Size = new System.Drawing.Size(323, 68);
            this.txtFooter.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(16, 151);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(165, 14);
            this.label4.TabIndex = 21;
            this.label4.Text = "Type Footer to display in Report :";
            // 
            // txtHeader
            // 
            this.txtHeader.Location = new System.Drawing.Point(55, 72);
            this.txtHeader.Multiline = true;
            this.txtHeader.Name = "txtHeader";
            this.txtHeader.Size = new System.Drawing.Size(323, 68);
            this.txtHeader.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 51);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(169, 14);
            this.label2.TabIndex = 19;
            this.label2.Text = "Type Header to display in Report :";
            // 
            // btnExport
            // 
            this.btnExport.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnExport.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnExport.Location = new System.Drawing.Point(439, 55);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(65, 38);
            this.btnExport.TabIndex = 12;
            this.btnExport.Text = "&Export to Excel";
            this.btnExport.UseVisualStyleBackColor = false;
            this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
            // 
            // btnClose
            // 
            this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClose.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnClose.Location = new System.Drawing.Point(717, 56);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(65, 38);
            this.btnClose.TabIndex = 16;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = false;
            this.btnClose.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRefresh.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRefresh.Location = new System.Drawing.Point(647, 55);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(65, 38);
            this.btnRefresh.TabIndex = 17;
            this.btnRefresh.Text = "&Refresh";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnRecompute
            // 
            this.btnRecompute.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRecompute.BackColor = System.Drawing.Color.WhiteSmoke;
            this.btnRecompute.Location = new System.Drawing.Point(578, 55);
            this.btnRecompute.Name = "btnRecompute";
            this.btnRecompute.Size = new System.Drawing.Size(65, 38);
            this.btnRecompute.TabIndex = 18;
            this.btnRecompute.Text = "Re C&ompute";
            this.btnRecompute.UseVisualStyleBackColor = false;
            this.btnRecompute.Click += new System.EventHandler(this.btnRecompute_Click);
            // 
            // NumberOfEventsAndRevenue
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(806, 487);
            this.Controls.Add(this.btnRecompute);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.pnlPrint);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.chkIncludeHeader);
            this.Controls.Add(this.btnExport);
            this.Controls.Add(this.grdRevenue);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Name = "NumberOfEventsAndRevenue";
            this.Text = "No. of Events & Revenue";
            this.Load += new System.EventHandler(this.NumberOfEventsAndRevenue_Load);
            this.Activated += new System.EventHandler(this.NumberOfEventsAndRevenue_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.grdRevenue)).EndInit();
            this.pnlPrint.ResumeLayout(false);
            this.pnlPrint.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private C1.Win.C1FlexGrid.C1FlexGrid grdRevenue;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.CheckBox chkIncludeHeader;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Panel pnlPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnRecompute;
        private System.Windows.Forms.ComboBox cboPrintType;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.TextBox txtFooter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtHeader;
        private System.Windows.Forms.Label label2;
    }
}