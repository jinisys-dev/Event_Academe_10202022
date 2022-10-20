using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Accounts.BusinessLayer;
using System.Windows.Forms;
using System.Reflection;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.UIFramework;
//using Microsoft.VisualBasic;

using Jinisys.Hotel.ConfigurationHotel.Presentation;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.Collections.Generic;
//using Jinisys.Hotel.Reservation.Presentation;
using C1.Win.C1FlexGrid;

namespace Jinisys.Hotel.Accounts.Presentation
{

	public class GuestUI : Maintenance2UI
	{

		#region " Windows Form Designer generated code "


		//Form overrides dispose to clean up the component list.
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (!(components == null))
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

        private System.ComponentModel.IContainer components;

        //Required by the Windows Form Designer

		//NOTE: The following procedure is required by the Windows Form Designer
		//It can be modified using the Windows Form Designer.
		//Do not modify it using the code editor.
		internal System.Windows.Forms.TabControl tabAccountManagement;
		internal System.Windows.Forms.TabPage TabPage7;
		internal System.Windows.Forms.GroupBox gbxCommands;
		internal System.Windows.Forms.Button btnDelete;
		internal System.Windows.Forms.Button btnSave;
		internal System.Windows.Forms.Button btnNew;
		internal System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.Label Label10;
		public System.Windows.Forms.Label Label11;
		public System.Windows.Forms.Label Label13;
		public System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.TabPage TabPage4;
		internal System.Windows.Forms.GroupBox GroupBox2;
		public System.Windows.Forms.PictureBox picGuestImg;
		internal System.Windows.Forms.TextBox txtGuestImage;
		public System.Windows.Forms.TextBox txtNoOfVisits;
		public System.Windows.Forms.TextBox txtTitle;
		public System.Windows.Forms.TextBox txtPassportID;
		public System.Windows.Forms.TextBox txtCitizenship;
		public System.Windows.Forms.TextBox txtAccountId;
		public System.Windows.Forms.TextBox txtFirstName;
		public System.Windows.Forms.TextBox txtMiddleName;
		public System.Windows.Forms.TextBox txtLastName;
		public System.Windows.Forms.TextBox txtAccountName;
		public System.Windows.Forms.Label Label35;
		public System.Windows.Forms.Label Label34;
		public System.Windows.Forms.Label Label8;
		public System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.ComboBox cboSex;
		public System.Windows.Forms.Label Label3;
		public System.Windows.Forms.Label Label1;
		public System.Windows.Forms.Label Label43;
		public System.Windows.Forms.Label Label2;
		public System.Windows.Forms.Label Label7;
		public System.Windows.Forms.Label Label37;
		public System.Windows.Forms.TextBox txtCity;
		public System.Windows.Forms.TextBox txtStreet;
		public System.Windows.Forms.TextBox txtZip;
		public System.Windows.Forms.TextBox txtCountry;
		public System.Windows.Forms.Label Label20;
		public System.Windows.Forms.Label Label9;
		public System.Windows.Forms.Label Label12;
		public System.Windows.Forms.Label Label15;
		public System.Windows.Forms.Label Label16;
		public System.Windows.Forms.Label Label17;
		public System.Windows.Forms.TextBox txtTelephoneNo;
		public System.Windows.Forms.TextBox txtMobileNo;
		public System.Windows.Forms.TextBox txtFaxNo;
		public System.Windows.Forms.TextBox txtEmailAddress;
		internal System.Windows.Forms.Button btnSearch;
		internal System.Windows.Forms.TextBox txtRemark;
		internal Panel pnlSearch;
		private Label label5;
		internal Label lblClose;
		internal Label label22;
		internal Label label23;
		internal Button btnCloseSearch;
		internal Button btnFind;
		internal TextBox txtSearch;
		private OpenFileDialog ofdGuestPic;
		internal Button btnClose;
		internal Button btnSelect;
		private TabPage tabPrivileges;
		public Label label19;
		public Label label4;
		internal TextBox txtConcierge;
		public Label label21;
		public Label label24;
		internal ComboBox cboAccount_Type;
		public Label label25;
		public TextBox txtCreateTime;
		public Label label26;
		private DateTimePicker dtpBirth_Date;
		internal Button btnRemovePrivilege;
		internal Button btnAddPrivilege;
		public Label label27;
		private NumericUpDown nudThreshold_Value;
		public TextBox txtCard_No;
		public Label label28;
		internal Button btnFolioHistory;
		internal Button btnMergeAccount;
		public Label lblTotal_Sales_Contribution;
		private TabPage tabPage1;
		public TextBox txtMemo;
		private DateTimePicker dtpCreditCardExpiry;
		public Label label69;
		public TextBox txtCreditCardType;
		public TextBox txtCreditCardNo;
		public Label label67;
		public Label label61;
		public Label label18;
		private CheckBox chkTaxExempted;
		private C1FlexGrid grdGuestPrivilege;
        private TabPage tabAcctMgt;
        private TextBox txtAffiliations;
        private Label label29;
        private TextBox txtNature;
        private Label label30;
        private TextBox txtBoard;
        private Label label31;
        private TextBox txtPillars;
        private Label label32;
        private Label label33;
        private DateTimePicker dtpAnniversary;
        private TabPage tabContactPersons;
        private C1FlexGrid gridContactList;
        private ContextMenuStrip mnuContactList;
        private ToolStripMenuItem mnuAddContact;
        private ToolStripMenuItem mnuRemoveContact;
        private DateTimePicker dtpBirthdate;
        internal Button btnExport;
        private SaveFileDialog exportAccountsDialog;
		internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdGuest;
		[System.Diagnostics.DebuggerStepThrough()]
		private void InitializeComponent()
		{
this.components = new System.ComponentModel.Container();
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GuestUI));
this.tabAccountManagement = new System.Windows.Forms.TabControl();
this.TabPage7 = new System.Windows.Forms.TabPage();
this.dtpCreditCardExpiry = new System.Windows.Forms.DateTimePicker();
this.label69 = new System.Windows.Forms.Label();
this.label18 = new System.Windows.Forms.Label();
this.txtCreditCardNo = new System.Windows.Forms.TextBox();
this.txtCreditCardType = new System.Windows.Forms.TextBox();
this.label61 = new System.Windows.Forms.Label();
this.Label17 = new System.Windows.Forms.Label();
this.txtEmailAddress = new System.Windows.Forms.TextBox();
this.label67 = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label15 = new System.Windows.Forms.Label();
this.Label12 = new System.Windows.Forms.Label();
this.txtFaxNo = new System.Windows.Forms.TextBox();
this.txtMobileNo = new System.Windows.Forms.TextBox();
this.txtTelephoneNo = new System.Windows.Forms.TextBox();
this.Label20 = new System.Windows.Forms.Label();
this.Label10 = new System.Windows.Forms.Label();
this.Label11 = new System.Windows.Forms.Label();
this.txtCity = new System.Windows.Forms.TextBox();
this.txtStreet = new System.Windows.Forms.TextBox();
this.txtZip = new System.Windows.Forms.TextBox();
this.txtCountry = new System.Windows.Forms.TextBox();
this.Label13 = new System.Windows.Forms.Label();
this.Label14 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.TabPage4 = new System.Windows.Forms.TabPage();
this.label19 = new System.Windows.Forms.Label();
this.label4 = new System.Windows.Forms.Label();
this.txtConcierge = new System.Windows.Forms.TextBox();
this.txtRemark = new System.Windows.Forms.TextBox();
this.tabPage1 = new System.Windows.Forms.TabPage();
this.txtMemo = new System.Windows.Forms.TextBox();
this.tabPrivileges = new System.Windows.Forms.TabPage();
this.grdGuestPrivilege = new C1.Win.C1FlexGrid.C1FlexGrid();
this.btnRemovePrivilege = new System.Windows.Forms.Button();
this.btnAddPrivilege = new System.Windows.Forms.Button();
this.tabAcctMgt = new System.Windows.Forms.TabPage();
this.dtpAnniversary = new System.Windows.Forms.DateTimePicker();
this.label33 = new System.Windows.Forms.Label();
this.txtPillars = new System.Windows.Forms.TextBox();
this.label32 = new System.Windows.Forms.Label();
this.txtBoard = new System.Windows.Forms.TextBox();
this.label31 = new System.Windows.Forms.Label();
this.txtNature = new System.Windows.Forms.TextBox();
this.label30 = new System.Windows.Forms.Label();
this.txtAffiliations = new System.Windows.Forms.TextBox();
this.label29 = new System.Windows.Forms.Label();
this.tabContactPersons = new System.Windows.Forms.TabPage();
this.gridContactList = new C1.Win.C1FlexGrid.C1FlexGrid();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnMergeAccount = new System.Windows.Forms.Button();
this.btnFolioHistory = new System.Windows.Forms.Button();
this.btnSelect = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnExport = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.GroupBox2 = new System.Windows.Forms.GroupBox();
this.picGuestImg = new System.Windows.Forms.PictureBox();
this.chkTaxExempted = new System.Windows.Forms.CheckBox();
this.lblTotal_Sales_Contribution = new System.Windows.Forms.Label();
this.txtCard_No = new System.Windows.Forms.TextBox();
this.label28 = new System.Windows.Forms.Label();
this.nudThreshold_Value = new System.Windows.Forms.NumericUpDown();
this.label27 = new System.Windows.Forms.Label();
this.dtpBirth_Date = new System.Windows.Forms.DateTimePicker();
this.txtCreateTime = new System.Windows.Forms.TextBox();
this.label26 = new System.Windows.Forms.Label();
this.cboAccount_Type = new System.Windows.Forms.ComboBox();
this.label25 = new System.Windows.Forms.Label();
this.label24 = new System.Windows.Forms.Label();
this.label21 = new System.Windows.Forms.Label();
this.txtNoOfVisits = new System.Windows.Forms.TextBox();
this.txtTitle = new System.Windows.Forms.TextBox();
this.txtPassportID = new System.Windows.Forms.TextBox();
this.txtCitizenship = new System.Windows.Forms.TextBox();
this.txtAccountId = new System.Windows.Forms.TextBox();
this.txtFirstName = new System.Windows.Forms.TextBox();
this.txtMiddleName = new System.Windows.Forms.TextBox();
this.txtLastName = new System.Windows.Forms.TextBox();
this.txtAccountName = new System.Windows.Forms.TextBox();
this.Label35 = new System.Windows.Forms.Label();
this.Label34 = new System.Windows.Forms.Label();
this.Label8 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.cboSex = new System.Windows.Forms.ComboBox();
this.Label3 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.Label43 = new System.Windows.Forms.Label();
this.Label2 = new System.Windows.Forms.Label();
this.Label7 = new System.Windows.Forms.Label();
this.Label37 = new System.Windows.Forms.Label();
this.txtGuestImage = new System.Windows.Forms.TextBox();
this.grdGuest = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label5 = new System.Windows.Forms.Label();
this.lblClose = new System.Windows.Forms.Label();
this.label22 = new System.Windows.Forms.Label();
this.label23 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.ofdGuestPic = new System.Windows.Forms.OpenFileDialog();
this.mnuContactList = new System.Windows.Forms.ContextMenuStrip(this.components);
this.mnuAddContact = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRemoveContact = new System.Windows.Forms.ToolStripMenuItem();
this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
this.exportAccountsDialog = new System.Windows.Forms.SaveFileDialog();
this.tabAccountManagement.SuspendLayout();
this.TabPage7.SuspendLayout();
this.TabPage4.SuspendLayout();
this.tabPage1.SuspendLayout();
this.tabPrivileges.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdGuestPrivilege)).BeginInit();
this.tabAcctMgt.SuspendLayout();
this.tabContactPersons.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridContactList)).BeginInit();
this.gbxCommands.SuspendLayout();
this.GroupBox2.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.picGuestImg)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudThreshold_Value)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.grdGuest)).BeginInit();
this.pnlSearch.SuspendLayout();
this.mnuContactList.SuspendLayout();
this.SuspendLayout();
// 
// tabAccountManagement
// 
this.tabAccountManagement.Controls.Add(this.TabPage7);
this.tabAccountManagement.Controls.Add(this.TabPage4);
this.tabAccountManagement.Controls.Add(this.tabPage1);
this.tabAccountManagement.Controls.Add(this.tabPrivileges);
this.tabAccountManagement.Controls.Add(this.tabAcctMgt);
this.tabAccountManagement.Controls.Add(this.tabContactPersons);
this.tabAccountManagement.Location = new System.Drawing.Point(236, 262);
this.tabAccountManagement.Multiline = true;
this.tabAccountManagement.Name = "tabAccountManagement";
this.tabAccountManagement.SelectedIndex = 0;
this.tabAccountManagement.Size = new System.Drawing.Size(531, 282);
this.tabAccountManagement.TabIndex = 18;
// 
// TabPage7
// 
this.TabPage7.Controls.Add(this.dtpCreditCardExpiry);
this.TabPage7.Controls.Add(this.label69);
this.TabPage7.Controls.Add(this.label18);
this.TabPage7.Controls.Add(this.txtCreditCardNo);
this.TabPage7.Controls.Add(this.txtCreditCardType);
this.TabPage7.Controls.Add(this.label61);
this.TabPage7.Controls.Add(this.Label17);
this.TabPage7.Controls.Add(this.txtEmailAddress);
this.TabPage7.Controls.Add(this.label67);
this.TabPage7.Controls.Add(this.Label16);
this.TabPage7.Controls.Add(this.Label15);
this.TabPage7.Controls.Add(this.Label12);
this.TabPage7.Controls.Add(this.txtFaxNo);
this.TabPage7.Controls.Add(this.txtMobileNo);
this.TabPage7.Controls.Add(this.txtTelephoneNo);
this.TabPage7.Controls.Add(this.Label20);
this.TabPage7.Controls.Add(this.Label10);
this.TabPage7.Controls.Add(this.Label11);
this.TabPage7.Controls.Add(this.txtCity);
this.TabPage7.Controls.Add(this.txtStreet);
this.TabPage7.Controls.Add(this.txtZip);
this.TabPage7.Controls.Add(this.txtCountry);
this.TabPage7.Controls.Add(this.Label13);
this.TabPage7.Controls.Add(this.Label14);
this.TabPage7.Controls.Add(this.Label9);
this.TabPage7.Location = new System.Drawing.Point(4, 23);
this.TabPage7.Name = "TabPage7";
this.TabPage7.Size = new System.Drawing.Size(523, 255);
this.TabPage7.TabIndex = 0;
this.TabPage7.Text = "Contact Information";
this.TabPage7.UseVisualStyleBackColor = true;
// 
// dtpCreditCardExpiry
// 
this.dtpCreditCardExpiry.CalendarMonthBackground = System.Drawing.Color.White;
this.dtpCreditCardExpiry.CalendarTitleForeColor = System.Drawing.Color.White;
this.dtpCreditCardExpiry.CustomFormat = "MMM. dd, yyyy";
this.dtpCreditCardExpiry.Format = System.Windows.Forms.DateTimePickerFormat.Short;
this.dtpCreditCardExpiry.Location = new System.Drawing.Point(314, 212);
this.dtpCreditCardExpiry.Name = "dtpCreditCardExpiry";
this.dtpCreditCardExpiry.Size = new System.Drawing.Size(82, 20);
this.dtpCreditCardExpiry.TabIndex = 29;
this.dtpCreditCardExpiry.Value = new System.DateTime(2009, 7, 25, 0, 0, 0, 0);
// 
// label69
// 
this.label69.BackColor = System.Drawing.SystemColors.Control;
this.label69.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label69.ForeColor = System.Drawing.Color.Black;
this.label69.Location = new System.Drawing.Point(313, 193);
this.label69.Name = "label69";
this.label69.Size = new System.Drawing.Size(76, 16);
this.label69.TabIndex = 124;
this.label69.Text = "Expiry Date :";
// 
// label18
// 
this.label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label18.ForeColor = System.Drawing.Color.Black;
this.label18.Location = new System.Drawing.Point(16, 171);
this.label18.Name = "label18";
this.label18.Size = new System.Drawing.Size(162, 16);
this.label18.TabIndex = 208;
this.label18.Text = "Credit Card Information :";
// 
// txtCreditCardNo
// 
this.txtCreditCardNo.BackColor = System.Drawing.Color.White;
this.txtCreditCardNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCreditCardNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.txtCreditCardNo.Location = new System.Drawing.Point(152, 212);
this.txtCreditCardNo.MaxLength = 16;
this.txtCreditCardNo.Name = "txtCreditCardNo";
this.txtCreditCardNo.Size = new System.Drawing.Size(142, 20);
this.txtCreditCardNo.TabIndex = 28;
// 
// txtCreditCardType
// 
this.txtCreditCardType.BackColor = System.Drawing.Color.White;
this.txtCreditCardType.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCreditCardType.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
this.txtCreditCardType.Location = new System.Drawing.Point(36, 212);
this.txtCreditCardType.MaxLength = 100;
this.txtCreditCardType.Name = "txtCreditCardType";
this.txtCreditCardType.Size = new System.Drawing.Size(103, 20);
this.txtCreditCardType.TabIndex = 27;
// 
// label61
// 
this.label61.BackColor = System.Drawing.SystemColors.Control;
this.label61.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label61.ForeColor = System.Drawing.Color.Black;
this.label61.Location = new System.Drawing.Point(151, 193);
this.label61.Name = "label61";
this.label61.Size = new System.Drawing.Size(94, 16);
this.label61.TabIndex = 114;
this.label61.Text = "Credit Card No. : ";
// 
// Label17
// 
this.Label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label17.ForeColor = System.Drawing.Color.Black;
this.Label17.Location = new System.Drawing.Point(16, 124);
this.Label17.Name = "Label17";
this.Label17.Size = new System.Drawing.Size(112, 16);
this.Label17.TabIndex = 95;
this.Label17.Text = "Email Address";
// 
// txtEmailAddress
// 
this.txtEmailAddress.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtEmailAddress.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEmailAddress.Location = new System.Drawing.Point(33, 140);
this.txtEmailAddress.Name = "txtEmailAddress";
this.txtEmailAddress.Size = new System.Drawing.Size(458, 20);
this.txtEmailAddress.TabIndex = 26;
// 
// label67
// 
this.label67.BackColor = System.Drawing.SystemColors.Control;
this.label67.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label67.ForeColor = System.Drawing.Color.Black;
this.label67.Location = new System.Drawing.Point(33, 193);
this.label67.Name = "label67";
this.label67.Size = new System.Drawing.Size(76, 16);
this.label67.TabIndex = 124;
this.label67.Text = "Card Type :";
// 
// Label16
// 
this.Label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label16.ForeColor = System.Drawing.Color.Black;
this.Label16.Location = new System.Drawing.Point(349, 26);
this.Label16.Name = "Label16";
this.Label16.Size = new System.Drawing.Size(58, 16);
this.Label16.TabIndex = 93;
this.Label16.Text = "Fax";
// 
// Label15
// 
this.Label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label15.ForeColor = System.Drawing.Color.Black;
this.Label15.Location = new System.Drawing.Point(192, 26);
this.Label15.Name = "Label15";
this.Label15.Size = new System.Drawing.Size(58, 16);
this.Label15.TabIndex = 92;
this.Label15.Text = "Mobile";
// 
// Label12
// 
this.Label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label12.ForeColor = System.Drawing.Color.Black;
this.Label12.Location = new System.Drawing.Point(33, 26);
this.Label12.Name = "Label12";
this.Label12.Size = new System.Drawing.Size(58, 16);
this.Label12.TabIndex = 91;
this.Label12.Text = "Telephone";
// 
// txtFaxNo
// 
this.txtFaxNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtFaxNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtFaxNo.Location = new System.Drawing.Point(349, 42);
this.txtFaxNo.MaxLength = 50;
this.txtFaxNo.Name = "txtFaxNo";
this.txtFaxNo.Size = new System.Drawing.Size(144, 20);
this.txtFaxNo.TabIndex = 21;
// 
// txtMobileNo
// 
this.txtMobileNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtMobileNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtMobileNo.Location = new System.Drawing.Point(192, 42);
this.txtMobileNo.MaxLength = 50;
this.txtMobileNo.Name = "txtMobileNo";
this.txtMobileNo.Size = new System.Drawing.Size(144, 20);
this.txtMobileNo.TabIndex = 20;
// 
// txtTelephoneNo
// 
this.txtTelephoneNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtTelephoneNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtTelephoneNo.Location = new System.Drawing.Point(33, 42);
this.txtTelephoneNo.MaxLength = 50;
this.txtTelephoneNo.Name = "txtTelephoneNo";
this.txtTelephoneNo.Size = new System.Drawing.Size(144, 20);
this.txtTelephoneNo.TabIndex = 19;
// 
// Label20
// 
this.Label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label20.ForeColor = System.Drawing.Color.Black;
this.Label20.Location = new System.Drawing.Point(16, 10);
this.Label20.Name = "Label20";
this.Label20.Size = new System.Drawing.Size(72, 16);
this.Label20.TabIndex = 87;
this.Label20.Text = "Contact No.";
// 
// Label10
// 
this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label10.ForeColor = System.Drawing.Color.Black;
this.Label10.Location = new System.Drawing.Point(158, 82);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(31, 16);
this.Label10.TabIndex = 83;
this.Label10.Text = "City ";
// 
// Label11
// 
this.Label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label11.ForeColor = System.Drawing.Color.Black;
this.Label11.Location = new System.Drawing.Point(33, 82);
this.Label11.Name = "Label11";
this.Label11.Size = new System.Drawing.Size(58, 16);
this.Label11.TabIndex = 80;
this.Label11.Text = "Street ";
// 
// txtCity
// 
this.txtCity.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCity.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCity.Location = new System.Drawing.Point(158, 98);
this.txtCity.MaxLength = 100;
this.txtCity.Name = "txtCity";
this.txtCity.Size = new System.Drawing.Size(136, 20);
this.txtCity.TabIndex = 23;
// 
// txtStreet
// 
this.txtStreet.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtStreet.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtStreet.Location = new System.Drawing.Point(33, 98);
this.txtStreet.MaxLength = 100;
this.txtStreet.Name = "txtStreet";
this.txtStreet.Size = new System.Drawing.Size(120, 20);
this.txtStreet.TabIndex = 22;
// 
// txtZip
// 
this.txtZip.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtZip.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtZip.Location = new System.Drawing.Point(428, 98);
this.txtZip.MaxLength = 10;
this.txtZip.Name = "txtZip";
this.txtZip.Size = new System.Drawing.Size(64, 20);
this.txtZip.TabIndex = 25;
// 
// txtCountry
// 
this.txtCountry.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
this.txtCountry.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtCountry.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCountry.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCountry.Location = new System.Drawing.Point(299, 98);
this.txtCountry.MaxLength = 100;
this.txtCountry.Name = "txtCountry";
this.txtCountry.Size = new System.Drawing.Size(123, 20);
this.txtCountry.TabIndex = 24;
this.txtCountry.TextChanged += new System.EventHandler(this.txtCountry_TextChanged);
// 
// Label13
// 
this.Label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label13.ForeColor = System.Drawing.Color.Black;
this.Label13.Location = new System.Drawing.Point(299, 82);
this.Label13.Name = "Label13";
this.Label13.Size = new System.Drawing.Size(58, 16);
this.Label13.TabIndex = 82;
this.Label13.Text = "Country ";
// 
// Label14
// 
this.Label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label14.ForeColor = System.Drawing.Color.Black;
this.Label14.Location = new System.Drawing.Point(428, 82);
this.Label14.Name = "Label14";
this.Label14.Size = new System.Drawing.Size(64, 16);
this.Label14.TabIndex = 81;
this.Label14.Text = "ZIP ";
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.ForeColor = System.Drawing.Color.Black;
this.Label9.Location = new System.Drawing.Point(16, 65);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(56, 16);
this.Label9.TabIndex = 87;
this.Label9.Text = "Address";
// 
// TabPage4
// 
this.TabPage4.Controls.Add(this.label19);
this.TabPage4.Controls.Add(this.label4);
this.TabPage4.Controls.Add(this.txtConcierge);
this.TabPage4.Controls.Add(this.txtRemark);
this.TabPage4.Location = new System.Drawing.Point(4, 23);
this.TabPage4.Name = "TabPage4";
this.TabPage4.Size = new System.Drawing.Size(523, 255);
this.TabPage4.TabIndex = 6;
this.TabPage4.Text = "Preferences";
this.TabPage4.UseVisualStyleBackColor = true;
// 
// label19
// 
this.label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label19.ForeColor = System.Drawing.Color.Black;
this.label19.Location = new System.Drawing.Point(19, 146);
this.label19.Name = "label19";
this.label19.Size = new System.Drawing.Size(72, 16);
this.label19.TabIndex = 89;
this.label19.Text = "Concierge";
// 
// label4
// 
this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label4.ForeColor = System.Drawing.Color.Black;
this.label4.Location = new System.Drawing.Point(19, 19);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(72, 16);
this.label4.TabIndex = 88;
this.label4.Text = "Remarks";
// 
// txtConcierge
// 
this.txtConcierge.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtConcierge.Location = new System.Drawing.Point(19, 165);
this.txtConcierge.Multiline = true;
this.txtConcierge.Name = "txtConcierge";
this.txtConcierge.Size = new System.Drawing.Size(487, 79);
this.txtConcierge.TabIndex = 31;
// 
// txtRemark
// 
this.txtRemark.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
this.txtRemark.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtRemark.Location = new System.Drawing.Point(19, 39);
this.txtRemark.Multiline = true;
this.txtRemark.Name = "txtRemark";
this.txtRemark.Size = new System.Drawing.Size(487, 96);
this.txtRemark.TabIndex = 30;
// 
// tabPage1
// 
this.tabPage1.Controls.Add(this.txtMemo);
this.tabPage1.Location = new System.Drawing.Point(4, 23);
this.tabPage1.Name = "tabPage1";
this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
this.tabPage1.Size = new System.Drawing.Size(523, 255);
this.tabPage1.TabIndex = 8;
this.tabPage1.Text = "Memo";
this.tabPage1.UseVisualStyleBackColor = true;
// 
// txtMemo
// 
this.txtMemo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtMemo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtMemo.Location = new System.Drawing.Point(14, 10);
this.txtMemo.Multiline = true;
this.txtMemo.Name = "txtMemo";
this.txtMemo.Size = new System.Drawing.Size(495, 235);
this.txtMemo.TabIndex = 32;
// 
// tabPrivileges
// 
this.tabPrivileges.Controls.Add(this.grdGuestPrivilege);
this.tabPrivileges.Controls.Add(this.btnRemovePrivilege);
this.tabPrivileges.Controls.Add(this.btnAddPrivilege);
this.tabPrivileges.Location = new System.Drawing.Point(4, 23);
this.tabPrivileges.Name = "tabPrivileges";
this.tabPrivileges.Padding = new System.Windows.Forms.Padding(3);
this.tabPrivileges.Size = new System.Drawing.Size(523, 255);
this.tabPrivileges.TabIndex = 7;
this.tabPrivileges.Text = "Privileges";
this.tabPrivileges.UseVisualStyleBackColor = true;
// 
// grdGuestPrivilege
// 
this.grdGuestPrivilege.ColumnInfo = "5,0,0,0,0,85,Columns:0{Width:81;Caption:\"Privilege Id\";}\t1{Width:172;Caption:\"Des" +
    "cription\";}\t2{Width:74;Caption:\"Days Applied\";}\t3{Width:89;Caption:\"Granted By\";" +
    "}\t4{Width:71;Caption:\"Date\";}\t";
