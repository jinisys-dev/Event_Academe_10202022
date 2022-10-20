/*
 * Jinisys Softwares, Inc.
 * Copyright © 2006
 * 
 * 
*/

using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.DataAccessLayer;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	
		public class DepartmentUI : Maintenance2UI, ClassMaintenanceInterface
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
			public System.Windows.Forms.GroupBox grpMain;
			public System.Windows.Forms.Label Label2;
			public System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSearch;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.TextBox txtName;
			public System.Windows.Forms.TextBox txtDeptID;
			internal System.Windows.Forms.Panel pnlSearch;
			private System.Windows.Forms.Label label4;
			internal System.Windows.Forms.Label picClose;
			internal System.Windows.Forms.Label Label16;
			internal System.Windows.Forms.Label Label6;
			internal System.Windows.Forms.Button btnCloseSearch;
			internal System.Windows.Forms.Button btnFind;
			internal System.Windows.Forms.TextBox txtSearch;
            internal Button btnClose;
			internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdDepartment;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DepartmentUI));
this.grpMain = new System.Windows.Forms.GroupBox();
this.txtName = new System.Windows.Forms.TextBox();
this.txtDeptID = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.grdDepartment = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label4 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.grpMain.SuspendLayout();
this.gbxCommands.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).BeginInit();
this.pnlSearch.SuspendLayout();
this.SuspendLayout();
// 
// grpMain
// 
this.grpMain.BackColor = System.Drawing.Color.Transparent;
this.grpMain.Controls.Add(this.txtName);
this.grpMain.Controls.Add(this.txtDeptID);
this.grpMain.Controls.Add(this.Label2);
this.grpMain.Controls.Add(this.Label1);
this.grpMain.Location = new System.Drawing.Point(229, 1);
this.grpMain.Name = "grpMain";
this.grpMain.Size = new System.Drawing.Size(315, 305);
this.grpMain.TabIndex = 186;
this.grpMain.TabStop = false;
// 
// txtName
// 
this.txtName.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtName.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtName.Location = new System.Drawing.Point(88, 79);
this.txtName.MaxLength = 20;
this.txtName.Multiline = true;
this.txtName.Name = "txtName";
this.txtName.Size = new System.Drawing.Size(192, 49);
this.txtName.TabIndex = 55;
// 
// txtDeptID
// 
this.txtDeptID.BackColor = System.Drawing.SystemColors.Info;
this.txtDeptID.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
this.txtDeptID.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.txtDeptID.Location = new System.Drawing.Point(88, 41);
this.txtDeptID.MaxLength = 50;
this.txtDeptID.Multiline = true;
this.txtDeptID.Name = "txtDeptID";
this.txtDeptID.Size = new System.Drawing.Size(160, 20);
this.txtDeptID.TabIndex = 1;
// 
// Label2
// 
this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label2.Location = new System.Drawing.Point(15, 79);
this.Label2.Name = "Label2";
this.Label2.Size = new System.Drawing.Size(64, 17);
this.Label2.TabIndex = 56;
this.Label2.Text = "Name";
// 
// Label1
// 
this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Label1.Location = new System.Drawing.Point(15, 43);
this.Label1.Name = "Label1";
this.Label1.Size = new System.Drawing.Size(78, 17);
this.Label1.TabIndex = 54;
this.Label1.Text = "Department";
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
this.gbxCommands.Location = new System.Drawing.Point(9, 306);
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.Size = new System.Drawing.Size(535, 47);
this.gbxCommands.TabIndex = 187;
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(463, 10);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 188;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
this.btnSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSearch.Location = new System.Drawing.Point(187, 10);
this.btnSearch.Name = "btnSearch";
this.btnSearch.Size = new System.Drawing.Size(66, 31);
this.btnSearch.TabIndex = 186;
this.btnSearch.Text = "Searc&h";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(6, 10);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 4;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnSave.Location = new System.Drawing.Point(325, 10);
this.btnSave.Name = "btnSave";
this.btnSave.Size = new System.Drawing.Size(66, 31);
this.btnSave.TabIndex = 8;
this.btnSave.Text = "&Save";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(256, 10);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 5;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCancel.Location = new System.Drawing.Point(394, 10);
this.btnCancel.Name = "btnCancel";
this.btnCancel.Size = new System.Drawing.Size(66, 31);
this.btnCancel.TabIndex = 9;
this.btnCancel.Text = "&Cancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
// 
// grdDepartment
// 
this.grdDepartment.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdDepartment.BackColorSel = System.Drawing.SystemColors.Info;
this.grdDepartment.Cols = 1;
this.grdDepartment.ColumnInfo = "1,0,0,0,0,85,Columns:0{Width:176;Caption:\"Department\";TextAlignFixed:CenterCenter" +
    ";}\t";
