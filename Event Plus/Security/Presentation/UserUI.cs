using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Security.BusinessLayer;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;


namespace Jinisys.Hotel.Security
{
	namespace Presentation
	{
		public class UserUI : Jinisys.Hotel.UIFramework.Maintenance2UI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public UserUI()
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();
				
				//Add any initialization after the InitializeComponent() call
				
			}
			
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
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.TextBox txtEmployeeIdNo;
			public System.Windows.Forms.Label Label8;
			public System.Windows.Forms.TextBox txtDesignation;
			public System.Windows.Forms.Label Label5;
			public System.Windows.Forms.Label Label4;
			public System.Windows.Forms.TextBox txtFirstName;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.TextBox txtLastName;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.TextBox txtUserId;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.GroupBox GroupBox1;
			internal System.Windows.Forms.Button btnSearch;
			internal System.Windows.Forms.Panel pnlSearch;
			internal System.Windows.Forms.Label picClose;
			internal System.Windows.Forms.Label Label11;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label16;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ListView lvwUsers;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnResetPassword;
			public System.Windows.Forms.Label Label6;
			internal System.Windows.Forms.ComboBox cboHotelId;
			internal System.Windows.Forms.TabPage TabPage1;
			internal System.Windows.Forms.TabPage TabPage2;
			internal System.Windows.Forms.GroupBox gbxPassword;
			public System.Windows.Forms.Label Label10;
			public System.Windows.Forms.TextBox txtConfirmPassword;
			public System.Windows.Forms.TextBox txtPassword;
			public System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.ComboBox cboDepartment;
			internal System.Windows.Forms.ComboBox cboHotelName;
			internal System.Windows.Forms.ColumnHeader RoomNo;
			internal System.Windows.Forms.ColumnHeader Type;
			internal System.Windows.Forms.ColumnHeader vFrom;
			internal System.Windows.Forms.ColumnHeader vTo;
			internal System.Windows.Forms.ColumnHeader Days;
			internal System.Windows.Forms.ColumnHeader RateType;
			internal System.Windows.Forms.ColumnHeader Rate;
			internal System.Windows.Forms.ColumnHeader Amount;
			internal System.Windows.Forms.ColumnHeader Breakfast;
			internal System.Windows.Forms.Button btnAdd;
			internal System.Windows.Forms.Button btnRemove;
            internal Button btnClose;
			private C1.Win.C1FlexGrid.C1FlexGrid grdRoles;
			internal System.Windows.Forms.TabControl tabUser;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserUI));
                this.gbxCommands = new System.Windows.Forms.GroupBox();
                this.btnClose = new System.Windows.Forms.Button();
                this.btnSearch = new System.Windows.Forms.Button();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnNew = new System.Windows.Forms.Button();
                this.btnCancel = new System.Windows.Forms.Button();
                this.btnDelete = new System.Windows.Forms.Button();
                this.btnResetPassword = new System.Windows.Forms.Button();
                this.txtEmployeeIdNo = new System.Windows.Forms.TextBox();
                this.Label8 = new System.Windows.Forms.Label();
                this.txtDesignation = new System.Windows.Forms.TextBox();
                this.Label5 = new System.Windows.Forms.Label();
                this.Label4 = new System.Windows.Forms.Label();
                this.txtFirstName = new System.Windows.Forms.TextBox();
                this.Label3 = new System.Windows.Forms.Label();
                this.txtLastName = new System.Windows.Forms.TextBox();
                this.Label2 = new System.Windows.Forms.Label();
                this.txtUserId = new System.Windows.Forms.TextBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.tabUser = new System.Windows.Forms.TabControl();
                this.TabPage1 = new System.Windows.Forms.TabPage();
                this.cboHotelName = new System.Windows.Forms.ComboBox();
                this.gbxPassword = new System.Windows.Forms.GroupBox();
                this.Label10 = new System.Windows.Forms.Label();
                this.txtConfirmPassword = new System.Windows.Forms.TextBox();
                this.txtPassword = new System.Windows.Forms.TextBox();
                this.Label7 = new System.Windows.Forms.Label();
                this.cboDepartment = new System.Windows.Forms.ComboBox();
                this.cboHotelId = new System.Windows.Forms.ComboBox();
                this.Label6 = new System.Windows.Forms.Label();
                this.TabPage2 = new System.Windows.Forms.TabPage();
                this.grdRoles = new C1.Win.C1FlexGrid.C1FlexGrid();
                this.btnRemove = new System.Windows.Forms.Button();
                this.btnAdd = new System.Windows.Forms.Button();
                this.pnlSearch = new System.Windows.Forms.Panel();
                this.picClose = new System.Windows.Forms.Label();
                this.Label11 = new System.Windows.Forms.Label();
                this.txtSearch = new System.Windows.Forms.TextBox();
                this.Label16 = new System.Windows.Forms.Label();
                this.lvwUsers = new System.Windows.Forms.ListView();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.RoomNo = new System.Windows.Forms.ColumnHeader();
                this.Type = new System.Windows.Forms.ColumnHeader();
                this.vFrom = new System.Windows.Forms.ColumnHeader();
                this.vTo = new System.Windows.Forms.ColumnHeader();
                this.Days = new System.Windows.Forms.ColumnHeader();
                this.RateType = new System.Windows.Forms.ColumnHeader();
                this.Rate = new System.Windows.Forms.ColumnHeader();
                this.Amount = new System.Windows.Forms.ColumnHeader();
                this.Breakfast = new System.Windows.Forms.ColumnHeader();
                this.gbxCommands.SuspendLayout();
                this.GroupBox1.SuspendLayout();
                this.tabUser.SuspendLayout();
                this.TabPage1.SuspendLayout();
                this.gbxPassword.SuspendLayout();
                this.TabPage2.SuspendLayout();
                ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).BeginInit();
                this.pnlSearch.SuspendLayout();
                this.SuspendLayout();
                // 
                // gbxCommands
                // 
                this.gbxCommands.Controls.Add(this.btnClose);
                this.gbxCommands.Controls.Add(this.btnSearch);
                this.gbxCommands.Controls.Add(this.btnSave);
                this.gbxCommands.Controls.Add(this.btnNew);
                this.gbxCommands.Controls.Add(this.btnCancel);
                this.gbxCommands.Controls.Add(this.btnDelete);
                this.gbxCommands.Controls.Add(this.btnResetPassword);
                this.gbxCommands.Location = new System.Drawing.Point(2, 421);
                this.gbxCommands.Name = "gbxCommands";
                this.gbxCommands.Size = new System.Drawing.Size(654, 47);
                this.gbxCommands.TabIndex = 13;
                this.gbxCommands.TabStop = false;
                // 
                // btnClose
                // 
                this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                this.btnClose.Location = new System.Drawing.Point(583, 11);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 191;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // btnSearch
                // 
                this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSearch.Location = new System.Drawing.Point(315, 11);
                this.btnSearch.Name = "btnSearch";
                this.btnSearch.Size = new System.Drawing.Size(66, 31);
                this.btnSearch.TabIndex = 19;
                this.btnSearch.Text = "&Search";
                this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
                // 
                // btnSave
                // 
                this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSave.Location = new System.Drawing.Point(449, 11);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(66, 31);
                this.btnSave.TabIndex = 21;
                this.btnSave.Text = "&Save";
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnNew
                // 
                this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnNew.Location = new System.Drawing.Point(382, 11);
                this.btnNew.Name = "btnNew";
                this.btnNew.Size = new System.Drawing.Size(66, 31);
                this.btnNew.TabIndex = 20;
                this.btnNew.Text = "&New";
                this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
                // 
                // btnCancel
                // 
                this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCancel.Location = new System.Drawing.Point(516, 11);
                this.btnCancel.Name = "btnCancel";
                this.btnCancel.Size = new System.Drawing.Size(66, 31);
                this.btnCancel.TabIndex = 22;
                this.btnCancel.Text = "&Cancel";
                this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
                // 
                // btnDelete
                // 
                this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnDelete.Location = new System.Drawing.Point(6, 11);
                this.btnDelete.Name = "btnDelete";
                this.btnDelete.Size = new System.Drawing.Size(66, 31);
                this.btnDelete.TabIndex = 16;
                this.btnDelete.Text = "&Delete";
                this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
                // 
                // btnResetPassword
                // 
                this.btnResetPassword.Cursor = System.Windows.Forms.Cursors.Hand;
                this.btnResetPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnResetPassword.Location = new System.Drawing.Point(78, 11);
                this.btnResetPassword.Name = "btnResetPassword";
                this.btnResetPassword.Size = new System.Drawing.Size(107, 31);
                this.btnResetPassword.TabIndex = 17;
                this.btnResetPassword.Text = "&Reset Password";
                this.btnResetPassword.Click += new System.EventHandler(this.btnResetPassword_Click);
                // 
                // txtEmployeeIdNo
                // 
                this.txtEmployeeIdNo.BackColor = System.Drawing.Color.White;
                this.txtEmployeeIdNo.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtEmployeeIdNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtEmployeeIdNo.Location = new System.Drawing.Point(16, 32);
                this.txtEmployeeIdNo.MaxLength = 20;
                this.txtEmployeeIdNo.Multiline = true;
                this.txtEmployeeIdNo.Name = "txtEmployeeIdNo";
                this.txtEmployeeIdNo.Size = new System.Drawing.Size(168, 20);
                this.txtEmployeeIdNo.TabIndex = 3;
                // 
                // Label8
                // 
                this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label8.Location = new System.Drawing.Point(16, 13);
                this.Label8.Name = "Label8";
                this.Label8.Size = new System.Drawing.Size(88, 17);
                this.Label8.TabIndex = 70;
                this.Label8.Text = "Employee ID No";
                // 
                // txtDesignation
                // 
                this.txtDesignation.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtDesignation.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtDesignation.Location = new System.Drawing.Point(216, 117);
                this.txtDesignation.MaxLength = 50;
                this.txtDesignation.Name = "txtDesignation";
                this.txtDesignation.Size = new System.Drawing.Size(171, 20);
                this.txtDesignation.TabIndex = 7;
                // 
                // Label5
                // 
                this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label5.Location = new System.Drawing.Point(216, 101);
                this.Label5.Name = "Label5";
                this.Label5.Size = new System.Drawing.Size(64, 17);
                this.Label5.TabIndex = 68;
                this.Label5.Text = "Designation";
                // 
                // Label4
                // 
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.Location = new System.Drawing.Point(16, 101);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(64, 17);
                this.Label4.TabIndex = 66;
                this.Label4.Text = "Department";
                // 
                // txtFirstName
                // 
                this.txtFirstName.BackColor = System.Drawing.SystemColors.Info;
                this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtFirstName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtFirstName.Location = new System.Drawing.Point(216, 161);
                this.txtFirstName.MaxLength = 50;
                this.txtFirstName.Name = "txtFirstName";
                this.txtFirstName.Size = new System.Drawing.Size(171, 20);
                this.txtFirstName.TabIndex = 9;
                // 
                // Label3
                // 
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.Location = new System.Drawing.Point(216, 143);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(64, 17);
                this.Label3.TabIndex = 64;
                this.Label3.Text = "First Name";
                // 
                // txtLastName
                // 
                this.txtLastName.BackColor = System.Drawing.SystemColors.Info;
                this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtLastName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtLastName.Location = new System.Drawing.Point(16, 161);
                this.txtLastName.MaxLength = 50;
                this.txtLastName.Name = "txtLastName";
                this.txtLastName.Size = new System.Drawing.Size(168, 20);
                this.txtLastName.TabIndex = 8;
                // 
                // Label2
                // 
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.Location = new System.Drawing.Point(16, 143);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(64, 17);
                this.Label2.TabIndex = 62;
                this.Label2.Text = "Last Name";
                // 
                // txtUserId
                // 
                this.txtUserId.BackColor = System.Drawing.SystemColors.Info;
                this.txtUserId.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtUserId.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtUserId.Location = new System.Drawing.Point(169, 27);
                this.txtUserId.MaxLength = 30;
                this.txtUserId.Multiline = true;
                this.txtUserId.Name = "txtUserId";
                this.txtUserId.Size = new System.Drawing.Size(202, 21);
                this.txtUserId.TabIndex = 1;
                this.txtUserId.TextChanged += new System.EventHandler(this.txtUserId_TextChanged);
                // 
                // Label1
                // 
                this.Label1.BackColor = System.Drawing.Color.Transparent;
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.Location = new System.Drawing.Point(113, 29);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(55, 17);
                this.Label1.TabIndex = 47;
                this.Label1.Text = "User ID";
                // 
                // GroupBox1
                // 
                this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
                this.GroupBox1.Controls.Add(this.tabUser);
                this.GroupBox1.Controls.Add(this.txtUserId);
                this.GroupBox1.Controls.Add(this.Label1);
                this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.GroupBox1.Location = new System.Drawing.Point(219, -3);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(437, 425);
                this.GroupBox1.TabIndex = 11;
                this.GroupBox1.TabStop = false;
                // 
                // tabUser
                // 
                this.tabUser.Controls.Add(this.TabPage1);
                this.tabUser.Controls.Add(this.TabPage2);
                this.tabUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.tabUser.Location = new System.Drawing.Point(14, 72);
                this.tabUser.Name = "tabUser";
                this.tabUser.SelectedIndex = 0;
                this.tabUser.Size = new System.Drawing.Size(408, 344);
                this.tabUser.TabIndex = 2;
                this.tabUser.SelectedIndexChanged += new System.EventHandler(this.tabUser_SelectedIndexChanged);
                // 
                // TabPage1
                // 
                this.TabPage1.Controls.Add(this.cboHotelName);
                this.TabPage1.Controls.Add(this.gbxPassword);
                this.TabPage1.Controls.Add(this.cboDepartment);
                this.TabPage1.Controls.Add(this.txtDesignation);
                this.TabPage1.Controls.Add(this.txtEmployeeIdNo);
                this.TabPage1.Controls.Add(this.txtLastName);
                this.TabPage1.Controls.Add(this.cboHotelId);
                this.TabPage1.Controls.Add(this.txtFirstName);
                this.TabPage1.Controls.Add(this.Label4);
                this.TabPage1.Controls.Add(this.Label5);
                this.TabPage1.Controls.Add(this.Label8);
                this.TabPage1.Controls.Add(this.Label6);
                this.TabPage1.Controls.Add(this.Label2);
                this.TabPage1.Controls.Add(this.Label3);
                this.TabPage1.Location = new System.Drawing.Point(4, 23);
                this.TabPage1.Name = "TabPage1";
                this.TabPage1.Size = new System.Drawing.Size(400, 317);
                this.TabPage1.TabIndex = 0;
                this.TabPage1.Text = "Personal Information";
                // 
                // cboHotelName
                // 
                this.cboHotelName.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboHotelName.Location = new System.Drawing.Point(88, 72);
                this.cboHotelName.MaxLength = 100;
                this.cboHotelName.Name = "cboHotelName";
                this.cboHotelName.Size = new System.Drawing.Size(299, 22);
                this.cboHotelName.TabIndex = 5;
                this.cboHotelName.SelectedIndexChanged += new System.EventHandler(this.cboHotelName_SelectedIndexChanged);
                // 
                // gbxPassword
                // 
                this.gbxPassword.BackColor = System.Drawing.Color.Transparent;
                this.gbxPassword.Controls.Add(this.Label10);
                this.gbxPassword.Controls.Add(this.txtConfirmPassword);
                this.gbxPassword.Controls.Add(this.txtPassword);
                this.gbxPassword.Controls.Add(this.Label7);
                this.gbxPassword.Enabled = false;
                this.gbxPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.gbxPassword.Location = new System.Drawing.Point(70, 193);
                this.gbxPassword.Name = "gbxPassword";
                this.gbxPassword.Size = new System.Drawing.Size(280, 111);
                this.gbxPassword.TabIndex = 186;
                this.gbxPassword.TabStop = false;
                // 
                // Label10
                // 
                this.Label10.BackColor = System.Drawing.Color.Transparent;
                this.Label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label10.Location = new System.Drawing.Point(21, 69);
                this.Label10.Name = "Label10";
                this.Label10.Size = new System.Drawing.Size(98, 17);
                this.Label10.TabIndex = 60;
                this.Label10.Text = "Confirm Password";
                // 
                // txtConfirmPassword
                // 
                this.txtConfirmPassword.BackColor = System.Drawing.Color.White;
                this.txtConfirmPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtConfirmPassword.Location = new System.Drawing.Point(125, 67);
                this.txtConfirmPassword.MaxLength = 20;
                this.txtConfirmPassword.Name = "txtConfirmPassword";
                this.txtConfirmPassword.PasswordChar = '●';
                this.txtConfirmPassword.Size = new System.Drawing.Size(139, 20);
                this.txtConfirmPassword.TabIndex = 12;
                // 
                // txtPassword
                // 
                this.txtPassword.BackColor = System.Drawing.Color.White;
                this.txtPassword.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtPassword.Location = new System.Drawing.Point(125, 31);
                this.txtPassword.MaxLength = 20;
                this.txtPassword.Name = "txtPassword";
                this.txtPassword.PasswordChar = '●';
                this.txtPassword.Size = new System.Drawing.Size(139, 20);
                this.txtPassword.TabIndex = 11;
                // 
                // Label7
                // 
                this.Label7.BackColor = System.Drawing.Color.Transparent;
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label7.Location = new System.Drawing.Point(21, 33);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(59, 17);
                this.Label7.TabIndex = 58;
                this.Label7.Text = "Password";
                // 
                // cboDepartment
                // 
                this.cboDepartment.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboDepartment.Location = new System.Drawing.Point(16, 116);
                this.cboDepartment.MaxLength = 100;
                this.cboDepartment.Name = "cboDepartment";
                this.cboDepartment.Size = new System.Drawing.Size(168, 22);
                this.cboDepartment.TabIndex = 6;
                // 
                // cboHotelId
                // 
                this.cboHotelId.BackColor = System.Drawing.SystemColors.Info;
                this.cboHotelId.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboHotelId.Location = new System.Drawing.Point(16, 72);
                this.cboHotelId.MaxLength = 5;
                this.cboHotelId.Name = "cboHotelId";
                this.cboHotelId.Size = new System.Drawing.Size(64, 22);
                this.cboHotelId.TabIndex = 4;
                this.cboHotelId.SelectedIndexChanged += new System.EventHandler(this.cboHotelId_SelectedIndexChanged);
                // 
                // Label6
                // 
                this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label6.Location = new System.Drawing.Point(16, 56);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(64, 17);
                this.Label6.TabIndex = 72;
                this.Label6.Text = "Hotel ID";
                // 
                // TabPage2
                // 
                this.TabPage2.Controls.Add(this.grdRoles);
                this.TabPage2.Controls.Add(this.btnRemove);
                this.TabPage2.Controls.Add(this.btnAdd);
                this.TabPage2.Location = new System.Drawing.Point(4, 23);
                this.TabPage2.Name = "TabPage2";
                this.TabPage2.Size = new System.Drawing.Size(400, 317);
                this.TabPage2.TabIndex = 1;
                this.TabPage2.Text = "User Roles";
                // 
                // grdRoles
                // 
                this.grdRoles.AllowEditing = false;
                this.grdRoles.ColumnInfo = "2,0,0,0,0,85,Columns:0{Width:28;DataType:System.Int32;TextAlign:RightCenter;}\t1{W" +
                    "idth:172;Caption:\"Role\";}\t";
                this.grdRoles.ExtendLastCol = true;
                this.grdRoles.Font = new System.Drawing.Font("Arial", 8.25F);
                this.grdRoles.Location = new System.Drawing.Point(9, 46);
                this.grdRoles.Name = "grdRoles";
                this.grdRoles.Rows.Count = 1;
                this.grdRoles.Rows.DefaultSize = 17;
                this.grdRoles.Size = new System.Drawing.Size(383, 258);
                this.grdRoles.StyleInfo = resources.GetString("grdRoles.StyleInfo");
                this.grdRoles.TabIndex = 16;
                this.grdRoles.SelChange += new System.EventHandler(this.grdRoles_SelChange);
                // 
                // btnRemove
                // 
                this.btnRemove.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnRemove.Location = new System.Drawing.Point(309, 12);
                this.btnRemove.Name = "btnRemove";
                this.btnRemove.Size = new System.Drawing.Size(83, 28);
                this.btnRemove.TabIndex = 14;
                this.btnRemove.Text = "&Remove Role";
                this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
                // 
                // btnAdd
                // 
                this.btnAdd.Font = new System.Drawing.Font("Arial", 8.25F);
                this.btnAdd.Location = new System.Drawing.Point(220, 12);
                this.btnAdd.Name = "btnAdd";
                this.btnAdd.Size = new System.Drawing.Size(83, 28);
                this.btnAdd.TabIndex = 13;
                this.btnAdd.Text = "&Add Role";
                this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
                // 
                // pnlSearch
                // 
                this.pnlSearch.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
                this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.pnlSearch.Controls.Add(this.picClose);
                this.pnlSearch.Controls.Add(this.Label11);
                this.pnlSearch.Controls.Add(this.txtSearch);
                this.pnlSearch.Controls.Add(this.Label16);
                this.pnlSearch.Location = new System.Drawing.Point(19, 165);
                this.pnlSearch.Name = "pnlSearch";
                this.pnlSearch.Size = new System.Drawing.Size(271, 105);
                this.pnlSearch.TabIndex = 184;
                this.pnlSearch.Visible = false;
                // 
                // picClose
                // 
                this.picClose.BackColor = System.Drawing.Color.SteelBlue;
                this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
                this.picClose.Location = new System.Drawing.Point(247, 4);
                this.picClose.Name = "picClose";
                this.picClose.Size = new System.Drawing.Size(18, 16);
                this.picClose.TabIndex = 5;
                this.picClose.Click += new System.EventHandler(this.picClose_Click);
                // 
                // Label11
                // 
                this.Label11.Location = new System.Drawing.Point(11, 38);
                this.Label11.Name = "Label11";
                this.Label11.Size = new System.Drawing.Size(240, 15);
                this.Label11.TabIndex = 4;
                this.Label11.Text = "Input Search String here";
                // 
                // txtSearch
                // 
                this.txtSearch.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
                this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.txtSearch.Location = new System.Drawing.Point(11, 62);
                this.txtSearch.Name = "txtSearch";
                this.txtSearch.Size = new System.Drawing.Size(248, 22);
                this.txtSearch.TabIndex = 23;
                this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
                this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
                // 
                // Label16
                // 
                this.Label16.BackColor = System.Drawing.Color.SteelBlue;
                this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
                this.Label16.Image = ((System.Drawing.Image)(resources.GetObject("Label16.Image")));
                this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
                this.Label16.Location = new System.Drawing.Point(2, 2);
                this.Label16.Name = "Label16";
                this.Label16.Size = new System.Drawing.Size(265, 19);
                this.Label16.TabIndex = 0;
                this.Label16.Text = "      Search";
                // 
                // lvwUsers
                // 
                this.lvwUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader2});
                this.lvwUsers.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.lvwUsers.FullRowSelect = true;
                this.lvwUsers.GridLines = true;
                this.lvwUsers.Location = new System.Drawing.Point(3, 2);
                this.lvwUsers.Name = "lvwUsers";
                this.lvwUsers.Size = new System.Drawing.Size(214, 419);
                this.lvwUsers.TabIndex = 0;
                this.lvwUsers.UseCompatibleStateImageBehavior = false;
                this.lvwUsers.View = System.Windows.Forms.View.Details;
                this.lvwUsers.SelectedIndexChanged += new System.EventHandler(this.lvwUsers_SelectedIndexChanged);
                this.lvwUsers.MouseDown += new System.Windows.Forms.MouseEventHandler(this.lvwUsers_MouseDown);
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "User Name";
                this.ColumnHeader2.Width = 194;
                // 
                // RoomNo
                // 
                this.RoomNo.Text = "Room No.";
                this.RoomNo.Width = 64;
                // 
                // Type
                // 
                this.Type.Text = "Type";
                this.Type.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.Type.Width = 119;
                // 
                // vFrom
                // 
                this.vFrom.Text = "From";
                this.vFrom.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.vFrom.Width = 117;
                // 
                // vTo
                // 
                this.vTo.Text = "To";
                this.vTo.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.vTo.Width = 87;
                // 
                // Days
                // 
                this.Days.Text = "Days";
                this.Days.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.Days.Width = 43;
                // 
                // RateType
                // 
                this.RateType.Text = "Rate Type";
                this.RateType.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.RateType.Width = 115;
                // 
                // Rate
                // 
                this.Rate.Text = "Rate";
                this.Rate.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.Rate.Width = 74;
                // 
                // Amount
                // 
                this.Amount.Text = "Amount";
                this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
                this.Amount.Width = 70;
                // 
                // Breakfast
                // 
                this.Breakfast.Text = "Breakfast";
                this.Breakfast.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
                this.Breakfast.Width = 80;
                // 
                // UserUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(658, 471);
                this.Controls.Add(this.pnlSearch);
                this.Controls.Add(this.lvwUsers);
                this.Controls.Add(this.GroupBox1);
                this.Controls.Add(this.gbxCommands);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "UserUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
                this.Text = "Users";
                this.Closing += new System.ComponentModel.CancelEventHandler(this.UserUI_Closing);
                this.TextChanged += new System.EventHandler(this.UserUI_TextChanged);
                this.Load += new System.EventHandler(this.UserUI_Load);
                this.gbxCommands.ResumeLayout(false);
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.tabUser.ResumeLayout(false);
                this.TabPage1.ResumeLayout(false);
                this.TabPage1.PerformLayout();
                this.gbxPassword.ResumeLayout(false);
                this.gbxPassword.PerformLayout();
                this.TabPage2.ResumeLayout(false);
                ((System.ComponentModel.ISupportInitialize)(this.grdRoles)).EndInit();
                this.pnlSearch.ResumeLayout(false);
                this.pnlSearch.PerformLayout();
                this.ResumeLayout(false);

			}
			
			#endregion
			
			
			private string connectionStr;
			public UserUI(string connectionString)
			{
				
				//This call is required by the Windows Form Designer.
				InitializeComponent();
				
				//Add any initialization after the InitializeComponent() call
				connectionStr = connectionString;
			}
			
			private void UserUI_Load(object sender, System.EventArgs e)
			{
				LoadData();
			}
			
			private void grdUsers_CurrentCellChanged(System.Object sender, System.EventArgs e)
			{
				BindRowToControls();
			}
			
			private void grdUsers_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
				DetectChanges();
			}
			
			private void btnNew_Click(System.Object sender, System.EventArgs e)
			{
				NewUser();                
			}
			
			private void UserUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
			{
				DetectChanges();
			}
			
			private void btnSave_Click(System.Object sender, System.EventArgs e)
			{
				SaveUser();
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				CancelTransaction();
			}
			
			private void btnDelete_Click(System.Object sender, System.EventArgs e)
			{
				DeleteUser();
			}
			
			private void UserUI_TextChanged(object sender, System.EventArgs e)
			{
				SetButtonState();
			}
			
			#region "----------------------------- M E T H O D S ---------------------"
			// Variables/Constants
			private string mode;
			private DatasetBinder DatasetBinder = new DatasetBinder();
			private ControlListener ControlListener = new ControlListener();
			//private FormToObjectInstanceBinder instanceBinder;
			
			private UserFacade oUserFacade;
			private Jinisys.Hotel.Security.BusinessLayer.User oUser;
			
			private Department oDepartment;
			private DepartmentFacade oDepartmentFacade;
			private void LoadData()
			{
				
				this.ControlListener.StopListen(this);
				
				oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
				oUser = new Jinisys.Hotel.Security.BusinessLayer.User();
				oUser = oUserFacade.GetUsers();

                ArrayList exempted = new ArrayList();
				exempted.Add(txtPassword);
				
				if (!(oUser == null))
				{
					object tempObj = (object)oUser;
					DatasetBinder.BindControls(this, ref tempObj, exempted);
				}
				
				// >> Get LIST of DEPARTMENTS
				GetDepartments();
				
				// >> Get List of HOTELS
				GetHotels();
				
				
				// Get All ROLES
				GetAllRoles();
				
				
				// >> getUserRoles
				LoadUserRoles();
				
				
				this.txtUserId.Enabled = false;
				LoadDataToListView(oUser.Tables[0]);
				
				ControlListener.Listen(this);
				SetButtonState(true);
			}
			
			//private RoleCollection oRoleCollection;
			private void LoadUserRoles()
			{
				oRolesFacade = new RolesFacade(GlobalVariables.gPersistentConnection);
				oUser.UserId = this.txtUserId.Text;
				oUser.HotelId = this.cboHotelId.Text;
				
				oUser.Roles = oRolesFacade.getUserRoles(oUser);


				this.grdRoles.Rows.Count = oUser.Roles.Count + 1;
				int i = 1;
				foreach (Role oRole in oUser.Roles)
				{
					this.grdRoles.SetData(i,0, i);
					this.grdRoles.SetData(i, 1, oRole.RoleName);

					//ListViewItem lst = new ListViewItem(oRole.RoleName);
					//lst.SubItems.Add(oRole.Description);
					
					//this.lvwRoles.Items.Add(lst);

					i++;
				}
				
			}
			
			private void GetDepartments()
			{
				oDepartment = new Department();
				oDepartmentFacade = new DepartmentFacade();
				oDepartment = (Department)oDepartmentFacade.loadObject();
				
				ArrayList arrayDept = new ArrayList();
				
				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in oDepartment.Tables[0].Rows)
				{
					dtRow = tempLoopVar_dtRow;
					arrayDept.Add(dtRow["DeptId"] + "-" + dtRow["Name"]);
				}
				
				this.cboDepartment.DataSource = arrayDept;
			}
			
			private HotelClass oHotel;
			private HotelFacade oHotelFacade;
			private void GetHotels()
			{
				oHotel = new HotelClass();
				oHotelFacade = new HotelFacade();
                oHotel = (HotelClass)oHotelFacade.loadObject();
				
				ArrayList[] arrayHotel = new ArrayList[3];
				arrayHotel[0] = new ArrayList();
				arrayHotel[1] = new ArrayList();
				
				DataRow dtRow;
				foreach (DataRow tempLoopVar_dtRow in oHotel.Tables[0].Rows)
				{
					dtRow = tempLoopVar_dtRow;
					arrayHotel[0].Add(dtRow["HotelId"]);
					arrayHotel[1].Add(dtRow["HotelName"]);
				}
				
				this.cboHotelId.DataSource = arrayHotel[0];
				this.cboHotelName.DataSource = arrayHotel[1];
			}
			
			private void LoadDataToListView(DataTable dt)
			{
				DataRow dtRow;
				
				this.lvwUsers.Items.Clear();
				foreach (DataRow tempLoopVar_dtRow in dt.Rows)
				{
					dtRow = tempLoopVar_dtRow;
					ListViewItem lvwItem = new ListViewItem(dtRow["UserId"].ToString() );
					
					this.lvwUsers.Items.Add(lvwItem);
				}
				
			}
			
			private void NewUser()
			{
				mode = "Add";
				ControlListener.StopListen(this);
				
				this.BindingContext[oUser.Tables["Users"]].SuspendBinding();
				this.txtUserId.Enabled = true;
				this.txtUserId.Focus();
				
				this.grdRoles.Rows.Count = 1;
				this.gbxPassword.Enabled = true;
				this.cboHotelId.SelectedIndex = 0;

				SetButtonState(false);
			}
			
			private RolesFacade oRolesFacade;
			private Role oRole;
			
			public void GetAllRoles()
			{
				oRolesFacade = new RolesFacade(GlobalVariables.gPersistentConnection);
				oRole = new Role();
				oRole = oRolesFacade.GetActiveRoles();
				

				ArrayList[] arrRoles = new ArrayList[1];
				arrRoles[0] = new ArrayList();
				string _strRoles = "";
				//arrRoles[1] = new ArrayList();
				
				//DataRow dtRow;
				foreach (DataRow _dtRow in oRole.Tables[0].Rows)
				{
					_strRoles += _dtRow["RoleName"].ToString() + "|";
					//dtRow = tempLoopVar_dtRow;
					//arrRoles[0].Add(dtRow["RoleName"]);
					///arrRoles[1].Add(dtRow["Description"]);
				}
				this.grdRoles.Cols[1].ComboList = _strRoles;
				
				//this.cboRoles.DataSource = arrRoles[0];
				//this.cboRoleDesc.DataSource = arrRoles[1];
			}
			
			private void DetectChanges()
			{
				if (this.Text.IndexOf("*") > 0)
				{
					if (MessageBox.Show("Save changes made to User Id '" + this.txtUserId.Text + "'?","Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
					{
						// >> call update USER
						UpdateUser();
					}
					else
					{
						this.BindingContext[oUser.Tables["Users"]].CancelCurrentEdit();
						this.Text = "Users";
						
					}
				}
			}
			
			private void BindRowToControls()
			{
				try
				{
					ControlListener.StopListen(this);
					this.BindingContext[oUser.Tables["Users"]].Position = Find(this.lvwUsers.SelectedItems[0].Text);
					
					ControlListener.Listen(this);
					
				}
				catch (Exception)
				{
				}
			}
			
			private void SaveUser()
			{
				
				if (this.txtUserId.Text == "")
				{
					MessageBox.Show("Please input User Id.","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.txtUserId.Focus();
					return;
				}
				
				if (this.txtLastName.Text == "" || this.txtFirstName.Text == "")
				{
					MessageBox.Show("Please input necessary fields..","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
					this.txtLastName.Focus();
					return;
				}

                if(gbxPassword.Visible == true)
                {
                    if (txtPassword.Text != txtConfirmPassword.Text)
                    {
                        MessageBox.Show("Password did not match.", "Event Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        this.txtLastName.Focus();
                        return;
                    }
                }

				// >> Save New User
				FormToObjectInstanceBinder.BindObjectToInputControls(this, oUser);
				oUser.CreatedBy = GlobalVariables.gLoggedOnUser;
				oUser.UpdatedBy = oUser.CreatedBy;
				assignUserRoles(oUser);
				
				
				// >> Update User
				if (this.Text.IndexOf("*") > 0)
				{
					if (mode == "Change Password")
					{
						oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
						
                        if (!oUserFacade.AuthenticateUser(ref oUser))
                        {
                            MessageBox.Show("Password did not match.","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                            this.txtConfirmPassword.Focus();
                            return;
                        }
                        else
                        {
                            if (this.txtPassword.Text.Equals(this.txtConfirmPassword.Text))
                            {
                                oUser.Password = this.txtPassword.Text;
                                UpdateUser();
                                return;
                            }
                            else
                            {
								MessageBox.Show("Password did not match.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                this.txtConfirmPassword.Focus();
                                return;
                            }

                        }
					}
                    
					UpdateUser();
					
					// >> Add New User
				}
				else
				{
					if (mode == "Add")
					{
						if (!(this.txtPassword.Text == this.txtConfirmPassword.Text))
						{
							MessageBox.Show("Password did not match.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							this.txtConfirmPassword.Focus();
							return;
						}
						
						AppendUser();

						
					}
				}
			}
			
			private void AppendUser()
			{
				
				oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
				if (oUserFacade.InsertUser(ref oUser))
				{
					MessageBox.Show("User sucessfully added.","Folio Pus", MessageBoxButtons.OK, MessageBoxIcon.Information);
					
					ListViewItem lvwItem = new ListViewItem(oUser.UserId);
					this.lvwUsers.Items.Add(lvwItem);
					
					
					this.txtConfirmPassword.Text = "";
					this.BindingContext[oUser.Tables["Users"]].ResumeBinding();
					this.Text = "Users";
					
					this.txtUserId.Enabled = false;
					this.txtPassword.Text = "";
					this.txtConfirmPassword.Text = "";

					mode = "";
					SetButtonState(true);
					
					ControlListener.Listen(this);
				}
				
			}
			
			private void assignUserRoles(User oUser)
			{
				RoleCollection _oRoleCollection = new RoleCollection();
		
				for (int i = 1; i < this.grdRoles.Rows.Count; i++)
				{
					Role _oRole = new Role();
					_oRole.RoleName = this.grdRoles.GetDataDisplay(i, 1);
					oRole.HotelId = GlobalVariables.gHotelId;


					_oRoleCollection.Add(_oRole);
				}

				oUser.Roles = _oRoleCollection;
			}



			private void UpdateUser()
			{
				//InstanceBinder.BindObjectToInputControls(Me, oUser)
				//oUser.UpdatedBy = GlobalVariables.LoggedOnUser
				//oUserFacade = New UserFacade(GlobalVariables.PersistentConnection)
                //oUser.Password = oUserFacade.GetOldPassword(oUser);
				this.txtPassword.Text = "";
				this.txtConfirmPassword.Text = "";
				if (oUserFacade.UpdateUser(ref oUser))
				{
					MessageBox.Show("User Info. sucessfully updated.","Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Information);
					
					
					this.BindingContext[oUser.Tables["Users"]].ResumeBinding();
					this.Text = "Users";
					
					mode = "";
					ControlListener.Listen(this);
				}
				
				
				
			}
			
			private void CancelTransaction()
			{
				if (mode == "Add")
				{
					if (this.lvwUsers.Items.Count > 0)
					{
						this.lvwUsers.Items[0].Selected = true;
					}
				}
				else
				{
					this.BindingContext[oUser.Tables["Users"]].CancelCurrentEdit();
					
				}
				
				this.BindingContext[oUser.Tables["Users"]].ResumeBinding();
				this.txtUserId.Enabled = false;
				
				this.gbxPassword.Enabled = false;
				
				mode = "";
				this.Text = "Users";
				SetButtonState(true);
				
				ControlListener.Listen(this);
			}
			
			private void DeleteUser()
			{
				if (MessageBox.Show("Delete User '" + this.txtUserId.Text + "'","Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					
					this.Text = "Users";
					ControlListener.StopListen(this);
					
					oUserFacade = new UserFacade(connectionStr);
					oUserFacade.DeleteUser(this.txtUserId.Text, ref oUser);
                    lvwUsers.Items[lvwUsers.SelectedIndices[0]].Remove();
					
					//If Me.grdUsers.VisibleRowCount > 0 Then _
					//Me.grdUsers.Select(0)
					
					ControlListener.Listen(this);
					
				}
			}
			
			private void SetButtonState()
			{
				if (this.Text.IndexOf("*") > 0)
				{
					SetButtonState(false);
				}
				else
				{
					SetButtonState(true);
				}
			}
			
			private void SetButtonState(bool stat)
			{
				UserUI with_1 = this;
				with_1.btnDelete.Enabled = stat;
				with_1.btnNew.Enabled = stat;
				with_1.btnSave.Enabled = ! stat;
				with_1.btnCancel.Enabled = ! stat;
				with_1.btnSearch.Enabled = stat;
				with_1.btnResetPassword.Enabled = stat;
			}
			
			#endregion
			
			private void lvwUsers_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				BindRowToControls();
			}
			
			private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					this.lvwUsers.Focus();
					
					DeselectItem();
					
					for (int i = 0; i <= this.lvwUsers.Items.Count - 1; i++)
					{
						if(this.lvwUsers.Items[i].Text.Contains(this.txtSearch.Text.ToUpper()))
						{
							
							this.lvwUsers.Items[i].Selected = true;
							this.lvwUsers.Items[i].EnsureVisible();
							
							this.pnlSearch.Visible = false;
							this.ControlListener.Listen(this);
							return;
						}
					}
				}
			}
			
			private void DeselectItem()
			{
				for (int i = 0; i <= this.lvwUsers.Items.Count - 1; i++)
				{
					this.lvwUsers.Items[i].Selected = false;
				}
			}
			
			private int Find(string key)
			{
				DataRow drUser;
				int i;
				
				i = 0;
				foreach (DataRow tempLoopVar_drUser in oUser.Tables[0].Rows)
				{
					drUser = tempLoopVar_drUser;
					if (drUser["UserId"].ToString() == key)
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
			
			private void picClose_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = false;
				this.ControlListener.Listen(this);
			}
			
			private void lvwUsers_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
			{
				DetectChanges();
			}
			
			private void btnSearch_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = true;
				this.txtSearch.Focus();
				this.txtSearch.SelectAll();
				this.ControlListener.StopListen(this);
			}
			
			private void txtSearch_TextChanged(System.Object sender, System.EventArgs e)
			{
				
			}
			
			private void cboHotelId_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
                try
                {
                    this.cboHotelName.SelectedIndex = cboHotelId.SelectedIndex;
                }
                catch
                {}
			}
			
			private void cboHotelName_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				this.cboHotelId.SelectedIndex = cboHotelName.SelectedIndex;
			}
			
			private void btnAdd_Click(System.Object sender, System.EventArgs e)
			{
				//ListViewItem lvwItem = new ListViewItem("");
				//lvwItem.SubItems.Add("");
				//lvwItem.BackColor = System.Drawing.SystemColors.Info;
				//this.lvwRoles.Items.Add(lvwItem);
				
				//lvwRoles_SubItemClicked(lvwRoles, new ListViewEx.SubItemEventArgs(lvwRoles.Items[lvwRoles.Items.Count - 1], 0));
				this.grdRoles.Rows.Count += 1;

				enumerateGridList();
				
			}

			private void enumerateGridList()
			{
				for (int i = 1; i < this.grdRoles.Rows.Count; i++)
				{
					this.grdRoles.SetData(i, 0, i);
				}
			}

			
			
			private void btnRemove_Click(System.Object sender, System.EventArgs e)
			{
				int _row = this.grdRoles.Row;
				if(_row <= 0)
					return;

				string _roleName = this.grdRoles.GetDataDisplay(_row, 1);

				if (MessageBox.Show("Are you sure you want to remove '" + _roleName + "'?", "Confirm",MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
				{
					if (mode == "Add")
					{
						
						this.grdRoles.Rows.Remove(_row);

						//this.lvwRoles.SelectedItems[0].Remove();
						enumerateGridList();

					}
					else
					{
						// remove user role
						oUserFacade = new UserFacade(GlobalVariables.gPersistentConnection);
						
						

						if (oUserFacade.RemoveUserRole(this.txtUserId.Text, this.cboHotelId.Text, _roleName))
						{
							this.grdRoles.Rows.Remove(_row);

							//this.lvwRoles.SelectedItems[0].Remove();
							enumerateGridList();
						}
					}
					
				}
			}
			
			//Private Function hasDuplicate(ByVal str As String) As Boolean
			//    Dim lst As ListViewItem
			//    For Each lst In Me.lvwRoles.Items
			//        'If lst.Text = str Then
			//        'Return True
			//        'End If
			//    Next
			
			//    Return False
			//End Function
			
			//private void btnChangePassword_Click(System.Object sender, System.EventArgs e)
			//{
			//    mode = "Change Password";
			//    this.gbxPassword.Enabled = true;
				
			//    this.txtOldPassword.Focus();
			//    SetButtonState(false);
			//}
			
			private void tabUser_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				if (mode != "Add")
				{
					if (tabUser.SelectedIndex == 1)
					{
						LoadUserRoles();
					}
				}
			}
			
			private void txtUserId_TextChanged(System.Object sender, System.EventArgs e)
			{
				tabUser.SelectedIndex = 0;
			}


            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

			private void grdRoles_SelChange(object sender, EventArgs e)
			{
				if (this.grdRoles.Col == 1)
				{
					this.grdRoles.AllowEditing = true;
				}
				else
				{
					this.grdRoles.AllowEditing = false;
				}
			}



			private void btnResetPassword_Click(object sender, EventArgs e)
			{
				ResetPasswordUI _oResetPasswordUI = new ResetPasswordUI(this.txtUserId.Text);
				_oResetPasswordUI.ShowDialog();

			}

			
		}
	}
}