this.grdGuestPrivilege.ExtendLastCol = true;
this.grdGuestPrivilege.Location = new System.Drawing.Point(8, 51);
this.grdGuestPrivilege.Name = "grdGuestPrivilege";
this.grdGuestPrivilege.Rows.Count = 1;
this.grdGuestPrivilege.Rows.DefaultSize = 17;
this.grdGuestPrivilege.Size = new System.Drawing.Size(509, 193);
this.grdGuestPrivilege.StyleInfo = resources.GetString("grdGuestPrivilege.StyleInfo");
this.grdGuestPrivilege.TabIndex = 36;
// 
// btnRemovePrivilege
// 
this.btnRemovePrivilege.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnRemovePrivilege.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnRemovePrivilege.Location = new System.Drawing.Point(445, 12);
this.btnRemovePrivilege.Name = "btnRemovePrivilege";
this.btnRemovePrivilege.Size = new System.Drawing.Size(66, 31);
this.btnRemovePrivilege.TabIndex = 34;
this.btnRemovePrivilege.Text = "Remo&ve";
this.btnRemovePrivilege.Click += new System.EventHandler(this.btnRemovePrivilege_Click);
// 
// btnAddPrivilege
// 
this.btnAddPrivilege.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnAddPrivilege.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnAddPrivilege.Location = new System.Drawing.Point(375, 12);
this.btnAddPrivilege.Name = "btnAddPrivilege";
this.btnAddPrivilege.Size = new System.Drawing.Size(66, 31);
this.btnAddPrivilege.TabIndex = 33;
this.btnAddPrivilege.Text = "A&dd";
this.btnAddPrivilege.Click += new System.EventHandler(this.btnAddPrivilege_Click);
// 
// tabAcctMgt
// 
this.tabAcctMgt.Controls.Add(this.dtpAnniversary);
this.tabAcctMgt.Controls.Add(this.label33);
this.tabAcctMgt.Controls.Add(this.txtPillars);
this.tabAcctMgt.Controls.Add(this.label32);
this.tabAcctMgt.Controls.Add(this.txtBoard);
this.tabAcctMgt.Controls.Add(this.label31);
this.tabAcctMgt.Controls.Add(this.txtNature);
this.tabAcctMgt.Controls.Add(this.label30);
this.tabAcctMgt.Controls.Add(this.txtAffiliations);
this.tabAcctMgt.Controls.Add(this.label29);
this.tabAcctMgt.Location = new System.Drawing.Point(4, 23);
this.tabAcctMgt.Name = "tabAcctMgt";
this.tabAcctMgt.Padding = new System.Windows.Forms.Padding(3);
this.tabAcctMgt.Size = new System.Drawing.Size(523, 255);
this.tabAcctMgt.TabIndex = 9;
this.tabAcctMgt.Text = "Account Information";
this.tabAcctMgt.UseVisualStyleBackColor = true;
// 
// dtpAnniversary
// 
this.dtpAnniversary.CustomFormat = "MMMM dd, yyyy";
this.dtpAnniversary.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpAnniversary.Location = new System.Drawing.Point(225, 229);
this.dtpAnniversary.Name = "dtpAnniversary";
this.dtpAnniversary.Size = new System.Drawing.Size(168, 20);
this.dtpAnniversary.TabIndex = 9;
// 
// label33
// 
this.label33.AutoSize = true;
this.label33.Location = new System.Drawing.Point(74, 232);
this.label33.Name = "label33";
this.label33.Size = new System.Drawing.Size(143, 14);
this.label33.TabIndex = 8;
this.label33.Text = "Year Founded / Anniversary";
// 
// txtPillars
// 
this.txtPillars.Location = new System.Drawing.Point(263, 117);
this.txtPillars.Multiline = true;
this.txtPillars.Name = "txtPillars";
this.txtPillars.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtPillars.Size = new System.Drawing.Size(254, 106);
this.txtPillars.TabIndex = 7;
// 
// label32
// 
this.label32.AutoSize = true;
this.label32.Location = new System.Drawing.Point(263, 100);
this.label32.Name = "label32";
this.label32.Size = new System.Drawing.Size(130, 14);
this.label32.TabIndex = 6;
this.label32.Text = "Pillars of the Organization";
// 
// txtBoard
// 
this.txtBoard.Location = new System.Drawing.Point(263, 20);
this.txtBoard.Multiline = true;
this.txtBoard.Name = "txtBoard";
this.txtBoard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtBoard.Size = new System.Drawing.Size(254, 77);
this.txtBoard.TabIndex = 5;
// 
// label31
// 
this.label31.AutoSize = true;
this.label31.Location = new System.Drawing.Point(263, 3);
this.label31.Name = "label31";
this.label31.Size = new System.Drawing.Size(217, 14);
this.label31.TabIndex = 4;
this.label31.Text = "Term of Office of Officers / Board Members";
// 
// txtNature
// 
this.txtNature.Location = new System.Drawing.Point(6, 117);
this.txtNature.Multiline = true;
this.txtNature.Name = "txtNature";
this.txtNature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtNature.Size = new System.Drawing.Size(251, 106);
this.txtNature.TabIndex = 3;
// 
// label30
// 
this.label30.AutoSize = true;
this.label30.Location = new System.Drawing.Point(6, 3);
this.label30.Name = "label30";
this.label30.Size = new System.Drawing.Size(58, 14);
this.label30.TabIndex = 2;
this.label30.Text = "Affiliations";
// 
// txtAffiliations
// 
this.txtAffiliations.Location = new System.Drawing.Point(6, 20);
this.txtAffiliations.Multiline = true;
this.txtAffiliations.Name = "txtAffiliations";
this.txtAffiliations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtAffiliations.Size = new System.Drawing.Size(251, 77);
this.txtAffiliations.TabIndex = 1;
// 
// label29
// 
this.label29.AutoSize = true;
this.label29.Location = new System.Drawing.Point(6, 100);
this.label29.Name = "label29";
this.label29.Size = new System.Drawing.Size(100, 14);
this.label29.TabIndex = 0;
this.label29.Text = "Nature of Business";
// 
// tabContactPersons
// 
this.tabContactPersons.Controls.Add(this.gridContactList);
this.tabContactPersons.Location = new System.Drawing.Point(4, 23);
this.tabContactPersons.Name = "tabContactPersons";
this.tabContactPersons.Padding = new System.Windows.Forms.Padding(3);
this.tabContactPersons.Size = new System.Drawing.Size(523, 255);
this.tabContactPersons.TabIndex = 10;
this.tabContactPersons.Text = "Contact Persons";
this.tabContactPersons.UseVisualStyleBackColor = true;
// 
// gridContactList
// 
this.gridContactList.ColumnInfo = resources.GetString("gridContactList.ColumnInfo");
this.gridContactList.Cursor = System.Windows.Forms.Cursors.Default;
this.gridContactList.Location = new System.Drawing.Point(6, 6);
this.gridContactList.Name = "gridContactList";
this.gridContactList.Rows.Count = 1;
this.gridContactList.Rows.DefaultSize = 17;
this.gridContactList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
this.gridContactList.Size = new System.Drawing.Size(514, 243);
this.gridContactList.StyleInfo = resources.GetString("gridContactList.StyleInfo");
this.gridContactList.TabIndex = 0;
this.gridContactList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridContactList_MouseClick);
this.gridContactList.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridContactList_BeforeEdit);
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnMergeAccount);
this.gbxCommands.Controls.Add(this.btnFolioHistory);
this.gbxCommands.Controls.Add(this.btnSelect);
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnExport);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(3, 546);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(763, 49);
this.gbxCommands.TabIndex = 36;
this.gbxCommands.TabStop = false;
// 
// btnMergeAccount
// 
this.btnMergeAccount.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnMergeAccount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnMergeAccount.Location = new System.Drawing.Point(203, 11);
this.btnMergeAccount.Name = "btnMergeAccount";
this.btnMergeAccount.Size = new System.Drawing.Size(132, 31);
this.btnMergeAccount.TabIndex = 39;
this.btnMergeAccount.Text = "&Merge Account Window";
this.btnMergeAccount.Click += new System.EventHandler(this.btnMergeAccount_Click);
// 
// btnFolioHistory
// 
this.btnFolioHistory.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnFolioHistory.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnFolioHistory.Location = new System.Drawing.Point(111, 12);
this.btnFolioHistory.Name = "btnFolioHistory";
this.btnFolioHistory.Size = new System.Drawing.Size(87, 31);
this.btnFolioHistory.TabIndex = 38;
this.btnFolioHistory.Text = "&Event History";
this.btnFolioHistory.Click += new System.EventHandler(this.btnFolioHistory_Click);
// 
// btnSelect
// 
this.btnSelect.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSelect.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSelect.Location = new System.Drawing.Point(340, 11);
this.btnSelect.Name = "btnSelect";
this.btnSelect.Size = new System.Drawing.Size(66, 31);
this.btnSelect.TabIndex = 40;
this.btnSelect.Text = "S&elect";
this.btnSelect.Visible = false;
this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnClose.Location = new System.Drawing.Point(691, 11);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 45;
this.btnClose.Text = "C&lose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(412, 11);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 41;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnExport
// 
this.btnExport.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnExport.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnExport.Location = new System.Drawing.Point(5, 12);
this.btnExport.Name = "btnExport";
this.btnExport.Size = new System.Drawing.Size(48, 31);
this.btnExport.TabIndex = 37;
this.btnExport.Text = "&Export";
this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnDelete.Location = new System.Drawing.Point(54, 12);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(56, 31);
this.btnDelete.TabIndex = 37;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSave.Location = new System.Drawing.Point(552, 11);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 43;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnNew.Location = new System.Drawing.Point(482, 11);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 42;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnCancel.Location = new System.Drawing.Point(622, 11);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 44;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// GroupBox2
// 
this.GroupBox2.Controls.Add(this.picGuestImg);
this.GroupBox2.Controls.Add(this.chkTaxExempted);
this.GroupBox2.Controls.Add(this.lblTotal_Sales_Contribution);
this.GroupBox2.Controls.Add(this.txtCard_No);
this.GroupBox2.Controls.Add(this.label28);
this.GroupBox2.Controls.Add(this.nudThreshold_Value);
this.GroupBox2.Controls.Add(this.label27);
this.GroupBox2.Controls.Add(this.dtpBirth_Date);
this.GroupBox2.Controls.Add(this.txtCreateTime);
this.GroupBox2.Controls.Add(this.label26);
this.GroupBox2.Controls.Add(this.cboAccount_Type);
this.GroupBox2.Controls.Add(this.label25);
this.GroupBox2.Controls.Add(this.label24);
this.GroupBox2.Controls.Add(this.label21);
this.GroupBox2.Controls.Add(this.txtNoOfVisits);
this.GroupBox2.Controls.Add(this.txtTitle);
this.GroupBox2.Controls.Add(this.txtPassportID);
this.GroupBox2.Controls.Add(this.txtCitizenship);
this.GroupBox2.Controls.Add(this.txtAccountId);
this.GroupBox2.Controls.Add(this.txtFirstName);
this.GroupBox2.Controls.Add(this.txtMiddleName);
this.GroupBox2.Controls.Add(this.txtLastName);
this.GroupBox2.Controls.Add(this.txtAccountName);
this.GroupBox2.Controls.Add(this.Label35);
this.GroupBox2.Controls.Add(this.Label34);
this.GroupBox2.Controls.Add(this.Label8);
this.GroupBox2.Controls.Add(this.Label6);
this.GroupBox2.Controls.Add(this.cboSex);
this.GroupBox2.Controls.Add(this.Label3);
this.GroupBox2.Controls.Add(this.Label1);
this.GroupBox2.Controls.Add(this.Label43);
this.GroupBox2.Controls.Add(this.Label2);
this.GroupBox2.Controls.Add(this.Label7);
this.GroupBox2.Controls.Add(this.Label37);
this.GroupBox2.Controls.Add(this.txtGuestImage);
this.GroupBox2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
this.GroupBox2.Location = new System.Drawing.Point(236, -2);
this.GroupBox2.Name = "GroupBox2";
this.GroupBox2.Size = new System.Drawing.Size(532, 258);
this.GroupBox2.TabIndex = 1;
this.GroupBox2.TabStop = false;
// 
// picGuestImg
// 
this.picGuestImg.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
this.picGuestImg.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.picGuestImg.Cursor = System.Windows.Forms.Cursors.Hand;
this.picGuestImg.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.picGuestImg.Location = new System.Drawing.Point(424, 16);
this.picGuestImg.Name = "picGuestImg";
this.picGuestImg.Size = new System.Drawing.Size(88, 72);
this.picGuestImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
this.picGuestImg.TabIndex = 144;
this.picGuestImg.TabStop = false;
this.picGuestImg.MouseLeave += new System.EventHandler(this.picGuestImg_MouseLeave);
this.picGuestImg.Click += new System.EventHandler(this.picGuestImg_Click);
this.picGuestImg.MouseHover += new System.EventHandler(this.picGuestImg_MouseHover);
// 
// chkTaxExempted
// 
this.chkTaxExempted.AutoSize = true;
this.chkTaxExempted.Location = new System.Drawing.Point(417, 192);
this.chkTaxExempted.Name = "chkTaxExempted";
this.chkTaxExempted.Size = new System.Drawing.Size(93, 18);
this.chkTaxExempted.TabIndex = 17;
this.chkTaxExempted.Text = "Tax Exempted";
this.chkTaxExempted.UseVisualStyleBackColor = true;
this.chkTaxExempted.Visible = false;
// 
// lblTotal_Sales_Contribution
// 
this.lblTotal_Sales_Contribution.BackColor = System.Drawing.SystemColors.Control;
this.lblTotal_Sales_Contribution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblTotal_Sales_Contribution.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblTotal_Sales_Contribution.ForeColor = System.Drawing.Color.Gray;
this.lblTotal_Sales_Contribution.Location = new System.Drawing.Point(318, 62);
this.lblTotal_Sales_Contribution.Name = "lblTotal_Sales_Contribution";
this.lblTotal_Sales_Contribution.Size = new System.Drawing.Size(92, 20);
this.lblTotal_Sales_Contribution.TabIndex = 206;
this.lblTotal_Sales_Contribution.Text = "0.00";
this.lblTotal_Sales_Contribution.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.lblTotal_Sales_Contribution.TextChanged += new System.EventHandler(this.lblTotal_Sales_Contribution_TextChanged);
// 
// txtCard_No
// 
this.txtCard_No.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCard_No.Location = new System.Drawing.Point(155, 231);
this.txtCard_No.MaxLength = 30;
this.txtCard_No.Name = "txtCard_No";
this.txtCard_No.Size = new System.Drawing.Size(143, 20);
this.txtCard_No.TabIndex = 16;
// 
// label28
// 
this.label28.BackColor = System.Drawing.Color.Transparent;
this.label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label28.ForeColor = System.Drawing.Color.Black;
this.label28.Location = new System.Drawing.Point(155, 215);
this.label28.Name = "label28";
this.label28.Size = new System.Drawing.Size(80, 14);
this.label28.TabIndex = 161;
this.label28.Text = "Card No.";
// 
// nudThreshold_Value
// 
this.nudThreshold_Value.DecimalPlaces = 2;
this.nudThreshold_Value.Location = new System.Drawing.Point(15, 190);
this.nudThreshold_Value.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
this.nudThreshold_Value.Name = "nudThreshold_Value";
this.nudThreshold_Value.Size = new System.Drawing.Size(117, 20);
this.nudThreshold_Value.TabIndex = 13;
this.nudThreshold_Value.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.nudThreshold_Value.ThousandsSeparator = true;
this.nudThreshold_Value.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
// 
// label27
// 
this.label27.BackColor = System.Drawing.Color.Transparent;
this.label27.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label27.ForeColor = System.Drawing.Color.Black;
this.label27.Location = new System.Drawing.Point(15, 174);
this.label27.Name = "label27";
this.label27.Size = new System.Drawing.Size(94, 14);
this.label27.TabIndex = 158;
this.label27.Text = "Threshold value";
// 
// dtpBirth_Date
// 
this.dtpBirth_Date.CustomFormat = "dd-MMM-yyyy";
this.dtpBirth_Date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpBirth_Date.Location = new System.Drawing.Point(389, 146);
this.dtpBirth_Date.MinDate = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
this.dtpBirth_Date.Name = "dtpBirth_Date";
this.dtpBirth_Date.Size = new System.Drawing.Size(123, 20);
this.dtpBirth_Date.TabIndex = 12;
this.dtpBirth_Date.Value = new System.DateTime(1900, 1, 1, 0, 0, 0, 0);
// 
// txtCreateTime
// 
this.txtCreateTime.BackColor = System.Drawing.SystemColors.Control;
this.txtCreateTime.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCreateTime.Location = new System.Drawing.Point(15, 231);
this.txtCreateTime.MaxLength = 30;
this.txtCreateTime.Name = "txtCreateTime";
this.txtCreateTime.ReadOnly = true;
this.txtCreateTime.Size = new System.Drawing.Size(117, 20);
this.txtCreateTime.TabIndex = 15;
// 
// label26
// 
this.label26.BackColor = System.Drawing.Color.Transparent;
this.label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label26.ForeColor = System.Drawing.Color.Black;
this.label26.Location = new System.Drawing.Point(15, 215);
this.label26.Name = "label26";
this.label26.Size = new System.Drawing.Size(80, 14);
this.label26.TabIndex = 155;
this.label26.Text = "Date Created";
// 
// cboAccount_Type
// 
this.cboAccount_Type.BackColor = System.Drawing.Color.White;
this.cboAccount_Type.Location = new System.Drawing.Point(155, 188);
this.cboAccount_Type.Name = "cboAccount_Type";
this.cboAccount_Type.Size = new System.Drawing.Size(143, 22);
this.cboAccount_Type.TabIndex = 14;
this.cboAccount_Type.SelectedIndexChanged += new System.EventHandler(this.cboAccount_Type_SelectedIndexChanged);
// 
// label25
// 
this.label25.BackColor = System.Drawing.Color.Transparent;
this.label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label25.ForeColor = System.Drawing.Color.Black;
this.label25.Location = new System.Drawing.Point(155, 172);
this.label25.Name = "label25";
this.label25.Size = new System.Drawing.Size(106, 17);
this.label25.TabIndex = 151;
this.label25.Text = "Account Type";
// 
// label24
// 
this.label24.BackColor = System.Drawing.Color.Transparent;
this.label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label24.ForeColor = System.Drawing.Color.Black;
this.label24.Location = new System.Drawing.Point(389, 129);
this.label24.Name = "label24";
this.label24.Size = new System.Drawing.Size(56, 14);
this.label24.TabIndex = 149;
this.label24.Text = "Birth date";
// 
// label21
// 
this.label21.Location = new System.Drawing.Point(317, 46);
this.label21.Name = "label21";
this.label21.Size = new System.Drawing.Size(65, 14);
this.label21.TabIndex = 147;
this.label21.Text = "Total Sales";
// 
// txtNoOfVisits
// 
this.txtNoOfVisits.BackColor = System.Drawing.SystemColors.Control;
this.txtNoOfVisits.Enabled = false;
this.txtNoOfVisits.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtNoOfVisits.ForeColor = System.Drawing.Color.Black;
this.txtNoOfVisits.Location = new System.Drawing.Point(241, 62);
this.txtNoOfVisits.Name = "txtNoOfVisits";
this.txtNoOfVisits.Size = new System.Drawing.Size(64, 20);
this.txtNoOfVisits.TabIndex = 4;
this.txtNoOfVisits.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
// 
// txtTitle
// 
this.txtTitle.BackColor = System.Drawing.Color.White;
this.txtTitle.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtTitle.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtTitle.Location = new System.Drawing.Point(15, 106);
this.txtTitle.MaxLength = 5;
this.txtTitle.Name = "txtTitle";
this.txtTitle.Size = new System.Drawing.Size(75, 20);
this.txtTitle.TabIndex = 5;
// 
// txtPassportID
// 
this.txtPassportID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtPassportID.Location = new System.Drawing.Point(241, 146);
this.txtPassportID.MaxLength = 30;
this.txtPassportID.Name = "txtPassportID";
this.txtPassportID.Size = new System.Drawing.Size(140, 20);
this.txtPassportID.TabIndex = 11;
// 
// txtCitizenship
// 
this.txtCitizenship.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
this.txtCitizenship.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
this.txtCitizenship.BackColor = System.Drawing.SystemColors.Info;
this.txtCitizenship.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCitizenship.Location = new System.Drawing.Point(93, 146);
this.txtCitizenship.MaxLength = 100;
this.txtCitizenship.Name = "txtCitizenship";
this.txtCitizenship.Size = new System.Drawing.Size(141, 20);
this.txtCitizenship.TabIndex = 10;
this.txtCitizenship.TextChanged += new System.EventHandler(this.txtCitizenship_TextChanged);
// 
// txtAccountId
// 
this.txtAccountId.BackColor = System.Drawing.SystemColors.Info;
this.txtAccountId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAccountId.Location = new System.Drawing.Point(81, 17);
this.txtAccountId.MaxLength = 10;
this.txtAccountId.Name = "txtAccountId";
this.txtAccountId.Size = new System.Drawing.Size(111, 20);
this.txtAccountId.TabIndex = 2;
this.txtAccountId.TextChanged += new System.EventHandler(this.txtAccountId_TextChanged);
this.txtAccountId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtAccountId_KeyPress);
// 
// txtFirstName
// 
this.txtFirstName.BackColor = System.Drawing.SystemColors.Info;
this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtFirstName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtFirstName.Location = new System.Drawing.Point(241, 106);
this.txtFirstName.MaxLength = 30;
this.txtFirstName.Name = "txtFirstName";
this.txtFirstName.Size = new System.Drawing.Size(140, 20);
this.txtFirstName.TabIndex = 7;
// 
// txtMiddleName
// 
this.txtMiddleName.BackColor = System.Drawing.Color.White;
this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtMiddleName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtMiddleName.Location = new System.Drawing.Point(389, 106);
this.txtMiddleName.MaxLength = 30;
this.txtMiddleName.Name = "txtMiddleName";
this.txtMiddleName.Size = new System.Drawing.Size(123, 20);
this.txtMiddleName.TabIndex = 8;
// 
// txtLastName
// 
this.txtLastName.BackColor = System.Drawing.SystemColors.Info;
this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtLastName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtLastName.Location = new System.Drawing.Point(94, 106);
this.txtLastName.MaxLength = 30;
this.txtLastName.Name = "txtLastName";
this.txtLastName.Size = new System.Drawing.Size(140, 20);
this.txtLastName.TabIndex = 6;
// 
// txtAccountName
// 
this.txtAccountName.BackColor = System.Drawing.Color.White;
this.txtAccountName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtAccountName.Location = new System.Drawing.Point(15, 62);
this.txtAccountName.MaxLength = 30;
this.txtAccountName.Name = "txtAccountName";
this.txtAccountName.Size = new System.Drawing.Size(181, 20);
this.txtAccountName.TabIndex = 3;
// 
// Label35
// 
this.Label35.Location = new System.Drawing.Point(240, 46);
this.Label35.Name = "Label35";
this.Label35.Size = new System.Drawing.Size(76, 14);
this.Label35.TabIndex = 141;
this.Label35.Text = "No. Of Visit";
// 
// Label34
// 
this.Label34.BackColor = System.Drawing.Color.Transparent;
this.Label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label34.ForeColor = System.Drawing.Color.Black;
this.Label34.Location = new System.Drawing.Point(15, 90);
this.Label34.Name = "Label34";
this.Label34.Size = new System.Drawing.Size(68, 15);
this.Label34.TabIndex = 139;
this.Label34.Text = "Title";
// 
// Label8
// 
this.Label8.BackColor = System.Drawing.Color.Transparent;
this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label8.ForeColor = System.Drawing.Color.Black;
this.Label8.Location = new System.Drawing.Point(241, 130);
this.Label8.Name = "Label8";
this.Label8.Size = new System.Drawing.Size(80, 14);
this.Label8.TabIndex = 137;
this.Label8.Text = "Passport ID";
// 
// Label6
// 
this.Label6.BackColor = System.Drawing.Color.Transparent;
this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label6.ForeColor = System.Drawing.Color.Black;
this.Label6.Location = new System.Drawing.Point(93, 130);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(62, 14);
this.Label6.TabIndex = 135;
this.Label6.Text = "Citizenship";
// 
// cboSex
// 
this.cboSex.BackColor = System.Drawing.SystemColors.Info;
this.cboSex.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboSex.Items.AddRange(new object[] {
            "MALE",
            "FEMALE"});
