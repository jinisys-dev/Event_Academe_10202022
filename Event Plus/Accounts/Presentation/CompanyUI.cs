using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Accounts.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

using Jinisys.Hotel.ConfigurationHotel.Presentation;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using System.Collections.Generic;
using System.Reflection;
using Jinisys.Hotel.Security.BusinessLayer;

namespace Jinisys.Hotel.Accounts.Presentation
{
	
		public class CompanyUI : Maintenance2UI
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
			internal System.Windows.Forms.TabControl TabControl2;
			internal System.Windows.Forms.TabPage TabPage7;
			public System.Windows.Forms.TextBox txtCountry2;
			public System.Windows.Forms.TextBox txtZip2;
			public System.Windows.Forms.TextBox txtStreet2;
			public System.Windows.Forms.TextBox txtCity2;
			public System.Windows.Forms.Label Label32;
			public System.Windows.Forms.Label Label46;
			public System.Windows.Forms.Label Label47;
			public System.Windows.Forms.Label Label31;
			public System.Windows.Forms.Label Label9;
			public System.Windows.Forms.Label Label10;
			public System.Windows.Forms.Label Label11;
			public System.Windows.Forms.TextBox txtCity1;
			public System.Windows.Forms.TextBox txtStreet1;
			public System.Windows.Forms.TextBox txtZip1;
			public System.Windows.Forms.TextBox txtCountry1;
			public System.Windows.Forms.Label Label12;
			public System.Windows.Forms.Label Label13;
			public System.Windows.Forms.Label Label14;
			public System.Windows.Forms.Label Label15;
			public System.Windows.Forms.Label Label16;
			public System.Windows.Forms.TextBox txtCity3;
			public System.Windows.Forms.TextBox txtStreet3;
			public System.Windows.Forms.TextBox txtZip3;
			public System.Windows.Forms.TextBox txtCountry3;
			public System.Windows.Forms.Label Label17;
			public System.Windows.Forms.Label Label18;
			internal System.Windows.Forms.TabPage TabPage8;
			public System.Windows.Forms.TextBox txtContactNumber3;
			public System.Windows.Forms.ComboBox cboContacttype3;
			public System.Windows.Forms.Label Label25;
			public System.Windows.Forms.Label Label26;
			public System.Windows.Forms.Label Label28;
			public System.Windows.Forms.TextBox txtContactNumber2;
			public System.Windows.Forms.ComboBox cboContacttype2;
			public System.Windows.Forms.Label Label21;
			public System.Windows.Forms.Label Label22;
			public System.Windows.Forms.Label Label24;
			public System.Windows.Forms.TextBox txtContactNumber1;
			public System.Windows.Forms.ComboBox cboContacttype1;
			public System.Windows.Forms.Label Label76;
			public System.Windows.Forms.Label Label20;
			public System.Windows.Forms.Label Label74;
			internal System.Windows.Forms.TabPage TabPage9;
			public System.Windows.Forms.Label Label33;
			public System.Windows.Forms.TextBox txtEmail3;
			public System.Windows.Forms.Label Label30;
			public System.Windows.Forms.TextBox txtEmail2;
			public System.Windows.Forms.Label Label29;
			public System.Windows.Forms.TextBox txtEmail1;
			internal System.Windows.Forms.GroupBox GroupBox2;
			public System.Windows.Forms.TextBox txtCompanyId;
			public System.Windows.Forms.Label Label43;
			public System.Windows.Forms.Label Label40;
			public System.Windows.Forms.TextBox txtCompanyCode;
			public System.Windows.Forms.Label Label23;
			public System.Windows.Forms.Label Label38;
			public System.Windows.Forms.TextBox txtContactPerson;
			public System.Windows.Forms.Label Label39;
			public System.Windows.Forms.TextBox txtDesignation;
			public System.Windows.Forms.Label Label27;
			public System.Windows.Forms.TextBox txtCompanyURL;
			public System.Windows.Forms.TextBox txtCompanyName;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnSearch;
            internal System.Windows.Forms.Label Label19;
            internal Panel pnlSearch;
            private Label label5;
            internal Label lblClose;
            internal Label label1;
            internal Label label2;
            internal Button btnCloseSearch;
            internal Button btnFind;
            internal TextBox txtSearch;
            internal Button btnClose;
			private TabPage tabPrivileges;
			internal Button btnRemovePrivilege;
			internal Button btnAddPrivilege;
			public TextBox txtCARD_NO;
			public Label label3;
			private NumericUpDown nudTHRESHOLD_VALUE;
			public Label label4;
			public TextBox txtCREATETIME;
			public Label label6;
			internal ComboBox cboACCOUNT_TYPE;
			public Label label7;
			public Label label8;
			public TextBox txtNO_OF_VISIT;
			public Label Label35;
			internal Button btnFolioHistory;
			private NumericUpDown nudX_DEAL_AMOUNT;
			public Label label34;
			internal Button btnMergeAccount;
			public Label lblTOTAL_SALES_CONTRIBUTED;
			private TabPage tabRemarks;
			public TextBox txtREMARKS;
			private C1.Win.C1FlexGrid.C1FlexGrid grdGuestPrivilege;
            private TabPage tabAcctMgt;
            private TextBox txtAffiliations;
            private Label label36;
            private TextBox txtBoard;
            private Label label37;
            private Label label41;
            private TextBox txtNature;
            private Label label42;
            private Label label44;
            private TextBox txtPillars;
            private DateTimePicker dtpAnniversary;
            private Panel panel2;
            private Panel panel1;
            private TabPage tabContactPersons;
            private C1.Win.C1FlexGrid.C1FlexGrid gridContactList;
            private ContextMenuStrip mnuContactList;
            private ToolStripMenuItem mnuAddContact;
            private ToolStripMenuItem mnuRemoveContact;
            private DateTimePicker dtpBirthdate;
            private Label label45;
            private TextBox txtTIN;
            internal Button btnExport;
            private SaveFileDialog exportAccountDialog;
            private TabPage tabJournal;
            private C1.Win.C1FlexGrid.C1FlexGrid grdJournal;
            private DateTimePicker dtJournal;
            private GroupBox groupBox1;
			internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdCompany;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
this.components = new System.ComponentModel.Container();
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CompanyUI));
this.TabControl2 = new System.Windows.Forms.TabControl();
this.TabPage7 = new System.Windows.Forms.TabPage();
this.txtCountry2 = new System.Windows.Forms.TextBox();
this.txtZip2 = new System.Windows.Forms.TextBox();
this.txtStreet2 = new System.Windows.Forms.TextBox();
this.txtCity2 = new System.Windows.Forms.TextBox();
this.Label32 = new System.Windows.Forms.Label();
this.Label46 = new System.Windows.Forms.Label();
this.Label47 = new System.Windows.Forms.Label();
this.Label31 = new System.Windows.Forms.Label();
this.Label9 = new System.Windows.Forms.Label();
this.Label12 = new System.Windows.Forms.Label();
this.Label15 = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.txtCity3 = new System.Windows.Forms.TextBox();
this.txtStreet3 = new System.Windows.Forms.TextBox();
this.txtZip3 = new System.Windows.Forms.TextBox();
this.txtCountry3 = new System.Windows.Forms.TextBox();
this.Label17 = new System.Windows.Forms.Label();
this.Label18 = new System.Windows.Forms.Label();
this.Label19 = new System.Windows.Forms.Label();
this.TabPage8 = new System.Windows.Forms.TabPage();
this.txtContactNumber3 = new System.Windows.Forms.TextBox();
this.cboContacttype3 = new System.Windows.Forms.ComboBox();
this.Label25 = new System.Windows.Forms.Label();
this.Label26 = new System.Windows.Forms.Label();
this.Label28 = new System.Windows.Forms.Label();
this.txtContactNumber2 = new System.Windows.Forms.TextBox();
this.cboContacttype2 = new System.Windows.Forms.ComboBox();
this.Label21 = new System.Windows.Forms.Label();
this.Label22 = new System.Windows.Forms.Label();
this.Label24 = new System.Windows.Forms.Label();
this.Label76 = new System.Windows.Forms.Label();
this.TabPage9 = new System.Windows.Forms.TabPage();
this.Label33 = new System.Windows.Forms.Label();
this.txtEmail3 = new System.Windows.Forms.TextBox();
this.Label30 = new System.Windows.Forms.Label();
this.txtEmail2 = new System.Windows.Forms.TextBox();
this.tabRemarks = new System.Windows.Forms.TabPage();
this.txtREMARKS = new System.Windows.Forms.TextBox();
this.tabPrivileges = new System.Windows.Forms.TabPage();
this.grdGuestPrivilege = new C1.Win.C1FlexGrid.C1FlexGrid();
this.btnRemovePrivilege = new System.Windows.Forms.Button();
this.btnAddPrivilege = new System.Windows.Forms.Button();
this.tabAcctMgt = new System.Windows.Forms.TabPage();
this.dtpAnniversary = new System.Windows.Forms.DateTimePicker();
this.txtPillars = new System.Windows.Forms.TextBox();
this.label44 = new System.Windows.Forms.Label();
this.label42 = new System.Windows.Forms.Label();
this.txtNature = new System.Windows.Forms.TextBox();
this.label41 = new System.Windows.Forms.Label();
this.txtBoard = new System.Windows.Forms.TextBox();
this.label37 = new System.Windows.Forms.Label();
this.txtAffiliations = new System.Windows.Forms.TextBox();
this.label36 = new System.Windows.Forms.Label();
this.tabContactPersons = new System.Windows.Forms.TabPage();
this.gridContactList = new C1.Win.C1FlexGrid.C1FlexGrid();
this.tabJournal = new System.Windows.Forms.TabPage();
this.grdJournal = new C1.Win.C1FlexGrid.C1FlexGrid();
this.dtJournal = new System.Windows.Forms.DateTimePicker();
this.Label10 = new System.Windows.Forms.Label();
this.Label11 = new System.Windows.Forms.Label();
this.txtCity1 = new System.Windows.Forms.TextBox();
this.txtStreet1 = new System.Windows.Forms.TextBox();
this.txtZip1 = new System.Windows.Forms.TextBox();
this.txtCountry1 = new System.Windows.Forms.TextBox();
this.Label13 = new System.Windows.Forms.Label();
this.Label14 = new System.Windows.Forms.Label();
this.txtContactNumber1 = new System.Windows.Forms.TextBox();
this.cboContacttype1 = new System.Windows.Forms.ComboBox();
this.Label20 = new System.Windows.Forms.Label();
this.Label74 = new System.Windows.Forms.Label();
this.Label29 = new System.Windows.Forms.Label();
this.txtEmail1 = new System.Windows.Forms.TextBox();
this.GroupBox2 = new System.Windows.Forms.GroupBox();
this.Label27 = new System.Windows.Forms.Label();
this.groupBox1 = new System.Windows.Forms.GroupBox();
this.panel2 = new System.Windows.Forms.Panel();
this.txtCompanyCode = new System.Windows.Forms.TextBox();
this.Label40 = new System.Windows.Forms.Label();
this.txtCompanyName = new System.Windows.Forms.TextBox();
this.Label23 = new System.Windows.Forms.Label();
this.txtCompanyURL = new System.Windows.Forms.TextBox();
this.panel1 = new System.Windows.Forms.Panel();
this.txtTIN = new System.Windows.Forms.TextBox();
this.label45 = new System.Windows.Forms.Label();
this.txtCREATETIME = new System.Windows.Forms.TextBox();
this.label6 = new System.Windows.Forms.Label();
this.lblTOTAL_SALES_CONTRIBUTED = new System.Windows.Forms.Label();
this.nudX_DEAL_AMOUNT = new System.Windows.Forms.NumericUpDown();
this.label34 = new System.Windows.Forms.Label();
this.txtCARD_NO = new System.Windows.Forms.TextBox();
this.label3 = new System.Windows.Forms.Label();
this.nudTHRESHOLD_VALUE = new System.Windows.Forms.NumericUpDown();
this.label4 = new System.Windows.Forms.Label();
this.cboACCOUNT_TYPE = new System.Windows.Forms.ComboBox();
this.label7 = new System.Windows.Forms.Label();
this.label8 = new System.Windows.Forms.Label();
this.txtNO_OF_VISIT = new System.Windows.Forms.TextBox();
this.Label35 = new System.Windows.Forms.Label();
this.txtCompanyId = new System.Windows.Forms.TextBox();
this.Label43 = new System.Windows.Forms.Label();
this.Label38 = new System.Windows.Forms.Label();
this.txtContactPerson = new System.Windows.Forms.TextBox();
this.Label39 = new System.Windows.Forms.Label();
this.txtDesignation = new System.Windows.Forms.TextBox();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnMergeAccount = new System.Windows.Forms.Button();
this.btnFolioHistory = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnExport = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grdCompany = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label5 = new System.Windows.Forms.Label();
this.lblClose = new System.Windows.Forms.Label();
this.label1 = new System.Windows.Forms.Label();
this.label2 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.mnuContactList = new System.Windows.Forms.ContextMenuStrip(this.components);
this.mnuAddContact = new System.Windows.Forms.ToolStripMenuItem();
this.mnuRemoveContact = new System.Windows.Forms.ToolStripMenuItem();
this.dtpBirthdate = new System.Windows.Forms.DateTimePicker();
this.exportAccountDialog = new System.Windows.Forms.SaveFileDialog();
this.TabControl2.SuspendLayout();
this.TabPage7.SuspendLayout();
this.TabPage8.SuspendLayout();
this.TabPage9.SuspendLayout();
this.tabRemarks.SuspendLayout();
this.tabPrivileges.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdGuestPrivilege)).BeginInit();
this.tabAcctMgt.SuspendLayout();
this.tabContactPersons.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.gridContactList)).BeginInit();
this.tabJournal.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdJournal)).BeginInit();
this.GroupBox2.SuspendLayout();
this.groupBox1.SuspendLayout();
this.panel2.SuspendLayout();
this.panel1.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudX_DEAL_AMOUNT)).BeginInit();
((System.ComponentModel.ISupportInitialize)(this.nudTHRESHOLD_VALUE)).BeginInit();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdCompany)).BeginInit();
this.pnlSearch.SuspendLayout();
this.mnuContactList.SuspendLayout();
this.SuspendLayout();
// 
// TabControl2
// 
this.TabControl2.Controls.Add(this.TabPage7);
this.TabControl2.Controls.Add(this.TabPage8);
this.TabControl2.Controls.Add(this.TabPage9);
this.TabControl2.Controls.Add(this.tabRemarks);
this.TabControl2.Controls.Add(this.tabPrivileges);
this.TabControl2.Controls.Add(this.tabAcctMgt);
this.TabControl2.Controls.Add(this.tabContactPersons);
this.TabControl2.Controls.Add(this.tabJournal);
this.TabControl2.Location = new System.Drawing.Point(237, 234);
this.TabControl2.Multiline = true;
this.TabControl2.Name = "TabControl2";
this.TabControl2.SelectedIndex = 0;
this.TabControl2.Size = new System.Drawing.Size(542, 293);
this.TabControl2.TabIndex = 13;
// 
// TabPage7
// 
this.TabPage7.Controls.Add(this.txtCountry2);
this.TabPage7.Controls.Add(this.txtZip2);
this.TabPage7.Controls.Add(this.txtStreet2);
this.TabPage7.Controls.Add(this.txtCity2);
this.TabPage7.Controls.Add(this.Label32);
this.TabPage7.Controls.Add(this.Label46);
this.TabPage7.Controls.Add(this.Label47);
this.TabPage7.Controls.Add(this.Label31);
this.TabPage7.Controls.Add(this.Label9);
this.TabPage7.Controls.Add(this.Label12);
this.TabPage7.Controls.Add(this.Label15);
this.TabPage7.Controls.Add(this.Label16);
this.TabPage7.Controls.Add(this.txtCity3);
this.TabPage7.Controls.Add(this.txtStreet3);
this.TabPage7.Controls.Add(this.txtZip3);
this.TabPage7.Controls.Add(this.txtCountry3);
this.TabPage7.Controls.Add(this.Label17);
this.TabPage7.Controls.Add(this.Label18);
this.TabPage7.Controls.Add(this.Label19);
this.TabPage7.Location = new System.Drawing.Point(4, 42);
this.TabPage7.Name = "TabPage7";
this.TabPage7.Size = new System.Drawing.Size(534, 247);
this.TabPage7.TabIndex = 0;
this.TabPage7.Text = "Address";
this.TabPage7.UseVisualStyleBackColor = true;
// 
// txtCountry2
// 
this.txtCountry2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCountry2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCountry2.Location = new System.Drawing.Point(296, 125);
this.txtCountry2.MaxLength = 100;
this.txtCountry2.Name = "txtCountry2";
this.txtCountry2.Size = new System.Drawing.Size(123, 20);
this.txtCountry2.TabIndex = 20;
// 
// txtZip2
// 
this.txtZip2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtZip2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtZip2.Location = new System.Drawing.Point(428, 125);
this.txtZip2.MaxLength = 100;
this.txtZip2.Name = "txtZip2";
this.txtZip2.Size = new System.Drawing.Size(64, 20);
this.txtZip2.TabIndex = 21;
// 
// txtStreet2
// 
this.txtStreet2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtStreet2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtStreet2.Location = new System.Drawing.Point(22, 125);
this.txtStreet2.MaxLength = 100;
this.txtStreet2.Name = "txtStreet2";
this.txtStreet2.Size = new System.Drawing.Size(120, 20);
this.txtStreet2.TabIndex = 18;
// 
// txtCity2
// 
this.txtCity2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCity2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCity2.Location = new System.Drawing.Point(151, 125);
this.txtCity2.MaxLength = 100;
this.txtCity2.Name = "txtCity2";
this.txtCity2.Size = new System.Drawing.Size(136, 20);
this.txtCity2.TabIndex = 19;
// 
// Label32
// 
this.Label32.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label32.ForeColor = System.Drawing.Color.Black;
this.Label32.Location = new System.Drawing.Point(296, 109);
this.Label32.Name = "Label32";
this.Label32.Size = new System.Drawing.Size(58, 16);
this.Label32.TabIndex = 82;
this.Label32.Text = "Country ";
// 
// Label46
// 
this.Label46.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label46.ForeColor = System.Drawing.Color.Black;
this.Label46.Location = new System.Drawing.Point(429, 109);
this.Label46.Name = "Label46";
this.Label46.Size = new System.Drawing.Size(64, 16);
this.Label46.TabIndex = 81;
this.Label46.Text = "ZIP ";
// 
// Label47
// 
this.Label47.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label47.ForeColor = System.Drawing.Color.Black;
this.Label47.Location = new System.Drawing.Point(153, 109);
this.Label47.Name = "Label47";
this.Label47.Size = new System.Drawing.Size(29, 16);
this.Label47.TabIndex = 83;
this.Label47.Text = "City ";
// 
// Label31
// 
this.Label31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label31.ForeColor = System.Drawing.Color.Black;
this.Label31.Location = new System.Drawing.Point(22, 109);
this.Label31.Name = "Label31";
this.Label31.Size = new System.Drawing.Size(58, 16);
this.Label31.TabIndex = 80;
this.Label31.Text = "Street ";
// 
// Label9
// 
this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label9.ForeColor = System.Drawing.Color.Black;
this.Label9.Location = new System.Drawing.Point(16, 85);
this.Label9.Name = "Label9";
this.Label9.Size = new System.Drawing.Size(79, 16);
this.Label9.TabIndex = 80;
this.Label9.Text = "Address 2 :";
// 
// Label12
// 
this.Label12.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label12.ForeColor = System.Drawing.Color.Black;
this.Label12.Location = new System.Drawing.Point(16, 15);
this.Label12.Name = "Label12";
this.Label12.Size = new System.Drawing.Size(79, 16);
this.Label12.TabIndex = 80;
this.Label12.Text = "Address 1 :";
// 
// Label15
// 
this.Label15.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label15.ForeColor = System.Drawing.Color.Black;
this.Label15.Location = new System.Drawing.Point(153, 189);
this.Label15.Name = "Label15";
this.Label15.Size = new System.Drawing.Size(29, 16);
this.Label15.TabIndex = 83;
this.Label15.Text = "City ";
// 
// Label16
// 
this.Label16.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label16.ForeColor = System.Drawing.Color.Black;
this.Label16.Location = new System.Drawing.Point(22, 189);
this.Label16.Name = "Label16";
this.Label16.Size = new System.Drawing.Size(58, 16);
this.Label16.TabIndex = 80;
this.Label16.Text = "Street ";
// 
// txtCity3
// 
this.txtCity3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCity3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCity3.Location = new System.Drawing.Point(151, 205);
this.txtCity3.MaxLength = 100;
this.txtCity3.Name = "txtCity3";
this.txtCity3.Size = new System.Drawing.Size(136, 20);
this.txtCity3.TabIndex = 23;
// 
// txtStreet3
// 
this.txtStreet3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtStreet3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtStreet3.Location = new System.Drawing.Point(22, 205);
this.txtStreet3.MaxLength = 100;
this.txtStreet3.Name = "txtStreet3";
this.txtStreet3.Size = new System.Drawing.Size(120, 20);
this.txtStreet3.TabIndex = 22;
// 
// txtZip3
// 
this.txtZip3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtZip3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtZip3.Location = new System.Drawing.Point(428, 205);
this.txtZip3.MaxLength = 100;
this.txtZip3.Name = "txtZip3";
this.txtZip3.Size = new System.Drawing.Size(64, 20);
this.txtZip3.TabIndex = 25;
// 
// txtCountry3
// 
this.txtCountry3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCountry3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCountry3.Location = new System.Drawing.Point(296, 205);
this.txtCountry3.MaxLength = 100;
this.txtCountry3.Name = "txtCountry3";
this.txtCountry3.Size = new System.Drawing.Size(123, 20);
this.txtCountry3.TabIndex = 24;
// 
// Label17
// 
this.Label17.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label17.ForeColor = System.Drawing.Color.Black;
this.Label17.Location = new System.Drawing.Point(16, 165);
this.Label17.Name = "Label17";
this.Label17.Size = new System.Drawing.Size(79, 16);
this.Label17.TabIndex = 80;
this.Label17.Text = "Address 3 :";
// 
// Label18
// 
this.Label18.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label18.ForeColor = System.Drawing.Color.Black;
this.Label18.Location = new System.Drawing.Point(296, 189);
this.Label18.Name = "Label18";
this.Label18.Size = new System.Drawing.Size(58, 16);
this.Label18.TabIndex = 82;
this.Label18.Text = "Country ";
// 
// Label19
// 
this.Label19.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label19.ForeColor = System.Drawing.Color.Black;
this.Label19.Location = new System.Drawing.Point(429, 189);
this.Label19.Name = "Label19";
this.Label19.Size = new System.Drawing.Size(64, 16);
this.Label19.TabIndex = 81;
this.Label19.Text = "ZIP ";
// 
// TabPage8
// 
this.TabPage8.Controls.Add(this.txtContactNumber3);
this.TabPage8.Controls.Add(this.cboContacttype3);
this.TabPage8.Controls.Add(this.Label25);
this.TabPage8.Controls.Add(this.Label26);
this.TabPage8.Controls.Add(this.Label28);
this.TabPage8.Controls.Add(this.txtContactNumber2);
this.TabPage8.Controls.Add(this.cboContacttype2);
this.TabPage8.Controls.Add(this.Label21);
this.TabPage8.Controls.Add(this.Label22);
this.TabPage8.Controls.Add(this.Label24);
this.TabPage8.Controls.Add(this.Label76);
this.TabPage8.Location = new System.Drawing.Point(4, 40);
this.TabPage8.Name = "TabPage8";
this.TabPage8.Size = new System.Drawing.Size(534, 249);
this.TabPage8.TabIndex = 1;
this.TabPage8.Text = "Contact Number";
this.TabPage8.UseVisualStyleBackColor = true;
this.TabPage8.Visible = false;
// 
// txtContactNumber3
// 
this.txtContactNumber3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtContactNumber3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtContactNumber3.Location = new System.Drawing.Point(48, 205);
this.txtContactNumber3.MaxLength = 35;
this.txtContactNumber3.Name = "txtContactNumber3";
this.txtContactNumber3.Size = new System.Drawing.Size(172, 20);
this.txtContactNumber3.TabIndex = 30;
// 
// cboContacttype3
// 
this.cboContacttype3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboContacttype3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboContacttype3.ItemHeight = 14;
this.cboContacttype3.Items.AddRange(new object[] {
            "PHONE",
            "FAX",
            "MOBILE"});
