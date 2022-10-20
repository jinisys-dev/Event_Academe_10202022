using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.Services.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.Services.Presentation
{
	
		public class HouseKeeperUI : Maintenance2UI
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
			
			//Required by the Windows Form Designer
			private System.ComponentModel.Container components = null;
			
			//NOTE: The following procedure is required by the Windows Form Designer
			//It can be modified using the Windows Form Designer.
			//Do not modify it using the code editor.
			public System.Windows.Forms.GroupBox GroupBox2;
			public System.Windows.Forms.TextBox txtHouseKeeperID;
			public System.Windows.Forms.TextBox txtMiddleName;
			public System.Windows.Forms.TextBox txtFirstName;
			public System.Windows.Forms.TextBox txtLastName;
			public System.Windows.Forms.Label Label9;
			public System.Windows.Forms.Label Label8;
			public System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.ListView lvwHousekeepers;
			internal System.Windows.Forms.ColumnHeader ColumnHeader2;
			internal System.Windows.Forms.ColumnHeader ColumnHeader3;
			internal System.Windows.Forms.Label Label6;
			internal System.Windows.Forms.Panel pnlSearch;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label16;
			internal System.Windows.Forms.Button btnSearch;
            internal Button btnClose;
			internal System.Windows.Forms.Label picClose;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HouseKeeperUI));
				this.GroupBox2 = new System.Windows.Forms.GroupBox();
				this.txtHouseKeeperID = new System.Windows.Forms.TextBox();
				this.txtMiddleName = new System.Windows.Forms.TextBox();
				this.txtFirstName = new System.Windows.Forms.TextBox();
				this.txtLastName = new System.Windows.Forms.TextBox();
				this.Label9 = new System.Windows.Forms.Label();
				this.Label8 = new System.Windows.Forms.Label();
				this.Label7 = new System.Windows.Forms.Label();
				this.Label6 = new System.Windows.Forms.Label();
				this.gbxCommands = new System.Windows.Forms.GroupBox();
				this.btnClose = new System.Windows.Forms.Button();
				this.btnSearch = new System.Windows.Forms.Button();
				this.btnSave = new System.Windows.Forms.Button();
				this.btnNew = new System.Windows.Forms.Button();
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnDelete = new System.Windows.Forms.Button();
				this.lvwHousekeepers = new System.Windows.Forms.ListView();
				this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
				this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
				this.pnlSearch = new System.Windows.Forms.Panel();
				this.picClose = new System.Windows.Forms.Label();
				this.Label1 = new System.Windows.Forms.Label();
				this.txtSearch = new System.Windows.Forms.TextBox();
				this.Label16 = new System.Windows.Forms.Label();
				this.GroupBox2.SuspendLayout();
				this.gbxCommands.SuspendLayout();
				this.pnlSearch.SuspendLayout();
				this.SuspendLayout();
				// 
				// GroupBox2
				// 
				this.GroupBox2.Controls.Add(this.txtHouseKeeperID);
				this.GroupBox2.Controls.Add(this.txtMiddleName);
				this.GroupBox2.Controls.Add(this.txtFirstName);
				this.GroupBox2.Controls.Add(this.txtLastName);
				this.GroupBox2.Controls.Add(this.Label9);
				this.GroupBox2.Controls.Add(this.Label8);
				this.GroupBox2.Controls.Add(this.Label7);
				this.GroupBox2.Controls.Add(this.Label6);
				this.GroupBox2.Location = new System.Drawing.Point(219, -4);
				this.GroupBox2.Name = "GroupBox2";
				this.GroupBox2.Size = new System.Drawing.Size(309, 311);
				this.GroupBox2.TabIndex = 34;
				this.GroupBox2.TabStop = false;
				// 
				// txtHouseKeeperID
				// 
				this.txtHouseKeeperID.BackColor = System.Drawing.SystemColors.Info;
				this.txtHouseKeeperID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtHouseKeeperID.Enabled = false;
				this.txtHouseKeeperID.Location = new System.Drawing.Point(96, 18);
				this.txtHouseKeeperID.MaxLength = 11;
				this.txtHouseKeeperID.Name = "txtHouseKeeperID";
				this.txtHouseKeeperID.Size = new System.Drawing.Size(99, 20);
				this.txtHouseKeeperID.TabIndex = 1;
				// 
				// txtMiddleName
				// 
				this.txtMiddleName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtMiddleName.Location = new System.Drawing.Point(96, 132);
				this.txtMiddleName.Name = "txtMiddleName";
				this.txtMiddleName.Size = new System.Drawing.Size(197, 20);
				this.txtMiddleName.TabIndex = 4;
				// 
				// txtFirstName
				// 
				this.txtFirstName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtFirstName.Location = new System.Drawing.Point(96, 56);
				this.txtFirstName.MaxLength = 30;
				this.txtFirstName.Name = "txtFirstName";
				this.txtFirstName.Size = new System.Drawing.Size(197, 20);
				this.txtFirstName.TabIndex = 2;
				// 
				// txtLastName
				// 
				this.txtLastName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
				this.txtLastName.Location = new System.Drawing.Point(96, 94);
				this.txtLastName.MaxLength = 30;
				this.txtLastName.Name = "txtLastName";
				this.txtLastName.Size = new System.Drawing.Size(197, 20);
				this.txtLastName.TabIndex = 3;
				// 
				// Label9
				// 
				this.Label9.Location = new System.Drawing.Point(11, 21);
				this.Label9.Name = "Label9";
				this.Label9.Size = new System.Drawing.Size(106, 11);
				this.Label9.TabIndex = 39;
				this.Label9.Text = "ID. No.";
				// 
				// Label8
				// 
				this.Label8.Location = new System.Drawing.Point(11, 58);
				this.Label8.Name = "Label8";
				this.Label8.Size = new System.Drawing.Size(67, 19);
				this.Label8.TabIndex = 35;
				this.Label8.Text = "First Name";
				// 
				// Label7
				// 
				this.Label7.Location = new System.Drawing.Point(11, 96);
				this.Label7.Name = "Label7";
				this.Label7.Size = new System.Drawing.Size(73, 22);
				this.Label7.TabIndex = 37;
				this.Label7.Text = "Last name";
				// 
				// Label6
				// 
				this.Label6.Location = new System.Drawing.Point(11, 135);
				this.Label6.Name = "Label6";
				this.Label6.Size = new System.Drawing.Size(74, 16);
				this.Label6.TabIndex = 36;
				this.Label6.Text = "Middle Name";
				// 
				// gbxCommands
				// 
				this.gbxCommands.Controls.Add(this.btnClose);
				this.gbxCommands.Controls.Add(this.btnSearch);
				this.gbxCommands.Controls.Add(this.btnSave);
				this.gbxCommands.Controls.Add(this.btnNew);
				this.gbxCommands.Controls.Add(this.btnCancel);
				this.gbxCommands.Controls.Add(this.btnDelete);
				this.gbxCommands.Location = new System.Drawing.Point(2, 307);
				this.gbxCommands.Name = "gbxCommands";
				this.gbxCommands.Size = new System.Drawing.Size(526, 47);
				this.gbxCommands.TabIndex = 35;
				this.gbxCommands.TabStop = false;
				// 
				// btnClose
				// 
				this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnClose.Location = new System.Drawing.Point(454, 11);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(66, 31);
				this.btnClose.TabIndex = 191;
				this.btnClose.Text = "C&lose";
				this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
				// 
				// btnSearch
				// 
				this.btnSearch.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnSearch.Location = new System.Drawing.Point(179, 11);
				this.btnSearch.Name = "btnSearch";
				this.btnSearch.Size = new System.Drawing.Size(66, 31);
				this.btnSearch.TabIndex = 10;
				this.btnSearch.Text = "Search";
				this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
				// 
				// btnSave
				// 
				this.btnSave.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnSave.Location = new System.Drawing.Point(317, 11);
				this.btnSave.Name = "btnSave";
				this.btnSave.Size = new System.Drawing.Size(66, 31);
				this.btnSave.TabIndex = 8;
				this.btnSave.Text = "Save";
				this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
				// 
				// btnNew
				// 
				this.btnNew.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnNew.Location = new System.Drawing.Point(248, 11);
				this.btnNew.Name = "btnNew";
				this.btnNew.Size = new System.Drawing.Size(66, 31);
				this.btnNew.TabIndex = 5;
				this.btnNew.Text = "New";
				this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
				// 
				// btnCancel
				// 
				this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnCancel.Location = new System.Drawing.Point(386, 11);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(66, 31);
				this.btnCancel.TabIndex = 9;
				this.btnCancel.Text = "Cancel";
				this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
				// 
				// btnDelete
				// 
				this.btnDelete.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnDelete.Location = new System.Drawing.Point(6, 11);
				this.btnDelete.Name = "btnDelete";
				this.btnDelete.Size = new System.Drawing.Size(66, 31);
				this.btnDelete.TabIndex = 4;
				this.btnDelete.Text = "Delete";
				this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
				// 
				// lvwHousekeepers
				// 
				this.lvwHousekeepers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader2,
            this.ColumnHeader3});
				this.lvwHousekeepers.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.lvwHousekeepers.FullRowSelect = true;
				this.lvwHousekeepers.GridLines = true;
				this.lvwHousekeepers.Location = new System.Drawing.Point(2, 1);
				this.lvwHousekeepers.Name = "lvwHousekeepers";
				this.lvwHousekeepers.Size = new System.Drawing.Size(214, 306);
				this.lvwHousekeepers.TabIndex = 127;
				this.lvwHousekeepers.UseCompatibleStateImageBehavior = false;
				this.lvwHousekeepers.View = System.Windows.Forms.View.Details;
				this.lvwHousekeepers.SelectedIndexChanged += new System.EventHandler(this.lvwHousekeepers_SelectedIndexChanged);
				// 
				// ColumnHeader2
				// 
				this.ColumnHeader2.Text = "ID";
				this.ColumnHeader2.Width = 54;
				// 
				// ColumnHeader3
				// 
				this.ColumnHeader3.Text = "Name";
				this.ColumnHeader3.Width = 137;
				// 
				// pnlSearch
				// 
				this.pnlSearch.BackColor = System.Drawing.SystemColors.Info;
				this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
				this.pnlSearch.Controls.Add(this.picClose);
				this.pnlSearch.Controls.Add(this.Label1);
				this.pnlSearch.Controls.Add(this.txtSearch);
				this.pnlSearch.Controls.Add(this.Label16);
				this.pnlSearch.Location = new System.Drawing.Point(130, 126);
				this.pnlSearch.Name = "pnlSearch";
				this.pnlSearch.Size = new System.Drawing.Size(271, 105);
				this.pnlSearch.TabIndex = 183;
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
				this.picClose.Click += new System.EventHandler(this.Close_Click);
				// 
				// Label1
				// 
				this.Label1.Location = new System.Drawing.Point(11, 38);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(240, 15);
				this.Label1.TabIndex = 4;
				this.Label1.Text = "Input Search String here";
				// 
				// txtSearch
				// 
				this.txtSearch.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.txtSearch.Location = new System.Drawing.Point(11, 62);
				this.txtSearch.Name = "txtSearch";
				this.txtSearch.Size = new System.Drawing.Size(248, 22);
				this.txtSearch.TabIndex = 3;
				this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
				// 
				// Label16
				// 
				this.Label16.BackColor = System.Drawing.Color.SteelBlue;
				this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
				this.Label16.Image = ((System.Drawing.Image)(resources.GetObject("Label16.Image")));
				this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
				this.Label16.Location = new System.Drawing.Point(1, 1);
				this.Label16.Name = "Label16";
				this.Label16.Size = new System.Drawing.Size(267, 20);
				this.Label16.TabIndex = 0;
				this.Label16.Text = "      Search";
				this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
				// 
				// HouseKeeperUI
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btnClose;
				this.ClientSize = new System.Drawing.Size(530, 356);
				this.Controls.Add(this.pnlSearch);
				this.Controls.Add(this.lvwHousekeepers);
				this.Controls.Add(this.gbxCommands);
				this.Controls.Add(this.GroupBox2);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.Name = "HouseKeeperUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
				this.Text = "House Keeper";
				this.Closing += new System.ComponentModel.CancelEventHandler(this.HouseKeeperUI_Closing);
				this.TextChanged += new System.EventHandler(this.HouseKeeperUI_TextChanged);
				this.Load += new System.EventHandler(this.HouseKeeperUI_Load);
				this.GroupBox2.ResumeLayout(false);
				this.GroupBox2.PerformLayout();
				this.gbxCommands.ResumeLayout(false);
				this.pnlSearch.ResumeLayout(false);
				this.pnlSearch.PerformLayout();
				this.ResumeLayout(false);

			}
			
			#endregion

            #region Variables and Constants

            private OperationMode mOperationMode;

            private ControlListener oControlListener ;
            private DatasetBinder oDataSetBinder ;

            private HouseKeeper oHouseKeeper ;
            private HouseKeeperFacade oHouseKeeperFacade;

            #endregion

            #region Constructor

            public HouseKeeperUI()
            {

                oControlListener = new ControlListener();
                oDataSetBinder = new DatasetBinder();
                oHouseKeeper = new HouseKeeper();
                oHouseKeeperFacade = new HouseKeeperFacade();
                InitializeComponent();
            }

            #endregion

            #region Methods

            private void populateDataGrid()
            {
               for (int i = 0; i <= oHouseKeeper.Tables[0].Rows.Count - 1; i++)
                {
                    ListViewItem lst = new ListViewItem(oHouseKeeper.Tables[0].Rows[i]["HousekeeperId"].ToString());
                    string name = oHouseKeeper.Tables[0].Rows[i]["FirstName"].ToString() + " " + oHouseKeeper.Tables[0].Rows[i]["LastName"].ToString();
                    lst.SubItems.Add(name);

                    this.lvwHousekeepers.Items.Add(lst);
                }

                oControlListener.Listen(this);
            }

            private bool hasChanges()
            {
                if (this.Text.IndexOf("*") > 0)
                    return true;
                else
                    return false;
            }

            private void bindRowToControls()
            {
                try
                {
                    oControlListener.StopListen(this);

                    this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].Position = findItemInDataSet(this.lvwHousekeepers.SelectedItems[0].Text);

                    oControlListener.Listen(this);

                }
                catch (Exception)
                {
                }
            }

            private void assignEntityValues()
            {
                oHouseKeeper.gHotelId = GlobalVariables.gHotelId;
                oHouseKeeper.HouseKeeperId = this.txtHouseKeeperID.Text;
                oHouseKeeper.LastName = this.txtLastName.Text;
                oHouseKeeper.FirstName = this.txtFirstName.Text;
                oHouseKeeper.MiddleName = this.txtMiddleName.Text;
                oHouseKeeper.CreatedBy = GlobalVariables.gLoggedOnUser;
            }

            private bool isRequiredEntriesFilled()
            {
                if (this.txtHouseKeeperID.Text.Length == 0 || this.txtLastName.Text.Length == 0 || this.txtFirstName.Text.Length == 0) return false;
                return true;
            }

            private void setActionButtonStates(bool a_stat)
            {
                btnDelete.Enabled = a_stat;
                btnNew.Enabled = a_stat;
                btnSave.Enabled = !a_stat;
                btnCancel.Enabled = !a_stat;
            }

            private void deselectItem()
            {
                for (int i = 0; i <= this.lvwHousekeepers.Items.Count - 1; i++)
                {
                    this.lvwHousekeepers.Items[i].Selected = false;
                }
            }

            private int findItemInDataSet(string key)
            {
               int i = 0;
                foreach (DataRow drRoom in oHouseKeeper.Tables[0].Rows)
                {
                  
                    if ((string)drRoom["HousekeeperId"] == key)
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
		
            #endregion			

            #region Data Access Methods

            public bool load()
            {
                try
                {
                    oHouseKeeperFacade = new HouseKeeperFacade();
                    oHouseKeeper = new HouseKeeper();
                    oHouseKeeper = oHouseKeeperFacade.getHouseKeeper();
                    return true;
                }
                catch (Exception) { return false; }
            }

            public int insert()
            {
                try
                {
                    int rowsAffected = 0;
                    oHouseKeeperFacade = new HouseKeeperFacade();
                    rowsAffected =oHouseKeeperFacade.insertHouseKeeper(oHouseKeeper);
                    return rowsAffected;
                }
                catch (Exception) { return 0; }
            }

            public int update()
            {
                try
                {
                    int rowsAffected = 0;
                    oHouseKeeperFacade = new HouseKeeperFacade();
                    rowsAffected = oHouseKeeperFacade.updateHouseKeeper(ref oHouseKeeper);
                    return rowsAffected;
                }
                catch (Exception) { return 0; }
            }

            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oHouseKeeperFacade = new HouseKeeperFacade();
                    rowsAffected = oHouseKeeperFacade.deleteHouseKeeper(ref oHouseKeeper);
                    return rowsAffected;
                }
                catch (Exception) { return 0; }
            }

            #endregion

            #region Events

            private void HouseKeeperUI_Load(object sender, System.EventArgs e)
            {
                if (load() == true)
                {

                    if (oHouseKeeper != null)
                    {
                        object temp_object = oHouseKeeper;
                        oDataSetBinder.BindControls(this, ref temp_object, new ArrayList());
                        populateDataGrid();
                    }
                }

				setActionButtonStates(true);
            }

            private void grdHouseKeeper_CurrentCellChanged(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void grdHouseKeeper_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
            {
                if (hasChanges() == true)
                {
                    if (MessageBox.Show("Save changes made to Housekeeper \'" + this.txtHouseKeeperID.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (update() > 0)
                        {
                            this.lvwHousekeepers.Items[findItemInDataSet(this.txtHouseKeeperID.Text)].SubItems[1].Text = oHouseKeeper.FirstName + " " + oHouseKeeper.LastName;

                            this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].ResumeBinding();
                            this.txtHouseKeeperID.Enabled = false;

                            this.BindingContext[oHouseKeeper.Tables["HouseKeepers"]].ResumeBinding();
                            this.Text = "Housekeepers";

                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows updated", "Database Update Error");
                        }
                    }
                    else
                    {
                        this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].CancelCurrentEdit();
                        this.Text = "Housekeepers";

                    }
                }
            }

            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {
                setOperationMode(OperationMode.Add);
                oControlListener.StopListen(this);

                this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].SuspendBinding();

                this.txtHouseKeeperID.Enabled = true;
                this.txtHouseKeeperID.Focus();

                setActionButtonStates(false);
            }

            private void HouseKeeperUI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
            {
                if (hasChanges() == true)
                {
                    if (MessageBox.Show("Save changes made to Housekeeper \'" + this.txtHouseKeeperID.Text + "\'", "Users", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                    {
                        if (update() > 0)
                        {
                            this.lvwHousekeepers.Items[findItemInDataSet(this.txtHouseKeeperID.Text)].SubItems[1].Text = oHouseKeeper.FirstName + " " + oHouseKeeper.LastName;

                            this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].ResumeBinding();
                            this.txtHouseKeeperID.Enabled = false;

                            this.BindingContext[oHouseKeeper.Tables["HouseKeepers"]].ResumeBinding();
                            this.Text = "Housekeepers";

                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows updated", "Database Update Error");
                        }
                    }
                    else
                    {
                        this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].CancelCurrentEdit();
                        this.Text = "Housekeepers";

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
                            if (insert() > 0)
                            {
                                ListViewItem lst = new ListViewItem(oHouseKeeper.HouseKeeperId);
                                lst.SubItems.Add(oHouseKeeper.FirstName + " " + oHouseKeeper.LastName);

                                this.lvwHousekeepers.Items.Add(lst);

                                this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].ResumeBinding();
                                this.txtHouseKeeperID.Enabled = false;

                                this.Text = "Housekeepers";

                                setActionButtonStates(true);

                                oControlListener.Listen(this);
                            }
                            else
                            {
                                MessageBox.Show("No rows added", "Database Insert Error");
                            }

                            break;
                        case OperationMode.Edit:
                            if (update() > 0)
                            {
                                this.lvwHousekeepers.Items[findItemInDataSet(this.txtHouseKeeperID.Text)].SubItems[1].Text = oHouseKeeper.FirstName + " " + oHouseKeeper.LastName;

                                this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].ResumeBinding();
                                this.txtHouseKeeperID.Enabled = false;

                                this.BindingContext[oHouseKeeper.Tables["HouseKeepers"]].ResumeBinding();
                                this.Text = "Housekeepers";

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
                }
                else
                {
                    MessageBox.Show("Please input necessary field(s)");
                    return;
                }
            }

            private void btnCancel_Click(System.Object sender, System.EventArgs e)
            {
                if (mOperationMode.Equals(OperationMode.Add))
                {
                    if (this.lvwHousekeepers.Items.Count > 0)
                    {
                        this.lvwHousekeepers.Items[0].Selected = true;
                    }
                }
                else
                {
                    this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].CancelCurrentEdit();
                }

                this.BindingContext[oHouseKeeper.Tables["Housekeepers"]].ResumeBinding();
                this.Text = "Housekeepers";
                setActionButtonStates(true);
                oControlListener.Listen(this);
            }

            private void btnDelete_Click(System.Object sender, System.EventArgs e)
            {

                if (MessageBox.Show("Delete Housekeeper \'" + this.txtLastName.Text + "\'", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
                {
                    this.Text = "Housekeepers";

                    oControlListener.StopListen(this);

                    oHouseKeeper.HouseKeeperId = this.txtHouseKeeperID.Text;
                    oHouseKeeper.UpdatedBy = GlobalVariables.gLoggedOnUser;
                    oHouseKeeper.gHotelId = GlobalVariables.gHotelId;
                    if (delete() > 0)
                    {
                        this.lvwHousekeepers.SelectedItems[0].Remove();

                        if (this.lvwHousekeepers.Items.Count > 0)
                        {
                            this.lvwHousekeepers.Items[0].Selected = true;
                        }


                        oControlListener.Listen(this);

                    }
                }
            }

            private void HouseKeeperUI_TextChanged(object sender, System.EventArgs e)
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

            private void lvwHousekeepers_SelectedIndexChanged(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void btnSearch_Click(System.Object sender, System.EventArgs e)
            {

                this.oControlListener.StopListen(this);
                this.pnlSearch.Visible = true;
                this.txtSearch.Focus();
            }

            private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
            {
                if (e.KeyChar == '\r')
                {
                    this.lvwHousekeepers.Focus();

                    deselectItem();

                    for (int i = 0; i <= this.lvwHousekeepers.Items.Count - 1; i++)
                    {
                        if (this.lvwHousekeepers.Items[i].SubItems[1].Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()) || this.lvwHousekeepers.Items[i].Text.ToUpper().Contains(this.txtSearch.Text.ToUpper()))
                        {

                            this.lvwHousekeepers.Items[i].Selected = true;

                            this.pnlSearch.Visible = false;

                            this.oControlListener.Listen(this);
                            return;
                        }
                    }
                }
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
   
		}
	}