this.cboSex.Location = new System.Drawing.Point(15, 146);
this.cboSex.Name = "cboSex";
this.cboSex.Size = new System.Drawing.Size(75, 22);
this.cboSex.TabIndex = 9;
// 
// Label3
// 
this.Label3.BackColor = System.Drawing.Color.Transparent;
this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label3.ForeColor = System.Drawing.Color.Black;
this.Label3.Location = new System.Drawing.Point(15, 130);
this.Label3.Name = "Label3";
this.Label3.Size = new System.Drawing.Size(56, 14);
this.Label3.TabIndex = 131;
this.Label3.Text = "Gender";
// 
// Label1
// 
this.Label1.BackColor = System.Drawing.Color.Transparent;
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.ForeColor = System.Drawing.Color.Black;
this.Label1.Location = new System.Drawing.Point(389, 90);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(76, 12);
this.Label1.TabIndex = 127;
this.Label1.Text = "Middle Name";
// 
// Label43
// 
this.Label43.Location = new System.Drawing.Point(15, 21);
this.Label43.Name = "Label43";
this.Label43.Size = new System.Drawing.Size(64, 14);
this.Label43.TabIndex = 121;
this.Label43.Text = "Account ID";
// 
// Label2
// 
this.Label2.BackColor = System.Drawing.Color.Transparent;
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.ForeColor = System.Drawing.Color.Black;
this.Label2.Location = new System.Drawing.Point(94, 90);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(68, 15);
this.Label2.TabIndex = 125;
this.Label2.Text = "Last Name";
// 
// Label7
// 
this.Label7.BackColor = System.Drawing.Color.Transparent;
this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label7.ForeColor = System.Drawing.Color.Black;
this.Label7.Location = new System.Drawing.Point(241, 90);
this.Label7.Name = "Label7";
this.Label7.Size = new System.Drawing.Size(80, 12);
this.Label7.TabIndex = 126;
this.Label7.Text = "First Name";
// 
// Label37
// 
this.Label37.Location = new System.Drawing.Point(15, 46);
this.Label37.Name = "Label37";
this.Label37.Size = new System.Drawing.Size(84, 14);
this.Label37.TabIndex = 143;
this.Label37.Text = "Account Name";
// 
// txtGuestImage
// 
this.txtGuestImage.Location = new System.Drawing.Point(429, 34);
this.txtGuestImage.Name = "txtGuestImage";
this.txtGuestImage.Size = new System.Drawing.Size(81, 20);
this.txtGuestImage.TabIndex = 145;
this.txtGuestImage.TextChanged += new System.EventHandler(this.txtGuestImage_TextChanged);
// 
// grdGuest
// 
this.grdGuest.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdGuest.AutoSearch = C1.Win.C1FlexGrid.AutoSearchEnum.FromTop;
this.grdGuest.BackColorSel = System.Drawing.SystemColors.Info;
this.grdGuest.Cols = 2;
this.grdGuest.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:38;Caption:\"Account ID\";Visible:False;TextAlign:Left" +
    "Center;TextAlignFixed:CenterCenter;}\t1{Width:104;Caption:\"Name\";TextAlign:LeftCe" +
    "nter;TextAlignFixed:CenterCenter;}\t";