this.cboContacttype3.Location = new System.Drawing.Point(224, 204);
this.cboContacttype3.Name = "cboContacttype3";
this.cboContacttype3.Size = new System.Drawing.Size(112, 22);
this.cboContacttype3.TabIndex = 31;
// 
// Label25
// 
this.Label25.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label25.ForeColor = System.Drawing.Color.Black;
this.Label25.Location = new System.Drawing.Point(48, 188);
this.Label25.Name = "Label25";
this.Label25.Size = new System.Drawing.Size(64, 16);
this.Label25.TabIndex = 57;
this.Label25.Text = "Number ";
// 
// Label26
// 
this.Label26.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label26.ForeColor = System.Drawing.Color.Black;
this.Label26.Location = new System.Drawing.Point(33, 163);
this.Label26.Name = "Label26";
this.Label26.Size = new System.Drawing.Size(80, 16);
this.Label26.TabIndex = 59;
this.Label26.Text = "Contact No. 3";
// 
// Label28
// 
this.Label28.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label28.ForeColor = System.Drawing.Color.Black;
this.Label28.Location = new System.Drawing.Point(224, 188);
this.Label28.Name = "Label28";
this.Label28.Size = new System.Drawing.Size(64, 16);
this.Label28.TabIndex = 61;
this.Label28.Text = "Type";
// 
// txtContactNumber2
// 
this.txtContactNumber2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtContactNumber2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtContactNumber2.Location = new System.Drawing.Point(48, 124);
this.txtContactNumber2.MaxLength = 35;
this.txtContactNumber2.Name = "txtContactNumber2";
this.txtContactNumber2.Size = new System.Drawing.Size(172, 20);
this.txtContactNumber2.TabIndex = 28;
// 
// cboContacttype2
// 
this.cboContacttype2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboContacttype2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboContacttype2.ItemHeight = 14;
this.cboContacttype2.Items.AddRange(new object[] {
            "PHONE",
            "FAX",
            "MOBILE"});