this.grdDepartment.ExtendLastCol = true;
this.grdDepartment.FixedCols = 0;
this.grdDepartment.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdDepartment.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdDepartment.ForeColorSel = System.Drawing.Color.Black;
this.grdDepartment.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdDepartment.Location = new System.Drawing.Point(9, 6);
this.grdDepartment.Name = "grdDepartment";
this.grdDepartment.NodeClosedPicture = null;
this.grdDepartment.NodeOpenPicture = null;
this.grdDepartment.OutlineCol = -1;
this.grdDepartment.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdDepartment.Size = new System.Drawing.Size(214, 300);
this.grdDepartment.StyleInfo = resources.GetString("grdDepartment.StyleInfo");
this.grdDepartment.TabIndex = 190;
this.grdDepartment.TreeColor = System.Drawing.Color.DarkGray;
this.grdDepartment.Click += new System.EventHandler(this.grdDepartment_Click);
this.grdDepartment.RowColChange += new System.EventHandler(this.grdDepartment_RowColChange);
// 
// pnlSearch
// 
this.pnlSearch.BackColor = System.Drawing.Color.White;
this.pnlSearch.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
this.pnlSearch.Controls.Add(this.label4);
this.pnlSearch.Controls.Add(this.picClose);
this.pnlSearch.Controls.Add(this.Label16);
this.pnlSearch.Controls.Add(this.Label6);
this.pnlSearch.Controls.Add(this.btnCloseSearch);
this.pnlSearch.Controls.Add(this.btnFind);
this.pnlSearch.Controls.Add(this.txtSearch);
this.pnlSearch.Location = new System.Drawing.Point(152, 106);
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.Size = new System.Drawing.Size(251, 149);
this.pnlSearch.TabIndex = 191;
this.pnlSearch.Visible = false;
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
// 
// label4
// 
this.label4.BackColor = System.Drawing.Color.Transparent;
this.label4.Enabled = false;
this.label4.Image = ((System.Drawing.Image)(resources.GetObject("label4.Image")));
this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.label4.Location = new System.Drawing.Point(200, 99);
this.label4.Name = "label4";
this.label4.Size = new System.Drawing.Size(48, 47);
this.label4.TabIndex = 6;
// 
// picClose
// 
this.picClose.BackColor = System.Drawing.Color.SteelBlue;
this.picClose.Image = ((System.Drawing.Image)(resources.GetObject("picClose.Image")));
this.picClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.picClose.Location = new System.Drawing.Point(229, 3);
this.picClose.Name = "picClose";
this.picClose.Size = new System.Drawing.Size(18, 16);
this.picClose.TabIndex = 5;
this.picClose.Click += new System.EventHandler(this.picClose_Click);
// 
// Label16
// 
this.Label16.BackColor = System.Drawing.Color.SteelBlue;
this.Label16.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold);
this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.Label16.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
this.Label16.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label16.Location = new System.Drawing.Point(1, 1);
this.Label16.Name = "Label16";
this.Label16.Size = new System.Drawing.Size(247, 21);
this.Label16.TabIndex = 0;
this.Label16.Text = " Search";
this.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
// 
// Label6
// 
this.Label6.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.Label6.Location = new System.Drawing.Point(16, 42);
this.Label6.Name = "Label6";
this.Label6.Size = new System.Drawing.Size(141, 15);
this.Label6.TabIndex = 4;
this.Label6.Text = "Input Search string here";
// 
// btnCloseSearch
// 
this.btnCloseSearch.BackColor = System.Drawing.SystemColors.Control;
this.btnCloseSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnCloseSearch.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnCloseSearch.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnCloseSearch.Location = new System.Drawing.Point(118, 97);
this.btnCloseSearch.Name = "btnCloseSearch";
this.btnCloseSearch.Size = new System.Drawing.Size(63, 30);
this.btnCloseSearch.TabIndex = 188;
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
this.btnFind.Location = new System.Drawing.Point(50, 97);
this.btnFind.Name = "btnFind";
this.btnFind.Size = new System.Drawing.Size(63, 30);
this.btnFind.TabIndex = 187;
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
this.txtSearch.TabIndex = 3;
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// DepartmentUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(553, 361);
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.grpMain);
this.Controls.Add(this.grdDepartment);
this.Controls.Add(this.gbxCommands);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.Name = "DepartmentUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Department";
this.TextChanged += new System.EventHandler(this.DepartmentUI_TextChanged);
this.Load += new System.EventHandler(this.DepartmentUI_Load);
this.grpMain.ResumeLayout(false);
this.grpMain.PerformLayout();
this.gbxCommands.ResumeLayout(false);
((System.ComponentModel.ISupportInitialize)(this.grdDepartment)).EndInit();
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
this.ResumeLayout(false);

			}
			
			#endregion
		    
            #region " Variables and Constants "
			
            private ControlListener oControlListener;
			private DepartmentFacade oDepartmentFacade;
			private Department oDepartment;
			private DatasetBinder oDatasetBinder;
            private OperationMode mOperationMode;

			#endregion
			
			#region " Constructor "

			public DepartmentUI()
			{
				InitializeComponent();
			    oControlListener = new ControlListener();
			}

			#endregion

			#region " Methods "

            /*********************************************************
             * Purpose: Initialize object instance
             *********************************************************/
			private void assignEntityValues()
			{
				oDepartment.DepartmentID = this.txtDeptID.Text;
				oDepartment.Name = this.txtName.Text;
			}

           /*********************************************************
           * Purpose: Check if control has a valid value
           *********************************************************/
            private bool isRequiredEntriesFilled()
            {
                if (this.txtDeptID.Text.Trim().Length == 0) return false;

                return true;
            }

		    /*********************************************************
             * Purpose: Populate record to Grid Control
             *********************************************************/
			private void populateDataGrid()
			{
				int i;
				this.grdDepartment.Rows = 1;
				
				foreach (DataRow dRow in oDepartment.Tables[0].Rows)
				{
					i = this.grdDepartment.Rows;
					this.grdDepartment.Rows++;
					
					this.grdDepartment.set_TextMatrix(i, 0, dRow["Name"].ToString());
				}
			}

          		
		  /********************************************************
           * Purpose: Set the state of the button
           *********************************************************/
			private void setActionButtonStates(bool a_states)
			{
                this.btnSearch.Enabled = a_states;
                this.btnDelete.Enabled = a_states;
                this.btnNew.Enabled = a_states;
                this.btnSave.Enabled = !a_states;
                this.btnCancel.Enabled = !a_states;
			}
			
           /*********************************************************
            * Purpose: Bind row to form controls
            *********************************************************/
			private void bindRowToControls()
			{
				try
				{
                
                    if (hasChanges())
                    {
                       
                            if (MessageBox.Show("Save changes made to '" + this.txtDeptID.Text + "' Department?", "Save", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                assignEntityValues();
                                update();
                            }
                            else
                            {
                                this.BindingContext[oDepartment.Tables[0]].CancelCurrentEdit();
                                this.Text = "Departments";
                            }
                       
                    }

					oControlListener.StopListen(this);

                    this.BindingContext[oDepartment.Tables[0]].Position = findItemInDataSet(this.grdDepartment.get_TextMatrix(this.grdDepartment.Row, 0));
					
				}
				catch (Exception)
				{
				}
				finally
				{
					if ( this.pnlSearch.Visible == false )
					{
						oControlListener.Listen(this);
					}
				}
			}

           /*********************************************************
           * Purpose: Find index of selected item in Local DataSet
           *********************************************************/
			private int findItemInDataSet(string a_key)
			{
				int i = 0;
                foreach (DataRow drDepartment in oDepartment.Tables[0].Rows)
				{
					if (drDepartment["Name"].ToString() == a_key)
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
            /********************************************************
            * Purpose:Search the List of DEPARTMENTS starting
            * from the Selected Row down
            * if Not Found then start the Search again from the top
            *********************************************************/
            private void searchItem()
			{
				bool isFound = false;

				if ( ! this.txtSearch.Text.Equals("") )
				{
					int i = 0;
					for (i = this.grdDepartment.Row + 1 ; i <= this.grdDepartment.Rows - 1; i++)
					{
						if ( this.grdDepartment.get_TextMatrix(i, 0).ToUpper().Contains( this.txtSearch.Text.ToUpper() ) )
						{
						
							this.grdDepartment.Row = i;
							isFound = true;
							return;
						}
					}
				
					if ( ! isFound )
					{
						for (i = 1 ; i <= this.grdDepartment.Rows - 1; i++)
						{
                            if (this.grdDepartment.get_TextMatrix(i, 0).ToUpper().Contains(this.txtSearch.Text.ToUpper()))
							{
						
								this.grdDepartment.Row = i;
								isFound = true;
								return;
							}
					
						}
					}
					MessageBox.Show("No matching record found.");
				}

			}

            private void setOperationMode(OperationMode a_OperationMode)
            {
                mOperationMode=a_OperationMode;
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


			#endregion

            #region ClassMaintenanceInterface Members

            /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oDepartmentFacade = new DepartmentFacade();
                    assignEntityValues();
                    rowsAffected = oDepartmentFacade.deleteObject(oDepartment);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }
            /********************************************************
             * Purpose: Insert new item into the database
             *********************************************************/
            public int insert()
            {
              try
                {
                    int rowsAdded = 0;
                    oDepartmentFacade = new DepartmentFacade();
                    rowsAdded = oDepartmentFacade.insertObject(oDepartment);
                    return rowsAdded;
                }
                catch (Exception)
                {
                    return 0;
                }
                
            }
           /********************************************************
           * Purpose: Retrieve data from the database
           *********************************************************/
            public bool load()
            {
                try
                {
                    oDepartmentFacade = new DepartmentFacade();
                    oDepartment = new Department();
                    oDepartment = (Department)oDepartmentFacade.loadObject();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
               
            }
           /********************************************************
           * Purpose: Update existing item 
           *********************************************************/
            public int update()
            {
                try
                {
                    int rowsAffected = 0;
                    oDepartmentFacade = new DepartmentFacade();
                    rowsAffected = oDepartmentFacade.updateObject(ref oDepartment);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }
            }

            #endregion
                                            
			#region " Events "
			
			private void DepartmentUI_Load(System.Object sender, System.EventArgs e)
			{
                if (load() == true)
                {
                    if (!oDepartment.Equals(null))
                    {
                        oDatasetBinder = new DatasetBinder();
                        object obj = (object)oDepartment;
                        oDatasetBinder.BindControls(this, ref obj, new ArrayList());
                        
                        populateDataGrid();
                    }
                    setActionButtonStates(true);
                    oControlListener.Listen(this);
                }

				setActionButtonStates(true);
			}

			private void btnDelete_Click(System.Object sender, System.EventArgs e)
			{
				
                this.oControlListener.StopListen(this);
                if (MessageBox.Show("Are you certain you want to remove Department '" + this.grdDepartment.get_TextMatrix(this.grdDepartment.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (delete() > 0)
                    {
                        this.grdDepartment.RemoveItem(this.grdDepartment.Row);
                    }
                    else
                    {
                        MessageBox.Show("No rows deleted", "Database Update Error");
                    }
                }
                this.oControlListener.Listen(this);
			}
			
			private void btnSearch_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = true;
				this.txtSearch.Focus();
                this.txtSearch.SelectAll();
			}
			
			private void btnNew_Click(System.Object sender, System.EventArgs e)
			{

                setOperationMode(OperationMode.Add);
                
                oControlListener.StopListen(this);

                this.BindingContext[oDepartment.Tables["Department"]].SuspendBinding();

                this.txtDeptID.Enabled = true;
                this.txtDeptID.Focus();

                setActionButtonStates(false);
				
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
                                MessageBox.Show("Item successfully added.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.grdDepartment.Rows++;

                                this.grdDepartment.set_TextMatrix(this.grdDepartment.Rows - 1, 0, oDepartment.Name);

                                this.BindingContext[oDepartment.Tables[0]].ResumeBinding();
                                this.Text = "Department";
                                this.txtDeptID.Enabled = false;

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
                                this.grdDepartment.set_TextMatrix(this.grdDepartment.Row, 0, this.txtName.Text);
                                this.BindingContext[oDepartment.Tables[0]].ResumeBinding();
                                this.Text = "Department";
                                this.txtDeptID.Enabled = false;
                                setActionButtonStates(true);

                                oControlListener.Listen(this);

                                MessageBox.Show("Item successfully updated.", "Department", MessageBoxButtons.OK, MessageBoxIcon.Information);

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
                    MessageBox.Show("Please Input Access Code!", "Save Entry");
                    this.txtDeptID.Focus();
                    return;
                   
                }
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				
                if (mOperationMode.Equals(OperationMode.Add))
                {
                    if (this.grdDepartment.Rows > 1)
                    {
                        this.grdDepartment.Row = 1;
                    }
                }
                else
				{
					this.BindingContext[oDepartment.Tables["Department"]].CancelCurrentEdit();	
				}
				this.BindingContext[oDepartment.Tables["Department"]].ResumeBinding();
				
        		this.Text = "Department";
				setActionButtonStates(true);
                oControlListener.Listen(this);
			}

			private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					searchItem();
				}
			}
			
			private void picClose_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = false;
			}

            private void pnlSearch_VisibleChanged(object sender, System.EventArgs e)
            {

                if (pnlSearch.Visible)
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

            private void btnCloseSearch_Click(object sender, System.EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void grdDepartment_Click(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void grdDepartment_RowColChange(object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void DepartmentUI_TextChanged(object sender, System.EventArgs e)
            {
                if (this.Text.IndexOf('*') > 0)
                {
                    setOperationMode(OperationMode.Edit);
                    setActionButtonStates(false);
                }
                else
                {
                    setActionButtonStates(true);
                }
            }

            private void btnFind_Click(object sender, System.EventArgs e)
            {
                searchItem();
            }


			#endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }
	
        }
		
	}

