using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.Accounts.BusinessLayer;
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Cashier
{
    namespace Presentation
    {
        public class TransactionRoutingUI : Jinisys.Hotel.UIFramework.TransactionUI
        {

            #region " Windows Form Designer generated code "

            public TransactionRoutingUI()
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
            internal System.Windows.Forms.ColumnHeader ColumnHeader2;
            internal System.Windows.Forms.ColumnHeader ColumnHeader3;
            internal System.Windows.Forms.ColumnHeader ColumnHeader4;
            internal System.Windows.Forms.ColumnHeader ColumnHeader5;
            internal System.Windows.Forms.Label Label7;
            internal System.Windows.Forms.GroupBox GroupBox1;
            internal System.Windows.Forms.Label Label4;
            internal System.Windows.Forms.Label Label2;
            internal System.Windows.Forms.ListView lvwFrom;
            internal System.Windows.Forms.TextBox txtRoomFrom;
            internal System.Windows.Forms.Button btnTransfer;
            internal System.Windows.Forms.Button btnReturn;
            internal System.Windows.Forms.Button bntSave;
            internal System.Windows.Forms.Button btnClose;
            internal System.Windows.Forms.TextBox txtGuestFrom;
            internal System.Windows.Forms.ListView lvwBrowseGroupName;
            internal System.Windows.Forms.ColumnHeader ColumnHeader11;
            internal System.Windows.Forms.ColumnHeader ColumnHeader12;
            internal System.Windows.Forms.ColumnHeader ColumnHeader13;
            internal System.Windows.Forms.GroupBox GroupBox2;
            internal System.Windows.Forms.Label Label3;
            internal System.Windows.Forms.Label Label5;
            internal System.Windows.Forms.Label Label6;
            internal System.Windows.Forms.ColumnHeader ColumnHeader14;
            internal System.Windows.Forms.ColumnHeader ColumnHeader15;
            internal System.Windows.Forms.ColumnHeader ColumnHeader16;
            internal System.Windows.Forms.TextBox txtGuestTo;
            internal System.Windows.Forms.TextBox txtRoomTo;
            internal System.Windows.Forms.ListView lvwBrowseGroupName1;
            internal System.Windows.Forms.ComboBox cboSubFolioFrom;
            internal System.Windows.Forms.Label Label1;
            internal System.Windows.Forms.Label Label8;
            internal System.Windows.Forms.ComboBox cboSubFolioTo;
            internal System.Windows.Forms.ListView lvwTo;
            internal System.Windows.Forms.ColumnHeader ColumnHeader18;
            internal System.Windows.Forms.ColumnHeader ColumnHeader19;
            internal System.Windows.Forms.ColumnHeader ColumnHeader20;
            internal System.Windows.Forms.ColumnHeader ColumnHeader21;
            private ComboBox cboFolioIdFrom;
            private ComboBox cboFolioIdTo;
            private ColumnHeader columnHeader6;
            private ColumnHeader columnHeader7;
            internal Label label9;
            internal Label label10;
            internal Label label11;
            internal Label label43;
            internal Label label24;
            private Button btnSearchFrom;
            private Button btnSearchTo;
            internal System.Windows.Forms.CheckBox chkCheckAll;
            [System.Diagnostics.DebuggerStepThrough()]
            private void InitializeComponent()
            {
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TransactionRoutingUI));
                this.lvwFrom = new System.Windows.Forms.ListView();
                this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader5 = new System.Windows.Forms.ColumnHeader();
                this.btnReturn = new System.Windows.Forms.Button();
                this.btnTransfer = new System.Windows.Forms.Button();
                this.Label7 = new System.Windows.Forms.Label();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.btnSearchFrom = new System.Windows.Forms.Button();
                this.label10 = new System.Windows.Forms.Label();
                this.cboFolioIdFrom = new System.Windows.Forms.ComboBox();
                this.Label1 = new System.Windows.Forms.Label();
                this.cboSubFolioFrom = new System.Windows.Forms.ComboBox();
                this.txtGuestFrom = new System.Windows.Forms.TextBox();
                this.chkCheckAll = new System.Windows.Forms.CheckBox();
                this.txtRoomFrom = new System.Windows.Forms.TextBox();
                this.Label4 = new System.Windows.Forms.Label();
                this.Label2 = new System.Windows.Forms.Label();
                this.btnClose = new System.Windows.Forms.Button();
                this.bntSave = new System.Windows.Forms.Button();
                this.lvwBrowseGroupName = new System.Windows.Forms.ListView();
                this.ColumnHeader11 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader12 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader13 = new System.Windows.Forms.ColumnHeader();
                this.GroupBox2 = new System.Windows.Forms.GroupBox();
                this.btnSearchTo = new System.Windows.Forms.Button();
                this.label11 = new System.Windows.Forms.Label();
                this.cboFolioIdTo = new System.Windows.Forms.ComboBox();
                this.Label8 = new System.Windows.Forms.Label();
                this.cboSubFolioTo = new System.Windows.Forms.ComboBox();
                this.lvwTo = new System.Windows.Forms.ListView();
                this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader18 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader19 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader20 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader21 = new System.Windows.Forms.ColumnHeader();
                this.txtGuestTo = new System.Windows.Forms.TextBox();
                this.txtRoomTo = new System.Windows.Forms.TextBox();
                this.Label3 = new System.Windows.Forms.Label();
                this.Label5 = new System.Windows.Forms.Label();
                this.Label6 = new System.Windows.Forms.Label();
                this.lvwBrowseGroupName1 = new System.Windows.Forms.ListView();
                this.ColumnHeader14 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader15 = new System.Windows.Forms.ColumnHeader();
                this.ColumnHeader16 = new System.Windows.Forms.ColumnHeader();
                this.label9 = new System.Windows.Forms.Label();
                this.label43 = new System.Windows.Forms.Label();
                this.label24 = new System.Windows.Forms.Label();
                this.GroupBox1.SuspendLayout();
                this.GroupBox2.SuspendLayout();
                this.SuspendLayout();
                // 
                // lvwFrom
                // 
                this.lvwFrom.CheckBoxes = true;
                this.lvwFrom.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader6,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.ColumnHeader5});
                this.lvwFrom.FullRowSelect = true;
                this.lvwFrom.GridLines = true;
                this.lvwFrom.Location = new System.Drawing.Point(16, 207);
                this.lvwFrom.Name = "lvwFrom";
                this.lvwFrom.Size = new System.Drawing.Size(369, 291);
                this.lvwFrom.TabIndex = 6;
                this.lvwFrom.UseCompatibleStateImageBehavior = false;
                this.lvwFrom.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader6
                // 
                this.columnHeader6.Text = "Trans. Date";
                this.columnHeader6.Width = 69;
                // 
                // ColumnHeader2
                // 
                this.ColumnHeader2.Text = "Ref#";
                this.ColumnHeader2.Width = 51;
                // 
                // ColumnHeader3
                // 
                this.ColumnHeader3.Text = "Code";
                this.ColumnHeader3.Width = 45;
                // 
                // ColumnHeader4
                // 
                this.ColumnHeader4.Text = "Memo";
                this.ColumnHeader4.Width = 115;
                // 
                // ColumnHeader5
                // 
                this.ColumnHeader5.Text = "Amount";
                // 
                // btnReturn
                // 
                this.btnReturn.Cursor = System.Windows.Forms.Cursors.Default;
                this.btnReturn.Image = ((System.Drawing.Image)(resources.GetObject("btnReturn.Image")));
                this.btnReturn.Location = new System.Drawing.Point(414, 362);
                this.btnReturn.Name = "btnReturn";
                this.btnReturn.Size = new System.Drawing.Size(32, 28);
                this.btnReturn.TabIndex = 9;
                this.btnReturn.Click += new System.EventHandler(this.btnReturn_Click);
                // 
                // btnTransfer
                // 
                this.btnTransfer.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnTransfer.Image = ((System.Drawing.Image)(resources.GetObject("btnTransfer.Image")));
                this.btnTransfer.Location = new System.Drawing.Point(414, 323);
                this.btnTransfer.Name = "btnTransfer";
                this.btnTransfer.Size = new System.Drawing.Size(32, 28);
                this.btnTransfer.TabIndex = 8;
                this.btnTransfer.Click += new System.EventHandler(this.btnTransfer_Click);
                // 
                // Label7
                // 
                this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label7.Location = new System.Drawing.Point(16, 32);
                this.Label7.Name = "Label7";
                this.Label7.Size = new System.Drawing.Size(72, 14);
                this.Label7.TabIndex = 13;
                this.Label7.Text = "Room No.";
                this.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // GroupBox1
                // 
                this.GroupBox1.Controls.Add(this.btnSearchFrom);
                this.GroupBox1.Controls.Add(this.lvwFrom);
                this.GroupBox1.Controls.Add(this.label10);
                this.GroupBox1.Controls.Add(this.cboFolioIdFrom);
                this.GroupBox1.Controls.Add(this.Label1);
                this.GroupBox1.Controls.Add(this.cboSubFolioFrom);
                this.GroupBox1.Controls.Add(this.txtGuestFrom);
                this.GroupBox1.Controls.Add(this.chkCheckAll);
                this.GroupBox1.Controls.Add(this.txtRoomFrom);
                this.GroupBox1.Controls.Add(this.Label4);
                this.GroupBox1.Controls.Add(this.Label2);
                this.GroupBox1.Controls.Add(this.Label7);
                this.GroupBox1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.GroupBox1.Location = new System.Drawing.Point(15, 115);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(395, 535);
                this.GroupBox1.TabIndex = 0;
                this.GroupBox1.TabStop = false;
                this.GroupBox1.Text = "FROM ( Origin Folio )";
                // 
                // btnSearchFrom
                // 
                this.btnSearchFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSearchFrom.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
                this.btnSearchFrom.Location = new System.Drawing.Point(179, 27);
                this.btnSearchFrom.Name = "btnSearchFrom";
                this.btnSearchFrom.Size = new System.Drawing.Size(26, 24);
                this.btnSearchFrom.TabIndex = 27;
                this.btnSearchFrom.UseVisualStyleBackColor = true;
                this.btnSearchFrom.Click += new System.EventHandler(this.btnSearchFrom_Click);
                // 
                // label10
                // 
                this.label10.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label10.Location = new System.Drawing.Point(16, 188);
                this.label10.Name = "label10";
                this.label10.Size = new System.Drawing.Size(80, 14);
                this.label10.TabIndex = 26;
                this.label10.Text = "Transactions :";
                this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // cboFolioIdFrom
                // 
                this.cboFolioIdFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboFolioIdFrom.FormattingEnabled = true;
                this.cboFolioIdFrom.Location = new System.Drawing.Point(117, 92);
                this.cboFolioIdFrom.Name = "cboFolioIdFrom";
                this.cboFolioIdFrom.Size = new System.Drawing.Size(157, 22);
                this.cboFolioIdFrom.TabIndex = 3;
                this.cboFolioIdFrom.TextChanged += new System.EventHandler(this.cboFolioIdFrom_TextChanged);
                // 
                // Label1
                // 
                this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label1.Location = new System.Drawing.Point(16, 65);
                this.Label1.Name = "Label1";
                this.Label1.Size = new System.Drawing.Size(69, 14);
                this.Label1.TabIndex = 25;
                this.Label1.Text = "Sub-Folio";
                this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // cboSubFolioFrom
                // 
                this.cboSubFolioFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboSubFolioFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.cboSubFolioFrom.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboSubFolioFrom.Location = new System.Drawing.Point(117, 61);
                this.cboSubFolioFrom.Name = "cboSubFolioFrom";
                this.cboSubFolioFrom.Size = new System.Drawing.Size(61, 22);
                this.cboSubFolioFrom.TabIndex = 2;
                this.cboSubFolioFrom.SelectedIndexChanged += new System.EventHandler(this.cboSubFolioFrom_SelectedIndexChanged);
                // 
                // txtGuestFrom
                // 
                this.txtGuestFrom.BackColor = System.Drawing.SystemColors.Info;
                this.txtGuestFrom.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtGuestFrom.Location = new System.Drawing.Point(117, 126);
                this.txtGuestFrom.Name = "txtGuestFrom";
                this.txtGuestFrom.Size = new System.Drawing.Size(265, 20);
                this.txtGuestFrom.TabIndex = 4;
                this.txtGuestFrom.TextChanged += new System.EventHandler(this.txtGuestFrom_TextChanged);
                this.txtGuestFrom.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGuestFrom_KeyDown);
                // 
                // chkCheckAll
                // 
                this.chkCheckAll.Location = new System.Drawing.Point(17, 504);
                this.chkCheckAll.Name = "chkCheckAll";
                this.chkCheckAll.Size = new System.Drawing.Size(91, 18);
                this.chkCheckAll.TabIndex = 7;
                this.chkCheckAll.Text = "Select All";
                this.chkCheckAll.CheckedChanged += new System.EventHandler(this.chkCheckAll_CheckedChanged);
                // 
                // txtRoomFrom
                // 
                this.txtRoomFrom.BackColor = System.Drawing.SystemColors.Info;
                this.txtRoomFrom.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtRoomFrom.Location = new System.Drawing.Point(117, 29);
                this.txtRoomFrom.Name = "txtRoomFrom";
                this.txtRoomFrom.Size = new System.Drawing.Size(61, 20);
                this.txtRoomFrom.TabIndex = 1;
                this.txtRoomFrom.Leave += new System.EventHandler(this.txtRoomFrom_Leave);
                this.txtRoomFrom.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomFrom_KeyPress);
                // 
                // Label4
                // 
                this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label4.Location = new System.Drawing.Point(16, 96);
                this.Label4.Name = "Label4";
                this.Label4.Size = new System.Drawing.Size(65, 14);
                this.Label4.TabIndex = 17;
                this.Label4.Text = "Folio ID";
                this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label2
                // 
                this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label2.Location = new System.Drawing.Point(16, 129);
                this.Label2.Name = "Label2";
                this.Label2.Size = new System.Drawing.Size(88, 14);
                this.Label2.TabIndex = 16;
                this.Label2.Text = "Guest/Company";
                this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // btnClose
                // 
                this.btnClose.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(777, 67);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 18;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // bntSave
                // 
                this.bntSave.Cursor = System.Windows.Forms.Cursors.Arrow;
                this.bntSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.bntSave.Location = new System.Drawing.Point(705, 67);
                this.bntSave.Name = "bntSave";
                this.bntSave.Size = new System.Drawing.Size(66, 31);
                this.bntSave.TabIndex = 17;
                this.bntSave.Text = "&Save";
                this.bntSave.Click += new System.EventHandler(this.bntSave_Click);
                // 
                // lvwBrowseGroupName
                // 
                this.lvwBrowseGroupName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lvwBrowseGroupName.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader11,
            this.ColumnHeader12,
            this.ColumnHeader13});
                this.lvwBrowseGroupName.FullRowSelect = true;
                this.lvwBrowseGroupName.Location = new System.Drawing.Point(128, 259);
                this.lvwBrowseGroupName.Name = "lvwBrowseGroupName";
                this.lvwBrowseGroupName.Size = new System.Drawing.Size(272, 150);
                this.lvwBrowseGroupName.TabIndex = 5;
                this.lvwBrowseGroupName.UseCompatibleStateImageBehavior = false;
                this.lvwBrowseGroupName.View = System.Windows.Forms.View.Details;
                this.lvwBrowseGroupName.Visible = false;
                this.lvwBrowseGroupName.DoubleClick += new System.EventHandler(this.lvwBrowseGroupName_DoubleClick);
                this.lvwBrowseGroupName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwBrowseGroupName_KeyDown);
                this.lvwBrowseGroupName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGroupName_KeyPress);
                // 
                // ColumnHeader11
                // 
                this.ColumnHeader11.Text = "GroupName";
                this.ColumnHeader11.Width = 108;
                // 
                // ColumnHeader12
                // 
                this.ColumnHeader12.Text = "Company";
                this.ColumnHeader12.Width = 197;
                // 
                // ColumnHeader13
                // 
                this.ColumnHeader13.Text = "FolioID";
                this.ColumnHeader13.Width = 112;
                // 
                // GroupBox2
                // 
                this.GroupBox2.Controls.Add(this.btnSearchTo);
                this.GroupBox2.Controls.Add(this.label11);
                this.GroupBox2.Controls.Add(this.cboFolioIdTo);
                this.GroupBox2.Controls.Add(this.Label8);
                this.GroupBox2.Controls.Add(this.cboSubFolioTo);
                this.GroupBox2.Controls.Add(this.lvwTo);
                this.GroupBox2.Controls.Add(this.txtGuestTo);
                this.GroupBox2.Controls.Add(this.txtRoomTo);
                this.GroupBox2.Controls.Add(this.Label3);
                this.GroupBox2.Controls.Add(this.Label5);
                this.GroupBox2.Controls.Add(this.Label6);
                this.GroupBox2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.GroupBox2.Location = new System.Drawing.Point(451, 115);
                this.GroupBox2.Name = "GroupBox2";
                this.GroupBox2.Size = new System.Drawing.Size(395, 535);
                this.GroupBox2.TabIndex = 10;
                this.GroupBox2.TabStop = false;
                this.GroupBox2.Text = "TO ( Destination Folio )";
                // 
                // btnSearchTo
                // 
                this.btnSearchTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSearchTo.Image = global::Jinisys.Hotel.Cashier.Properties.Resources.search_small;
                this.btnSearchTo.Location = new System.Drawing.Point(181, 27);
                this.btnSearchTo.Name = "btnSearchTo";
                this.btnSearchTo.Size = new System.Drawing.Size(26, 24);
                this.btnSearchTo.TabIndex = 140;
                this.btnSearchTo.UseVisualStyleBackColor = true;
                this.btnSearchTo.Click += new System.EventHandler(this.btnSearchTo_Click);
                // 
                // label11
                // 
                this.label11.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label11.Location = new System.Drawing.Point(18, 188);
                this.label11.Name = "label11";
                this.label11.Size = new System.Drawing.Size(80, 14);
                this.label11.TabIndex = 28;
                this.label11.Text = "Transactions :";
                this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // cboFolioIdTo
                // 
                this.cboFolioIdTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboFolioIdTo.FormattingEnabled = true;
                this.cboFolioIdTo.Location = new System.Drawing.Point(110, 92);
                this.cboFolioIdTo.Name = "cboFolioIdTo";
                this.cboFolioIdTo.Size = new System.Drawing.Size(157, 22);
                this.cboFolioIdTo.TabIndex = 13;
                this.cboFolioIdTo.TextChanged += new System.EventHandler(this.cboFolioIdTo_TextChanged);
                // 
                // Label8
                // 
                this.Label8.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label8.Location = new System.Drawing.Point(18, 64);
                this.Label8.Name = "Label8";
                this.Label8.Size = new System.Drawing.Size(63, 17);
                this.Label8.TabIndex = 27;
                this.Label8.Text = "Sub-Folio";
                this.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // cboSubFolioTo
                // 
                this.cboSubFolioTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
                this.cboSubFolioTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.cboSubFolioTo.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
                this.cboSubFolioTo.Location = new System.Drawing.Point(110, 61);
                this.cboSubFolioTo.Name = "cboSubFolioTo";
                this.cboSubFolioTo.Size = new System.Drawing.Size(70, 22);
                this.cboSubFolioTo.TabIndex = 12;
                this.cboSubFolioTo.SelectedIndexChanged += new System.EventHandler(this.cboSubFolioTo_SelectedIndexChanged);
                // 
                // lvwTo
                // 
                this.lvwTo.CheckBoxes = true;
                this.lvwTo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader7,
            this.ColumnHeader18,
            this.ColumnHeader19,
            this.ColumnHeader20,
            this.ColumnHeader21});
                this.lvwTo.FullRowSelect = true;
                this.lvwTo.GridLines = true;
                this.lvwTo.Location = new System.Drawing.Point(18, 207);
                this.lvwTo.Name = "lvwTo";
                this.lvwTo.Size = new System.Drawing.Size(369, 291);
                this.lvwTo.TabIndex = 16;
                this.lvwTo.UseCompatibleStateImageBehavior = false;
                this.lvwTo.View = System.Windows.Forms.View.Details;
                // 
                // columnHeader7
                // 
                this.columnHeader7.Text = "Trans. Date";
                this.columnHeader7.Width = 69;
                // 
                // ColumnHeader18
                // 
                this.ColumnHeader18.Text = "Ref#";
                this.ColumnHeader18.Width = 51;
                // 
                // ColumnHeader19
                // 
                this.ColumnHeader19.Text = "Code";
                this.ColumnHeader19.Width = 45;
                // 
                // ColumnHeader20
                // 
                this.ColumnHeader20.Text = "Memo";
                this.ColumnHeader20.Width = 115;
                // 
                // ColumnHeader21
                // 
                this.ColumnHeader21.Text = "Amount";
                // 
                // txtGuestTo
                // 
                this.txtGuestTo.BackColor = System.Drawing.SystemColors.Info;
                this.txtGuestTo.Font = new System.Drawing.Font("Arial", 8.25F);
                this.txtGuestTo.Location = new System.Drawing.Point(110, 126);
                this.txtGuestTo.Name = "txtGuestTo";
                this.txtGuestTo.Size = new System.Drawing.Size(265, 20);
                this.txtGuestTo.TabIndex = 14;
                this.txtGuestTo.GotFocus += new System.EventHandler(this.txtGuest1_GotFocus);
                this.txtGuestTo.TextChanged += new System.EventHandler(this.txtGuestTo_TextChanged);
                this.txtGuestTo.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtGuestTo_KeyDown);
                // 
                // txtRoomTo
                // 
                this.txtRoomTo.BackColor = System.Drawing.SystemColors.Info;
                this.txtRoomTo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
                this.txtRoomTo.Location = new System.Drawing.Point(110, 29);
                this.txtRoomTo.Name = "txtRoomTo";
                this.txtRoomTo.Size = new System.Drawing.Size(70, 20);
                this.txtRoomTo.TabIndex = 11;
                this.txtRoomTo.Leave += new System.EventHandler(this.txtRoomTo_Leave);
                this.txtRoomTo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtRoomTo_KeyPress);
                // 
                // Label3
                // 
                this.Label3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label3.Location = new System.Drawing.Point(18, 97);
                this.Label3.Name = "Label3";
                this.Label3.Size = new System.Drawing.Size(65, 12);
                this.Label3.TabIndex = 17;
                this.Label3.Text = "Folio ID";
                this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label5
                // 
                this.Label5.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label5.Location = new System.Drawing.Point(18, 129);
                this.Label5.Name = "Label5";
                this.Label5.Size = new System.Drawing.Size(88, 15);
                this.Label5.TabIndex = 16;
                this.Label5.Text = "Guest/Company";
                this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // Label6
                // 
                this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Label6.Location = new System.Drawing.Point(18, 31);
                this.Label6.Name = "Label6";
                this.Label6.Size = new System.Drawing.Size(64, 17);
                this.Label6.TabIndex = 13;
                this.Label6.Text = "Room No.";
                this.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // lvwBrowseGroupName1
                // 
                this.lvwBrowseGroupName1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                this.lvwBrowseGroupName1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader14,
            this.ColumnHeader15,
            this.ColumnHeader16});
                this.lvwBrowseGroupName1.FullRowSelect = true;
                this.lvwBrowseGroupName1.Location = new System.Drawing.Point(560, 259);
                this.lvwBrowseGroupName1.Name = "lvwBrowseGroupName1";
                this.lvwBrowseGroupName1.Size = new System.Drawing.Size(272, 150);
                this.lvwBrowseGroupName1.TabIndex = 15;
                this.lvwBrowseGroupName1.UseCompatibleStateImageBehavior = false;
                this.lvwBrowseGroupName1.View = System.Windows.Forms.View.Details;
                this.lvwBrowseGroupName1.Visible = false;
                this.lvwBrowseGroupName1.DoubleClick += new System.EventHandler(this.lvwBrowseGroupName1_DoubleClick);
                this.lvwBrowseGroupName1.KeyDown += new System.Windows.Forms.KeyEventHandler(this.lvwBrowseGroupName1_KeyDown);
                this.lvwBrowseGroupName1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.lvwBrowseGroupName1_KeyPress);
                // 
                // ColumnHeader14
                // 
                this.ColumnHeader14.Text = "GroupName";
                this.ColumnHeader14.Width = 108;
                // 
                // ColumnHeader15
                // 
                this.ColumnHeader15.Text = "Company";
                this.ColumnHeader15.Width = 197;
                // 
                // ColumnHeader16
                // 
                this.ColumnHeader16.Text = "FolioID";
                this.ColumnHeader16.Width = 112;
                // 
                // label9
                // 
                this.label9.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.label9.Location = new System.Drawing.Point(17, 19);
                this.label9.Name = "label9";
                this.label9.Size = new System.Drawing.Size(199, 27);
                this.label9.TabIndex = 19;
                this.label9.Text = "Transaction Routing";
                this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
                // 
                // label43
                // 
                this.label43.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label43.Image = ((System.Drawing.Image)(resources.GetObject("label43.Image")));
                this.label43.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
                this.label43.Location = new System.Drawing.Point(17, 60);
                this.label43.Name = "label43";
                this.label43.Size = new System.Drawing.Size(29, 30);
                this.label43.TabIndex = 139;
                // 
                // label24
                // 
                this.label24.Font = new System.Drawing.Font("Arial", 8.25F);
                this.label24.Location = new System.Drawing.Point(53, 60);
                this.label24.Name = "label24";
                this.label24.Size = new System.Drawing.Size(288, 33);
                this.label24.TabIndex = 138;
                this.label24.Text = "Transaction Routing allows you to transfer transactions from one room to another." +
                    "";
                // 
                // TransactionRoutingUI
                // 
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.ClientSize = new System.Drawing.Size(855, 656);
                this.Controls.Add(this.lvwBrowseGroupName1);
                this.Controls.Add(this.lvwBrowseGroupName);
                this.Controls.Add(this.label43);
                this.Controls.Add(this.label24);
                this.Controls.Add(this.label9);
                this.Controls.Add(this.GroupBox2);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.bntSave);
                this.Controls.Add(this.btnTransfer);
                this.Controls.Add(this.btnReturn);
                this.Controls.Add(this.GroupBox1);
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "TransactionRoutingUI";
                this.Text = "Transaction Routing";
                this.Activated += new System.EventHandler(this.TransactionRoutingUI_Activated);
                this.Load += new System.EventHandler(this.TransactionRoutingUI_Load);
                this.GroupBox1.ResumeLayout(false);
                this.GroupBox1.PerformLayout();
                this.GroupBox2.ResumeLayout(false);
                this.GroupBox2.PerformLayout();
                this.ResumeLayout(false);

            }

            #endregion

            #region "Variable Declareation"
            private MySqlConnection localConnection;
            private FolioFacade oFolioFacade;
            private FolioTransaction oFolioTrans = new FolioTransaction();
            private FolioTransactionFacade oFolioTransFacade;
            private Jinisys.Hotel.BusinessSharedClasses.FormToObjectInstanceBinder oFormtoObjectInstance = new Jinisys.Hotel.BusinessSharedClasses.FormToObjectInstanceBinder();
            #endregion

            public TransactionRoutingUI(MySqlConnection con)
            {
                //This call is required by the Windows Form Designer.
                InitializeComponent();
                localConnection = con;
                oFolioFacade = new FolioFacade();
                oFolioTransFacade = new FolioTransactionFacade();
            }

            private void chkCheckAll_CheckedChanged(System.Object sender, System.EventArgs e)
            {
                ListViewItem lvwItem;
                foreach (ListViewItem tempLoopVar_lvwItem in this.lvwFrom.Items)
                {
                    lvwItem = tempLoopVar_lvwItem;
                    lvwItem.Checked = System.Convert.ToBoolean(chkCheckAll.CheckState);
                }
            }

            private void btnClose_Click(System.Object sender, System.EventArgs e)
            {
                this.Close();
            }

            private string side = "";
            private void txtGuestFrom_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                SKeyDown(sender, e, this.lvwBrowseGroupName);
            }

            private void lvwBrowseGroupName_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.lvwBrowseGroupName.Visible = false;
                }
            }

            private void txtGuestTo_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                SKeyDown(sender, e, this.lvwBrowseGroupName1);
            }

            private void txtGuest1_GotFocus(object sender, System.EventArgs e)
            {
                side = "Right";
            }

            private void lvwBrowseGroupName1_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
            {
                if (e.KeyCode == Keys.Escape)
                {
                    this.lvwBrowseGroupName1.Visible = false;
                }
            }

            private void lvwBrowseGroupName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    assignTextBoxValue(null, this.cboFolioIdFrom, txtGuestFrom, lvwBrowseGroupName);
                }
            }

            private void lvwBrowseGroupName1_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    assignTextBoxValue(null, this.cboFolioIdTo, txtGuestTo, lvwBrowseGroupName1);
                }
            }

            private void lvwBrowseGroupName1_DoubleClick(object sender, System.EventArgs e)
            {
                assignTextBoxValue(null, this.cboFolioIdTo, txtGuestTo, lvwBrowseGroupName1);
            }


            DataView dtView;
            public DataView getRec()
            {
                string cmdText = "select folio.groupname,if(substring(folio.companyid,1,1)='G',fGetCompanyName(folio.companyid), fGetGuestName(folio.companyid)) as companyName,folio.folioid from Folio  where Folio.Status=\'ONGOING\'";
                MySqlCommand cmd = new MySqlCommand(cmdText, GlobalVariables.gPersistentConnection);
                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                DataTable dt = new DataTable("LookUp");
                da.Fill(dt);
                DataView dtView = dt.DefaultView;
                return dtView;
            }

            //Private TransferedItems As New Collection
            private FolioTransactions TransferredItems = new FolioTransactions();
            private void btnTransfer_Click(System.Object sender, System.EventArgs e)
            {
                // to check if ORIGIN_FOLIO.SUB-FOLIO are
                // the same as DESTINATION_FOLIO.SUB-FOLIO
                if (this.cboFolioIdTo.Text == this.cboFolioIdFrom.Text)
                {
                    if (this.cboSubFolioFrom.Text == this.cboSubFolioTo.Text)
                    {
                        MessageBox.Show(" Source and Destination Folio are the same. \r\n Can't proceed transaction transfer. \r\n", "Invalid Transaction", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        return;
                    }
                }

                if (this.cboFolioIdTo.Text != "")
                {

                    int i = 0;
                    foreach (ListViewItem lvwItem in this.lvwFrom.Items)
                    {
                        if (lvwItem.Checked == true)
                        {
                            // to check whether transferring are allowed for transactions on previous dates
                            DateTime _transDate = DateTime.Parse(lvwItem.Text);
                            if (_transDate.Date < DateTime.Parse(GlobalVariables.gAuditDate).Date)
                            {
                                if (bool.Parse(ConfigVariables.gAllowPreviousDaysRouting) == false && 
                                    cboFolioIdFrom.Text != cboFolioIdTo.Text)
                                {
                                    MessageBox.Show("Cannot transfer transaction.\r\n\r\n" +
                                        "Transaction date is less than the current system date.\r\nTransfer only transactions that are within the day. ", "Route Transaction", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    return;
                                }
                            }
                            
                            this.lvwFrom.Items.Remove(lvwItem);
                            this.lvwTo.Items.Add(lvwItem);

                            FolioTransaction fTran = new FolioTransaction();
                            fTran = oFolio.SubFolios.Item(this.cboSubFolioFrom.SelectedIndex).FolioTransactions.Item(i);

                            fTran.SourceFolio = fTran.FolioID;
                            fTran.SourceSubFolio = fTran.SubFolio;
                            fTran.RouteSequence += fTran.FolioID + "(" + fTran.SubFolio + ")";

                            fTran.FolioID = this.cboFolioIdTo.Text;
                            fTran.SubFolio = this.cboSubFolioTo.Text;

                            if (oDestinationFolio != null)
                            {

                                oDestinationFolio.SubFolios.Item(this.cboSubFolioTo.SelectedIndex).FolioTransactions.Add(fTran);

                                // removes SELECTED TRANSACTION from ORIGIN FOLIO
                                oFolio.SubFolios.Item(this.cboSubFolioFrom.SelectedIndex).FolioTransactions.RemoveAt(i);

                                TransferredItems.Add(fTran);

                                i--;
                            }
                        }
                        i++;
                    }

                }
                else
                {
                    MessageBox.Show("Please select a destination Folio!", "No Destination Folio", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    this.txtRoomTo.Focus();
                }

            }

            private void btnReturn_Click(System.Object sender, System.EventArgs e)
            {
                try
                {
                    if (this.cboFolioIdFrom.Text != "")
                    {
                        int i = 0;
                        foreach (ListViewItem lvwItem in this.lvwTo.Items)
                        {
                            if (lvwItem.Checked == true)
                            {

                                FolioTransaction fTran = new FolioTransaction();
                                //fTran = oDestinationFolio.SubFolios.Item(this.cboSubFolioTo.SelectedIndex).Folio.FolioTransactions.Item(i);
                                fTran = oDestinationFolio.SubFolios.Item(this.cboSubFolioTo.SelectedIndex).FolioTransactions.Item(i);

                                if (fTran.SourceFolio != this.cboFolioIdFrom.Text)
                                {
                                    MessageBox.Show("Invalid Operation.\r\nTransaction does not belong to selected Folio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }

                                if (fTran.SourceSubFolio != this.cboSubFolioFrom.Text)
                                {
                                    MessageBox.Show("Invalid Operation. Incorrect Sub-Folio", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }

                                //>> check if in Folio Transaction to transfer
                                //>> trap reverse transfer
                                bool found = false;
                                foreach (FolioTransaction tFolioTrans in TransferredItems)
                                {
                                    if (tFolioTrans.FolioTransactionNo == fTran.FolioTransactionNo)
                                    {
                                        found = true;
                                        break;
                                    }
                                }
                                if (!found)
                                {
                                    MessageBox.Show("Invalid Operation.\r\nTransaction does not belong to selected Origin Folio.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                    return;
                                }
                                //>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>..



                                fTran.FolioID = fTran.SourceFolio;
                                fTran.SubFolio = fTran.SourceSubFolio;

                                fTran.SourceFolio = "";
                                fTran.SourceSubFolio = "";
                                fTran.RouteSequence.Replace(fTran.FolioID + "(" + fTran.SubFolio + ")", "");

                                this.lvwTo.Items.Remove(lvwItem);
                                this.lvwFrom.Items.Add(lvwItem);

                                oDestinationFolio.SubFolios.Item(this.cboSubFolioTo.SelectedIndex).FolioTransactions.RemoveAt(i);
                                oFolio.SubFolios.Item(this.cboSubFolioFrom.SelectedIndex).FolioTransactions.Add(fTran);

                                RemoveInCollection(fTran);

                                i--;
                            }
                            i++;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Invalid Operation!" + "\r\nError: " + ex.Message, "Invalid Operation", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            public void RemoveInCollection(FolioTransaction oFTran)
            {
                int i = 0;
                FolioTransaction oFolioTrans;
                foreach (FolioTransaction tempLoopVar_oFolioTrans in TransferredItems)
                {
                    oFolioTrans = tempLoopVar_oFolioTrans;

                    if (oFolioTrans.PostingDate == oFTran.PostingDate && oFolioTrans.TransactionCode == oFTran.TransactionCode)
                    {
                        TransferredItems.RemoveAt(i);
                        break;
                    }

                    i++;
                }

            }

            private void bntSave_Click(System.Object sender, System.EventArgs e)
            {
                if (TransferredItems.Count > 0)
                {
                    SaveEntry();
                }
                else
                {
                    MessageBox.Show("No items selected for transfer", "Invalid Transaction", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            public void SaveEntry()
            {
                MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();

                oFolioTransFacade = new FolioTransactionFacade();

                foreach (FolioTransaction fTrans in TransferredItems)
                {
                    fTrans.Memo += "(FR. " + this.txtRoomFrom.Text + ")";
                    fTrans.HotelID = GlobalVariables.gHotelId;
                    fTrans.CreatedBy = GlobalVariables.gLoggedOnUser;
                    fTrans.AccountID = oDestinationFolio.AccountID;
                    fTrans.UpdatedBy = GlobalVariables.gLoggedOnUser;
                }

                if (oFolioTransFacade.InsertFolioTransactionsFromTransfer(TransferredItems, ref myTransaction))
                {

                    myTransaction.Commit();

                    this.cboSubFolioFrom_SelectedIndexChanged(this, new EventArgs());
                    TransferredItems.Clear();
                    MessageBox.Show(" Transaction successful. \r\n Charges has been successfully transferred", "Transaction Routing", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    string folioId = this.cboFolioIdTo.Text;
                    string folioNo = this.cboFolioIdFrom.Text;
                    cboFolioIdTo.Text = "";
                    this.cboFolioIdFrom.Text = "";
                    this.cboFolioIdTo.Text = folioId;
                    this.cboFolioIdFrom.Text = folioNo;
                }
                else
                {
                    myTransaction.Rollback();
                }

            }

            private void SKeyDown(object sender, System.Windows.Forms.KeyEventArgs e, ListView lv)
            {
                if (e.KeyCode == System.Windows.Forms.Keys.Down)
                {
                    lv.Select();
                }
                else if (e.KeyCode == System.Windows.Forms.Keys.Escape)
                {
                    lv.Visible = false;
                    return;
                }
                loadList(1, txtGuestFrom.Text, lv);
            }

            private object loadList(byte filteFlag, string filter, ListView lv)
            {
                string filterValue;
                try
                {
                    if (lv.Visible == false)
                    {
                        lv.Visible = true;
                    }

                    if (dtView == null)
                    {
                        dtView = getRec();
                    }
                    filterValue = filter.Replace("\'", "\'\'");
                    if (filteFlag == 1)
                    {
                        dtView.RowStateFilter = DataViewRowState.OriginalRows;
                        dtView.RowFilter = "GroupName like \'" + filterValue + "%\'";
                        if (dtView.Count == 0)
                        {
                            dtView.RowFilter = "CompanyName like \'" + filter + "%\'";
                        }
                    }

                    DataRowView dtr;
                    lv.Items.Clear();
                    foreach (DataRowView tempLoopVar_dtr in dtView)
                    {
                        dtr = tempLoopVar_dtr;
                        ListViewItem li = new ListViewItem(dtr[0].ToString());
                        li.SubItems.Add(dtr[1].ToString());
                        li.SubItems.Add(dtr[2].ToString());
                        lv.Items.Add(li);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Load List Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                return null;
            }

            private void lvwBrowseGroupName_DoubleClick(object sender, System.EventArgs e)
            {
                assignTextBoxValue(null, cboFolioIdFrom, txtGuestFrom, lvwBrowseGroupName);
            }

            private void assignTextBoxValue(Control ctrl, Control ctrl2, Control ctrl3, ListView lv)
            {
                if (lv.SelectedItems.Count > 0)
                {
                    if (ctrl != null)
                    {
                        ctrl.Text = this.lvwBrowseGroupName.SelectedItems[0].Text;
                    }
                    ListViewItem li = new ListViewItem();
                    li = lv.SelectedItems[0];

                    ctrl2.Text = li.SubItems[2].Text;
                    ctrl3.Text = li.SubItems[1].Text;
                }
                lv.Items.Clear();
                lv.Visible = false;
            }

            Jinisys.Hotel.Accounts.BusinessLayer.GuestFacade oGuestFACADE;
            Guest oGuest = new Guest();

            #region "Origin Folio"

            private Folio oFolio;
            private void txtRoomFrom_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        //this.MdiParent.Cursor = Cursors.WaitCursor;

                        if (this.txtRoomFrom.Text.Trim().Length > 0)
                        {
                            oFolio = new Folio();

                            oFolioFacade = new FolioFacade();
                            //oFolio = oFolioFacade.GetFolioByRoomID(this.txtRoomFrom.Text);

                            // loads all folio related to this ROOM
                            ArrayList roomFromList = new ArrayList();
                            roomFromList = getAllFolioByRoom(this.txtRoomFrom.Text);

                            this.cboFolioIdFrom.DataSource = roomFromList;

                            if (roomFromList != null)
                            {
                                oFolio = oFolioFacade.GetFolio(roomFromList[0].ToString());
                            }
                            else
                            {
                                MessageBox.Show("No guest at room " + this.txtRoomFrom.Text + " !", "Invalid Room", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                                return;
                            }


                            //cboSubFolioFrom_SelectedIndexChanged(sender, e);
                            this.cboSubFolioFrom.SelectedIndex = 0;

                            //for creating subfolios of groups
                            if (oFolio.FolioType == "GROUP")
                            {
                                this.cboSubFolioFrom.Items.Clear();
                                this.cboSubFolioFrom.Items.Add("A");
                                this.cboSubFolioFrom.Text = "A";
                            }
                            else
                            {
                                this.cboSubFolioFrom.Items.Clear();
                                this.cboSubFolioFrom.Items.Add("A");
                                this.cboSubFolioFrom.Items.Add("B");
                                this.cboSubFolioFrom.Items.Add("C");
                                this.cboSubFolioFrom.Items.Add("D");
                                this.cboSubFolioFrom.Text = "A";
                            }

                        }
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("No guest at room " + this.txtRoomFrom.Text + " !", "Invalid Room", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }

                this.MdiParent.Cursor = Cursors.Default;
            }

            public ArrayList getAllFolioByRoom(string a_RoomNo)
            {
                try
                {
                    ArrayList folioIds = new ArrayList();
                    DataTable dtFolio = new DataTable();
                    MySqlDataAdapter dtAdapter = new MySqlDataAdapter("call spGetAllFolioIdsByRoom('" + a_RoomNo + "')", GlobalVariables.gPersistentConnection);
                    dtAdapter.Fill(dtFolio);

                    if (dtFolio != null)
                    {
                        foreach (DataRow dtRow in dtFolio.Rows)
                        {
                            folioIds.Add(dtRow["FolioId"]);
                        }

                        return folioIds;
                    }
                    else
                    {
                        return null;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return null;
                }


            }

            private void cboFolioIdFrom_TextChanged(object sender, System.EventArgs e)
            {
                try
                {
                    if (this.cboFolioIdFrom.Text != "")
                    {
                        oFolioFacade = new FolioFacade();
                        //oFolio = new Folio();
                        oFolio = oFolioFacade.GetFolio(this.cboFolioIdFrom.Text);

                        if (oFolio.FolioType.ToUpper() != "Group".ToUpper())
                        {
                            //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                            //used a constant parameter to avoid possible error/dependencies, no time to check
                            this.txtRoomFrom.Text = oFolioFacade.GetCurrentRoomOccupied(this.cboFolioIdFrom.Text, "INDIVIDUAL");
                        }

                        if (oFolio != null)
                        {
                            if (oFolio.FolioType.ToUpper() != "Group".ToUpper())
                            {
                                oGuestFACADE = new GuestFacade();
                                oGuest = oGuestFACADE.getGuestRecord(oFolio.AccountID);
                                this.txtGuestFrom.Text = oGuest.LastName + ", " + oGuest.FirstName;
                                this.cboFolioIdFrom.Text = oFolio.FolioID;
                            }
                            else
                            {
                                if (oFolio.CompanyID.StartsWith("G"))
                                {
                                    CompanyFacade oCompanyFacade = new CompanyFacade();
                                    Company oCompany = new Company();
                                    oCompany = oCompanyFacade.getCompanyAccount(oFolio.CompanyID);
                                    this.txtGuestFrom.Text = oCompany.CompanyName;
                                    this.cboFolioIdFrom.Text = oFolio.FolioID;
                                }
                                else
                                {
                                    oGuestFACADE = new GuestFacade();
                                    oGuest = oGuestFACADE.getGuestRecord(oFolio.AccountID);
                                    //this.txtGuestFrom.Text = oGuest.LastName + ", " + oGuest.FirstName;
                                    this.txtGuestFrom.Text = oFolio.GroupName;
                                    this.cboFolioIdFrom.Text = oFolio.FolioID;
                                }
                            }
                        }


                        this.cboSubFolioFrom_SelectedIndexChanged(sender, e);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lvwFrom.Items.Clear();
                }
            }

            private void cboSubFolioFrom_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                try
                {
                    if (oFolio != null)
                    {
                        //oFolio.CreateSubFolio();

                        //SubFolio oSubFolio;
                        foreach (SubFolio oSubFolio in oFolio.SubFolios)
                        {
                            //oSubFolio = tempLoopVar_oSubFolio;
                            oSubFolio.Folio.FolioTransactions = oFolioFacade.GetFolioTransactions(oFolio.FolioID, oSubFolio.SubFolio_Renamed);
                            if (oSubFolio.SubFolio_Renamed == cboSubFolioFrom.Text)
                            {
                                showSubFolioTransaction(oSubFolio.FolioTransactions, cboSubFolioFrom.Text, lvwFrom);
                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            #endregion


            #region "Destination Folio"

            private Folio oDestinationFolio;

            private void txtRoomTo_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                try
                {
                    if (e.KeyChar == '\r')
                    {
                        //this.MdiParent.Cursor = Cursors.WaitCursor;

                        if (this.txtRoomTo.Text.Trim().Length > 0)
                        {
                            oDestinationFolio = new Folio();

                            oFolioFacade = new FolioFacade();

                            // this is changed to show all Possible Folio of a Room
                            ArrayList roomToList = new ArrayList();
                            roomToList = getAllFolioByRoom(this.txtRoomTo.Text);

                            this.cboFolioIdTo.DataSource = roomToList;

                            if (roomToList != null)
                            {
                                oDestinationFolio = oFolioFacade.GetFolio(roomToList[0].ToString());
                            }
                            else
                            {
                                MessageBox.Show("No guest at room " + this.txtRoomTo.Text + " !", "Invalid Room", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return;
                            }

                            //cboSubFolioTo_SelectedIndexChanged(sender, e);

                            //for creating sub folios for group
                            if (oDestinationFolio.FolioType == "GROUP")
                            {
                                this.cboSubFolioTo.Items.Clear();
                                this.cboSubFolioTo.Items.Add("A");
                                this.cboSubFolioTo.Text = "A";
                            }
                            else
                            {
                                this.cboSubFolioTo.Items.Clear();
                                this.cboSubFolioTo.Items.Add("A");
                                this.cboSubFolioTo.Items.Add("B");
                                this.cboSubFolioTo.Items.Add("C");
                                this.cboSubFolioTo.Items.Add("D");
                                this.cboSubFolioTo.Text = "A";
                            }
                            this.cboSubFolioTo.SelectedIndex = 0;

                        }
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("No guest at room " + this.txtRoomTo.Text + "!", "Invalid Room No.", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.txtRoomTo.Text = "";
                }


                this.MdiParent.Cursor = Cursors.Default;
            }

            private void cboFolioIdTo_TextChanged(object sender, System.EventArgs e)
            {
                try
                {
                    if (this.cboFolioIdTo.Text != "")
                    {
                        oDestinationFolio = oFolioFacade.GetFolio(this.cboFolioIdTo.Text);

                        if (oDestinationFolio.FolioType.ToUpper() != "Group".ToUpper())
                        {
                            //jlo 8-9-10 added a new parameter to enable the method return multiple rooms
                            //used a constant parameter to avoid possible error/dependencies, no time to check
                            this.txtRoomTo.Text = oFolioFacade.GetCurrentRoomOccupied(this.cboFolioIdTo.Text, "INDIVIDUAL");
                        }

                        if (oDestinationFolio != null)
                        {
                            if (oDestinationFolio.FolioType.ToUpper() != "Group".ToUpper())
                            {
                                oGuestFACADE = new GuestFacade();
                                oGuest = oGuestFACADE.getGuestRecord(oDestinationFolio.AccountID);
                                this.txtGuestTo.Text = oGuest.LastName + ", " + oGuest.FirstName;
                                this.cboFolioIdTo.Text = oDestinationFolio.FolioID;
                            }
                            else
                            {
                                if (oDestinationFolio.CompanyID.StartsWith("G"))
                                {
                                    CompanyFacade oCompanyFacade = new CompanyFacade();
                                    Company oCompany = new Company();
                                    oCompany = oCompanyFacade.getCompanyAccount(oDestinationFolio.CompanyID);
                                    this.txtGuestTo.Text = oCompany.CompanyName;
                                    this.cboFolioIdTo.Text = oDestinationFolio.FolioID;
                                }
                                else
                                {
                                    oGuestFACADE = new GuestFacade();
                                    oGuest = oGuestFACADE.getGuestRecord(oDestinationFolio.AccountID);
                                    //this.txtGuestTo.Text = oGuest.LastName + ", " + oGuest.FirstName;
                                    this.txtGuestTo.Text = oDestinationFolio.GroupName;
                                    this.cboFolioIdTo.Text = oDestinationFolio.FolioID;
                                }
                            }
                        }

                        this.cboSubFolioTo_SelectedIndexChanged(sender, e);

                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    this.lvwTo.Items.Clear();
                }
            }


            private void cboSubFolioTo_SelectedIndexChanged(object sender, System.EventArgs e)
            {
                try
                {
                    if (oDestinationFolio != null)
                    {
                        //oDestinationFolio.CreateSubFolio();

                        //SubFolio oSubFolio;
                        foreach (SubFolio oSubFolio in oDestinationFolio.SubFolios)
                        {
                            //oSubFolio = tempLoopVar_oSubFolio;
                            oSubFolio.Folio.FolioTransactions = oFolioFacade.GetFolioTransactions(oDestinationFolio.FolioID, oSubFolio.SubFolio_Renamed);

                            if (oSubFolio.SubFolio_Renamed == cboSubFolioTo.Text)
                            {
                                showSubFolioTransaction(oSubFolio.FolioTransactions, cboSubFolioTo.Text, lvwTo);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            #endregion


            public void showSubFolioTransaction(FolioTransactions fTrans, string subFolio, ListView lvw)
            {
                try
                {
                    lvw.Items.Clear();
                    FolioTransaction ftran;

                    foreach (FolioTransaction tempLoopVar_ftran in fTrans)
                    {
                        ftran = tempLoopVar_ftran;
                        ListViewItem lvwItem = new ListViewItem();
                        //lvwItem.Text = string.Format("{0:MM/dd/yy hh:mm}",ftran.PostingDate);

                        lvwItem.Text = string.Format("{0:MM/dd/yy}", ftran.TransactionDate);
                        //lvwItem.SubItems.Add(string.Format("{0:MM/dd/yy}",ftran.TransactionDate));
                        lvwItem.SubItems.Add(ftran.ReferenceNo);
                        lvwItem.SubItems.Add(ftran.TransactionCode);
                        //lvwItem.SubItems.Add(ftran.RouteSequence)
                        lvwItem.SubItems.Add(ftran.Memo);
                        lvwItem.SubItems.Add(string.Format("{0:#,##0.00}", ftran.NetAmount));

                        //lvwItem.SubItems.Add(Format(ftran.GovernmentTax, GlobalVariables.gCurrencyFormat))
                        //lvwItem.SubItems.Add(Format(ftran.LocalTax, GlobalVariables.gCurrencyFormat))
                        //lvwItem.SubItems.Add(Format(ftran.ServiceCharge, GlobalVariables.gCurrencyFormat))
                        //lvwItem.SubItems.Add(Format(ftran.Discount, GlobalVariables.gCurrencyFormat))
                        //lvwItem.SubItems.Add(Format(ftran.NetBaseAmount, GlobalVariables.gCurrencyFormat))
                        lvw.Items.Add(lvwItem);

                        if (ftran.PostToLedger == "1")
                        {
                            lvwItem.BackColor = System.Drawing.Color.WhiteSmoke;
                        }
                        else
                        {
                            lvwItem.BackColor = System.Drawing.Color.White;
                        }
                    }

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "ShowSubFolioTransaction Exception", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }

            private void txtRoomFrom_Leave(object sender, EventArgs e)
            {
                try
                {
                    this.txtRoomFrom_KeyPress(sender, new KeyPressEventArgs('\r'));
                }
                catch
                { }
            }

            private void txtRoomTo_Leave(object sender, EventArgs e)
            {
                try
                {
                    this.txtRoomTo_KeyPress(sender, new KeyPressEventArgs('\r'));
                }
                catch { }
            }

            private void TransactionRoutingUI_Load(object sender, EventArgs e)
            {

            }

            private void TransactionRoutingUI_Activated(object sender, EventArgs e)
            {
                this.WindowState = FormWindowState.Maximized;
            }

            private void txtGuestFrom_TextChanged(object sender, EventArgs e)
            {
                //loadList(1, txtGuestFrom.Text, lvwBrowseGroupName);
            }

            private void txtGuestTo_TextChanged(object sender, EventArgs e)
            {
                //loadList(1, txtGuestTo.Text, lvwBrowseGroupName1);
            }

            private void btnSearchFrom_Click(object sender, EventArgs e)
            {
                try
                {
                    BrowseFolioUI _browseFolioUI = new BrowseFolioUI();
                    txtRoomFrom.Text = "";
                    Folio _oFolio = new Folio();

                    _oFolio = _browseFolioUI.showDialog(this);
                    this.txtRoomFrom.Text = _oFolio.RoomNo;

                    if (txtRoomFrom.Text == "")
                    {
                        // loads all folio related to this ROOM
                        ArrayList roomFromList = new ArrayList();
                        roomFromList.Add(_oFolio.FolioID);

                        this.cboFolioIdFrom.DataSource = roomFromList;
                        this.cboSubFolioFrom.SelectedIndex = 0;

                        //for creating subfolios of groups
                        if (oFolio.FolioType == "GROUP")
                        {
                            this.cboSubFolioFrom.Items.Clear();
                            this.cboSubFolioFrom.Items.Add("A");
                            this.cboSubFolioFrom.Text = "A";
                        }
                        else
                        {
                            this.cboSubFolioFrom.Items.Clear();
                            this.cboSubFolioFrom.Items.Add("A");
                            this.cboSubFolioFrom.Items.Add("B");
                            this.cboSubFolioFrom.Items.Add("C");
                            this.cboSubFolioFrom.Items.Add("D");
                            this.cboSubFolioFrom.Text = "A";
                        }
                    }
                    else
                    {
                        txtRoomFrom_KeyPress(this, new KeyPressEventArgs((char)13));
                    }
                }
                catch { }
            }

            private void btnSearchTo_Click(object sender, EventArgs e)
            {
                try
                {
                    BrowseFolioUI _browseFolioUI = new BrowseFolioUI();
                    Folio _oFolio = new Folio();

                    _oFolio = _browseFolioUI.showDialog(this);
                    txtRoomTo.Text = _oFolio.RoomNo;

                    if (txtRoomTo.Text == "")
                    {
                        // loads all folio related to this ROOM
                        ArrayList roomFromList = new ArrayList();
                        roomFromList.Add(_oFolio.FolioID);

                        this.cboFolioIdTo.DataSource = roomFromList;
                        this.cboSubFolioTo.SelectedIndex = 0;

                        //for creating subfolios of groups
                        if (oFolio.FolioType == "GROUP")
                        {
                            this.cboSubFolioTo.Items.Clear();
                            this.cboSubFolioTo.Items.Add("A");
                            this.cboSubFolioTo.Text = "A";
                        }
                        else
                        {
                            this.cboSubFolioTo.Items.Clear();
                            this.cboSubFolioTo.Items.Add("A");
                            this.cboSubFolioTo.Items.Add("B");
                            this.cboSubFolioTo.Items.Add("C");
                            this.cboSubFolioTo.Items.Add("D");
                            this.cboSubFolioTo.Text = "A";
                        }
                    }
                    else
                    {
                        txtRoomTo_KeyPress(this, new KeyPressEventArgs((char)13));
                    }
                }
                catch { }
            }

        }
    }

}
