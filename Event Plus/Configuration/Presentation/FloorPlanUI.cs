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
using System.Windows.Forms;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
	
		public class FloorPlanUI : Maintenance2UI
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
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnChange;
            private ContextMenuStrip popUpMenu;
            private ToolStripMenuItem mnuEdit;
            private ToolStripSeparator toolStripMenuItem1;
            private ToolStripMenuItem mnuAdd;
            private ToolStripMenuItem mnuDelete;
            internal Button btnClose;
			internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdFloor;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
this.components = new System.ComponentModel.Container();
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FloorPlanUI));
this.btnDelete = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnChange = new System.Windows.Forms.Button();
this.grdFloor = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.popUpMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
this.mnuEdit = new System.Windows.Forms.ToolStripMenuItem();
this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
this.mnuAdd = new System.Windows.Forms.ToolStripMenuItem();
this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
this.btnClose = new System.Windows.Forms.Button();
((System.ComponentModel.ISupportInitialize)(this.grdFloor)).BeginInit();
this.popUpMenu.SuspendLayout();
this.SuspendLayout();
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnDelete.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnDelete.Location = new System.Drawing.Point(14, 293);
this.btnDelete.Name = "btnDelete";
this.btnDelete.Size = new System.Drawing.Size(66, 31);
this.btnDelete.TabIndex = 22;
this.btnDelete.Text = "&Delete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnNew.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnNew.Location = new System.Drawing.Point(374, 293);
this.btnNew.Name = "btnNew";
this.btnNew.Size = new System.Drawing.Size(66, 31);
this.btnNew.TabIndex = 85;
this.btnNew.Text = "&New";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnChange
// 
this.btnChange.Cursor = System.Windows.Forms.Cursors.Arrow;
this.btnChange.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnChange.Location = new System.Drawing.Point(304, 293);
this.btnChange.Name = "btnChange";
this.btnChange.Size = new System.Drawing.Size(66, 31);
this.btnChange.TabIndex = 86;
this.btnChange.Text = "&Change";
this.btnChange.Click += new System.EventHandler(this.btnChange_Click);
// 
// grdFloor
// 
this.grdFloor.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdFloor.BackColorSel = System.Drawing.SystemColors.Info;
this.grdFloor.Cols = 3;
this.grdFloor.ColumnInfo = resources.GetString("grdFloor.ColumnInfo");
this.grdFloor.ContextMenuStrip = this.popUpMenu;
this.grdFloor.ExtendLastCol = true;
this.grdFloor.FixedCols = 0;
this.grdFloor.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdFloor.Font = new System.Drawing.Font("Arial", 8.25F);
this.grdFloor.ForeColorSel = System.Drawing.Color.Black;
this.grdFloor.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdFloor.Location = new System.Drawing.Point(12, 13);
this.grdFloor.Name = "grdFloor";
this.grdFloor.NodeClosedPicture = null;
this.grdFloor.NodeOpenPicture = null;
this.grdFloor.OutlineCol = -1;
this.grdFloor.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdFloor.Size = new System.Drawing.Size(497, 268);
this.grdFloor.StyleInfo = resources.GetString("grdFloor.StyleInfo");
this.grdFloor.TabIndex = 188;
this.grdFloor.TreeColor = System.Drawing.Color.DarkGray;
this.grdFloor.DoubleClick += new System.EventHandler(this.grdFloor_DoubleClick);
// 
// popUpMenu
// 
this.popUpMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuEdit,
            this.toolStripMenuItem1,
            this.mnuAdd,
            this.mnuDelete});