this.cboContacttype2.Location = new System.Drawing.Point(224, 123);
this.cboContacttype2.Name = "cboContacttype2";
this.cboContacttype2.Size = new System.Drawing.Size(112, 22);
this.cboContacttype2.TabIndex = 29;
// 
// Label21
// 
this.Label21.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label21.ForeColor = System.Drawing.Color.Black;
this.Label21.Location = new System.Drawing.Point(48, 108);
this.Label21.Name = "Label21";
this.Label21.Size = new System.Drawing.Size(64, 16);
this.Label21.TabIndex = 50;
this.Label21.Text = "Number ";
// 
// Label22
// 
this.Label22.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label22.ForeColor = System.Drawing.Color.Black;
this.Label22.Location = new System.Drawing.Point(33, 89);
this.Label22.Name = "Label22";
this.Label22.Size = new System.Drawing.Size(80, 16);
this.Label22.TabIndex = 52;
this.Label22.Text = "Contact No. 2";
// 
// Label24
// 
this.Label24.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label24.ForeColor = System.Drawing.Color.Black;
this.Label24.Location = new System.Drawing.Point(224, 108);
this.Label24.Name = "Label24";
this.Label24.Size = new System.Drawing.Size(64, 16);
this.Label24.TabIndex = 54;
this.Label24.Text = "Type";
// 
// Label76
// 
this.Label76.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label76.ForeColor = System.Drawing.Color.Black;
this.Label76.Location = new System.Drawing.Point(48, 36);
this.Label76.Name = "Label76";
this.Label76.Size = new System.Drawing.Size(64, 16);
this.Label76.TabIndex = 44;
this.Label76.Text = "Number ";
// 
// TabPage9
// 
this.TabPage9.Controls.Add(this.Label33);
this.TabPage9.Controls.Add(this.txtEmail3);
this.TabPage9.Controls.Add(this.Label30);
this.TabPage9.Controls.Add(this.txtEmail2);
this.TabPage9.Location = new System.Drawing.Point(4, 40);
this.TabPage9.Name = "TabPage9";
this.TabPage9.Size = new System.Drawing.Size(534, 249);
this.TabPage9.TabIndex = 2;
this.TabPage9.Text = "Email Address";
this.TabPage9.UseVisualStyleBackColor = true;
this.TabPage9.Visible = false;
// 
// Label33
// 
this.Label33.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label33.ForeColor = System.Drawing.Color.Black;
this.Label33.Location = new System.Drawing.Point(51, 145);
this.Label33.Name = "Label33";
this.Label33.Size = new System.Drawing.Size(104, 16);
this.Label33.TabIndex = 50;
this.Label33.Text = "Email Address 3";
// 
// txtEmail3
// 
this.txtEmail3.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtEmail3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEmail3.Location = new System.Drawing.Point(51, 165);
this.txtEmail3.Name = "txtEmail3";
this.txtEmail3.Size = new System.Drawing.Size(320, 20);
this.txtEmail3.TabIndex = 34;
// 
// Label30
// 
this.Label30.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label30.ForeColor = System.Drawing.Color.Black;
this.Label30.Location = new System.Drawing.Point(51, 87);
this.Label30.Name = "Label30";
this.Label30.Size = new System.Drawing.Size(112, 16);
this.Label30.TabIndex = 48;
this.Label30.Text = "Email Address 2";
// 
// txtEmail2
// 
this.txtEmail2.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtEmail2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEmail2.Location = new System.Drawing.Point(51, 107);
this.txtEmail2.Name = "txtEmail2";
this.txtEmail2.Size = new System.Drawing.Size(320, 20);
this.txtEmail2.TabIndex = 33;
// 
// tabRemarks
// 
this.tabRemarks.Controls.Add(this.txtREMARKS);
this.tabRemarks.Location = new System.Drawing.Point(4, 40);
this.tabRemarks.Name = "tabRemarks";
this.tabRemarks.Padding = new System.Windows.Forms.Padding(3);
this.tabRemarks.Size = new System.Drawing.Size(534, 249);
this.tabRemarks.TabIndex = 4;
this.tabRemarks.Text = "Remarks";
this.tabRemarks.UseVisualStyleBackColor = true;
// 
// txtREMARKS
// 
this.txtREMARKS.BackColor = System.Drawing.Color.White;
this.txtREMARKS.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtREMARKS.Location = new System.Drawing.Point(7, 11);
this.txtREMARKS.MaxLength = 100000;
this.txtREMARKS.Multiline = true;
this.txtREMARKS.Name = "txtREMARKS";
this.txtREMARKS.Size = new System.Drawing.Size(520, 225);
this.txtREMARKS.TabIndex = 38;
// 
// tabPrivileges
// 
this.tabPrivileges.Controls.Add(this.grdGuestPrivilege);
this.tabPrivileges.Controls.Add(this.btnRemovePrivilege);
this.tabPrivileges.Controls.Add(this.btnAddPrivilege);
this.tabPrivileges.Location = new System.Drawing.Point(4, 40);
this.tabPrivileges.Name = "tabPrivileges";
this.tabPrivileges.Padding = new System.Windows.Forms.Padding(3);
this.tabPrivileges.Size = new System.Drawing.Size(534, 249);
this.tabPrivileges.TabIndex = 3;
this.tabPrivileges.Text = "Privileges";
this.tabPrivileges.UseVisualStyleBackColor = true;
// 
// grdGuestPrivilege
// 
this.grdGuestPrivilege.ColumnInfo = "5,0,0,0,0,85,Columns:0{Width:81;Caption:\"Privilege Id\";}\t1{Width:172;Caption:\"Des" +
    "cription\";}\t2{Width:74;Caption:\"Days Applied\";}\t3{Width:89;Caption:\"Granted By\";" +
    "}\t4{Width:71;Caption:\"Date\";}\t";