this.grdGuest.ExtendLastCol = true;
this.grdGuest.FixedCols = 0;
this.grdGuest.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdGuest.ForeColorSel = System.Drawing.Color.Black;
this.grdGuest.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdGuest.Location = new System.Drawing.Point(2, 3);
this.grdGuest.Name = "grdGuest";
this.grdGuest.NodeClosedPicture = null;
this.grdGuest.NodeOpenPicture = null;
this.grdGuest.OutlineCol = -1;
this.grdGuest.Rows = 9;
this.grdGuest.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdGuest.Size = new System.Drawing.Size(231, 541);
this.grdGuest.StyleInfo = resources.GetString("grdGuest.StyleInfo");
this.grdGuest.TabIndex = 0;
this.grdGuest.TreeColor = System.Drawing.Color.DarkGray;
this.grdGuest.Click += new System.EventHandler(this.grdGuest_Click);
this.grdGuest.RowColChange += new System.EventHandler(this.grdGuest_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label5);
this.pnlSearch.Controls.Add(this.lblClose);
this.pnlSearch.Controls.Add(this.label22);
this.pnlSearch.Controls.Add(this.label23);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(12, 214);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 46;
this.pnlSearch.Visible = false;
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
// 
// label5
// 
this.label5.BackColor = System.Drawing.Color.Transparent;
this.label5.Enabled = false;
this.label5.Image = ((System.Drawing.Image)(resources.GetObject("label5.Image")));
this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label5.Location = new System.Drawing.Point(200, 99);
this.label5.Name = "label5";
this.label5.Size = new System.Drawing.Size(48, 47);
this.label5.TabIndex = 6;
// 
// lblClose
// 
this.lblClose.BackColor = System.Drawing.Color.SteelBlue;
this.lblClose.Image = ((System.Drawing.Image)(resources.GetObject("lblClose.Image")));
this.lblClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.lblClose.Location = new System.Drawing.Point(229, 3);
this.lblClose.Name = "lblClose";
this.lblClose.Size = new System.Drawing.Size(18, 16);
this.lblClose.TabIndex = 5;
this.lblClose.Click += new System.EventHandler(this.lblClose_Click);
// 
// label22
// 
this.label22.BackColor = System.Drawing.Color.SteelBlue;
this.label22.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
this.label22.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.label22.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.label22.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label22.Location = new System.Drawing.Point(1, 1);
this.label22.Name = "label22";
this.label22.Size = new System.Drawing.Size(247, 21);
this.label22.TabIndex = 0;
this.label22.Text = " Search";
this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label23
// 
this.label23.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label23.Location = new System.Drawing.Point(16, 42);
this.label23.Name = "label23";
this.label23.Size = new System.Drawing.Size(141, 15);
this.label23.TabIndex = 4;
this.label23.Text = "Input Search string here";
// 
// btnCloseSearch
// 
this.btnCloseSearch.BackColor = System.Drawing.SystemColors.Control;
this.btnCloseSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCloseSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCloseSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnCloseSearch.Location = new System.Drawing.Point(126, 97);
this.btnCloseSearch.Name = "btnCloseSearch";
this.btnCloseSearch.Size = new System.Drawing.Size(63, 30);
this.btnCloseSearch.TabIndex = 49;
this.btnCloseSearch.Text = "&Close";
this.btnCloseSearch.UseVisualStyleBackColor = false;
this.btnCloseSearch.Click += new System.EventHandler(this.btnCloseSearch_Click);
// 
// btnFind
// 
this.btnFind.BackColor = System.Drawing.SystemColors.Control;
this.btnFind.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnFind.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnFind.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnFind.Location = new System.Drawing.Point(58, 97);
this.btnFind.Name = "btnFind";
this.btnFind.Size = new System.Drawing.Size(63, 30);
this.btnFind.TabIndex = 48;
this.btnFind.Text = "&Find";
this.btnFind.UseVisualStyleBackColor = false;
this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
// 
// txtSearch
// 
this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F);
this.txtSearch.Location = new System.Drawing.Point(16, 62);
this.txtSearch.Name = "txtSearch";
this.txtSearch.Size = new System.Drawing.Size(221, 22);
this.txtSearch.TabIndex = 47;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// ofdGuestPic
// 
this.ofdGuestPic.Filter = "JPG (* .jpg)|*.jpg|GIF (*.gif)|*.gif| PNG (*.png)|*.png| Bitmap (*.bmp)|* .bmp";
this.ofdGuestPic.Title = "Select Guest Image";
// 
// mnuContactList
// 
this.mnuContactList.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuAddContact,
            this.mnuRemoveContact});
