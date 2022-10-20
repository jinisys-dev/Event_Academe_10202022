namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class MemoUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MemoUI));
            this.tbnGenerate = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnReload = new System.Windows.Forms.Button();
            this.tblMemo = new System.Windows.Forms.TableLayoutPanel();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnRemoveRecipient = new System.Windows.Forms.Button();
            this.btnAddRecipient = new System.Windows.Forms.Button();
            this.lblMemoFor = new System.Windows.Forms.Label();
            this.grdMemoFor = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grdSystemChanges = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnRemoveChanges = new System.Windows.Forms.Button();
            this.btnAddChanges = new System.Windows.Forms.Button();
            this.lblChanges = new System.Windows.Forms.Label();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.txtControlNo = new System.Windows.Forms.TextBox();
            this.lblControlNo = new System.Windows.Forms.Label();
            this.lblTo = new System.Windows.Forms.Label();
            this.lblFrom = new System.Windows.Forms.Label();
            this.btnGo = new System.Windows.Forms.Button();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.tableLayoutPanel1.SuspendLayout();
            this.tblMemo.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemoFor)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemChanges)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpDetails.SuspendLayout();
            this.SuspendLayout();
            // 
            // tbnGenerate
            // 
            this.tbnGenerate.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tbnGenerate.Location = new System.Drawing.Point(561, 3);
            this.tbnGenerate.Name = "tbnGenerate";
            this.tbnGenerate.Size = new System.Drawing.Size(115, 42);
            this.tbnGenerate.TabIndex = 0;
            this.tbnGenerate.Text = "Generate";
            this.tbnGenerate.UseVisualStyleBackColor = true;
            this.tbnGenerate.Click += new System.EventHandler(this.tbnGenerate_Click);
            // 
            // btnClose
            // 
            this.btnClose.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnClose.Location = new System.Drawing.Point(682, 3);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 42);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 56.35359F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.19337F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15.46961F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.80732F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Controls.Add(this.tbnGenerate, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnClose, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnReload, 1, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 532);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(781, 48);
            this.tableLayoutPanel1.TabIndex = 2;
            // 
            // btnReload
            // 
            this.btnReload.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnReload.Location = new System.Drawing.Point(443, 3);
            this.btnReload.Name = "btnReload";
            this.btnReload.Size = new System.Drawing.Size(112, 42);
            this.btnReload.TabIndex = 2;
            this.btnReload.Text = "Reload";
            this.btnReload.UseVisualStyleBackColor = true;
            this.btnReload.Click += new System.EventHandler(this.btnReload_Click);
            // 
            // tblMemo
            // 
            this.tblMemo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tblMemo.ColumnCount = 3;
            this.tblMemo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.16931F));
            this.tblMemo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 3.439153F));
            this.tblMemo.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 59.39154F));
            this.tblMemo.Controls.Add(this.groupBox2, 0, 0);
            this.tblMemo.Controls.Add(this.grdMemoFor, 0, 1);
            this.tblMemo.Controls.Add(this.grdSystemChanges, 2, 1);
            this.tblMemo.Controls.Add(this.groupBox1, 2, 0);
            this.tblMemo.Location = new System.Drawing.Point(9, 75);
            this.tblMemo.Name = "tblMemo";
            this.tblMemo.RowCount = 2;
            this.tblMemo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 40F));
            this.tblMemo.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 384F));
            this.tblMemo.Size = new System.Drawing.Size(757, 444);
            this.tblMemo.TabIndex = 3;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnRemoveRecipient);
            this.groupBox2.Controls.Add(this.btnAddRecipient);
            this.groupBox2.Controls.Add(this.lblMemoFor);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(275, 34);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            // 
            // btnRemoveRecipient
            // 
            this.btnRemoveRecipient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveRecipient.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveRecipient.Image")));
            this.btnRemoveRecipient.Location = new System.Drawing.Point(245, 12);
            this.btnRemoveRecipient.Name = "btnRemoveRecipient";
            this.btnRemoveRecipient.Size = new System.Drawing.Size(21, 21);
            this.btnRemoveRecipient.TabIndex = 16;
            this.btnRemoveRecipient.UseVisualStyleBackColor = true;
            this.btnRemoveRecipient.Click += new System.EventHandler(this.btnRemoveRecipient_Click);
            // 
            // btnAddRecipient
            // 
            this.btnAddRecipient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddRecipient.Image = ((System.Drawing.Image)(resources.GetObject("btnAddRecipient.Image")));
            this.btnAddRecipient.Location = new System.Drawing.Point(219, 12);
            this.btnAddRecipient.Name = "btnAddRecipient";
            this.btnAddRecipient.Size = new System.Drawing.Size(21, 21);
            this.btnAddRecipient.TabIndex = 15;
            this.btnAddRecipient.UseVisualStyleBackColor = true;
            this.btnAddRecipient.Click += new System.EventHandler(this.btnAddRecipient_Click);
            // 
            // lblMemoFor
            // 
            this.lblMemoFor.AutoSize = true;
            this.lblMemoFor.Location = new System.Drawing.Point(6, 13);
            this.lblMemoFor.Name = "lblMemoFor";
            this.lblMemoFor.Size = new System.Drawing.Size(93, 13);
            this.lblMemoFor.TabIndex = 2;
            this.lblMemoFor.Text = "Included in memo:";
            // 
            // grdMemoFor
            // 
            this.grdMemoFor.AllowAddNew = true;
            this.grdMemoFor.AllowDelete = true;
            this.grdMemoFor.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:64;Caption:\"Tran. Code\";Visible:False;DataType:Syste" +
                "m.String;TextAlign:LeftCenter;}\t1{Width:192;DataType:System.String;TextAlign:Lef" +
                "tCenter;}\t";
            this.grdMemoFor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdMemoFor.ExtendLastCol = true;
            this.grdMemoFor.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdMemoFor.Location = new System.Drawing.Point(3, 43);
            this.grdMemoFor.Name = "grdMemoFor";
            this.grdMemoFor.Rows.Count = 1;
            this.grdMemoFor.Rows.DefaultSize = 17;
            this.grdMemoFor.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdMemoFor.Size = new System.Drawing.Size(275, 398);
            this.grdMemoFor.StyleInfo = resources.GetString("grdMemoFor.StyleInfo");
            this.grdMemoFor.TabIndex = 180;
            // 
            // grdSystemChanges
            // 
            this.grdSystemChanges.AllowEditing = false;
            this.grdSystemChanges.AllowMerging = C1.Win.C1FlexGrid.AllowMergingEnum.RestrictCols;
            this.grdSystemChanges.AutoGenerateColumns = false;
            this.grdSystemChanges.BackColor = System.Drawing.Color.WhiteSmoke;
            this.grdSystemChanges.ColumnInfo = resources.GetString("grdSystemChanges.ColumnInfo");
            this.grdSystemChanges.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grdSystemChanges.ExtendLastCol = true;
            this.grdSystemChanges.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
            this.grdSystemChanges.Location = new System.Drawing.Point(310, 43);
            this.grdSystemChanges.Name = "grdSystemChanges";
            this.grdSystemChanges.Rows.Count = 1;
            this.grdSystemChanges.Rows.DefaultSize = 17;
            this.grdSystemChanges.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange;
            this.grdSystemChanges.Size = new System.Drawing.Size(444, 398);
            this.grdSystemChanges.StyleInfo = resources.GetString("grdSystemChanges.StyleInfo");
            this.grdSystemChanges.TabIndex = 181;
            this.grdSystemChanges.Click += new System.EventHandler(this.grdSystemChanges_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnRemoveChanges);
            this.groupBox1.Controls.Add(this.btnAddChanges);
            this.groupBox1.Controls.Add(this.lblChanges);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(310, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(444, 34);
            this.groupBox1.TabIndex = 182;
            this.groupBox1.TabStop = false;
            // 
            // btnRemoveChanges
            // 
            this.btnRemoveChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveChanges.Image = ((System.Drawing.Image)(resources.GetObject("btnRemoveChanges.Image")));
            this.btnRemoveChanges.Location = new System.Drawing.Point(416, 10);
            this.btnRemoveChanges.Name = "btnRemoveChanges";
            this.btnRemoveChanges.Size = new System.Drawing.Size(21, 21);
            this.btnRemoveChanges.TabIndex = 18;
            this.btnRemoveChanges.UseVisualStyleBackColor = true;
            this.btnRemoveChanges.Click += new System.EventHandler(this.btnRemoveChanges_Click);
            // 
            // btnAddChanges
            // 
            this.btnAddChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddChanges.Image = ((System.Drawing.Image)(resources.GetObject("btnAddChanges.Image")));
            this.btnAddChanges.Location = new System.Drawing.Point(390, 10);
            this.btnAddChanges.Name = "btnAddChanges";
            this.btnAddChanges.Size = new System.Drawing.Size(21, 21);
            this.btnAddChanges.TabIndex = 17;
            this.btnAddChanges.UseVisualStyleBackColor = true;
            this.btnAddChanges.Visible = false;
            this.btnAddChanges.Click += new System.EventHandler(this.btnAddChanges_Click);
            // 
            // lblChanges
            // 
            this.lblChanges.AutoSize = true;
            this.lblChanges.Location = new System.Drawing.Point(6, 13);
            this.lblChanges.Name = "lblChanges";
            this.lblChanges.Size = new System.Drawing.Size(52, 13);
            this.lblChanges.TabIndex = 3;
            this.lblChanges.Text = "Changes:";
            // 
            // grpDetails
            // 
            this.grpDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.grpDetails.Controls.Add(this.txtControlNo);
            this.grpDetails.Controls.Add(this.lblControlNo);
            this.grpDetails.Controls.Add(this.lblTo);
            this.grpDetails.Controls.Add(this.lblFrom);
            this.grpDetails.Controls.Add(this.btnGo);
            this.grpDetails.Controls.Add(this.dtpTo);
            this.grpDetails.Controls.Add(this.dtpFrom);
            this.grpDetails.Controls.Add(this.tblMemo);
            this.grpDetails.Location = new System.Drawing.Point(3, 1);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(775, 525);
            this.grpDetails.TabIndex = 4;
            this.grpDetails.TabStop = false;
            // 
            // txtControlNo
            // 
            this.txtControlNo.BackColor = System.Drawing.SystemColors.Control;
            this.txtControlNo.Location = new System.Drawing.Point(87, 14);
            this.txtControlNo.Name = "txtControlNo";
            this.txtControlNo.ReadOnly = true;
            this.txtControlNo.Size = new System.Drawing.Size(148, 20);
            this.txtControlNo.TabIndex = 9;
            // 
            // lblControlNo
            // 
            this.lblControlNo.AutoSize = true;
            this.lblControlNo.Location = new System.Drawing.Point(18, 18);
            this.lblControlNo.Name = "lblControlNo";
            this.lblControlNo.Size = new System.Drawing.Size(63, 13);
            this.lblControlNo.TabIndex = 8;
            this.lblControlNo.Text = "Control No :";
            // 
            // lblTo
            // 
            this.lblTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTo.AutoSize = true;
            this.lblTo.Location = new System.Drawing.Point(467, 41);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(20, 13);
            this.lblTo.TabIndex = 7;
            this.lblTo.Text = "To";
            // 
            // lblFrom
            // 
            this.lblFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblFrom.AutoSize = true;
            this.lblFrom.Location = new System.Drawing.Point(465, 17);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(30, 13);
            this.lblFrom.TabIndex = 7;
            this.lblFrom.Text = "From";
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.Location = new System.Drawing.Point(720, 11);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(43, 49);
            this.btnGo.TabIndex = 6;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // dtpTo
            // 
            this.dtpTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpTo.Location = new System.Drawing.Point(514, 37);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(200, 20);
            this.dtpTo.TabIndex = 5;
            // 
            // dtpFrom
            // 
            this.dtpFrom.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.dtpFrom.Location = new System.Drawing.Point(514, 11);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(200, 20);
            this.dtpFrom.TabIndex = 4;
            // 
            // MemoUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(781, 580);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "MemoUI";
            this.Text = "Memo";
            this.Load += new System.EventHandler(this.MemoUI_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tblMemo.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdMemoFor)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdSystemChanges)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button tbnGenerate;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tblMemo;
        private System.Windows.Forms.GroupBox grpDetails;
        private System.Windows.Forms.DateTimePicker dtpTo;
        private System.Windows.Forms.DateTimePicker dtpFrom;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblTo;
        private System.Windows.Forms.Label lblFrom;
        private System.Windows.Forms.Label lblControlNo;
        private System.Windows.Forms.TextBox txtControlNo;
        private System.Windows.Forms.Label lblMemoFor;
        private System.Windows.Forms.Label lblChanges;
        private C1.Win.C1FlexGrid.C1FlexGrid grdMemoFor;
        private C1.Win.C1FlexGrid.C1FlexGrid grdSystemChanges;
        private System.Windows.Forms.Button btnReload;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveRecipient;
        private System.Windows.Forms.Button btnAddRecipient;
        private System.Windows.Forms.Button btnRemoveChanges;
        private System.Windows.Forms.Button btnAddChanges;
    }
}