this.grdGuestPrivilege.ExtendLastCol = true;
this.grdGuestPrivilege.Location = new System.Drawing.Point(9, 46);
this.grdGuestPrivilege.Name = "grdGuestPrivilege";
this.grdGuestPrivilege.Rows.Count = 1;
this.grdGuestPrivilege.Rows.DefaultSize = 17;
this.grdGuestPrivilege.Size = new System.Drawing.Size(515, 182);
this.grdGuestPrivilege.StyleInfo = resources.GetString("grdGuestPrivilege.StyleInfo");
this.grdGuestPrivilege.TabIndex = 38;
// 
// btnRemovePrivilege
// 
this.btnRemovePrivilege.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnRemovePrivilege.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnRemovePrivilege.Location = new System.Drawing.Point(456, 6);
this.btnRemovePrivilege.Name = "btnRemovePrivilege";
this.btnRemovePrivilege.Size = new System.Drawing.Size(66, 31);
this.btnRemovePrivilege.TabIndex = 37;
this.btnRemovePrivilege.Text = "Remo&ve";
this.btnRemovePrivilege.Click += new System.EventHandler(this.btnRemovePrivilege_Click);
// 
// btnAddPrivilege
// 
this.btnAddPrivilege.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnAddPrivilege.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnAddPrivilege.Location = new System.Drawing.Point(386, 6);
this.btnAddPrivilege.Name = "btnAddPrivilege";
this.btnAddPrivilege.Size = new System.Drawing.Size(66, 31);
this.btnAddPrivilege.TabIndex = 36;
this.btnAddPrivilege.Text = "A&dd";
this.btnAddPrivilege.Click += new System.EventHandler(this.btnAddPrivilege_Click);
// 
// tabAcctMgt
// 
this.tabAcctMgt.Controls.Add(this.dtpAnniversary);
this.tabAcctMgt.Controls.Add(this.txtPillars);
this.tabAcctMgt.Controls.Add(this.label44);
this.tabAcctMgt.Controls.Add(this.label42);
this.tabAcctMgt.Controls.Add(this.txtNature);
this.tabAcctMgt.Controls.Add(this.label41);
this.tabAcctMgt.Controls.Add(this.txtBoard);
this.tabAcctMgt.Controls.Add(this.label37);
this.tabAcctMgt.Controls.Add(this.txtAffiliations);
this.tabAcctMgt.Controls.Add(this.label36);
this.tabAcctMgt.Location = new System.Drawing.Point(4, 40);
this.tabAcctMgt.Name = "tabAcctMgt";
this.tabAcctMgt.Padding = new System.Windows.Forms.Padding(3);
this.tabAcctMgt.Size = new System.Drawing.Size(534, 249);
this.tabAcctMgt.TabIndex = 5;
this.tabAcctMgt.Text = "Account Information";
this.tabAcctMgt.UseVisualStyleBackColor = true;
// 
// dtpAnniversary
// 
this.dtpAnniversary.CustomFormat = "MMMM dd, yyyy";
this.dtpAnniversary.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpAnniversary.Location = new System.Drawing.Point(255, 218);
this.dtpAnniversary.Name = "dtpAnniversary";
this.dtpAnniversary.Size = new System.Drawing.Size(166, 20);
this.dtpAnniversary.TabIndex = 9;
// 
// txtPillars
// 
this.txtPillars.Location = new System.Drawing.Point(266, 117);
this.txtPillars.Multiline = true;
this.txtPillars.Name = "txtPillars";
this.txtPillars.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtPillars.Size = new System.Drawing.Size(262, 95);
this.txtPillars.TabIndex = 8;
// 
// label44
// 
this.label44.AutoSize = true;
this.label44.Location = new System.Drawing.Point(266, 100);
this.label44.Name = "label44";
this.label44.Size = new System.Drawing.Size(130, 14);
this.label44.TabIndex = 7;
this.label44.Text = "Pillars of the Organization";
// 
// label42
// 
this.label42.AutoSize = true;
this.label42.Location = new System.Drawing.Point(106, 221);
this.label42.Name = "label42";
this.label42.Size = new System.Drawing.Size(143, 14);
this.label42.TabIndex = 6;
this.label42.Text = "Year Founded / Anniversary";
// 
// txtNature
// 
this.txtNature.Location = new System.Drawing.Point(6, 117);
this.txtNature.Multiline = true;
this.txtNature.Name = "txtNature";
this.txtNature.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtNature.Size = new System.Drawing.Size(254, 95);
this.txtNature.TabIndex = 5;
// 
// label41
// 
this.label41.AutoSize = true;
this.label41.Location = new System.Drawing.Point(6, 100);
this.label41.Name = "label41";
this.label41.Size = new System.Drawing.Size(100, 14);
this.label41.TabIndex = 4;
this.label41.Text = "Nature of Business";
// 
// txtBoard
// 
this.txtBoard.Location = new System.Drawing.Point(266, 20);
this.txtBoard.Multiline = true;
this.txtBoard.Name = "txtBoard";
this.txtBoard.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtBoard.Size = new System.Drawing.Size(262, 77);
this.txtBoard.TabIndex = 3;
// 
// label37
// 
this.label37.AutoSize = true;
this.label37.Location = new System.Drawing.Point(266, 3);
this.label37.Name = "label37";
this.label37.Size = new System.Drawing.Size(217, 14);
this.label37.TabIndex = 2;
this.label37.Text = "Term of Office of Officers / Board Members";
// 
// txtAffiliations
// 
this.txtAffiliations.Location = new System.Drawing.Point(9, 20);
this.txtAffiliations.Multiline = true;
this.txtAffiliations.Name = "txtAffiliations";
this.txtAffiliations.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
this.txtAffiliations.Size = new System.Drawing.Size(251, 77);
this.txtAffiliations.TabIndex = 1;
// 
// label36
// 
this.label36.AutoSize = true;
this.label36.Location = new System.Drawing.Point(6, 3);
this.label36.Name = "label36";
this.label36.Size = new System.Drawing.Size(58, 14);
this.label36.TabIndex = 0;
this.label36.Text = "Affiliations";
// 
// tabContactPersons
// 
this.tabContactPersons.Controls.Add(this.gridContactList);
this.tabContactPersons.Location = new System.Drawing.Point(4, 40);
this.tabContactPersons.Name = "tabContactPersons";
this.tabContactPersons.Padding = new System.Windows.Forms.Padding(3);
this.tabContactPersons.Size = new System.Drawing.Size(534, 249);
this.tabContactPersons.TabIndex = 6;
this.tabContactPersons.Text = "Contact Persons";
this.tabContactPersons.UseVisualStyleBackColor = true;
// 
// gridContactList
// 
this.gridContactList.ColumnInfo = resources.GetString("gridContactList.ColumnInfo");
this.gridContactList.Location = new System.Drawing.Point(9, 11);
this.gridContactList.Name = "gridContactList";
this.gridContactList.Rows.Count = 1;
this.gridContactList.Rows.DefaultSize = 17;
this.gridContactList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
this.gridContactList.Size = new System.Drawing.Size(515, 257);
this.gridContactList.StyleInfo = resources.GetString("gridContactList.StyleInfo");
this.gridContactList.TabIndex = 0;
this.gridContactList.MouseClick += new System.Windows.Forms.MouseEventHandler(this.gridContactList_MouseClick);
this.gridContactList.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.gridContactList_BeforeEdit);
// 
// tabJournal
// 
this.tabJournal.Controls.Add(this.grdJournal);
this.tabJournal.Controls.Add(this.dtJournal);
this.tabJournal.Location = new System.Drawing.Point(4, 40);
this.tabJournal.Name = "tabJournal";
this.tabJournal.Padding = new System.Windows.Forms.Padding(3);
this.tabJournal.Size = new System.Drawing.Size(534, 249);
this.tabJournal.TabIndex = 7;
this.tabJournal.Text = "Journal";
this.tabJournal.UseVisualStyleBackColor = true;
// 
// grdJournal
// 
this.grdJournal.AllowAddNew = true;
this.grdJournal.AllowDelete = true;
this.grdJournal.AutoGenerateColumns = false;
this.grdJournal.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:420;Name:\"Remarks\";Caption:\"Remarks\";TextAlign:LeftC" +
    "enter;TextAlignFixed:CenterCenter;}\t1{Width:185;Name:\"Date\";Caption:\"Date\";TextA" +
    "lignFixed:CenterCenter;}\t";
this.grdJournal.Dock = System.Windows.Forms.DockStyle.Fill;
this.grdJournal.Location = new System.Drawing.Point(3, 3);
this.grdJournal.Name = "grdJournal";
this.grdJournal.Rows.Count = 1;
this.grdJournal.Rows.DefaultSize = 17;
this.grdJournal.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row;
this.grdJournal.Size = new System.Drawing.Size(528, 243);
this.grdJournal.StyleInfo = resources.GetString("grdJournal.StyleInfo");
this.grdJournal.TabIndex = 2;
this.grdJournal.BeforeEdit += new C1.Win.C1FlexGrid.RowColEventHandler(this.grdJournal_BeforeEdit);
// 
// dtJournal
// 
this.dtJournal.Location = new System.Drawing.Point(169, 102);
this.dtJournal.Name = "dtJournal";
this.dtJournal.Size = new System.Drawing.Size(200, 20);
this.dtJournal.TabIndex = 209;
this.dtJournal.Visible = false;
// 
// Label10
// 
this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label10.ForeColor = System.Drawing.Color.Black;
this.Label10.Location = new System.Drawing.Point(141, 16);
this.Label10.Name = "Label10";
this.Label10.Size = new System.Drawing.Size(29, 16);
this.Label10.TabIndex = 83;
this.Label10.Text = "City ";
// 
// Label11
// 
this.Label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label11.ForeColor = System.Drawing.Color.Black;
this.Label11.Location = new System.Drawing.Point(8, 15);
this.Label11.Name = "Label11";
this.Label11.Size = new System.Drawing.Size(50, 16);
this.Label11.TabIndex = 80;
this.Label11.Text = "Street ";
// 
// txtCity1
// 
this.txtCity1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCity1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCity1.Location = new System.Drawing.Point(142, 32);
this.txtCity1.MaxLength = 100;
this.txtCity1.Name = "txtCity1";
this.txtCity1.Size = new System.Drawing.Size(136, 20);
this.txtCity1.TabIndex = 15;
// 
// txtStreet1
// 
this.txtStreet1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtStreet1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtStreet1.Location = new System.Drawing.Point(6, 32);
this.txtStreet1.MaxLength = 100;
this.txtStreet1.Name = "txtStreet1";
this.txtStreet1.Size = new System.Drawing.Size(120, 20);
this.txtStreet1.TabIndex = 14;
// 
// txtZip1
// 
this.txtZip1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtZip1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtZip1.Location = new System.Drawing.Point(430, 32);
this.txtZip1.MaxLength = 100;
this.txtZip1.Name = "txtZip1";
this.txtZip1.Size = new System.Drawing.Size(93, 20);
this.txtZip1.TabIndex = 17;
// 
// txtCountry1
// 
this.txtCountry1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCountry1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCountry1.Location = new System.Drawing.Point(291, 32);
this.txtCountry1.MaxLength = 100;
this.txtCountry1.Name = "txtCountry1";
this.txtCountry1.Size = new System.Drawing.Size(123, 20);
this.txtCountry1.TabIndex = 16;
// 
// Label13
// 
this.Label13.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label13.ForeColor = System.Drawing.Color.Black;
this.Label13.Location = new System.Drawing.Point(289, 16);
this.Label13.Name = "Label13";
this.Label13.Size = new System.Drawing.Size(58, 16);
this.Label13.TabIndex = 82;
this.Label13.Text = "Country ";
// 
// Label14
// 
this.Label14.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label14.ForeColor = System.Drawing.Color.Black;
this.Label14.Location = new System.Drawing.Point(431, 16);
this.Label14.Name = "Label14";
this.Label14.Size = new System.Drawing.Size(64, 16);
this.Label14.TabIndex = 81;
this.Label14.Text = "ZIP ";
// 
// txtContactNumber1
// 
this.txtContactNumber1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtContactNumber1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtContactNumber1.Location = new System.Drawing.Point(89, 148);
this.txtContactNumber1.MaxLength = 35;
this.txtContactNumber1.Name = "txtContactNumber1";
this.txtContactNumber1.Size = new System.Drawing.Size(172, 20);
this.txtContactNumber1.TabIndex = 26;
// 
// cboContacttype1
// 
this.cboContacttype1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboContacttype1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.cboContacttype1.ItemHeight = 14;
this.cboContacttype1.Items.AddRange(new object[] {
            "PHONE",
            "FAX",
            "MOBILE"});