this.popUpMenu.Name = "popUpMenu";
this.popUpMenu.Size = new System.Drawing.Size(129, 76);
// 
// mnuEdit
// 
this.mnuEdit.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.mnuEdit.Name = "mnuEdit";
this.mnuEdit.Size = new System.Drawing.Size(128, 22);
this.mnuEdit.Text = "Edit";
this.mnuEdit.Click += new System.EventHandler(this.mnuEdit_Click);
// 
// toolStripMenuItem1
// 
this.toolStripMenuItem1.Name = "toolStripMenuItem1";
this.toolStripMenuItem1.Size = new System.Drawing.Size(125, 6);
// 
// mnuAdd
// 
this.mnuAdd.Name = "mnuAdd";
this.mnuAdd.Size = new System.Drawing.Size(128, 22);
this.mnuAdd.Text = "Add New";
this.mnuAdd.Click += new System.EventHandler(this.mnuAdd_Click);
// 
// mnuDelete
// 
this.mnuDelete.Name = "mnuDelete";
this.mnuDelete.Size = new System.Drawing.Size(128, 22);
this.mnuDelete.Text = "Delete";
this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F);
this.btnClose.ImeMode = System.Windows.Forms.ImeMode.NoControl;
this.btnClose.Location = new System.Drawing.Point(444, 293);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 31);
this.btnClose.TabIndex = 189;
this.btnClose.Text = "Cl&ose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// FloorPlanUI
// 
this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(519, 336);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.btnDelete);
this.Controls.Add(this.btnChange);
this.Controls.Add(this.btnNew);
this.Controls.Add(this.grdFloor);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
this.MinimizeBox = false;
this.Name = "FloorPlanUI";
this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
this.Text = "Floor Plan";
this.Activated += new System.EventHandler(this.FloorPlanUI_Activated);
this.Load += new System.EventHandler(this.FloorPlanUI_Load);
((System.ComponentModel.ISupportInitialize)(this.grdFloor)).EndInit();
this.popUpMenu.ResumeLayout(false);
this.ResumeLayout(false);

			}
			
			#endregion

            #region " VARIABLES/CONSTANTS "

            private Floor oFloor;
            private FloorFacade oFloorFacade;
            private DatasetBinder oDatasetBinder;
            private FloorLayoutUI oFloorLayoutUI;

            #endregion

            #region " CONSTRUCTORS "

            public FloorPlanUI()
            {

                InitializeComponent();
                oDatasetBinder = new DatasetBinder();
               
            }

            #endregion

            #region " METHODS "

            /*********************************************************
             * Purpose: Populate record to Grid Control
             *********************************************************/
            private void popuLateDataGrid(DataTable a_dataTableFloor)
            {
                int i;

                this.grdFloor.Rows = 1;
                foreach (DataRow dtRow in a_dataTableFloor.Rows)
                {
                    this.grdFloor.Rows++;
                    i = this.grdFloor.Rows - 1;

                    this.grdFloor.set_TextMatrix(i, 0, dtRow["Floor"].ToString());
                    this.grdFloor.set_TextMatrix(i, 1, dtRow["FloorLayoutImage"].ToString());
                    this.grdFloor.set_TextMatrix(i, 2, dtRow["HotelId"].ToString());
                }
            }

		    private void changeFloorImage()
			{
                oFloor.HotelID = (int)this.grdFloor.get_ValueMatrix(this.grdFloor.Row, 2);
                oFloor.FloorName = this.grdFloor.get_TextMatrix(this.grdFloor.Row, 0);
                oFloor.FloorLayoutImage = this.grdFloor.get_TextMatrix(this.grdFloor.Row, 1);

				oFloorLayoutUI = new FloorLayoutUI(oFloor);
                oFloorLayoutUI.MdiParent = this.MdiParent;
                oFloorLayoutUI.Show();
			}

            private void assignEntityValues()
            {
                oFloor.FloorName = this.grdFloor.get_TextMatrix(this.grdFloor.Row, 0);
                oFloor.HotelID = GlobalVariables.gHotelId;
                oFloor.UpdatedBy = GlobalVariables.gLoggedOnUser;
            }

            /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oFloorFacade = new Jinisys.Hotel.ConfigurationHotel.BusinessLayer.FloorFacade();
                    assignEntityValues();
                    rowsAffected = oFloorFacade.deleteFloor(ref oFloor);
                    return rowsAffected;
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
                    oFloorFacade = new FloorFacade();
                    oFloor = new Floor();
                    oFloor = oFloorFacade.getFloors();
                    return true;
                }
                catch (Exception)
                {
                    return false;
                }
            }

          	#endregion

            #region " EVENTS "

            private void FloorPlanUI_Load(object sender, System.EventArgs e)
            {
                if (load() == true)
                {
                    if (!oFloor.Equals(null))
                    {
                        popuLateDataGrid(oFloor.Tables[0]);
                    }
                }
               
            }

            private void btnNew_Click(System.Object sender, System.EventArgs e)
            {
               
                    oFloorLayoutUI = new FloorLayoutUI(oFloor);
                    oFloorLayoutUI.MdiParent = this.MdiParent;
                    oFloorLayoutUI.Show();
           }

            private void btnDelete_Click(System.Object sender, System.EventArgs e)
            {
                    string floorName = "";
                    floorName = this.grdFloor.get_TextMatrix(this.grdFloor.Row, 1);

                    if (MessageBox.Show("Delete " + floorName + " ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (delete() > 0)
                        {
                            this.grdFloor.RemoveItem(this.grdFloor.Row);
                        }
                    }
            }

            private void FloorPlanUI_Activated(object sender, System.EventArgs e)
            {
                popuLateDataGrid(oFloor.Tables["Floors"]);
            }

            private void btnChange_Click(System.Object sender, System.EventArgs e)
            {
                changeFloorImage();
            }

            private void grdFloor_DoubleClick(object sender, EventArgs e)
            {
                changeFloorImage();
            }

            private void mnuEdit_Click(object sender, EventArgs e)
            {
                changeFloorImage();
            }

            private void mnuAdd_Click(object sender, EventArgs e)
            {
                    oFloorLayoutUI = new FloorLayoutUI(oFloor);
                    oFloorLayoutUI.MdiParent = this.MdiParent;
                    oFloorLayoutUI.Show();
            }

            private void mnuDelete_Click(object sender, EventArgs e)
            {
             
                    string floorName = "";
                    floorName = this.grdFloor.get_TextMatrix(this.grdFloor.Row, 1);

                    if (MessageBox.Show("Delete " + floorName + " ?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        if (delete() > 0)
                        {
                            this.grdFloor.RemoveItem(this.grdFloor.Row);
                        }
                    }

                }

            #endregion

            private void btnClose_Click(object sender, EventArgs e)
            {
                this.Close();
            }

            }
}
	

