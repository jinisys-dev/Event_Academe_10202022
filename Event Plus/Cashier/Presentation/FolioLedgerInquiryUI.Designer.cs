namespace Jinisys.Hotel.Cashier.Presentation
{
    partial class FolioLedgerInquiryUI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FolioLedgerInquiryUI));
            this.grdInquiry = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnViewFolioTrans = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.y = new System.Windows.Forms.Label();
            this.txtAccount = new System.Windows.Forms.TextBox();
            this.imgIcon = new System.Windows.Forms.ImageList(this.components);
            this.btnBrowseCust = new System.Windows.Forms.Button();
            this.tabFolioInquiry = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.lvwBrowseGuestName = new System.Windows.Forms.ListView();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.gridIndividualHistory = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.lvwBrowseGroupName = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.gridCompanyHistory = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.grdCompanyGuests = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.btnBrowseCompany = new System.Windows.Forms.Button();
            this.txtCompanyName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabFolio = new System.Windows.Forms.TabPage();
            this.grdFolioSearch = new C1.Win.C1FlexGrid.C1FlexGrid();
            this.label2 = new System.Windows.Forms.Label();
            this.txtFolioSearch = new System.Windows.Forms.TextBox();
            this.btnPrint = new System.Windows.Forms.Button();
            this.btnACR = new System.Windows.Forms.Button();
            this.pnlRemarks = new System.Windows.Forms.Panel();
            this.chkNoPayments = new System.Windows.Forms.CheckBox();
            this.btnRemarksCancel = new System.Windows.Forms.Button();
            this.btnRemarksOK = new System.Windows.Forms.Button();
            this.label116 = new System.Windows.Forms.Label();
            this.txtGroupRemarks = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdInquiry)).BeginInit();
            this.tabFolioInquiry.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndividualHistory)).BeginInit();
            this.tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanyHistory)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyGuests)).BeginInit();
            this.tabFolio.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioSearch)).BeginInit();
            this.pnlRemarks.SuspendLayout();
            this.SuspendLayout();
            // 
            // grdInquiry
            // 
            this.grdInquiry.ColumnInfo = resources.GetString("grdInquiry.ColumnInfo");
            this.grdInquiry.ExtendLastCol = true;
            this.grdInquiry.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grdInquiry.Location = new System.Drawing.Point(9, 57);
            this.grdInquiry.Name = "grdInquiry";
            this.grdInquiry.Rows.Count = 1;
            this.grdInquiry.Rows.DefaultSize = 17;
            this.grdInquiry.Size = new System.Drawing.Size(684, 371);
            this.grdInquiry.StyleInfo = resources.GetString("grdInquiry.StyleInfo");
            this.grdInquiry.TabIndex = 4;
            this.grdInquiry.DoubleClick += new System.EventHandler(this.grdInquiry_DoubleClick);
            // 
            // btnViewFolioTrans
            // 
            this.btnViewFolioTrans.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnViewFolioTrans.Location = new System.Drawing.Point(564, 493);
            this.btnViewFolioTrans.Name = "btnViewFolioTrans";
            this.btnViewFolioTrans.Size = new System.Drawing.Size(81, 31);
            this.btnViewFolioTrans.TabIndex = 5;
            this.btnViewFolioTrans.Text = "&View Details";
            this.btnViewFolioTrans.Click += new System.EventHandler(this.btnViewFolioTrans_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(651, 493);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(66, 31);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "Cl&ose";
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // y
            // 
            this.y.AutoSize = true;
            this.y.Font = new System.Drawing.Font("Arial", 8.25F);
            this.y.Location = new System.Drawing.Point(17, 28);
            this.y.Name = "y";
            this.y.Size = new System.Drawing.Size(37, 14);
            this.y.TabIndex = 15;
            this.y.Text = "Name:";
            // 
            // txtAccount
            // 
            this.txtAccount.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtAccount.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtAccount.Location = new System.Drawing.Point(60, 25);
            this.txtAccount.Name = "txtAccount";
            this.txtAccount.Size = new System.Drawing.Size(310, 20);
            this.txtAccount.TabIndex = 1;
            this.txtAccount.TextChanged += new System.EventHandler(this.txtAccount_TextChanged);
            this.txtAccount.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAccount_KeyDown);
            this.txtAccount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccount_KeyPress);
            // 
            // imgIcon
            // 
            this.imgIcon.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imgIcon.ImageStream")));
            this.imgIcon.TransparentColor = System.Drawing.Color.Transparent;
            this.imgIcon.Images.SetKeyName(0, "");
            this.imgIcon.Images.SetKeyName(1, "Find_ico_6.ico");
            // 
            // btnBrowseCust
            // 
            this.btnBrowseCust.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnBrowseCust.ImageIndex = 1;
            this.btnBrowseCust.ImageList = this.imgIcon;
            this.btnBrowseCust.Location = new System.Drawing.Point(379, 24);
            this.btnBrowseCust.Name = "btnBrowseCust";
            this.btnBrowseCust.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseCust.TabIndex = 2;
            this.btnBrowseCust.Click += new System.EventHandler(this.btnBrowseCust_Click);
            // 
            // tabFolioInquiry
            // 
            this.tabFolioInquiry.Controls.Add(this.tabPage1);
            this.tabFolioInquiry.Controls.Add(this.tabPage2);
            this.tabFolioInquiry.Controls.Add(this.tabFolio);
            this.tabFolioInquiry.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
            this.tabFolioInquiry.Location = new System.Drawing.Point(9, 16);
            this.tabFolioInquiry.Name = "tabFolioInquiry";
            this.tabFolioInquiry.SelectedIndex = 0;
            this.tabFolioInquiry.Size = new System.Drawing.Size(712, 463);
            this.tabFolioInquiry.TabIndex = 0;
            this.tabFolioInquiry.SelectedIndexChanged += new System.EventHandler(this.tabFolioInquiry_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.lvwBrowseGuestName);
            this.tabPage1.Controls.Add(this.gridIndividualHistory);
            this.tabPage1.Controls.Add(this.grdInquiry);
            this.tabPage1.Controls.Add(this.btnBrowseCust);
            this.tabPage1.Controls.Add(this.y);
            this.tabPage1.Controls.Add(this.txtAccount);
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(704, 436);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Individual";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // lvwBrowseGuestName
            // 
            this.lvwBrowseGuestName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwBrowseGuestName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5});
            this.lvwBrowseGuestName.FullRowSelect = true;
            this.lvwBrowseGuestName.Location = new System.Drawing.Point(59, 43);
            this.lvwBrowseGuestName.Name = "lvwBrowseGuestName";
            this.lvwBrowseGuestName.Size = new System.Drawing.Size(406, 162);
            this.lvwBrowseGuestName.TabIndex = 3;
            this.lvwBrowseGuestName.UseCompatibleStateImageBehavior = false;
            this.lvwBrowseGuestName.View = System.Windows.Forms.View.Details;
            this.lvwBrowseGuestName.Visible = false;
            this.lvwBrowseGuestName.DoubleClick += new System.EventHandler(this.lvwBrowseGuestName_DoubleClick);
            this.lvwBrowseGuestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGuestName_KeyPress);
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Account Id";
            this.columnHeader3.Width = 93;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Last Name";
            this.columnHeader4.Width = 140;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "First Name";
            this.columnHeader5.Width = 155;
            // 
            // gridIndividualHistory
            // 
            this.gridIndividualHistory.AllowEditing = false;
            this.gridIndividualHistory.ColumnInfo = "5,0,0,0,0,85,Columns:0{Caption:\"Ref No.\";}\t1{Width:400;Caption:\"Event Title\";}\t2{" +
                "Caption:\"StartDate\";}\t3{Caption:\"EndDate\";}\t4{Caption:\"folioID\";Visible:False;}\t" +
                "";
            this.gridIndividualHistory.ExtendLastCol = true;
            this.gridIndividualHistory.Location = new System.Drawing.Point(9, 57);
            this.gridIndividualHistory.Name = "gridIndividualHistory";
            this.gridIndividualHistory.Rows.Count = 1;
            this.gridIndividualHistory.Rows.DefaultSize = 17;
            this.gridIndividualHistory.Size = new System.Drawing.Size(684, 371);
            this.gridIndividualHistory.StyleInfo = resources.GetString("gridIndividualHistory.StyleInfo");
            this.gridIndividualHistory.TabIndex = 16;
            this.gridIndividualHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridIndividualHistory_MouseDoubleClick);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.lvwBrowseGroupName);
            this.tabPage2.Controls.Add(this.gridCompanyHistory);
            this.tabPage2.Controls.Add(this.grdCompanyGuests);
            this.tabPage2.Controls.Add(this.btnBrowseCompany);
            this.tabPage2.Controls.Add(this.txtCompanyName);
            this.tabPage2.Controls.Add(this.label1);
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(704, 436);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Group/Company";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // lvwBrowseGroupName
            // 
            this.lvwBrowseGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvwBrowseGroupName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2});
            this.lvwBrowseGroupName.FullRowSelect = true;
            this.lvwBrowseGroupName.Location = new System.Drawing.Point(106, 42);
            this.lvwBrowseGroupName.Name = "lvwBrowseGroupName";
            this.lvwBrowseGroupName.Size = new System.Drawing.Size(473, 243);
            this.lvwBrowseGroupName.TabIndex = 9;
            this.lvwBrowseGroupName.UseCompatibleStateImageBehavior = false;
            this.lvwBrowseGroupName.View = System.Windows.Forms.View.Details;
            this.lvwBrowseGroupName.Visible = false;
            this.lvwBrowseGroupName.DoubleClick += new System.EventHandler(this.lvwBrowseGroupName_DoubleClick);
            this.lvwBrowseGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGroupName_KeyPress);
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "Company Id";
            this.ColumnHeader1.Width = 88;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Company Name";
            this.ColumnHeader2.Width = 362;
            // 
            // gridCompanyHistory
            // 
            this.gridCompanyHistory.AllowEditing = false;
            this.gridCompanyHistory.ColumnInfo = "5,0,0,0,0,85,Columns:0{Caption:\"Ref. No\";}\t1{Width:400;Caption:\"Event Title\";}\t2{" +
                "Caption:\"StartDate\";}\t3{Caption:\"EndDate\";}\t4{Caption:\"folioID\";Visible:False;}\t" +
                "";
            this.gridCompanyHistory.ExtendLastCol = true;
            this.gridCompanyHistory.Location = new System.Drawing.Point(6, 52);
            this.gridCompanyHistory.Name = "gridCompanyHistory";
            this.gridCompanyHistory.Rows.Count = 1;
            this.gridCompanyHistory.Rows.DefaultSize = 17;
            this.gridCompanyHistory.Size = new System.Drawing.Size(687, 376);
            this.gridCompanyHistory.StyleInfo = resources.GetString("gridCompanyHistory.StyleInfo");
            this.gridCompanyHistory.TabIndex = 20;
            this.gridCompanyHistory.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.gridCompanyHistory_MouseDoubleClick);
            // 
            // grdCompanyGuests
            // 
            this.grdCompanyGuests.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:75;Caption:\"Account ID\";}\t1{Width:258;Caption:\"Guest" +
                " Name\";}\t";
            this.grdCompanyGuests.ExtendLastCol = true;
            this.grdCompanyGuests.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grdCompanyGuests.Location = new System.Drawing.Point(621, 374);
            this.grdCompanyGuests.Name = "grdCompanyGuests";
            this.grdCompanyGuests.Rows.Count = 1;
            this.grdCompanyGuests.Rows.DefaultSize = 17;
            this.grdCompanyGuests.Size = new System.Drawing.Size(72, 54);
            this.grdCompanyGuests.StyleInfo = resources.GetString("grdCompanyGuests.StyleInfo");
            this.grdCompanyGuests.TabIndex = 10;
            this.grdCompanyGuests.Click += new System.EventHandler(this.grdCompanyGuests_Click);
            this.grdCompanyGuests.DoubleClick += new System.EventHandler(this.grdCompanyGuests_DoubleClick);
            // 
            // btnBrowseCompany
            // 
            this.btnBrowseCompany.Font = new System.Drawing.Font("Arial", 8.25F);
            this.btnBrowseCompany.ImageIndex = 1;
            this.btnBrowseCompany.ImageList = this.imgIcon;
            this.btnBrowseCompany.Location = new System.Drawing.Point(582, 23);
            this.btnBrowseCompany.Name = "btnBrowseCompany";
            this.btnBrowseCompany.Size = new System.Drawing.Size(25, 23);
            this.btnBrowseCompany.TabIndex = 8;
            this.btnBrowseCompany.Click += new System.EventHandler(this.btnBrowseCompany_Click);
            // 
            // txtCompanyName
            // 
            this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtCompanyName.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtCompanyName.Location = new System.Drawing.Point(106, 25);
            this.txtCompanyName.Name = "txtCompanyName";
            this.txtCompanyName.Size = new System.Drawing.Size(472, 20);
            this.txtCompanyName.TabIndex = 7;
            this.txtCompanyName.TextChanged += new System.EventHandler(this.txtCompanyName_TextChanged);
            this.txtCompanyName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtCompanyName_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label1.Location = new System.Drawing.Point(15, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 14);
            this.label1.TabIndex = 19;
            this.label1.Text = "Company Name:";
            // 
            // tabFolio
            // 
            this.tabFolio.Controls.Add(this.grdFolioSearch);
            this.tabFolio.Controls.Add(this.label2);
            this.tabFolio.Controls.Add(this.txtFolioSearch);
            this.tabFolio.Location = new System.Drawing.Point(4, 23);
            this.tabFolio.Name = "tabFolio";
            this.tabFolio.Padding = new System.Windows.Forms.Padding(3);
            this.tabFolio.Size = new System.Drawing.Size(704, 436);
            this.tabFolio.TabIndex = 2;
            this.tabFolio.Text = "Folio      ";
            this.tabFolio.UseVisualStyleBackColor = true;
            // 
            // grdFolioSearch
            // 
            this.grdFolioSearch.ColumnInfo = "5,0,0,0,0,85,Columns:0{Width:244;Caption:\"Room(s) Rented\";}\t1{Width:98;Caption:\"F" +
                "olio Id\";}\t2{Width:138;Caption:\"From\";}\t3{Width:114;Caption:\"To\";}\t4{Width:77;Ca" +
                "ption:\"Status\";}\t";
            this.grdFolioSearch.ExtendLastCol = true;
            this.grdFolioSearch.Font = new System.Drawing.Font("Arial", 8.25F);
            this.grdFolioSearch.Location = new System.Drawing.Point(10, 49);
            this.grdFolioSearch.Name = "grdFolioSearch";
            this.grdFolioSearch.Rows.Count = 1;
            this.grdFolioSearch.Rows.DefaultSize = 17;
            this.grdFolioSearch.Size = new System.Drawing.Size(684, 371);
            this.grdFolioSearch.StyleInfo = resources.GetString("grdFolioSearch.StyleInfo");
            this.grdFolioSearch.TabIndex = 17;
            this.grdFolioSearch.DoubleClick += new System.EventHandler(this.grdFolioSearch_DoubleClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial", 8.25F);
            this.label2.Location = new System.Drawing.Point(18, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 14);
            this.label2.TabIndex = 18;
            this.label2.Text = "Folio ID :";
            // 
            // txtFolioSearch
            // 
            this.txtFolioSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
            this.txtFolioSearch.Font = new System.Drawing.Font("Arial", 8.25F);
            this.txtFolioSearch.Location = new System.Drawing.Point(68, 17);
            this.txtFolioSearch.Name = "txtFolioSearch";
            this.txtFolioSearch.Size = new System.Drawing.Size(310, 20);
            this.txtFolioSearch.TabIndex = 16;
            this.txtFolioSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFolioSearch_KeyPress);
            // 
            // btnPrint
            // 
            this.btnPrint.Location = new System.Drawing.Point(426, 493);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(132, 31);
            this.btnPrint.TabIndex = 7;
            this.btnPrint.Text = "Print Account History";
            this.btnPrint.UseVisualStyleBackColor = true;
            this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
            // 
            // btnACR
            // 
            this.btnACR.Location = new System.Drawing.Point(345, 493);
            this.btnACR.Name = "btnACR";
            this.btnACR.Size = new System.Drawing.Size(75, 31);
            this.btnACR.TabIndex = 8;
            this.btnACR.Text = "Print ACR";
            this.btnACR.UseVisualStyleBackColor = true;
            this.btnACR.Click += new System.EventHandler(this.btnACR_Click);
            // 
            // pnlRemarks
            // 
            this.pnlRemarks.BackColor = System.Drawing.Color.Gainsboro;
            this.pnlRemarks.Controls.Add(this.chkNoPayments);
            this.pnlRemarks.Controls.Add(this.btnRemarksCancel);
            this.pnlRemarks.Controls.Add(this.btnRemarksOK);
            this.pnlRemarks.Controls.Add(this.label116);
            this.pnlRemarks.Controls.Add(this.txtGroupRemarks);
            this.pnlRemarks.Location = new System.Drawing.Point(13, 481);
            this.pnlRemarks.Name = "pnlRemarks";
            this.pnlRemarks.Size = new System.Drawing.Size(358, 205);
            this.pnlRemarks.TabIndex = 117;
            this.pnlRemarks.Visible = false;
            // 
            // chkNoPayments
            // 
            this.chkNoPayments.AutoSize = true;
            this.chkNoPayments.Location = new System.Drawing.Point(254, 24);
            this.chkNoPayments.Name = "chkNoPayments";
            this.chkNoPayments.Size = new System.Drawing.Size(89, 18);
            this.chkNoPayments.TabIndex = 165;
            this.chkNoPayments.Text = "No Payments";
            this.chkNoPayments.UseVisualStyleBackColor = true;
            // 
            // btnRemarksCancel
            // 
            this.btnRemarksCancel.Location = new System.Drawing.Point(187, 157);
            this.btnRemarksCancel.Name = "btnRemarksCancel";
            this.btnRemarksCancel.Size = new System.Drawing.Size(75, 30);
            this.btnRemarksCancel.TabIndex = 164;
            this.btnRemarksCancel.Text = "Cancel";
            this.btnRemarksCancel.UseVisualStyleBackColor = true;
            this.btnRemarksCancel.Click += new System.EventHandler(this.btnRemarksCancel_Click);
            // 
            // btnRemarksOK
            // 
            this.btnRemarksOK.Location = new System.Drawing.Point(268, 157);
            this.btnRemarksOK.Name = "btnRemarksOK";
            this.btnRemarksOK.Size = new System.Drawing.Size(75, 30);
            this.btnRemarksOK.TabIndex = 163;
            this.btnRemarksOK.Text = "OK";
            this.btnRemarksOK.UseVisualStyleBackColor = true;
            this.btnRemarksOK.Click += new System.EventHandler(this.btnRemarksOK_Click);
            // 
            // label116
            // 
            this.label116.AutoSize = true;
            this.label116.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label116.Location = new System.Drawing.Point(18, 25);
            this.label116.Name = "label116";
            this.label116.Size = new System.Drawing.Size(52, 14);
            this.label116.TabIndex = 162;
            this.label116.Text = "Remarks:";
            // 
            // txtGroupRemarks
            // 
            this.txtGroupRemarks.Location = new System.Drawing.Point(21, 60);
            this.txtGroupRemarks.Multiline = true;
            this.txtGroupRemarks.Name = "txtGroupRemarks";
            this.txtGroupRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtGroupRemarks.Size = new System.Drawing.Size(322, 91);
            this.txtGroupRemarks.TabIndex = 161;
            // 
            // FolioLedgerInquiryUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(735, 536);
            this.Controls.Add(this.btnACR);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.tabFolioInquiry);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnViewFolioTrans);
            this.Controls.Add(this.pnlRemarks);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FolioLedgerInquiryUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Event History";
            this.Load += new System.EventHandler(this.FolioLedgerInquiryUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdInquiry)).EndInit();
            this.tabFolioInquiry.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridIndividualHistory)).EndInit();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridCompanyHistory)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdCompanyGuests)).EndInit();
            this.tabFolio.ResumeLayout(false);
            this.tabFolio.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFolioSearch)).EndInit();
            this.pnlRemarks.ResumeLayout(false);
            this.pnlRemarks.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private C1.Win.C1FlexGrid.C1FlexGrid grdInquiry;
        internal System.Windows.Forms.Button btnViewFolioTrans;
        internal System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label y;
        private System.Windows.Forms.TextBox txtAccount;
        internal System.Windows.Forms.ImageList imgIcon;
        internal System.Windows.Forms.Button btnBrowseCust;
        private System.Windows.Forms.TabControl tabFolioInquiry;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private C1.Win.C1FlexGrid.C1FlexGrid grdCompanyGuests;
        internal System.Windows.Forms.Button btnBrowseCompany;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCompanyName;
        internal System.Windows.Forms.ListView lvwBrowseGroupName;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ListView lvwBrowseGuestName;
        internal System.Windows.Forms.ColumnHeader columnHeader3;
        internal System.Windows.Forms.ColumnHeader columnHeader4;
        internal System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.TabPage tabFolio;
        private C1.Win.C1FlexGrid.C1FlexGrid grdFolioSearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtFolioSearch;
        private C1.Win.C1FlexGrid.C1FlexGrid gridCompanyHistory;
        private C1.Win.C1FlexGrid.C1FlexGrid gridIndividualHistory;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.Button btnACR;
        private System.Windows.Forms.Panel pnlRemarks;
        private System.Windows.Forms.CheckBox chkNoPayments;
        private System.Windows.Forms.Button btnRemarksCancel;
        private System.Windows.Forms.Button btnRemarksOK;
        private System.Windows.Forms.Label label116;
        private System.Windows.Forms.TextBox txtGroupRemarks;
    }
}