this.cboContacttype1.Location = new System.Drawing.Point(311, 147);
this.cboContacttype1.Name = "cboContacttype1";
this.cboContacttype1.Size = new System.Drawing.Size(112, 22);
this.cboContacttype1.TabIndex = 27;
// 
// Label20
// 
this.Label20.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label20.ForeColor = System.Drawing.Color.Black;
this.Label20.Location = new System.Drawing.Point(11, 151);
this.Label20.Name = "Label20";
this.Label20.Size = new System.Drawing.Size(80, 16);
this.Label20.TabIndex = 45;
this.Label20.Text = "Contact No.";
// 
// Label74
// 
this.Label74.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label74.ForeColor = System.Drawing.Color.Black;
this.Label74.Location = new System.Drawing.Point(276, 150);
this.Label74.Name = "Label74";
this.Label74.Size = new System.Drawing.Size(64, 16);
this.Label74.TabIndex = 47;
this.Label74.Text = "Type";
// 
// Label29
// 
this.Label29.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label29.ForeColor = System.Drawing.Color.Black;
this.Label29.Location = new System.Drawing.Point(11, 129);
this.Label29.Name = "Label29";
this.Label29.Size = new System.Drawing.Size(112, 16);
this.Label29.TabIndex = 46;
this.Label29.Text = "Email Address ";
// 
// txtEmail1
// 
this.txtEmail1.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtEmail1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtEmail1.Location = new System.Drawing.Point(89, 125);
this.txtEmail1.Name = "txtEmail1";
this.txtEmail1.Size = new System.Drawing.Size(442, 20);
this.txtEmail1.TabIndex = 32;
// 
// GroupBox2
// 
this.GroupBox2.Controls.Add(this.Label27);
this.GroupBox2.Controls.Add(this.groupBox1);
this.GroupBox2.Controls.Add(this.panel2);
this.GroupBox2.Controls.Add(this.txtCompanyURL);
this.GroupBox2.Controls.Add(this.txtEmail1);
this.GroupBox2.Controls.Add(this.Label29);
this.GroupBox2.Controls.Add(this.panel1);
this.GroupBox2.Controls.Add(this.lblTOTAL_SALES_CONTRIBUTED);
this.GroupBox2.Controls.Add(this.cboContacttype1);
this.GroupBox2.Controls.Add(this.Label74);
this.GroupBox2.Controls.Add(this.nudX_DEAL_AMOUNT);
this.GroupBox2.Controls.Add(this.label34);
this.GroupBox2.Controls.Add(this.txtContactNumber1);
this.GroupBox2.Controls.Add(this.txtCARD_NO);
this.GroupBox2.Controls.Add(this.label3);
this.GroupBox2.Controls.Add(this.nudTHRESHOLD_VALUE);
this.GroupBox2.Controls.Add(this.Label20);
this.GroupBox2.Controls.Add(this.label4);
this.GroupBox2.Controls.Add(this.cboACCOUNT_TYPE);
this.GroupBox2.Controls.Add(this.label7);
this.GroupBox2.Controls.Add(this.label8);
this.GroupBox2.Controls.Add(this.txtNO_OF_VISIT);
this.GroupBox2.Controls.Add(this.Label35);
this.GroupBox2.Controls.Add(this.txtCompanyId);
this.GroupBox2.Controls.Add(this.Label43);
this.GroupBox2.Controls.Add(this.Label38);
this.GroupBox2.Controls.Add(this.txtContactPerson);
this.GroupBox2.Controls.Add(this.Label39);
this.GroupBox2.Controls.Add(this.txtDesignation);
this.GroupBox2.Location = new System.Drawing.Point(236, 0);
this.GroupBox2.Name = "GroupBox2";
this.GroupBox2.Size = new System.Drawing.Size(543, 231);
this.GroupBox2.TabIndex = 177;
this.GroupBox2.TabStop = false;
// 
// Label27
// 
this.Label27.Location = new System.Drawing.Point(10, 75);
this.Label27.Name = "Label27";
this.Label27.Size = new System.Drawing.Size(84, 14);
this.Label27.TabIndex = 183;
this.Label27.Text = "Company URL";
// 
// groupBox1
// 
this.groupBox1.Controls.Add(this.Label11);
this.groupBox1.Controls.Add(this.Label14);
this.groupBox1.Controls.Add(this.Label13);
this.groupBox1.Controls.Add(this.txtCountry1);
this.groupBox1.Controls.Add(this.txtZip1);
this.groupBox1.Controls.Add(this.txtStreet1);
this.groupBox1.Controls.Add(this.txtCity1);
this.groupBox1.Controls.Add(this.Label10);
this.groupBox1.Location = new System.Drawing.Point(6, 168);
this.groupBox1.Name = "groupBox1";
this.groupBox1.Size = new System.Drawing.Size(529, 57);
this.groupBox1.TabIndex = 208;
this.groupBox1.TabStop = false;
this.groupBox1.Text = "Address";
// 
// panel2
// 
this.panel2.Controls.Add(this.txtCompanyCode);
this.panel2.Controls.Add(this.Label40);
this.panel2.Controls.Add(this.txtCompanyName);
this.panel2.Controls.Add(this.Label23);
this.panel2.Location = new System.Drawing.Point(4, 41);
this.panel2.Name = "panel2";
this.panel2.Size = new System.Drawing.Size(538, 30);
this.panel2.TabIndex = 207;
// 
// txtCompanyCode
// 
this.txtCompanyCode.BackColor = System.Drawing.SystemColors.Info;
this.txtCompanyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyCode.Location = new System.Drawing.Point(86, 4);
this.txtCompanyCode.Name = "txtCompanyCode";
this.txtCompanyCode.Size = new System.Drawing.Size(107, 20);
this.txtCompanyCode.TabIndex = 3;
// 
// Label40
// 
this.Label40.Location = new System.Drawing.Point(7, 6);
this.Label40.Name = "Label40";
this.Label40.Size = new System.Drawing.Size(94, 14);
this.Label40.TabIndex = 190;
this.Label40.Text = "Company Code";
// 
// txtCompanyName
// 
this.txtCompanyName.BackColor = System.Drawing.SystemColors.Info;
this.txtCompanyName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtCompanyName.Location = new System.Drawing.Point(284, 5);
this.txtCompanyName.Name = "txtCompanyName";
this.txtCompanyName.Size = new System.Drawing.Size(243, 20);
this.txtCompanyName.TabIndex = 4;
// 
// Label23
// 
this.Label23.Location = new System.Drawing.Point(199, 6);
this.Label23.Name = "Label23";
this.Label23.Size = new System.Drawing.Size(94, 14);
this.Label23.TabIndex = 184;
this.Label23.Text = "Company Name";
// 
// txtCompanyURL
// 
this.txtCompanyURL.BackColor = System.Drawing.Color.White;
this.txtCompanyURL.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyURL.Location = new System.Drawing.Point(89, 72);
this.txtCompanyURL.Name = "txtCompanyURL";
this.txtCompanyURL.Size = new System.Drawing.Size(441, 20);
this.txtCompanyURL.TabIndex = 7;
// 
// panel1
// 
this.panel1.Controls.Add(this.txtTIN);
this.panel1.Controls.Add(this.label45);
this.panel1.Controls.Add(this.txtCREATETIME);
this.panel1.Controls.Add(this.label6);
this.panel1.Location = new System.Drawing.Point(9, 98);
this.panel1.Name = "panel1";
this.panel1.Size = new System.Drawing.Size(528, 27);
this.panel1.TabIndex = 206;
// 
// txtTIN
// 
this.txtTIN.Location = new System.Drawing.Point(302, 3);
this.txtTIN.MaxLength = 20;
this.txtTIN.Name = "txtTIN";
this.txtTIN.Size = new System.Drawing.Size(220, 20);
this.txtTIN.TabIndex = 200;
// 
// label45
// 
this.label45.AutoSize = true;
this.label45.Location = new System.Drawing.Point(234, 7);
this.label45.Name = "label45";
this.label45.Size = new System.Drawing.Size(62, 14);
this.label45.TabIndex = 199;
this.label45.Text = "TIN Number";
// 
// txtCREATETIME
// 
this.txtCREATETIME.BackColor = System.Drawing.SystemColors.Control;
this.txtCREATETIME.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCREATETIME.Location = new System.Drawing.Point(81, 3);
this.txtCREATETIME.MaxLength = 30;
this.txtCREATETIME.Name = "txtCREATETIME";
this.txtCREATETIME.ReadOnly = true;
this.txtCREATETIME.Size = new System.Drawing.Size(117, 20);
this.txtCREATETIME.TabIndex = 12;
// 
// label6
// 
this.label6.BackColor = System.Drawing.Color.Transparent;
this.label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label6.ForeColor = System.Drawing.Color.Black;
this.label6.Location = new System.Drawing.Point(1, 6);
this.label6.Name = "label6";
this.label6.Size = new System.Drawing.Size(80, 14);
this.label6.TabIndex = 198;
this.label6.Text = "Date Created";
// 
// lblTOTAL_SALES_CONTRIBUTED
// 
this.lblTOTAL_SALES_CONTRIBUTED.BackColor = System.Drawing.Color.White;
this.lblTOTAL_SALES_CONTRIBUTED.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
this.lblTOTAL_SALES_CONTRIBUTED.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.lblTOTAL_SALES_CONTRIBUTED.ForeColor = System.Drawing.Color.Gray;
this.lblTOTAL_SALES_CONTRIBUTED.Location = new System.Drawing.Point(460, 16);
this.lblTOTAL_SALES_CONTRIBUTED.Name = "lblTOTAL_SALES_CONTRIBUTED";
this.lblTOTAL_SALES_CONTRIBUTED.Size = new System.Drawing.Size(76, 20);
this.lblTOTAL_SALES_CONTRIBUTED.TabIndex = 205;
this.lblTOTAL_SALES_CONTRIBUTED.Text = "0.00";
this.lblTOTAL_SALES_CONTRIBUTED.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
this.lblTOTAL_SALES_CONTRIBUTED.Visible = false;
this.lblTOTAL_SALES_CONTRIBUTED.TextChanged += new System.EventHandler(this.lblTotal_Sales_Contribution_TextChanged);
// 
// nudX_DEAL_AMOUNT
// 
this.nudX_DEAL_AMOUNT.DecimalPlaces = 2;
this.nudX_DEAL_AMOUNT.Location = new System.Drawing.Point(293, 190);
this.nudX_DEAL_AMOUNT.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
this.nudX_DEAL_AMOUNT.Name = "nudX_DEAL_AMOUNT";
this.nudX_DEAL_AMOUNT.Size = new System.Drawing.Size(117, 20);
this.nudX_DEAL_AMOUNT.TabIndex = 10;
this.nudX_DEAL_AMOUNT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.nudX_DEAL_AMOUNT.ThousandsSeparator = true;
this.nudX_DEAL_AMOUNT.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
// 
// label34
// 
this.label34.BackColor = System.Drawing.Color.Transparent;
this.label34.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label34.ForeColor = System.Drawing.Color.Black;
this.label34.Location = new System.Drawing.Point(301, 196);
this.label34.Name = "label34";
this.label34.Size = new System.Drawing.Size(94, 14);
this.label34.TabIndex = 203;
this.label34.Text = "X-Deal Amount";
// 
// txtCARD_NO
// 
this.txtCARD_NO.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCARD_NO.Location = new System.Drawing.Point(425, 192);
this.txtCARD_NO.MaxLength = 30;
this.txtCARD_NO.Name = "txtCARD_NO";
this.txtCARD_NO.Size = new System.Drawing.Size(41, 20);
this.txtCARD_NO.TabIndex = 11;
// 
// label3
// 
this.label3.BackColor = System.Drawing.Color.Transparent;
this.label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label3.ForeColor = System.Drawing.Color.Black;
this.label3.Location = new System.Drawing.Point(425, 195);
this.label3.Name = "label3";
this.label3.Size = new System.Drawing.Size(10, 14);
this.label3.TabIndex = 202;
this.label3.Text = "Card No.";
// 
// nudTHRESHOLD_VALUE
// 
this.nudTHRESHOLD_VALUE.DecimalPlaces = 2;
this.nudTHRESHOLD_VALUE.Location = new System.Drawing.Point(10, 198);
this.nudTHRESHOLD_VALUE.Maximum = new decimal(new int[] {
            10000000,
            0,
            0,
            0});
this.nudTHRESHOLD_VALUE.Name = "nudTHRESHOLD_VALUE";
this.nudTHRESHOLD_VALUE.Size = new System.Drawing.Size(117, 20);
this.nudTHRESHOLD_VALUE.TabIndex = 8;
this.nudTHRESHOLD_VALUE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
this.nudTHRESHOLD_VALUE.ThousandsSeparator = true;
this.nudTHRESHOLD_VALUE.Value = new decimal(new int[] {
            10000,
            0,
            0,
            0});