this.mnuContactList.Name = "mnuContactList";
this.mnuContactList.Size = new System.Drawing.Size(118, 48);
// 
// mnuAddContact
// 
this.mnuAddContact.Name = "mnuAddContact";
this.mnuAddContact.Size = new System.Drawing.Size(117, 22);
this.mnuAddContact.Text = "Add";
this.mnuAddContact.Click += new System.EventHandler(this.mnuAddContact_Click);
// 
// mnuRemoveContact
// 
this.mnuRemoveContact.Name = "mnuRemoveContact";
this.mnuRemoveContact.Size = new System.Drawing.Size(117, 22);
this.mnuRemoveContact.Text = "Remove";
this.mnuRemoveContact.Click += new System.EventHandler(this.mnuRemoveContact_Click);
// 
// dtpBirthdate
// 
this.dtpBirthdate.CustomFormat = "MM/dd/yyyy";
this.dtpBirthdate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpBirthdate.Location = new System.Drawing.Point(546, 332);
this.dtpBirthdate.Name = "dtpBirthdate";
this.dtpBirthdate.Size = new System.Drawing.Size(100, 20);
this.dtpBirthdate.TabIndex = 207;
// 
// exportAccountsDialog
// 
this.exportAccountsDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportAccountsDialog_FileOk);
// 
// GuestUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(770, 599);
this.Controls.Add(this.tabAccountManagement);
this.Controls.Add(this.GroupBox2);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.grdGuest);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.dtpBirthdate);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "GuestUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Guest Account";
this.Load += new System.EventHandler(this.GuestUI_Load);
this.Closing += new System.ComponentModel.CancelEventHandler(this.GuestUI_Closing);
this.TextChanged += new System.EventHandler(this.GuestUI_TextChanged);
this.tabAccountManagement.ResumeLayout(false);
this.TabPage7.ResumeLayout(false);
this.TabPage7.PerformLayout();
this.TabPage4.ResumeLayout(false);
this.TabPage4.PerformLayout();
this.tabPage1.ResumeLayout(false);
this.tabPage1.PerformLayout();
this.tabPrivileges.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdGuestPrivilege)).EndInit();
this.tabAcctMgt.ResumeLayout(false);
this.tabAcctMgt.PerformLayout();
this.tabContactPersons.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.gridContactList)).EndInit();
this.gbxCommands.ResumeLayout(false);
this.GroupBox2.ResumeLayout(false);
this.GroupBox2.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.picGuestImg)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudThreshold_Value)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.grdGuest)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.mnuContactList.ResumeLayout(false);
this.ResumeLayout(false);

		}

		#endregion

		#region Variables and Constants

		//private DatasetBinder oDataSetBinder ;
		private FormToObjectInstanceBinder oInstanceBinder;
		private ControlListener oControlListener;

		private Guest oGuest;
		private GuestFacade oGuestFacade;
		private Guest rGuest;
		private Sequence oSequence;
		private OperationMode mOperationMode = OperationMode.Edit;

		private string mFlag;

		#endregion

		#region Constructors

		public GuestUI()
		{
			oGuest = new Guest();
			oSequence = new Sequence();
			oGuestFacade = new GuestFacade();
			oControlListener = new ControlListener();
			//oDataSetBinder = new DatasetBinder();
			oInstanceBinder = new FormToObjectInstanceBinder();
			InitializeComponent();

		}
		public GuestUI(string a_flag, Guest a_sguest)
		{
			oGuest = new Guest();
			oSequence = new Sequence();
			oGuestFacade = new GuestFacade();
			oControlListener = new ControlListener();
			//oDataSetBinder = new DatasetBinder();
			oInstanceBinder = new FormToObjectInstanceBinder();
			mFlag = a_flag;
			rGuest = a_sguest;
			InitializeComponent();

		}

		/* SCR-00101 Line # 4
		* Jerome, April 18, 2008
		* To handle multiple guest(dependent) per room
		*/
        //constructor for Reservation Folio (Dependent Guests)
		private C1.Win.C1FlexGrid.C1FlexGrid grdFolio;
        private string lMode = "";
		public GuestUI(ref C1.Win.C1FlexGrid.C1FlexGrid grid, string pMode)
		{
			oGuest = new Guest();
			oSequence = new Sequence();
			oGuestFacade = new GuestFacade();
			oControlListener = new ControlListener();
			//oDataSetBinder = new DatasetBinder();
			oInstanceBinder = new FormToObjectInstanceBinder();
            lMode = pMode;

			InitializeComponent();

			this.btnSelect.Visible = true;
			grdFolio = grid;
			this.StartPosition = FormStartPosition.CenterScreen;
			this.grdGuest.DoubleClick += new System.EventHandler(this.grdGuest_DoubleClick);

			setActionButtonStates(true);
			this.btnFolioHistory.Visible = false;
			this.btnMergeAccount.Visible = false;

		}
		/* end SRC-00101 Line # 4 */

		#endregion

		#region Methods

		DataView _dtView;
		private void populateDataGrid()
		{
			if (lWhereCondition == "")
			{
				DataTable tempTable = oGuest.Tables[0];
				int totalRows = tempTable.Rows.Count;

				this.grdGuest.Rows = 1;
				this.grdGuest.Rows = totalRows + 1;

		
				int i = 1;
				for (int row = 0; row < totalRows; row++)
				{
					string name = tempTable.Rows[row]["LastName"].ToString() + ", " + tempTable.Rows[row]["FirstName"].ToString();
					string accountID = tempTable.Rows[row]["AccountId"].ToString();

					this.grdGuest.set_TextMatrix(i, 0, accountID);
					this.grdGuest.set_TextMatrix(i, 1, name);

					i++;
				}

			}
			else
			{
				_dtView = oGuest.Tables[0].DefaultView;
				_dtView.RowStateFilter = DataViewRowState.OriginalRows;
				_dtView.RowFilter = lWhereCondition;

				this.grdGuest.Rows = 1;
				this.grdGuest.Rows = _dtView.Count + 1;

				int i = 1;
				//int totalRows = _dtView.Count;
				//for (int row = 0; row < totalRows; row++)
				//{
				//    string name = _dtView[row]["LastName"].ToString() + ", " + _dtView[row]["FirstName"].ToString();
				//    string accountID = _dtView[row]["AccountId"].ToString();

				//    this.grdGuest.set_TextMatrix(i, 0, accountID);
				//    this.grdGuest.set_TextMatrix(i, 1, name);

				//    i++;
				//}


				foreach (DataRowView dRow in _dtView)
				{

					string name = dRow["LastName"].ToString() + ", " + dRow["FirstName"].ToString();
					string accountID = dRow["AccountId"].ToString();

					this.grdGuest.set_TextMatrix(i, 0, accountID);
					this.grdGuest.set_TextMatrix(i, 1, name);

					i++;
				}
			}
		}

		private void bindRowToControls()
		{
			//try
			//{

			//    if (hasChanges())
			//    {
			//        if (MessageBox.Show("Save changes made to Account '" + this.txtLastName.Text + "'", "Save Changes", MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
			//        {
			//            if ( update() )
			//            {
			//                MessageBox.Show("Item successfully updated.", "Guest Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
			//            }
			//            else
			//            {
			//                MessageBox.Show("No rows updated", "Database Update Error");
			//            }
			//        }
			//        else
			//        {
			//            this.BindingContext[oGuest.Tables[0]].CancelCurrentEdit();
			//            this.Text = "Guest Account";

			//        }
			//    }

			oControlListener.StopListen(this);

			//    int location = findItemInDataSet(this.grdGuest.get_TextMatrix(this.grdGuest.Row, 0));
			//    this.BindingContext[oGuest.Tables[0]].Position = location;
			int _row = this.grdGuest.Row;
			string _accountId = this.grdGuest.get_TextMatrix(_row, 0);

			this.txtAccountId.Text = _accountId;

			loadGuestPrivileges(this.txtAccountId.Text);
            loadAccountInformation(this.txtAccountId.Text);
            loadContactPersons(this.txtAccountId.Text);
			//}
			//catch (Exception ex) { MessageBox.Show(ex.Message); }
			//finally
			//{
			//    if (!this.pnlSearch.Visible)
			//    {
			oControlListener.Listen(this);
			//    }
			//}
		}

        private void loadAccountInformation(string pAccountID)
        {
            AccountInformation _oAccountInformation = new AccountInformation(pAccountID, GlobalVariables.gHotelId);
            txtAffiliations.Text = _oAccountInformation.Affiliations;
            txtBoard.Text = _oAccountInformation.OfficeOfficers;
            txtNature.Text = _oAccountInformation.NatureOfBusiness;
            txtPillars.Text = _oAccountInformation.PillarsOfOrganization;
            try
            {
                dtpAnniversary.Value = _oAccountInformation.Anniversary;
            }
            catch
            {
                dtpAnniversary.Value = DateTime.Now;
            }
        }


        private void loadContactPersons(string pAccountID)
        {
            ContactPerson _oContactPerson = new ContactPerson();
            DataTable _dt = _oContactPerson.getContactPersons(pAccountID, GlobalVariables.gHotelId);
            gridContactList.Rows.Count = 1;
            int _row = 1;

            foreach (DataRow _dRow in _dt.Rows)
            {
                gridContactList.Rows.Count++;
                gridContactList.SetData(_row, 0, _dRow["contactID"]);
                gridContactList.SetData(_row, 1, _dRow["lastName"]);
                gridContactList.SetData(_row, 2, _dRow["firstName"]);
                gridContactList.SetData(_row, 3, _dRow["middleName"]);
                gridContactList.SetData(_row, 4, _dRow["designation"]);
                gridContactList.SetData(_row, 5, _dRow["personType"]);
                gridContactList.SetData(_row, 6, _dRow["address"]);
                gridContactList.SetData(_row, 7, _dRow["telNo"]);
                gridContactList.SetData(_row, 8, _dRow["mobileNo"]);
                gridContactList.SetData(_row, 9, _dRow["faxNo"]);
                gridContactList.SetData(_row, 10, _dRow["email"]);
                gridContactList.SetData(_row, 11, _dRow["birthdate"]);
                _row++;
            }
        }

		private void loadGuestPrivileges(string a_AccountId)
		{
			oGuestFacade = new GuestFacade();
			oGuestFacade.getAccountPrivileges(a_AccountId, ref oGuest);

			this.grdGuestPrivilege.Rows.Count = oGuest.AccountPrivileges.Count + 1;
			int i = 1;
			foreach (PrivilegeHeader privilege in oGuest.AccountPrivileges)
			{
				this.grdGuestPrivilege.SetData(i, 0, privilege.PrivilegeID);
				this.grdGuestPrivilege.SetData(i, 1, privilege.Description);
				this.grdGuestPrivilege.SetData(i, 2, privilege.DaysApplied);
				this.grdGuestPrivilege.SetData(i, 3, privilege.CreatedBy);
				this.grdGuestPrivilege.SetData(i, 4, string.Format("{0:dd-MMM-yyyy hh:mm tt}", DateTime.Parse(privilege.CreatedDate)));


				i++;
			}

		}

		private bool isRequiredEntriesFilled()
		{
			if (this.txtLastName.Text.Length == 0 || this.txtFirstName.Text.Length == 0) return false;

			return true;

		}

		private bool hasChanges()
		{
			if (this.Text.IndexOf("*") > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void setActionButtonStates(bool a_stat)
		{
			this.btnDelete.Enabled = a_stat;
			this.btnNew.Enabled = a_stat;
			this.btnSave.Enabled = !a_stat;
			this.btnCancel.Enabled = !a_stat;

			this.btnSelect.Enabled = a_stat;
		}

		private int findItemInDataSet(string a_key)
		{
			if (a_key == "")
				return 0;

			int i = 0;
			foreach (DataRow drGuest in oGuest.Tables[0].Rows)
			{

				if ((string)drGuest["AccountId"] == a_key)
				{
					return i;
				}
				else
				{
					i++;
				}
			}
			return 0;
		}

		private void setOperationMode(OperationMode a_OperationMode)
		{
			mOperationMode = a_OperationMode;
		}

		// Method: SearchItem()
		// Description: Search the List of Currency Codes starting 
		// from the Selected Row down
		// if Not Found then start the Search again from the top..

		private void searchItem()
		{
			bool isFound = false;

			if (!this.txtSearch.Text.Equals(""))
			{
				int i = 0;
				for (i = this.grdGuest.Row + 1; i <= this.grdGuest.Rows - 1; i++)
				{
					if (this.grdGuest.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.grdGuest.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
					{
						this.grdGuest.Row = i;
						isFound = true;
						return;
					}
				}

				if (!isFound)
				{
					for (i = 1; i <= this.grdGuest.Rows - 1; i++)
					{
						if (this.grdGuest.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.grdGuest.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
						{
							this.grdGuest.Row = i;
							isFound = true;
							return;
						}

					}
				}

				MessageBox.Show("No matching record found.");
			}

		}

		#endregion

		#region Data Access Methods

		public bool load()
		{
			try
			{
				oGuest = new Guest();
				oGuestFacade = new GuestFacade();
				oGuest = oGuestFacade.getGuests();

                loadAccountTypes();
				return true;
			}
			catch (Exception)
			{
				return false;
			}

		}

        PrivilegeHeader loPrivilegeHeader = new PrivilegeHeader();
        public void loadAccountTypes()
        {
            PrivilegeFacade _oPrivilegeFacade = new PrivilegeFacade();
            loPrivilegeHeader = (PrivilegeHeader)_oPrivilegeFacade.loadObject();

            DataTable dTable = loPrivilegeHeader.Tables["PrivilegeHeader"];
            for (int i = 0; i <= dTable.Rows.Count - 1; i++)
            {
                cboAccount_Type.Items.Add(dTable.Rows[i]["PrivilegeID"].ToString());
            }

            cboAccount_Type.Items.Add("WALK-IN");
            cboAccount_Type.Items.Add("NONE");
            cboAccount_Type.Items.Add("");
            //cboAccount_Type.DisplayMember = "PrivilegeID";
            //cboAccount_Type.ValueMember = "PrivilegeID";
            //cboAccount_Type.DataSource = _oPrivilegeHeader;
        }

		public void assignEntityValues()
		{
			if (this.nudThreshold_Value.Text == "")
			{
				this.nudThreshold_Value.Value = 0;
				//return;
			}

			FormToObjectInstanceBinder.BindObjectToInputControls(this, oGuest);

			// assigns Account Privilegs
			IList<PrivilegeHeader> privileges = new List<PrivilegeHeader>();
			for (int i = 1; i < this.grdGuestPrivilege.Rows.Count; i++)
			{
				PrivilegeHeader newPriv = new PrivilegeHeader();

				newPriv.PrivilegeID = this.grdGuestPrivilege.GetDataDisplay(i, 0);

				privileges.Add(newPriv);
			}

			oGuest.AccountId = this.txtAccountId.Text;
			oGuest.AccountPrivileges = privileges;

			oGuest.GuestImage = oGuest.GuestImage.Replace(@"\", @"\\");
			oGuest.HotelID = GlobalVariables.gHotelId;
			oGuest.CreatedBy = GlobalVariables.gLoggedOnUser;
			oGuest.CreditCardExpiry = string.Format("{0:yyyy-MM-dd}", this.dtpCreditCardExpiry.Value);
			oGuest.TaxExempted = this.chkTaxExempted.Checked ? 1 : 0;

            AccountInformation _oAccountInformation = new AccountInformation();
            _oAccountInformation.AccountID = txtAccountId.Text;
            _oAccountInformation.HotelID = GlobalVariables.gHotelId;
            _oAccountInformation.Affiliations = txtAffiliations.Text;
            _oAccountInformation.OfficeOfficers = txtBoard.Text;
            _oAccountInformation.PillarsOfOrganization = txtPillars.Text;
            _oAccountInformation.NatureOfBusiness = txtNature.Text;
            _oAccountInformation.Anniversary = dtpAnniversary.Value;

            oGuest.AccountInformation = _oAccountInformation;

            //assign contact persons
            IList<ContactPerson> _contactPersons = new List<ContactPerson>();
            try
            {
                ContactPerson _oContactPerson;
                for (int row = 1; row < gridContactList.Rows.Count; row++)
                {
                    _oContactPerson = new ContactPerson();
                    if (gridContactList.GetDataDisplay(row, 0).ToString() != "")
                    {
                        _oContactPerson.ContactID = gridContactList.GetDataDisplay(row, 0).ToString();
                    }
                    else
                    {
                        _oContactPerson.ContactID = "AUTO";
                    }

                    _oContactPerson.AccountID = txtAccountId.Text;
                    _oContactPerson.HotelID = GlobalVariables.gHotelId.ToString();
                    _oContactPerson.LastName = gridContactList.GetDataDisplay(row, 1).ToString();
                    _oContactPerson.FirstName = gridContactList.GetDataDisplay(row, 2).ToString();
                    _oContactPerson.MiddleName = gridContactList.GetDataDisplay(row, 3).ToString();
                    _oContactPerson.Designation = gridContactList.GetDataDisplay(row, 4).ToString();
                    _oContactPerson.PersonType = gridContactList.GetDataDisplay(row, 5).ToString();
                    _oContactPerson.Address = gridContactList.GetDataDisplay(row, 6).ToString();
                    _oContactPerson.TelNo = gridContactList.GetDataDisplay(row, 7).ToString();
                    _oContactPerson.MobileNo = gridContactList.GetDataDisplay(row, 8).ToString();
                    _oContactPerson.FaxNo = gridContactList.GetDataDisplay(row, 9).ToString();
                    _oContactPerson.Email = gridContactList.GetDataDisplay(row, 10).ToString();
                    try
                    {
                        _oContactPerson.BirthDate = DateTime.Parse(gridContactList.GetDataDisplay(row, 11).ToString());
                    }
                    catch
                    {
                        _oContactPerson.BirthDate = DateTime.Parse("01-01-1900");
                    }

                    _contactPersons.Add(_oContactPerson);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error @assignContactPersons\r\n" + ex.Message);
            }

            oGuest.ContactPersons = _contactPersons;
		}

		public bool insert()
		{
			try
			{
				bool success = false;

				oGuestFacade = new GuestFacade();

                if (!oGuestFacade.checkIfGuestNameExists(oGuest.FirstName, oGuest.LastName))
                {
                    success = oGuestFacade.insertGuest(ref oGuest);
                }
                else
                {
                    if (MessageBox.Show("Guestname already exists!\r\n\r\nDo you want to continue saving this guest?", "Guest Exists", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                    {
                        success = oGuestFacade.insertGuest(ref oGuest);
                    }
                }

				return success;

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		public bool update()
		{
			try
			{
				bool isSuccessful = false;

				object primaryKey;
				primaryKey = this.grdGuest.get_TextMatrix(this.grdGuest.Row, 0);

				oGuestFacade = new GuestFacade();

				isSuccessful = oGuestFacade.updateGuest(ref oGuest);

				return isSuccessful;

			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
				return false;
			}
		}
		public int delete()
		{
			try
			{

				int rowsAffected = 0;
				oGuestFacade = new GuestFacade();
				FormToObjectInstanceBinder.BindObjectToInputControls(this, oGuest);
				rowsAffected = oGuestFacade.deleteGuest(this.txtAccountId.Text, ref oGuest);

				return rowsAffected;
			}
			catch (Exception)
			{
				return 0;
			}
		}

		#endregion

		#region Events
        private ComboBox cboPersonType = new ComboBox();
		private void GuestUI_Load(object sender, System.EventArgs e)
		{

			if (load() == true)
			{
				if (oGuest != null)
				{
					//try
					//{
					object tempGues = oGuest;
					//oDataSetBinder.BindControls((Control)this, ref tempGues, new ArrayList());
					populateDataGrid();

					if (this.grdGuest.Rows > 1)
					{
						this.grdGuest_RowColChange(sender, e);
					}
					//}
					//catch { }
				}

				oControlListener.Listen(this);
			}



			//load Counties & Nationalities list
			AutoCompleteStringCollection _counties = new AutoCompleteStringCollection();
			AutoCompleteStringCollection _nationalities = new AutoCompleteStringCollection();

			foreach (Country _oCountry in GlobalVariables.gCountryList)
			{
				_counties.Add(_oCountry.CountryName);
				_nationalities.Add(_oCountry.Nationality);
			}

			this.txtCountry.AutoCompleteCustomSource = _counties;
			this.txtCitizenship.AutoCompleteCustomSource = _nationalities;
            
            if(ConfigVariables.gIsEMMOnly == "true")
            {
                tabAccountManagement.Controls.Remove(tabPrivileges);
                tabAccountManagement.Controls.Remove(TabPage7);
            }

			setActionButtonStates(true);

            //load person type for contactpersons
            ContactPerson _cotnactPerson = new ContactPerson();
            DataTable _personType = _cotnactPerson.getPersonType();
            cboPersonType.DropDownStyle = ComboBoxStyle.DropDownList;
            foreach (DataRow _dRow in _personType.Rows)
            {
                cboPersonType.Items.Add(_dRow["value"].ToString());
            }
		}

		private void btnNew_Click(System.Object sender, System.EventArgs e)
		{
			oSequence = new Sequence();
			setOperationMode(OperationMode.Add);

			oControlListener.StopListen(this);
			//this.BindingContext[oGuest.Tables["Guests"]].SuspendBinding();

			this.txtAccountId.Text = oSequence.getSequenceId("I-", 12, "seq_Guest");

            //clearForNewEntry();

			this.txtAccountName.Focus();
            gridContactList.Rows.Count = 1;
            FormToObjectInstanceBinder.clearTextboxes(this);
			setActionButtonStates(false);

            //SCR#556 Rolly 10-07-2015 
            clearForNewEntry();
		}

		private void clearForNewEntry()
		{
			this.txtAccountName.Text = "";

			this.txtAccountName.Text = "";
			this.txtLastName.Text = "";
			this.txtFirstName.Text = "";
			this.txtMiddleName.Text = "";
			this.cboSex.SelectedIndex = 0;
			this.txtCitizenship.Text = "";
			this.txtPassportID.Text = "";
			this.txtGuestImage.Text = "";
			this.txtTelephoneNo.Text = "";
			this.txtMobileNo.Text = "";
			this.txtFaxNo.Text = "";
			this.txtStreet.Text = "";
			this.txtCity.Text = "";
			this.txtCountry.Text = "";
			this.txtZip.Text = "";
			this.txtEmailAddress.Text = "";
			this.txtMemo.Text = "";
			this.txtConcierge.Text = "";
			this.txtRemark.Text = "";
			this.txtNoOfVisits.Text = "0";
            this.txtCreateTime.Text = DateTime.Parse(GlobalVariables.gAuditDate + " " + DateTime.Now.ToLongTimeString()).ToString("MM/dd/yyyy hh:mm:ss tt");
			this.dtpBirth_Date.Value = DateTime.Parse("01/01/1900");
			this.cboAccount_Type.Text = "WALK-IN";
			this.txtCard_No.Text = "";
			this.nudThreshold_Value.Text = ConfigVariables.gDefaultGuestThresholdValue;
			this.lblTotal_Sales_Contribution.Text = "0.00";
			this.txtCreditCardType.Text = "";
			this.txtCreditCardNo.Text = "";

			this.grdGuestPrivilege.Rows.Count = 1;

		}

		private void GuestUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (hasChanges())
			{
                assignEntityValues();
				if (MessageBox.Show("Save changes made to Account \'" + this.txtLastName.Text + "\'", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (update())
					{
						MessageBox.Show("Item successfully updated.", "Guest Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
					}
					else
					{
						MessageBox.Show("No rows updated", "Database Update Error");
					}
				}
				else
				{
					this.BindingContext[oGuest.Tables["Guests"]].CancelCurrentEdit();
					this.Text = "Guest Account";

				}
			}
		}

		private void btnSave_Click(System.Object sender, System.EventArgs e)
		{
			if (isRequiredEntriesFilled())
			{

				assignEntityValues();

				switch (mOperationMode)
				{

					case OperationMode.Add:
						if (mFlag == "Reservation")
						{
							FormToObjectInstanceBinder.BindObjectToInputControls(this, rGuest);
						}
						if (insert())
						{
							string name = oGuest.Tables[0].Rows[oGuest.Tables[0].Rows.Count - 1]["LastName"] + ", " + oGuest.Tables[0].Rows[oGuest.Tables[0].Rows.Count - 1]["FirstName"];

							this.grdGuest.Rows++;
							this.grdGuest.set_TextMatrix(this.grdGuest.Rows - 1, 0, oGuest.Tables[0].Rows[oGuest.Tables[0].Rows.Count - 1]["AccountId"].ToString());
							this.grdGuest.set_TextMatrix(this.grdGuest.Rows - 1, 1, name);

							this.grdGuest.Row = this.grdGuest.Rows - 1;
							if (this.btnSelect.Visible == true)
							{
								btnSelect_Click(sender, e);
							}

							this.BindingContext[oGuest.Tables["Guests"]].ResumeBinding();

							this.Text = "Guest Account";
							setActionButtonStates(true);

							oControlListener.Listen(this);

						}
						
						if (mFlag == "Reservation")
						{
							this.Hide();
						}


						break;
					case OperationMode.Edit:
						if (update())
						{
							MessageBox.Show("Item successfully updated.", "Guest Account", MessageBoxButtons.OK, MessageBoxIcon.Information);

							this.grdGuest.set_TextMatrix(this.grdGuest.Row, 1, this.txtLastName.Text + ", " + this.txtFirstName.Text);
							this.BindingContext[oGuest.Tables["Guests"]].ResumeBinding();

							this.Text = "Guest Account";
							oControlListener.Listen(this);
						}
						//else
						//{
						//    MessageBox.Show("No rows updated", "Database Update Error");
						//}
						break;
					default:
						MessageBox.Show("Invalid operation mode", "Abort operation");
						break;
				}
			}
			else
			{
				MessageBox.Show("Please fill-up all highlighted fields..", "Save Error");
				this.txtFirstName.Focus();
				return;
			}
            loadContactPersons(txtAccountId.Text);
		}

		private void btnCancel_Click(System.Object sender, System.EventArgs e)
		{
			DialogResult rsp = MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

			if (rsp == DialogResult.Yes)
			{
				if (mOperationMode.Equals(OperationMode.Add))
				{
					if (this.grdGuest.Rows > 1)
					{
						this.grdGuest.Row = 1;
					}
				}
				else
				{
					this.BindingContext[oGuest.Tables["Guests"]].CancelCurrentEdit();
				}
                this.BindingContext[oGuest.Tables["Guests"]].ResumeBinding();
                int _currentRow = grdGuest.Row;
                grdGuest.Select(0, 0);
                grdGuest.Select(_currentRow, 0);
                this.Text = "Guest Account";
                setActionButtonStates(true);
                mOperationMode = OperationMode.Edit;

                oControlListener.Listen(this);
            }
		}

		private void btnDelete_Click(System.Object sender, System.EventArgs e)
		{
			try
			{
				oControlListener.StopListen(this);
				if (MessageBox.Show("Delete Guest \'" + this.txtAccountName.Text + "\'", "Confirm Delete ", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (delete() > 0)
					{
						this.grdGuest.RemoveItem(this.grdGuest.Row);
					}

				}

			}
			catch (Exception)
			{
				this.grdGuest.RemoveItem(0);
			}
			finally
			{
				this.oControlListener.Listen(this);
			}
		}

		private void GuestUI_TextChanged(object sender, System.EventArgs e)
		{
			if (this.Text.IndexOf('*') > 0)
			{
				setOperationMode(OperationMode.Edit);
				setActionButtonStates(false);
                this.BindingContext[oGuest.Tables["Guests"]].SuspendBinding();
			}
			else
			{
				setActionButtonStates(true);
			}
		}

		private void txtGuestImage_TextChanged(System.Object sender, System.EventArgs e)
		{
			System.Drawing.Image img = null;
			if (this.txtGuestImage.Text != "")
			{
				try
				{
					img = System.Drawing.Image.FromFile(this.txtGuestImage.Text);
					this.picGuestImg.Image = img;
				}
				catch (Exception)
				{
					this.picGuestImg.Image = null;
				}
			}
		}

		private void picGuestImg_Click(System.Object sender, System.EventArgs e)
		{
			if (this.ofdGuestPic.ShowDialog() == DialogResult.OK)
			{
				this.txtGuestImage.Text = ofdGuestPic.FileName;
			}
		}

		private void grdGuest_Click(System.Object sender, System.EventArgs e)
		{
			bindRowToControls();
		}

		private void grdGuest_RowColChange(object sender, System.EventArgs e)
		{
			bindRowToControls();
		}

		private void lblClose_Click(object sender, EventArgs e)
		{
			this.pnlSearch.Visible = false;
		}

		private void pnlSearch_VisibleChanged(object sender, EventArgs e)
		{
			if (pnlSearch.Visible == true)
			{
				this.oControlListener.StopListen(this);
				this.gbxCommands.Enabled = false;
			}
			else
			{
				this.oControlListener.Listen(this);
				this.gbxCommands.Enabled = true;
			}
		}

		private void btnCloseSearch_Click(object sender, EventArgs e)
		{
			this.pnlSearch.Visible = false;
		}

		private void btnFind_Click(object sender, EventArgs e)
		{
			searchItem();
		}

		private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
            oControlListener.StopListen(this);
			if (e.KeyChar == '\r')
			{
				searchItem();
                oControlListener.Listen(this);
            }
		}

		private void txtAccountId_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = true;
		}

		private void Close_Click(System.Object sender, System.EventArgs e)
		{
			this.pnlSearch.Visible = false;
		}

		private void btnSearch_Click(System.Object sender, System.EventArgs e)
		{
			this.pnlSearch.Visible = true;
			this.txtSearch.Focus();
			this.txtSearch.SelectAll();
		}

		#endregion

		string lWhereCondition = "";
		public void showDialog(string pWhereCondition)
		{
			lWhereCondition = pWhereCondition;
			base.ShowDialog();
		}

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		/* SCR-00101 Line # 4
		* Jerome, April 18, 2008
		* To handle multiple guest(dependent) per room
		*/
        private void btnSelect_Click(object sender, EventArgs e)
		{
			int _row = this.grdGuest.Row;

            if (lMode != "REPLACE")
            {
                grdFolio.Rows.Count += 1;
                int lastRow = grdFolio.Rows.Count - 1;

                this.grdFolio.SetData(lastRow, 0, lastRow.ToString());
                this.grdFolio.SetData(lastRow, 1, this.txtAccountId.Text);
                this.grdFolio.SetData(lastRow, 2, this.txtLastName.Text);
                this.grdFolio.SetData(lastRow, 3, this.txtFirstName.Text);
                this.grdFolio.SetData(lastRow, 4, this.txtCitizenship.Text);
                this.grdFolio.SetData(lastRow, 5, this.txtPassportID.Text);

                string address = this.txtStreet.Text + " " + this.txtCity.Text + ", " + this.txtCountry.Text;
                this.grdFolio.SetData(lastRow, 6, address);
                //this.grdGuest.RemoveItem(_row);

                DialogResult rsp = MessageBox.Show("Would you like to add another guest?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (rsp == DialogResult.No)
                {
                    this.Close();
                }
            }
            else
            {
                this.grdFolio.SetData(grdFolio.Row, 0, grdFolio.Row);
                this.grdFolio.SetData(grdFolio.Row, 1, this.txtAccountId.Text);
                this.grdFolio.SetData(grdFolio.Row, 2, this.txtLastName.Text);
                this.grdFolio.SetData(grdFolio.Row, 3, this.txtFirstName.Text);
                this.grdFolio.SetData(grdFolio.Row, 4, this.txtCitizenship.Text);
                this.grdFolio.SetData(grdFolio.Row, 5, this.txtPassportID.Text);

                string address = this.txtStreet.Text + " " + this.txtCity.Text + ", " + this.txtCountry.Text;
                this.grdFolio.SetData(grdFolio.Row, 6, address);
                //this.grdGuest.RemoveItem(grdFolio.Row);

                this.Close();
            }
		}

		private void grdGuest_DoubleClick(object sender, EventArgs e)
		{
			this.btnSelect_Click(sender, e);
		}

		private void picGuestImg_MouseHover(object sender, EventArgs e)
		{
			if (picGuestImg.Image != null)
			{
				this.picGuestImg.Size = new System.Drawing.Size(200, 180);
				this.picGuestImg.Location = new System.Drawing.Point(311, 16);
			}
		}

		private void picGuestImg_MouseLeave(object sender, EventArgs e)
		{
			this.picGuestImg.Size = new System.Drawing.Size(88, 72);
			this.picGuestImg.Location = new System.Drawing.Point(424, 16);
		}

		private void btnAddPrivilege_Click(object sender, EventArgs e)
		{
			PrivilegeHeaderUI privilegeUI = new PrivilegeHeaderUI(ref this.grdGuestPrivilege);
			privilegeUI.ShowDialog();

			if (mOperationMode != OperationMode.Add)
			{
				this.Text = "Guest Account*";
			}

		}

		private void btnRemovePrivilege_Click(object sender, EventArgs e)
		{
			try
			{
				int row = this.grdGuestPrivilege.Row;

				DialogResult rsp = MessageBox.Show("Remove selected privilege?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (rsp == DialogResult.Yes)
					this.grdGuestPrivilege.RemoveItem(row);

                if (mOperationMode != OperationMode.Add)
                {
                    this.Text = "Guest Account*";
                }
			}
			catch
			{ }
		}

		private void btnFolioHistory_Click(object sender, EventArgs e)
		{
			// load Folio History from Reservation Module
			// uses Assembly to avoid Cross-reference problem
			// Jerome, April 26, 2008
			string accountId = this.txtAccountId.Text;
			string name = this.txtLastName.Text + ", " + this.txtFirstName.Text;

            /* Gene
             * 05-Mar-12
             * Specified the startup path of event plus
             * This fixes the error where the system will locate the reservation dll from the last path used in an export or import process previously made
             */
            // Old Code
            //Assembly asm = Assembly.LoadFrom("Reservation.dll");
            Assembly asm = Assembly.LoadFrom(Application.StartupPath + "\\Reservation.dll");
			Type t = asm.GetType("Jinisys.Hotel.Reservation.Presentation.BrowseFolioHistoryUI");

			Type[] paramTypes = { typeof(System.String), typeof(System.String) };
			object[] objParams = { accountId, name };
			ConstructorInfo ci = t.GetConstructor(paramTypes);
			Form frm = (Form)ci.Invoke(objParams);

			frm.MdiParent = this.MdiParent;
			frm.Show();
		}

		private void btnMergeAccount_Click(object sender, EventArgs e)
		{
			MergeAccountUI mergeUI = new MergeAccountUI();
			mergeUI.MdiParent = this.MdiParent;
			mergeUI.Show();

			this.Close();
		}

		private void lblTotal_Sales_Contribution_TextChanged(object sender, EventArgs e)
		{
			try
			{
				this.lblTotal_Sales_Contribution.Text = double.Parse(this.lblTotal_Sales_Contribution.Text).ToString("N");
			}
			catch { }
		}


		private void txtCitizenship_TextChanged(object sender, EventArgs e)
		{
			string _citizenship = this.txtCitizenship.Text;

			if (_citizenship.Trim().Length > 0)
			{

				foreach (Country _oCountry in GlobalVariables.gCountryList)
				{
					if (_oCountry.Nationality == _citizenship)
					{
						this.txtCountry.Text = _oCountry.CountryName;
					}
				}
			}
		}

		private void txtCountry_TextChanged(object sender, EventArgs e)
		{
			string _country = this.txtCountry.Text;

			if (_country.Trim().Length > 0)
			{

				foreach (Country _oCountry in GlobalVariables.gCountryList)
				{
					if (_oCountry.CountryName == _country)
					{
						this.txtCitizenship.Text = _oCountry.Nationality;
					}
				}
			}
		}

		private void txtAccountId_TextChanged(object sender, EventArgs e)
		{
			//_dtView.RowStateFilter = DataViewRowState.OriginalRows;
			//_dtView.RowFilter = "AccountId = '" + this.txtAccountId.Text + "'";
			DataTable tempTable = oGuest.Tables[0];
			int totalRows = tempTable.Rows.Count;

			for (int row = 0; row < totalRows; row++)
			{ 
				string _acccountID = tempTable.Rows[row]["AccountId"].ToString();

				if (_acccountID == this.txtAccountId.Text)
				{
					    this.txtAccountName.Text = tempTable.Rows[row]["AccountName"].ToString();

					    this.txtTitle.Text = tempTable.Rows[row]["Title"].ToString();
					    this.txtLastName.Text = tempTable.Rows[row]["LastName"].ToString();
					    this.txtFirstName.Text = tempTable.Rows[row]["FirstName"].ToString();
					    this.txtMiddleName.Text = tempTable.Rows[row]["MiddleName"].ToString();
					    this.cboSex.Text = tempTable.Rows[row]["Sex"].ToString();
					    this.txtCitizenship.Text = tempTable.Rows[row]["Citizenship"].ToString();
					    this.txtPassportID.Text = tempTable.Rows[row]["PassportId"].ToString();
					    this.txtGuestImage.Text = tempTable.Rows[row]["GuestImage"].ToString();
					    this.txtTelephoneNo.Text = tempTable.Rows[row]["TelephoneNo"].ToString();
					    this.txtMobileNo.Text = tempTable.Rows[row]["MobileNo"].ToString();
					    this.txtFaxNo.Text = tempTable.Rows[row]["FaxNo"].ToString();
					    this.txtStreet.Text = tempTable.Rows[row]["Street"].ToString();
					    this.txtCity.Text = tempTable.Rows[row]["City"].ToString();
					    this.txtCountry.Text = tempTable.Rows[row]["Country"].ToString();
					    this.txtZip.Text = tempTable.Rows[row]["Zip"].ToString();
					    this.txtEmailAddress.Text = tempTable.Rows[row]["EmailAddress"].ToString();
					    this.txtMemo.Text = tempTable.Rows[row]["Memo"].ToString();
					    this.txtConcierge.Text = tempTable.Rows[row]["Concierge"].ToString();
					    this.txtRemark.Text = tempTable.Rows[row]["Remark"].ToString();
					    this.txtNoOfVisits.Text = tempTable.Rows[row]["NoOfVisits"].ToString();
					    //this.txtHotelID.Text = dtRow["HotelID"].ToString();
					    this.txtCreateTime.Text = tempTable.Rows[row]["CreateTime"].ToString();
					    //this.txtCreatedBy.Text = dtRow["CreatedBy"].ToString();
					    //.txtUpdateTime.Text = dtRow["UpdateTime"].ToString();
					    //this.txtUpdatedBy.Text = dtRow["UpdatedBy"].ToString();
					    //this.txtAccountName.Text = dtRow["AccountPrivileges"].ToString();
					    this.dtpBirth_Date.Value = DateTime.Parse( tempTable.Rows[row]["BIRTH_DATE"].ToString() );
					    this.cboAccount_Type.Text = tempTable.Rows[row]["ACCOUNT_TYPE"].ToString();
					    this.txtCard_No.Text = tempTable.Rows[row]["CARD_NO"].ToString();
					    this.nudThreshold_Value.Text = tempTable.Rows[row]["THRESHOLD_VALUE"].ToString();
					    this.lblTotal_Sales_Contribution.Text = tempTable.Rows[row]["TOTAL_SALES_CONTRIBUTION"].ToString();
					    this.txtCreditCardType.Text = tempTable.Rows[row]["CreditCardType"].ToString();
					    this.txtCreditCardNo.Text = tempTable.Rows[row]["CreditCardNo"].ToString();

					    try
					    {
					        this.dtpCreditCardExpiry.Value = DateTime.Parse(tempTable.Rows[row]["CreditCardExpiry"].ToString());
					    }
					    catch { }

					    this.chkTaxExempted.Checked = tempTable.Rows[row]["TaxExempted"].ToString() == "1" ? true: false;

					break;
					}
					
				}

		}
			//if (_dtView.Count > 0)
			//{
			//    DataRowView dtRow = _dtView[0];

			//    this.txtAccountName.Text = dtRow["AccountName"].ToString();

			//    this.txtTitle.Text = dtRow["Title"].ToString();
			//    this.txtLastName.Text = dtRow["LastName"].ToString();
			//    this.txtFirstName.Text = dtRow["FirstName"].ToString();
			//    this.txtMiddleName.Text = dtRow["MiddleName"].ToString();
			//    this.cboSex.Text = dtRow["Sex"].ToString();
			//    this.txtCitizenship.Text = dtRow["Citizenship"].ToString();
			//    this.txtPassportID.Text = dtRow["PassportId"].ToString();
			//    this.txtGuestImage.Text = dtRow["GuestImage"].ToString();
			//    this.txtTelephoneNo.Text = dtRow["TelephoneNo"].ToString();
			//    this.txtMobileNo.Text = dtRow["MobileNo"].ToString();
			//    this.txtFaxNo.Text = dtRow["FaxNo"].ToString();
			//    this.txtStreet.Text = dtRow["Street"].ToString();
			//    this.txtCity.Text = dtRow["City"].ToString();
			//    this.txtCountry.Text = dtRow["Country"].ToString();
			//    this.txtZip.Text = dtRow["Zip"].ToString();
			//    this.txtEmailAddress.Text = dtRow["EmailAddress"].ToString();
			//    this.txtMemo.Text = dtRow["Memo"].ToString();
			//    this.txtConcierge.Text = dtRow["Concierge"].ToString();
			//    this.txtRemark.Text = dtRow["Remark"].ToString();
			//    this.txtNoOfVisits.Text = dtRow["NoOfVisits"].ToString();
			//    //this.txtHotelID.Text = dtRow["HotelID"].ToString();
			//    this.txtCreateTime.Text = dtRow["CreateTime"].ToString();
			//    //this.txtCreatedBy.Text = dtRow["CreatedBy"].ToString();
			//    //.txtUpdateTime.Text = dtRow["UpdateTime"].ToString();
			//    //this.txtUpdatedBy.Text = dtRow["UpdatedBy"].ToString();
			//    //this.txtAccountName.Text = dtRow["AccountPrivileges"].ToString();
			//    this.dtpBirth_Date.Value = DateTime.Parse( dtRow["BIRTH_DATE"].ToString() );
			//    this.cboAccount_Type.Text = dtRow["ACCOUNT_TYPE"].ToString();
			//    this.txtCard_No.Text = dtRow["CARD_NO"].ToString();
			//    this.nudThreshold_Value.Text = dtRow["THRESHOLD_VALUE"].ToString();
			//    this.lblTotal_Sales_Contribution.Text = dtRow["TOTAL_SALES_CONTRIBUTION"].ToString();
			//    this.txtCreditCardType.Text = dtRow["CreditCardType"].ToString();
			//    this.txtCreditCardNo.Text = dtRow["CreditCardNo"].ToString();
				
			//    try
			//    {
			//        this.dtpCreditCardExpiry.Value = DateTime.Parse(dtRow["CreditCardExpiry"].ToString());
			//    }
			//    catch { }

			//    this.chkTaxExempted.Checked = dtRow["TaxExempted"].ToString() == "1" ? true: false;

			//}

		//}

		private void cboAccount_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            grdGuestPrivilege.Rows.Count = 1;
            try
            {
                DataTable dTable = loPrivilegeHeader.Tables["PrivilegeHeader"];
                for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                {
                    if (dTable.Rows[i]["PrivilegeID"].ToString() == cboAccount_Type.Text)
                    {
                        grdGuestPrivilege.Rows.Count++;
                        grdGuestPrivilege.SetData(1, 0, dTable.Rows[i]["PrivilegeID"].ToString());
                        grdGuestPrivilege.SetData(1, 1, dTable.Rows[i]["Description"].ToString());
                        grdGuestPrivilege.SetData(1, 2, dTable.Rows[i]["DaysApplied"].ToString());
                        grdGuestPrivilege.SetData(1, 3, GlobalVariables.gLoggedOnUser);
                        grdGuestPrivilege.SetData(1, 4, DateTime.Now.ToString("yyyy-MMM-dd"));
                        break;
                    }
                }
            }
            catch { }
        }

        private void gridContactList_MouseClick(object sender, MouseEventArgs e)
        {
            try
            {
                if (e.Button == MouseButtons.Right)
                {
                    System.Drawing.Point point = new System.Drawing.Point(e.X, e.Y);

                    this.mnuAddContact.Enabled = true;
                    this.mnuRemoveContact.Enabled = true;
                    mnuContactList.Show(this.gridContactList, point);
                }
            }
            catch (Exception)
            {

            }
        }

        private void mnuAddContact_Click(object sender, EventArgs e)
        {
            gridContactList.Rows.Count++;
            gridContactList.SetData(gridContactList.Rows.Count - 1, 5, cboPersonType.Items[0].ToString());
        }

        private void mnuRemoveContact_Click(object sender, EventArgs e)
        {
            gridContactList.RemoveItem(gridContactList.Row);
        }

        private void gridContactList_BeforeEdit(object sender, RowColEventArgs e)
        {
            if (e.Col == 11)
            {
                gridContactList.Cols[11].Editor = dtpBirthdate;
            }
            if (e.Col == 5)
            {
                gridContactList.Cols[5].Editor = cboPersonType;
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            exportAccountsDialog.Filter = "Excel Files (*.xls)|*.xls";
            exportAccountsDialog.ShowDialog();
        }

        private void exportAccountsDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                grdGuest.SaveExcel(exportAccountsDialog.FileName);
            }
            catch
            {

            }
        }
	}
		
	
}
