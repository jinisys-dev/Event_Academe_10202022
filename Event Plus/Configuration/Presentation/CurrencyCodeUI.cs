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
using Jinisys.Hotel.BusinessSharedClasses;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using MySql.Data.MySqlClient;
using System.Windows.Forms;
using Jinisys.Hotel.UIFramework;

namespace Jinisys.Hotel.ConfigurationHotel
{
	namespace Presentation
	{
		public class CurrencyCodeUI : Maintenance2UI, ClassMaintenanceInterface
		{
	       
			#region " Variables "

            private OperationMode mOperationMode;
            private DatasetBinder oDataSetBinder ;
			private FormToObjectInstanceBinder oInstanceBinder ;
			private ControlListener oControlListener;
			private CurrencyCode oCurrencyCode;

			private System.Windows.Forms.Label label4;
			internal System.Windows.Forms.Button btnCloseSearch;
			internal System.Windows.Forms.Button btnFind;
            internal Button btnClose;

			private CurrencyCodeFacade oCurrencyCodeFacade;
			
			#endregion
			
			#region " Constructor "

			public CurrencyCodeUI()
			{
				
				InitializeComponent();
				
			    oDataSetBinder = new DatasetBinder();
			    oInstanceBinder = new FormToObjectInstanceBinder();
			    oControlListener = new ControlListener();
			}