// 
// label4
// 
this.label4.BackColor = System.Drawing.Color.Transparent;
this.label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label4.ForeColor = System.Drawing.Color.Black;
this.label4.Location = new System.Drawing.Point(9, 113);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(94, 14);
this.label4.TabIndex = 199;
this.label4.Text = "Threshold value";
// 
// cboACCOUNT_TYPE
// 
this.cboACCOUNT_TYPE.BackColor = System.Drawing.Color.White;
this.cboACCOUNT_TYPE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
this.cboACCOUNT_TYPE.Items.AddRange(new object[] {
            "EXECUTIVE",
            "ELITE",
            "VIP",
            "REGULAR",
            "WALK-IN",
            "NONE"});
this.cboACCOUNT_TYPE.Location = new System.Drawing.Point(150, 196);
this.cboACCOUNT_TYPE.Name = "cboACCOUNT_TYPE";
this.cboACCOUNT_TYPE.Size = new System.Drawing.Size(143, 22);
this.cboACCOUNT_TYPE.TabIndex = 9;
this.cboACCOUNT_TYPE.SelectedIndexChanged += new System.EventHandler(this.cboACCOUNT_TYPE_SelectedIndexChanged);
// 
// label7
// 
this.label7.BackColor = System.Drawing.Color.Transparent;
this.label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.label7.ForeColor = System.Drawing.Color.Black;
this.label7.Location = new System.Drawing.Point(149, 111);
this.label7.Name = "label7";
this.label7.Size = new System.Drawing.Size(106, 17);
this.label7.TabIndex = 195;
this.label7.Text = "Account Type";
// 
// label8
// 
this.label8.Location = new System.Drawing.Point(403, 19);
this.label8.Name = "label8";
this.label8.Size = new System.Drawing.Size(65, 14);
this.label8.TabIndex = 194;
this.label8.Text = "Total Sales";
this.label8.Visible = false;
// 
// txtNO_OF_VISIT
// 
this.txtNO_OF_VISIT.BackColor = System.Drawing.Color.White;
this.txtNO_OF_VISIT.Enabled = false;
this.txtNO_OF_VISIT.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtNO_OF_VISIT.ForeColor = System.Drawing.Color.Black;
this.txtNO_OF_VISIT.Location = new System.Drawing.Point(333, 16);
this.txtNO_OF_VISIT.Name = "txtNO_OF_VISIT";
this.txtNO_OF_VISIT.Size = new System.Drawing.Size(64, 20);
this.txtNO_OF_VISIT.TabIndex = 52;
this.txtNO_OF_VISIT.Text = "0";
this.txtNO_OF_VISIT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
this.txtNO_OF_VISIT.Visible = false;
// 
// Label35
// 
this.Label35.Location = new System.Drawing.Point(256, 19);
this.Label35.Name = "Label35";
this.Label35.Size = new System.Drawing.Size(76, 14);
this.Label35.TabIndex = 192;
this.Label35.Text = "No. Of Visit";
this.Label35.Visible = false;
// 
// txtCompanyId
// 
this.txtCompanyId.BackColor = System.Drawing.SystemColors.Info;
this.txtCompanyId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtCompanyId.Location = new System.Drawing.Point(90, 19);
this.txtCompanyId.Name = "txtCompanyId";
this.txtCompanyId.Size = new System.Drawing.Size(139, 20);
this.txtCompanyId.TabIndex = 2;
this.txtCompanyId.TextChanged += new System.EventHandler(this.txtCompanyId_TextChanged);
this.txtCompanyId.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCompanyId_KeyPress);
// 
// Label43
// 
this.Label43.Location = new System.Drawing.Point(11, 22);
this.Label43.Name = "Label43";
this.Label43.Size = new System.Drawing.Size(64, 14);
this.Label43.TabIndex = 178;
this.Label43.Text = "Account ID";
// 
// Label38
// 
this.Label38.Location = new System.Drawing.Point(9, 51);
this.Label38.Name = "Label38";
this.Label38.Size = new System.Drawing.Size(94, 10);
this.Label38.TabIndex = 186;
this.Label38.Text = "Contact Person";
// 
// txtContactPerson
// 
this.txtContactPerson.BackColor = System.Drawing.SystemColors.Info;
this.txtContactPerson.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtContactPerson.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtContactPerson.Location = new System.Drawing.Point(9, 51);
this.txtContactPerson.Name = "txtContactPerson";
this.txtContactPerson.Size = new System.Drawing.Size(288, 20);
this.txtContactPerson.TabIndex = 5;
// 
// Label39
// 
this.Label39.Location = new System.Drawing.Point(303, 51);
this.Label39.Name = "Label39";
this.Label39.Size = new System.Drawing.Size(94, 10);
this.Label39.TabIndex = 188;
this.Label39.Text = "Designation";
// 
// txtDesignation
// 
this.txtDesignation.BackColor = System.Drawing.Color.White;
this.txtDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDesignation.Location = new System.Drawing.Point(305, 51);
this.txtDesignation.Name = "txtDesignation";
this.txtDesignation.Size = new System.Drawing.Size(224, 20);
this.txtDesignation.TabIndex = 6;
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnMergeAccount);
this.gbxCommands.Controls.Add(this.btnFolioHistory);
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnExport);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(3, 528);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(776, 49);
this.gbxCommands.TabIndex = 39;
this.gbxCommands.TabStop = false;
// 
// btnMergeAccount
// 
this.btnMergeAccount.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnMergeAccount.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnMergeAccount.Location = new System.Drawing.Point(233, 12);
this.btnMergeAccount.Name = "btnMergeAccount";
this.btnMergeAccount.Size = new System.Drawing.Size(141, 31);
this.btnMergeAccount.TabIndex = 42;
this.btnMergeAccount.Text = "&Merge Account Window";
this.btnMergeAccount.Click += new System.EventHandler(this.btnMergeAccount_Click);
// 
// btnFolioHistory
// 
this.btnFolioHistory.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnFolioHistory.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnFolioHistory.Location = new System.Drawing.Point(132, 11);
this.btnFolioHistory.Name = "btnFolioHistory";
this.btnFolioHistory.Size = new System.Drawing.Size(97, 31);
this.btnFolioHistory.TabIndex = 41;
this.btnFolioHistory.Text = "&Event History";
this.btnFolioHistory.Click += new System.EventHandler(this.btnFolioHistory_Click);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnClose.Location = new System.Drawing.Point(703, 12);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 47;
this.btnClose.Text = "C&lose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSearch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSearch.Location = new System.Drawing.Point(423, 12);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 43;
this.btnSearch.Text = "&Search";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnExport
// 
this.btnExport.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnExport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnExport.Location = new System.Drawing.Point(5, 11);
this.btnExport.Name = "btnExport";
this.btnExport.Size = new System.Drawing.Size(54, 31);
this.btnExport.TabIndex = 40;
this.btnExport.Text = "&Export";
this.btnExport.Click += new System.EventHandler(this.btnExport_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnDelete.Location = new System.Drawing.Point(61, 11);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 40;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnSave.Location = new System.Drawing.Point(563, 12);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 45;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnNew.Location = new System.Drawing.Point(493, 12);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 44;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.btnCancel.Location = new System.Drawing.Point(633, 12);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 46;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// grdCompany
// 
this.grdCompany.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdCompany.BackColorSel = System.Drawing.SystemColors.Info;
this.grdCompany.Cols = 2;
this.grdCompany.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:3;Caption:\"Account ID\";TextAlign:LeftCenter;TextAlig" +
    "nFixed:CenterCenter;}\t1{Width:104;Caption:\"Company Name\";TextAlign:LeftCenter;Te" +
    "xtAlignFixed:CenterCenter;}\t";
this.grdCompany.ExtendLastCol = true;
this.grdCompany.FixedCols = 0;
this.grdCompany.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdCompany.ForeColorSel = System.Drawing.Color.Black;
this.grdCompany.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdCompany.Location = new System.Drawing.Point(3, 3);
this.grdCompany.Name = "grdCompany";
this.grdCompany.NodeClosedPicture = null;
this.grdCompany.NodeOpenPicture = null;
this.grdCompany.OutlineCol = -1;
this.grdCompany.Rows = 9;
this.grdCompany.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdCompany.Size = new System.Drawing.Size(229, 524);
this.grdCompany.StyleInfo = resources.GetString("grdCompany.StyleInfo");
this.grdCompany.TabIndex = 0;
this.grdCompany.TreeColor = System.Drawing.Color.DarkGray;
this.grdCompany.Click += new System.EventHandler(this.grdCompany_Click);
this.grdCompany.RowColChange += new System.EventHandler(this.grdCompany_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label5);
this.pnlSearch.Controls.Add(this.lblClose);
this.pnlSearch.Controls.Add(this.label1);
this.pnlSearch.Controls.Add(this.label2);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(6, 249);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 48;
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
// label1
// 
this.label1.BackColor = System.Drawing.Color.SteelBlue;
this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label1.Location = new System.Drawing.Point(1, 1);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(247, 21);
this.label1.TabIndex = 0;
this.label1.Text = " Search";
this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// label2
// 
this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label2.Location = new System.Drawing.Point(16, 42);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(141, 15);
this.label2.TabIndex = 4;
this.label2.Text = "Input Search string here";
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
this.btnCloseSearch.TabIndex = 51;
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
this.btnFind.TabIndex = 50;
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
this.txtSearch.TabIndex = 49;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
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
this.dtpBirthdate.Location = new System.Drawing.Point(410, 253);
this.dtpBirthdate.Name = "dtpBirthdate";
this.dtpBirthdate.Size = new System.Drawing.Size(200, 20);
this.dtpBirthdate.TabIndex = 208;
// 
// exportAccountDialog
// 
this.exportAccountDialog.FileOk += new System.ComponentModel.CancelEventHandler(this.exportAccountDialog_FileOk);
// 
// CompanyUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(785, 583);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.GroupBox2);
this.Controls.Add(this.TabControl2);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.grdCompany);
this.Controls.Add(this.dtpBirthdate);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "CompanyUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
this.Text = "Company Account";
this.Load += new System.EventHandler(this.CompanyUI_Load);
this.Closing += new System.ComponentModel.CancelEventHandler(this.CompanyUI_Closing);
this.TextChanged += new System.EventHandler(this.CompanyUI_TextChanged);
this.TabControl2.ResumeLayout(false);
this.TabPage7.ResumeLayout(false);
this.TabPage7.PerformLayout();
this.TabPage8.ResumeLayout(false);
this.TabPage8.PerformLayout();
this.TabPage9.ResumeLayout(false);
this.TabPage9.PerformLayout();
this.tabRemarks.ResumeLayout(false);
this.tabRemarks.PerformLayout();
this.tabPrivileges.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdGuestPrivilege)).EndInit();
this.tabAcctMgt.ResumeLayout(false);
this.tabAcctMgt.PerformLayout();
this.tabContactPersons.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.gridContactList)).EndInit();
this.tabJournal.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdJournal)).EndInit();
this.GroupBox2.ResumeLayout(false);
this.GroupBox2.PerformLayout();
this.groupBox1.ResumeLayout(false);
this.groupBox1.PerformLayout();
this.panel2.ResumeLayout(false);
this.panel2.PerformLayout();
this.panel1.ResumeLayout(false);
this.panel1.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudX_DEAL_AMOUNT)).EndInit();
((System.ComponentModel.ISupportInitialize)(this.nudTHRESHOLD_VALUE)).EndInit();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdCompany)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.mnuContactList.ResumeLayout(false);
this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables and Constants

            private DatasetBinder oDataSetBinder;
            private FormToObjectInstanceBinder oInstanceBinder;
            private ControlListener oControlListener;
            private Sequence oSequence;

            private Company oCompany;
            private CompanyFacade oCompanyFacade ;
            private OperationMode mOperationMode;

            #endregion

            #region Constructor

            public CompanyUI()
            {
                oDataSetBinder = new DatasetBinder();
                oInstanceBinder = new FormToObjectInstanceBinder();
                oControlListener = new ControlListener();
                oCompany = new Company();
                oCompanyFacade = new CompanyFacade();
                oSequence = new Sequence();

                //This call is required by the Windows Form Designer.
                InitializeComponent();
            }

            #endregion

            #region Methods

            DataView _dtView;
			private void populateDataGrid()
			{
                int i;

                this.grdCompany.Rows = 1;
                _dtView = oCompany.Tables[0].DefaultView;
                _dtView.RowStateFilter = DataViewRowState.OriginalRows;
                //_dtView.RowFilter = lWhereCondition;

                foreach (DataRowView dRow in _dtView)
                {
                    i = this.grdCompany.Rows;
                    this.grdCompany.Rows++;

                    this.grdCompany.set_TextMatrix(i, 0, dRow["CompanyId"].ToString());
                    this.grdCompany.set_TextMatrix(i, 1, dRow["CompanyName"].ToString());
                }

                //int i;
                //this.grdCompany.Rows = 1;
                //foreach (DataRow dRow in oCompany.Tables[0].Rows)
                //{
					
                //    i = this.grdCompany.Rows;
                //    this.grdCompany.Rows++;
					
                //    this.grdCompany.set_TextMatrix(i, 0, dRow["CompanyId"].ToString());
                //    this.grdCompany.set_TextMatrix(i, 1, dRow["CompanyName"].ToString());
                //}
				
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

			private void bindRowToControls()
			{
                //try
                //{
                //    if (hasChanges())
                //    {
                //        if (MessageBox.Show("Save changes made to Company \'" + this.txtCompanyName.Text + "\'", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                //        {
                //            if (update() > 0)
                //            {
                //                MessageBox.Show("Item successfully updated.", "Company Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                //            }
                //            else
                //            {
                //                MessageBox.Show("No rows updated", "Database Update Error");
                //            }
                //        }
                //        else
                //        {
                //            this.BindingContext[oCompany.Tables["CompanyAccounts"]].CancelCurrentEdit();
                //            this.Text = "Company Account";

                //        }
                //    }
					
                //    oControlListener.StopListen(this);
                //    this.BindingContext[oCompany.Tables["CompanyAccounts"]].Position = findItemInDataSet(this.grdCompany.get_TextMatrix(this.grdCompany.Row, 0));


                //    loadCompanyPrivileges(this.txtCompanyId.Text);

                //}
                //catch (Exception)
                //{
                //}
                //finally
                //{
                //    if (! this.pnlSearch.Visible )
                //    {
                //        oControlListener.Listen(this);
                //    }
                //}

                oControlListener.StopListen(this);

                int _row = this.grdCompany.Row;
                string _accountId = this.grdCompany.get_TextMatrix(_row, 0);

                this.txtCompanyId.Text = _accountId;

                loadCompanyPrivileges(this.txtCompanyId.Text);
                loadAccountInformation(this.txtCompanyId.Text);
                loadContactPersons(this.txtCompanyId.Text);
                oControlListener.Listen(this);
                loadJournalList();
			}

            private void loadAccountInformation(string pAccountID)
            {
                AccountInformation _oAccountInformation = new AccountInformation(pAccountID, GlobalVariables.gHotelId);
                txtBoard.Text = _oAccountInformation.OfficeOfficers;
                txtPillars.Text = _oAccountInformation.PillarsOfOrganization;
                txtAffiliations.Text = _oAccountInformation.Affiliations;
                txtNature.Text = _oAccountInformation.NatureOfBusiness;
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

			private void loadCompanyPrivileges(string a_AccountId)
			{
				oCompanyFacade = new CompanyFacade();
				//oCompanyFacade.getAccountPrivileges(a_AccountId, ref oCompany);
				oCompany.AccountPrivileges = oCompanyFacade.getAccountPrivileges(a_AccountId);

				this.grdGuestPrivilege.Rows.Count = oCompany.AccountPrivileges.Count + 1;
				int i = 1;
				foreach (PrivilegeHeader privilege in oCompany.AccountPrivileges)
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
                //if (this.txtCompanyCode.Text.Length == 0 || this.txtCompanyName.Text.Length == 0 || this.txtContactPerson.Text.Length == 0) return false;
                if (this.txtCompanyCode.Text.Length == 0 || this.txtCompanyName.Text.Length == 0) return false;
                return true;
                
            }

            private void assignEntityValues()
            {
                FormToObjectInstanceBinder.BindObjectToInputControls(this, oCompany);
                oCompany.HotelID = GlobalVariables.gHotelId;
                oCompany.CreatedBy = GlobalVariables.gLoggedOnUser;
                oCompany.UpdatedBy = GlobalVariables.gLoggedOnUser;

				// assigns Account Privilegs
				IList<PrivilegeHeader> privileges = new List<PrivilegeHeader>();
				for (int i = 1; i < this.grdGuestPrivilege.Rows.Count; i++)
				{
					PrivilegeHeader newPriv = new PrivilegeHeader();

					newPriv.PrivilegeID = this.grdGuestPrivilege.GetDataDisplay(i, 0);

					privileges.Add(newPriv);
				}
				oCompany.AccountPrivileges = privileges;
                AccountInformation _oAccountInformation = new AccountInformation();

                _oAccountInformation.AccountID = txtCompanyId.Text;
                _oAccountInformation.HotelID = GlobalVariables.gHotelId;
                _oAccountInformation.Affiliations = txtAffiliations.Text;
                _oAccountInformation.OfficeOfficers = txtBoard.Text;
                _oAccountInformation.NatureOfBusiness = txtNature.Text;
                _oAccountInformation.PillarsOfOrganization = txtPillars.Text;
                _oAccountInformation.Anniversary = dtpAnniversary.Value;

                oCompany.AccountInformation = _oAccountInformation;
                
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

                        _oContactPerson.AccountID = txtCompanyId.Text;
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
                oCompany.ContactPersons = _contactPersons;
            }

            private void setActionButtonStates(bool a_stat)
			{
                btnDelete.Enabled = a_stat;
				btnNew.Enabled = a_stat;
				btnSave.Enabled = ! a_stat;
				btnCancel.Enabled = ! a_stat;
			}
			
			private int findItemInDataSet(string a_key)
			{
				DataRow drCompany;
				int i;
				
				i = 0;
				foreach (DataRow tempLoopVar_drCompany in oCompany.Tables[0].Rows)
				{
					drCompany = tempLoopVar_drCompany;
					if ((string) drCompany["CompanyId"] == a_key)
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
                    for (i = this.grdCompany.Row + 1; i <= this.grdCompany.Rows - 1; i++)
                    {
                        if (this.grdCompany.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.grdCompany.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.grdCompany.Row = i;
                            isFound = true;
                            return;
                        }
                    }

                    if (!isFound)
                    {
                        for (i = 1; i <= this.grdCompany.Rows - 1; i++)
                        {
                            if (this.grdCompany.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.grdCompany.get_TextMatrix(i, 1).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                            {

                                this.grdCompany.Row = i;
                                isFound = true;
                                return;
                            }

                        }
                    }

                    MessageBox.Show("No matching record found.");
                }

            }

			#endregion

            #region Special Methods

            public bool load()
            {
                try
                {
                    oCompany = new Company();
                    oCompanyFacade = new CompanyFacade();
                    oCompany = oCompanyFacade.getCompanyAccountsData();

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
                    cboACCOUNT_TYPE.Items.Add(dTable.Rows[i]["PrivilegeID"].ToString());
                }

                cboACCOUNT_TYPE.Items.Add("WALK-IN");
                cboACCOUNT_TYPE.Items.Add("NONE");
                cboACCOUNT_TYPE.Items.Add("");
                //cboAccount_Type.DisplayMember = "PrivilegeID";
                //cboAccount_Type.ValueMember = "PrivilegeID";
                //cboAccount_Type.DataSource = _oPrivilegeHeader;
            }

            public int insert()
            {
                try
                {
                    int rowsAffected=0;
                    oCompanyFacade = new CompanyFacade();
                    rowsAffected = oCompanyFacade.insertCompanyGuest(ref oCompany);

                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            public int update()
            {
                try
                {
                    int rowsAffected = 0;
                    object primaryKey = this.grdCompany.get_TextMatrix(this.grdCompany.Row, 0);
                    oCompanyFacade = new CompanyFacade();
                    rowsAffected = oCompanyFacade.updateCompanyAccount(primaryKey, ref oCompany);

                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oCompanyFacade = new CompanyFacade();
				    FormToObjectInstanceBinder.BindObjectToInputControls(this, oCompany);
                    rowsAffected=oCompanyFacade.deleteCompanyAccount(this.txtCompanyId.Text, oCompany);

                    return rowsAffected;
                }
                catch(Exception)
                {
                        return 0;
                }
            }

            #endregion

            #region Events

            private ComboBox cboPersonType = new ComboBox();
            private void CompanyUI_Load(object sender, System.EventArgs e)
            {
                if (load() == true)
                {
                    if (oCompany != null)
                    {
                        object objCompany = oCompany;
                        populateDataGrid();

                        if (this.grdCompany.Rows > 1)
                        {
                            this.grdCompany_RowColChange(sender, e);
                        }
                    }

                    oControlListener.Listen(this);
                }
				setActionButtonStates(true);
                mOperationMode = OperationMode.Edit;

                if (ConfigVariables.gIsEMMOnly == "true")
                {
                    TabControl2.Controls.Remove(tabPrivileges);
                }

                //load person type for contactpersons
                ContactPerson _cotnactPerson = new ContactPerson();
                DataTable _personType = _cotnactPerson.getPersonType();
                cboPersonType.DropDownStyle = ComboBoxStyle.DropDownList;
                foreach (DataRow _dRow in _personType.Rows)
                {
                    cboPersonType.Items.Add(_dRow["value"].ToString());
                }
                removeTabs();
            }
            private void removeTabs()
            {
                TabControl2.TabPages.Remove(TabPage7);
                TabControl2.TabPages.Remove(TabPage8);
                TabControl2.TabPages.Remove(TabPage9);

            }

            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {
                oSequence = new Sequence();

                setOperationMode(OperationMode.Add);
                oControlListener.StopListen(this);

                this.txtCompanyId.Text = oSequence.getSequenceId("G-", 12, "seq_company");
                clearForNewEntry();
                this.txtCompanyCode.Focus();

                setActionButtonStates(false);
            }

            private void clearForNewEntry()
            {
                this.lblTOTAL_SALES_CONTRIBUTED.Text = "0.00";
                this.txtNO_OF_VISIT.Text = "0";
                this.txtCREATETIME.Text = DateTime.Now.ToString("MM/dd/yyyy hh:mm:ss tt");
                this.txtCARD_NO.Text = "";
                this.txtCity1.Text = "";
                this.txtCity2.Text = "";
                this.txtCity3.Text = "";
                this.txtCompanyCode.Text = "";
                this.txtCompanyName.Text = "";
                this.txtCompanyURL.Text = "";
                this.txtContactNumber1.Text = "";
                this.txtContactNumber2.Text = "";
                this.txtContactNumber3.Text = "";
                this.txtContactPerson.Text = "";
                this.txtCountry1.Text = "";
                this.txtCountry2.Text = "";
                this.txtCountry3.Text = "";
                this.txtDesignation.Text = "";
                this.txtEmail1.Text = "";
                this.txtEmail2.Text = "";
                this.txtEmail3.Text = "";
                this.txtREMARKS.Text = "";
                this.txtStreet1.Text = "";
                this.txtStreet2.Text = "";
                this.txtStreet3.Text = "";
                this.txtZip1.Text = "";
                this.txtZip2.Text = "";
                this.txtZip3.Text = "";

                this.nudTHRESHOLD_VALUE.Text = ConfigVariables.gDefaultCompanyThresholdValue;
                this.nudX_DEAL_AMOUNT.Text = "0.00";

                this.cboACCOUNT_TYPE.Text = "";
                this.cboContacttype1.Text = "";
                this.cboContacttype2.Text = "";
                this.cboContacttype3.Text = "";

                this.grdGuestPrivilege.Rows.Count = 1;
            }

            private void CompanyUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (hasChanges())
                {
                    if (MessageBox.Show("Save changes made to Company \'" + this.txtCompanyName.Text + "\'", "Save Changes", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (update() > 0)
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
                        this.BindingContext[oCompany.Tables["CompanyAccounts"]].CancelCurrentEdit();
                        this.Text = "Company Account";

                    }
                }
            }


            private void btnSave_Click(System.Object sender, System.EventArgs e)
            {
              if (isRequiredEntriesFilled())
                {
                    assignEntityValues();
                    saveJournalList();
                    switch (mOperationMode)
                    {

                        case OperationMode.Add:
                            if (insert() > 0)
                            {
                                this.grdCompany.Rows++;

                                this.grdCompany.set_TextMatrix(this.grdCompany.Rows - 1, 0, oCompany.CompanyId);
                                this.grdCompany.set_TextMatrix(this.grdCompany.Rows - 1, 1, oCompany.CompanyName);

                                this.grdCompany.Row = this.grdCompany.Rows - 1;
                                this.BindingContext[oCompany.Tables["CompanyAccounts"]].ResumeBinding();

                                this.Text = "Company Account";
                               
                                setActionButtonStates(true);

                                oControlListener.Listen(this);
                                mOperationMode = OperationMode.Edit;
                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.Edit:
                            if (update() > 0)
                            {
                                MessageBox.Show("Item successfully updated.", "Guest Account", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                this.grdCompany.set_TextMatrix(this.grdCompany.Row, 1, this.txtCompanyName.Text);
                                this.BindingContext[oCompany.Tables["CompanyAccounts"]].ResumeBinding();
                                this.Text = "Company Account";
                                oControlListener.Listen(this);

                            }
                            else
                            {
                                MessageBox.Show("No rows updated", "Database Update Error");
                            }
                            break;
                        default:
                            MessageBox.Show("Invalid operation mode", "Abort operation");
                            break;
                    }

                    loadContactPersons(txtCompanyId.Text);
                }
                else
                {
                    MessageBox.Show("Please fill-up all highlighted fields..", "Save Error");
                    this.txtCompanyName.Focus();
                    return;
                }
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
				DialogResult rsp = MessageBox.Show("Are you sure you want to cancel?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

				if (rsp == DialogResult.Yes)
				{
					if (mOperationMode.Equals(OperationMode.Add))
					{
						if (this.grdCompany.Rows > 1)
						{
							this.grdCompany.Row = 1;
						}
					}
					else
					{
						this.BindingContext[oCompany.Tables["CompanyAccounts"]].CancelCurrentEdit();
					}
                    this.BindingContext[oCompany.Tables["CompanyAccounts"]].ResumeBinding();
                    int _currentRow = grdCompany.Row;
                    grdCompany.Select(0, 0);
                    grdCompany.Select(_currentRow, 0);
                    this.Text = "Company Account";

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

                    if (MessageBox.Show("Delete Company Account \'" + this.txtCompanyName.Text + "\'", "Confirm Delete",MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (delete() > 0)
                        {
                            this.grdCompany.RemoveItem(this.grdCompany.Row);
                        }

                    }

                }
                catch (Exception)
                {
                    this.grdCompany.RemoveItem(0);
                }
                finally
                {
                    this.oControlListener.Listen(this);
                }
            }

            private void CompanyUI_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf("*") > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                }
                else
                {
                    setActionButtonStates(true);
                }
            }

            private void btnFind_Click(object sender, EventArgs e)
            {
                searchItem();
            }

            private void btnCloseSearch_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void lblClose_Click(object sender, EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void grdCompany_Click(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void grdCompany_RowColChange(object sender, System.EventArgs e)
            {
                bindRowToControls();
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

            private void lvwCompany_SelectedIndexChanged(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void btnSearch_Click(System.Object sender, System.EventArgs e)
            {
                this.pnlSearch.Visible = true;
                this.txtSearch.Focus();
                this.txtSearch.SelectAll();
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

            private void txtCompanyId_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)

            {
                e.Handled = true;
            }

            private void Close_Click(System.Object sender, System.EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            #endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void btnAddPrivilege_Click(object sender, EventArgs e)
			{
				PrivilegeHeaderUI privilegeUI = new PrivilegeHeaderUI(ref this.grdGuestPrivilege);
				privilegeUI.ShowDialog();

                if (mOperationMode != OperationMode.Add)
                {
                    this.Text = "Company Account*";
                }
			}

			private void btnRemovePrivilege_Click(object sender, EventArgs e)
			{
				try
				{
					int row = this.grdGuestPrivilege.Row;

					DialogResult rsp = MessageBox.Show("Remove select privilege?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (rsp == DialogResult.Yes)
						this.grdGuestPrivilege.RemoveItem(row);

                    if (mOperationMode != OperationMode.Add)
                    {
                        this.Text = "Company Account*";
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
				string accountId = this.txtCompanyId.Text;
				string name = this.txtCompanyName.Text;

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

			//private void txtTotal_Sales_Contribution_TextChanged(object sender, EventArgs e)
			//{
			//    try
			//    {

			//        this.txtTotal_Sales_Contribution.Text = double.Parse(txtTotal_Sales_Contribution.Text).ToString("N");
			//        this.Text = "Company Account";
			//    }
			//    catch { }

			//}

			private void btnMergeAccount_Click(object sender, EventArgs e)
			{
				MergeCompanyAccountUI mergeUI = new MergeCompanyAccountUI();
				mergeUI.MdiParent = this.MdiParent;
				mergeUI.Show();

				this.Close();
			}

			private void lblTotal_Sales_Contribution_TextChanged(object sender, EventArgs e)
			{
				try
				{
					this.lblTOTAL_SALES_CONTRIBUTED.Text = double.Parse(this.lblTOTAL_SALES_CONTRIBUTED.Text).ToString("N");
				}
				catch { }
			}

            private void txtCompanyId_TextChanged(object sender, EventArgs e)
            {
                _dtView.RowStateFilter = DataViewRowState.OriginalRows;
                _dtView.RowFilter = "CompanyID = '" + this.txtCompanyId.Text + "'";

                if (_dtView.Count > 0)
                {
                    DataRowView dtRow = _dtView[0];

                    this.txtCARD_NO.Text = dtRow["CARD_NO"].ToString();
                    this.txtCity1.Text = dtRow["city1"].ToString();
                    this.txtCity2.Text = dtRow["city2"].ToString();
                    this.txtCity3.Text = dtRow["city3"].ToString();
                    this.txtCompanyCode.Text = dtRow["companyCode"].ToString();
                    this.txtCompanyName.Text = dtRow["companyName"].ToString();
                    this.txtCompanyURL.Text = dtRow["companyUrl"].ToString();
                    this.txtContactNumber1.Text = dtRow["contactNumber1"].ToString();
                    this.txtContactNumber2.Text = dtRow["contactNumber2"].ToString();
                    this.txtContactNumber3.Text = dtRow["contactNumber3"].ToString();
                    this.txtContactPerson.Text = dtRow["contactPerson"].ToString();
                    this.txtCountry1.Text = dtRow["country1"].ToString();
                    this.txtCountry2.Text = dtRow["country2"].ToString();
                    this.txtCountry3.Text = dtRow["country3"].ToString();
                    this.txtCREATETIME.Text = string.Format("{0:dd-MMM-yyyy hh:mm}", dtRow["createtime"]);
                    this.txtDesignation.Text = dtRow["designation"].ToString();
                    this.txtEmail1.Text = dtRow["email1"].ToString();
                    this.txtEmail2.Text = dtRow["email2"].ToString();
                    this.txtEmail3.Text = dtRow["email3"].ToString();
                    this.txtNO_OF_VISIT.Text = dtRow["NO_OF_VISIT"].ToString();
                    this.txtREMARKS.Text = dtRow["remarks"].ToString();
                    this.txtStreet1.Text = dtRow["street1"].ToString();
                    this.txtStreet2.Text = dtRow["street2"].ToString();
                    this.txtStreet3.Text = dtRow["street3"].ToString();
                    this.txtZip1.Text = dtRow["zip1"].ToString();
                    this.txtZip2.Text = dtRow["zip2"].ToString();
                    this.txtZip3.Text = dtRow["zip3"].ToString();
                    this.lblTOTAL_SALES_CONTRIBUTED.Text = dtRow["TOTAL_SALES_CONTRIBUTION"].ToString();
                    this.nudTHRESHOLD_VALUE.Value = decimal.Parse(dtRow["THRESHOLD_VALUE"].ToString());
                    this.nudX_DEAL_AMOUNT.Value = decimal.Parse(dtRow["X_DEAL_AMOUNT"].ToString());
                    this.cboACCOUNT_TYPE.Text = dtRow["ACCOUNT_TYPE"].ToString();
                    this.cboContacttype1.Text = dtRow["contacttype1"].ToString();
                    this.cboContacttype2.Text = dtRow["contactType2"].ToString();
                    this.cboContacttype3.Text = dtRow["contactType3"].ToString();
                    /* Gene
                     * 02-Mar-12
                     */
                    this.txtTIN.Text = dtRow["TIN"].ToString();
                }
            }

            private void cboACCOUNT_TYPE_SelectedIndexChanged(object sender, EventArgs e)
            {
                grdGuestPrivilege.Rows.Count = 1;
                try
                {
                    DataTable dTable = loPrivilegeHeader.Tables["PrivilegeHeader"];
                    for (int i = 0; i <= dTable.Rows.Count - 1; i++)
                    {
                        if (dTable.Rows[i]["PrivilegeID"].ToString() == cboACCOUNT_TYPE.Text)
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

            private void gridContactList_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
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
                exportAccountDialog.Filter = "Excel Files (*.xls)|*.xls";
                exportAccountDialog.ShowDialog();
            }

            private void exportAccountDialog_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
            {
                try
                {
                    grdCompany.SaveExcel(exportAccountDialog.FileName);
                    MessageBox.Show("Succesfully exported!", "Export", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch
                {}
            }

            private void loadJournalList()
            {
                try
                {
                    
                
                    grdJournal.DataSource = oCompanyFacade.getCompanyJournal(txtCompanyId.Text);
                    grdJournal.Cols[1].Width = 185;
                    grdJournal.Cols[0].Width = 420;
                }
                catch
                {

                }
            }
            private void saveJournalList()
            {
                
                try
                {
                    if (grdJournal.Rows.Count > 1)
                    {
                        
                        oCompanyFacade.deleteCompantJournal(txtCompanyId.Text);
                     
                        foreach (C1.Win.C1FlexGrid.Row _row in grdJournal.Rows)
                        {
                            if (_row.Index <1)
                            {
                                continue;
                            }
                            oCompanyFacade.insertCompantJournal(txtCompanyId.Text,
                                                                _row[0].ToString(),
                                                                DateTime.Parse(_row[1].ToString()));
                        }
                    }
                }
                catch
                {
               
                }

            }

            private void grdJournal_BeforeEdit(object sender, C1.Win.C1FlexGrid.RowColEventArgs e)
            {

                if (e.Col == 1)
                {
                    grdJournal.Cols[1].Editor = dtJournal;
                }
            }
        }

	}