			#endregion
			
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
			public System.Windows.Forms.GroupBox GroupBox1;
			public System.Windows.Forms.Label Label1;
			public System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.GroupBox gbxCommands;
			internal System.Windows.Forms.Button btnSearch;
			internal System.Windows.Forms.Button btnDelete;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnNew;
			internal System.Windows.Forms.Button btnCancel;
			public System.Windows.Forms.Label Label3;
			public System.Windows.Forms.TextBox txtCurrencyCode;
			public System.Windows.Forms.TextBox txtCurrency;
			internal System.Windows.Forms.Panel pnlSearch;
			internal System.Windows.Forms.Label picClose;
			internal System.Windows.Forms.Label Label6;
			internal System.Windows.Forms.TextBox txtSearch;
			internal System.Windows.Forms.Label Label16;
			internal C1.Win.C1FlexGrid.Classic.C1FlexGridClassic grdCurrency;
			internal System.Windows.Forms.NumericUpDown nudConversionRate;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CurrencyCodeUI));
this.GroupBox1 = new System.Windows.Forms.GroupBox();
this.nudConversionRate = new System.Windows.Forms.NumericUpDown();
this.Label3 = new System.Windows.Forms.Label();
this.Label1 = new System.Windows.Forms.Label();
this.txtCurrencyCode = new System.Windows.Forms.TextBox();
this.txtCurrency = new System.Windows.Forms.TextBox();
this.Label2 = new System.Windows.Forms.Label();
this.gbxCommands = new System.Windows.Forms.GroupBox();
this.btnClose = new System.Windows.Forms.Button();
this.btnSearch = new System.Windows.Forms.Button();
this.btnDelete = new System.Windows.Forms.Button();
this.btnSave = new System.Windows.Forms.Button();
this.btnNew = new System.Windows.Forms.Button();
this.btnCancel = new System.Windows.Forms.Button();
this.pnlSearch = new System.Windows.Forms.Panel();
this.label4 = new System.Windows.Forms.Label();
this.picClose = new System.Windows.Forms.Label();
this.Label16 = new System.Windows.Forms.Label();
this.Label6 = new System.Windows.Forms.Label();
this.btnCloseSearch = new System.Windows.Forms.Button();
this.btnFind = new System.Windows.Forms.Button();
this.txtSearch = new System.Windows.Forms.TextBox();
this.grdCurrency = new C1.Win.C1FlexGrid.Classic.C1FlexGridClassic();
this.GroupBox1.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.nudConversionRate)).BeginInit();
this.gbxCommands.SuspendLayout();
this.pnlSearch.SuspendLayout();
((System.ComponentModel.ISupportInitialize)(this.grdCurrency)).BeginInit();
this.SuspendLayout();
// 
// GroupBox1
// 
this.GroupBox1.BackColor = System.Drawing.Color.Transparent;
this.GroupBox1.Controls.Add(this.nudConversionRate);
this.GroupBox1.Controls.Add(this.Label3);
this.GroupBox1.Controls.Add(this.Label1);
this.GroupBox1.Controls.Add(this.txtCurrencyCode);
this.GroupBox1.Controls.Add(this.txtCurrency);
this.GroupBox1.Controls.Add(this.Label2);
resources.ApplyResources(this.GroupBox1, "GroupBox1");
this.GroupBox1.Name = "GroupBox1";
this.GroupBox1.TabStop = false;
// 
// nudConversionRate
// 
this.nudConversionRate.DecimalPlaces = 2;
resources.ApplyResources(this.nudConversionRate, "nudConversionRate");
this.nudConversionRate.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
this.nudConversionRate.Name = "nudConversionRate";
this.nudConversionRate.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
// 
// Label3
// 
resources.ApplyResources(this.Label3, "Label3");
this.Label3.Name = "Label3";
// 
// Label1
// 
resources.ApplyResources(this.Label1, "Label1");
this.Label1.Name = "Label1";
// 
// txtCurrencyCode
// 
this.txtCurrencyCode.BackColor = System.Drawing.SystemColors.Info;
this.txtCurrencyCode.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
resources.ApplyResources(this.txtCurrencyCode, "txtCurrencyCode");
this.txtCurrencyCode.Name = "txtCurrencyCode";
// 
// txtCurrency
// 
this.txtCurrency.CharacterCasing = System.Windows.Forms.CharacterCasing.Upper;
resources.ApplyResources(this.txtCurrency, "txtCurrency");
this.txtCurrency.Name = "txtCurrency";
// 
// Label2
// 
resources.ApplyResources(this.Label2, "Label2");
this.Label2.Name = "Label2";
// 
// gbxCommands
// 
this.gbxCommands.Controls.Add(this.btnClose);
this.gbxCommands.Controls.Add(this.btnSearch);
this.gbxCommands.Controls.Add(this.btnDelete);
this.gbxCommands.Controls.Add(this.btnSave);
this.gbxCommands.Controls.Add(this.btnNew);
this.gbxCommands.Controls.Add(this.btnCancel);
resources.ApplyResources(this.gbxCommands, "gbxCommands");
this.gbxCommands.Name = "gbxCommands";
this.gbxCommands.TabStop = false;
// 
// btnClose
// 
this.btnClose.Cursor = System.Windows.Forms.Cursors.Default;
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
resources.ApplyResources(this.btnClose, "btnClose");
this.btnClose.Name = "btnClose";
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnSearch
// 
this.btnSearch.Cursor = System.Windows.Forms.Cursors.Default;
resources.ApplyResources(this.btnSearch, "btnSearch");
this.btnSearch.Name = "btnSearch";
this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
// 
// btnDelete
// 
this.btnDelete.Cursor = System.Windows.Forms.Cursors.Default;
resources.ApplyResources(this.btnDelete, "btnDelete");
this.btnDelete.Name = "btnDelete";
this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
// 
// btnSave
// 
this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
resources.ApplyResources(this.btnSave, "btnSave");
this.btnSave.Name = "btnSave";
this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
// 
// btnNew
// 
this.btnNew.Cursor = System.Windows.Forms.Cursors.Default;
resources.ApplyResources(this.btnNew, "btnNew");
this.btnNew.Name = "btnNew";
this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
// 
// btnCancel
// 
this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
resources.ApplyResources(this.btnCancel, "btnCancel");
this.btnCancel.Name = "btnCancel";
this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
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
resources.ApplyResources(this.pnlSearch, "pnlSearch");
this.pnlSearch.Name = "pnlSearch";
this.pnlSearch.VisibleChanged += new System.EventHandler(this.pnlSearch_VisibleChanged);
// 
// label4
// 
this.label4.BackColor = System.Drawing.Color.Transparent;
resources.ApplyResources(this.label4, "label4");
this.label4.Name = "label4";
// 
// picClose
// 
this.picClose.BackColor = System.Drawing.Color.SteelBlue;
resources.ApplyResources(this.picClose, "picClose");
this.picClose.Name = "picClose";
this.picClose.Click += new System.EventHandler(this.picClose_Click);
// 
// Label16
// 
this.Label16.BackColor = System.Drawing.Color.SteelBlue;
resources.ApplyResources(this.Label16, "Label16");
this.Label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
this.Label16.Name = "Label16";
// 
// Label6
// 
resources.ApplyResources(this.Label6, "Label6");
this.Label6.Name = "Label6";
// 
// btnCloseSearch
// 
this.btnCloseSearch.BackColor = System.Drawing.SystemColors.Control;
this.btnCloseSearch.Cursor = System.Windows.Forms.Cursors.Arrow;
resources.ApplyResources(this.btnCloseSearch, "btnCloseSearch");
this.btnCloseSearch.Name = "btnCloseSearch";
this.btnCloseSearch.UseVisualStyleBackColor = false;
this.btnCloseSearch.Click += new System.EventHandler(this.btnCloseSearch_Click);
// 
// btnFind
// 
this.btnFind.BackColor = System.Drawing.SystemColors.Control;
this.btnFind.Cursor = System.Windows.Forms.Cursors.Arrow;
resources.ApplyResources(this.btnFind, "btnFind");
this.btnFind.Name = "btnFind";
this.btnFind.UseVisualStyleBackColor = false;
this.btnFind.Click += new System.EventHandler(this.btnFind_Click);
// 
// txtSearch
// 
this.txtSearch.BackColor = System.Drawing.SystemColors.Info;
resources.ApplyResources(this.txtSearch, "txtSearch");
this.txtSearch.Name = "txtSearch";
this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
// 
// grdCurrency
// 
this.grdCurrency.AllowUserResizing = C1.Win.C1FlexGrid.Classic.AllowUserResizeSettings.flexResizeColumns;
this.grdCurrency.BackColorSel = System.Drawing.SystemColors.Info;
this.grdCurrency.Cols = 1;
resources.ApplyResources(this.grdCurrency, "grdCurrency");
this.grdCurrency.ExtendLastCol = true;
this.grdCurrency.FixedCols = 0;
this.grdCurrency.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdCurrency.ForeColorSel = System.Drawing.Color.Black;
this.grdCurrency.GridColorFixed = System.Drawing.SystemColors.ControlDark;
this.grdCurrency.Name = "grdCurrency";
this.grdCurrency.NodeClosedPicture = null;
this.grdCurrency.NodeOpenPicture = null;
this.grdCurrency.OutlineCol = -1;
this.grdCurrency.SelectionMode = C1.Win.C1FlexGrid.Classic.SelModeSettings.flexSelectionByRow;
this.grdCurrency.StyleInfo = resources.GetString("grdCurrency.StyleInfo");
this.grdCurrency.TreeColor = System.Drawing.Color.DarkGray;
this.grdCurrency.Click += new System.EventHandler(this.grdCurrency_Click);
this.grdCurrency.RowColChange += new System.EventHandler(this.grdCurrency_RowColChange);
// 
// CurrencyCodeUI
// 
resources.ApplyResources(this, "$this");
this.CancelButton = this.btnClose;
this.Controls.Add(this.pnlSearch);
this.Controls.Add(this.GroupBox1);
this.Controls.Add(this.gbxCommands);
this.Controls.Add(this.grdCurrency);
this.Name = "CurrencyCodeUI";
this.Closing += new System.ComponentModel.CancelEventHandler(this.CurrencyCodeUI_Closing);
this.TextChanged += new System.EventHandler(this.CurrencyCodeUI_TextChanged);
this.Load += new System.EventHandler(this.CurrencyCodeUI_Load);
this.GroupBox1.ResumeLayout(false);
this.GroupBox1.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.nudConversionRate)).EndInit();
this.gbxCommands.ResumeLayout(false);
this.pnlSearch.ResumeLayout(false);
this.pnlSearch.PerformLayout();
((System.ComponentModel.ISupportInitialize)(this.grdCurrency)).EndInit();
this.ResumeLayout(false);

			}
			
			#endregion

			#region " Methods "

            /*********************************************************
             * Purpose: Populate record to Grid Control
             *********************************************************/
		    public bool populateDataGrid( DataTable a_Currency )
			{
				int i = 0;
                try
                {
                    this.grdCurrency.Rows = 1;

                    foreach (DataRow dRow in a_Currency.Rows)
                    {
                        i = this.grdCurrency.Rows;
                        this.grdCurrency.Rows++;

                        this.grdCurrency.set_TextMatrix(i, 0, dRow["CurrencyCode"].ToString());
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Populating Data Grid.");
                    return false;
                }
			}

            /*********************************************************
             * Purpose: Ready for new transaction
             *********************************************************/
            private void setOperationMode(OperationMode a_OperationMode)
			{
                mOperationMode = a_OperationMode;
			}

           /*********************************************************
           * Purpose: Check if control has a valid value
           *********************************************************/
            private bool isRequiredEntriesFilled()
            {
                if (this.txtCurrencyCode.Text.Trim().Length > 0)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

			/*********************************************************
             * Purpose: Initialize object instance
             *********************************************************/
			private void assignEntityValues()
			{
				oCurrencyCode.CurCode = this.txtCurrencyCode.Text;
				oCurrencyCode.Currency = this.txtCurrency.Text;
				oCurrencyCode.ConversionRate = Decimal.Parse(this.nudConversionRate.Text);
				oCurrencyCode.HotelID = GlobalVariables.gHotelId;
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
                        if (MessageBox.Show("Save changes made to Currency Code '" + this.txtCurrencyCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            assignEntityValues();
                            update();
                        }
                        else
                        {
                            this.BindingContext[oCurrencyCode.Tables[0]].CancelCurrentEdit();
                            this.Text = "Currency Codes";
                        }
                    }

					oControlListener.StopListen(this);
					this.BindingContext[oCurrencyCode.Tables[0]].Position = findItemInDataset(this.grdCurrency.get_TextMatrix(this.grdCurrency.Row, 0));
				}
				catch (Exception)
				{ }
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
            private int findItemInDataset(string key)
			{
				int i = 0;
                foreach (DataRow drCurrencyCode in oCurrencyCode.Tables[0].Rows)
				{
					if (drCurrencyCode["currencycode"].ToString() == key)
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

            /********************************************************
            * Purpose: Set the state of the button
            *********************************************************/
            private void setActionButtonStates(bool state)
			{
				this.btnSearch.Enabled = state;
				this.btnNew.Enabled = state;
				this.btnDelete.Enabled = state;
				this.btnSave.Enabled = ! state;
				this.btnCancel.Enabled = ! state;
			}

            /********************************************************
             * Purpose:Search the List of Currency Codes starting
		     * from the Selected Row down
			 * if Not Found then start the Search again from the top
             *********************************************************/
			private void searchItem()
			{
				bool isFound = false;

				if ( ! this.txtSearch.Text.Equals("") )
				{
                    int i = 0;
					for (i = this.grdCurrency.Row + 1; i <= this.grdCurrency.Rows - 1; i++)
					{

                         if ( this.grdCurrency.get_TextMatrix(i, 0).ToUpper().Contains( this.txtSearch.Text.ToUpper() ) )
						{
						
							this.grdCurrency.Row = i;
							isFound = true;
							return;
						}
					}
				
					if ( ! isFound )
					{
						for (i = 1 ; i <= this.grdCurrency.Rows - 1; i++)
						{
							
                            if ( this.grdCurrency.get_TextMatrix(i, 0).ToUpper().Contains( this.txtSearch.Text.ToUpper() ) )
							{
						
								this.grdCurrency.Row = i;
								isFound = true;
								return;
							}
					
						}
					}

					MessageBox.Show("No matching record found.");
				}

			}

            #endregion

            #region   MaintenanceUIInterface Members

            /********************************************************
            * Purpose: Mark existing item as DELETED
            *********************************************************/
            public int delete()
            {
                try
                {
                    int rowsAffected = 0;
                    oCurrencyCodeFacade = new CurrencyCodeFacade();
                    assignEntityValues();
                    rowsAffected = oCurrencyCodeFacade.deleteObject(oCurrencyCode);
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
                    assignEntityValues();
                    int rowsAdded = 0;
                    oCurrencyCodeFacade = new CurrencyCodeFacade();
                    rowsAdded = oCurrencyCodeFacade.insertObject(ref oCurrencyCode);
                    return rowsAdded;
                }
                catch(Exception ex)
                {
                    MessageBox.Show(ex.Message);
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
                    oCurrencyCodeFacade = new CurrencyCodeFacade();
                    oCurrencyCode = new CurrencyCode();
                    oCurrencyCode = (CurrencyCode)oCurrencyCodeFacade.loadObject();
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
                    assignEntityValues();
                    int rowsAffected = 0;
                    oCurrencyCodeFacade = new CurrencyCodeFacade();
                    rowsAffected=oCurrencyCodeFacade.updateObject(ref oCurrencyCode);
                    return rowsAffected;
                }
                catch (Exception)
                {
                    return 0;
                }

            }
        
            #endregion

			#region " Events "

			private void btnSearch_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = true;
				this.txtSearch.Focus();
                this.txtSearch.SelectAll();
			}

			private void CurrencyCodeUI_Load(System.Object sender, System.EventArgs e)
			{
                if (load()==true)
                {
                    if (!oCurrencyCode.Equals(null))
                    {
                        object obj = (object)oCurrencyCode;
                        oDataSetBinder.BindControls(this, ref obj, new ArrayList());

                        populateDataGrid(oCurrencyCode.Tables["CurrencyCode"]);
                    }

                    this.txtCurrencyCode.Enabled = false;
                    oControlListener.Listen(this);
                }

				setActionButtonStates(true);
			}

			private void btnNew_Click(System.Object sender, System.EventArgs e)
			{
                // Set operation mode to ADD
                setOperationMode(OperationMode.Add);
                
                // Disable control listeners for all controls in the form
                oControlListener.StopListen(this);
                
                // Suspend binding context for all controls
                this.BindingContext[oCurrencyCode.Tables["CurrencyCode"]].SuspendBinding();

                // Set action button states
                setActionButtonStates(false);

                // Enable Currency code textbox
                this.txtCurrencyCode.Enabled = true;

                // Set focus to Currency code textbox
                this.txtCurrencyCode.Focus();
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
                                MessageBox.Show("Item successfully added.", "Currency", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                this.grdCurrency.Rows++;
                                this.grdCurrency.set_TextMatrix(this.grdCurrency.Rows - 1, 0, oCurrencyCode.CurCode);

                                // >> Resume Binding
                                this.BindingContext[oCurrencyCode.Tables[0]].ResumeBinding();
                                this.Text = "Currency Codes";

                                //mode = "";
                                this.txtCurrencyCode.Enabled = false;

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
                                MessageBox.Show("Item successfully updated.", "Currency", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                
                                this.BindingContext[oCurrencyCode.Tables["CurrencyCode"]].ResumeBinding();
                                this.Text = "Currency Codes";
                                this.txtCurrencyCode.Enabled = false;
                                setActionButtonStates(true);
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
                    MessageBox.Show("Please input currency code!", "Save Error");
                    this.txtCurrencyCode.Focus();
                    return;                
                }
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
                if (mOperationMode.Equals(OperationMode.Add))
                {
                    if (this.grdCurrency.Rows > 1)
                    {
                        this.grdCurrency.Row = 1;
                    }
                }
                else
                {
                    this.BindingContext[oCurrencyCode.Tables["CurrencyCode"]].CancelCurrentEdit();
                }

                this.BindingContext[oCurrencyCode.Tables["CurrencyCode"]].ResumeBinding();

                this.Text = "Currency Codes";
                this.txtCurrencyCode.Enabled = false;

                setActionButtonStates(true);
                oControlListener.Listen(this);
			}
			
			private void btnDelete_Click(System.Object sender, System.EventArgs e)
			{
                this.oControlListener.StopListen(this);
                if (MessageBox.Show("Are you certain you want to remove Currency '" + this.grdCurrency.get_TextMatrix(this.grdCurrency.Row, 0) + "'?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (delete() > 0)
                    {
                        this.grdCurrency.RemoveItem(this.grdCurrency.Row);
                    }
                    else
                    {
                        MessageBox.Show("No rows deleted", "Database Update Error");
                    }
                }
                this.oControlListener.Listen(this);
           	}

			private void CurrencyCodeUI_TextChanged(object sender, System.EventArgs e)
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

			private void picClose_Click(System.Object sender, System.EventArgs e)
			{
				this.pnlSearch.Visible = false;
			}
			
			private void txtSearch_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				if (e.KeyChar == '\r')
				{
					searchItem();
				}
			}
			
			private void lvwCurrencyCodes_MouseDown(System.Object sender, System.Windows.Forms.MouseEventArgs e)
			{
                if ( hasChanges() )
                {
                    if (MessageBox.Show("Save changes made to Currency Code '" + this.txtCurrencyCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oCurrencyCode.Tables[0]].CancelCurrentEdit();
                        this.Text = "Currency Codes";
                    }
                }
			}

            private void grdCurrency_Click(System.Object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void grdCurrency_RowColChange(object sender, System.EventArgs e)
            {
                bindRowToControls();
            }

            private void btnCloseSearch_Click(object sender, System.EventArgs e)
            {
                this.pnlSearch.Visible = false;
            }

            private void btnFind_Click(object sender, System.EventArgs e)
            {
                searchItem();
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

            private void CurrencyCodeUI_Closing(object sender, EventArgs e)
            {
                if (hasChanges())
                {
                    if (MessageBox.Show("Save changes made to Currency Code '" + this.txtCurrencyCode.Text + "'", "Save?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        assignEntityValues();
                        update();
                    }
                    else
                    {
                        this.BindingContext[oCurrencyCode.Tables[0]].CancelCurrentEdit();
                        this.Text = "Currency Codes";
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
}
