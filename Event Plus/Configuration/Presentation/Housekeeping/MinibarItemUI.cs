using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.ConfigurationHotel.Presentation
{
    public partial class MinibarItemUI : Form
    {
        public MinibarItemUI()
        {
           
            InitializeComponent();
          
        }
        private MinibarItemFacade oItemFacade = new MinibarItemFacade();
        private MinibarItem items = null;
        private DataSet ds = new DataSet("Items");
        private ControlListener oControlListener = new ControlListener();
        private DatasetBinder oDatasetBinder = new DatasetBinder();
        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;
        private int CurrPos = 0;
        private MinibarItemCategory cat;
        private MinibarItemCategoryFacade catFacade = new MinibarItemCategoryFacade();
        private void ItemUI_Load(object sender, EventArgs e)
        {
            items = oItemFacade.getItems();
            items.TableName = "minibar_items";
            cat = catFacade.getCategories();
            loadcombo(cat);
            if (loadList())
            {
                ds.Tables.Add(items);
                object obj = (object)ds;
                oDatasetBinder.BindControls(this, ref obj, new ArrayList());

            }
          
            this.txtItemCode.Enabled = false;
           
            this.setActionButtonStates(true);
            oControlListener.Listen(this);
           
        }
        private void loadcombo(MinibarItemCategory cat)
        {
                     
            this.cboCategories.DataSource = cat;
            this.cboCategories.DisplayMember = "CategoryName";
            this.cboCategories.ValueMember = "CategoryID";
        }
        private bool loadList()
        {
            try
            {
                this.lstItem.Items.Clear();
                foreach (DataRow row in items.Rows)
                {
                    ListViewItem li = new ListViewItem(row["itemCode"].ToString());
                    li.SubItems.Add(row["description"].ToString());
                    this.lstItem.Items.Add(li);
                }
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;

            }

        }
        private void setActionButtonStates(bool state)
        {
            this.btnSearch.Enabled = state;
            this.btnNew.Enabled = state;
            this.btnDelete.Enabled = state;
            this.btnSave.Enabled = !state;
            this.btnCancel.Enabled = !state;
        }
        /*********************************************************
          * Purpose: Ready for new transaction
          *********************************************************/
        private void setOperationMode(OperationMode a_OperationMode)
        {
            mOperationMode = a_OperationMode;
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            // Set operation mode to ADD
            setOperationMode(OperationMode.ADD);

            // Disable control listeners for all controls in the form
            oControlListener.StopListen(this);

            // Suspend binding context for all controls
            this.BindingContext[ds.Tables[0]].SuspendBinding();

            // Set action button states
            setActionButtonStates(false);

            // Enable Currency code textbox
			this.txtItemCode.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                //if (this.lstItem.Rows > 1)
                //{
                //    this.lstItem.Items.= 1;
                //}
            }
            else
            {
                this.BindingContext[ds.Tables[0]].CancelCurrentEdit();
            }
            this.BindingContext[ds.Tables[0]].ResumeBinding();
            this.Text = "Items";
			this.txtItemCode.Enabled = false;
            setActionButtonStates(true);
            oControlListener.Listen(this);
        }
        private void updatePosition()
        {
            this.BindingContext[items].Position = CurrPos;
            this.cboCategories.SelectedValue = items.Rows[CurrPos]["CategoryId"];
            this.Refresh();
        }
        private bool assignEntityValues()
        {
			items.ItemCode = this.txtItemCode.Text;
            items.Description = this.txtDescription.Text;
            items.CategoryId = int.Parse(this.cboCategories.SelectedValue.ToString());
            items.UnitPrice = this.nudUnitPrice.Value;
            return true;
        }
        private void lstItem_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oControlListener.StopListen(this);
                if (this.lstItem.SelectedItems != null)
                {
                    CurrPos = this.lstItem.SelectedItems[0].Index;
                    updatePosition();
                }
                oControlListener.Listen(this);
            }
            catch (Exception)
            {
                oControlListener.Listen(this);
            }
        }
        /*********************************************************
          * Purpose: Check if control has a valid value
          *********************************************************/
        private bool isRequiredEntriesFilled()
        {
			if (this.txtItemCode.Text.Trim().Length > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        /********************************************************
         * Purpose: Insert new item into the database
         *********************************************************/
        public bool insert()
        {
            try
            {
                bool rowsAdded = false;
                MinibarItemFacade oItemFacade = new MinibarItemFacade();
                rowsAdded = oItemFacade.Save(ref items);
                return true;
            }
            catch (Exception ex)
            {
				MessageBox.Show("Database Insert Error.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        /********************************************************
       * Purpose: Update existing item 
       *********************************************************/
        
        public bool update()
        {
            try
            {
                bool rowsAffected=false;
                MinibarItemFacade oItemFacade = new MinibarItemFacade();
                rowsAffected = oItemFacade.Update(ref items);
                return rowsAffected;
            }
            catch (Exception ex)
            {
				MessageBox.Show("Database Update Error.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

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

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isRequiredEntriesFilled())
            {
                assignEntityValues();

                switch (mOperationMode)
                {
                    case OperationMode.ADD:
                        if (insert())
                        {
                            MessageBox.Show("Item successfully added.", "Items ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadList();

                            // >> Resume Binding
                            this.BindingContext[ds.Tables[0]].ResumeBinding();
                            this.Text = "Rooms";

                            //mode = "";
							this.txtItemCode.Enabled = false;

                            setActionButtonStates(true);
                            oControlListener.Listen(this);

                        }

                        break;
                    case OperationMode.EDIT:
                        if (update())
                        {
                            MessageBox.Show("Item successfully updated.", "Rooms", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadList();
                            this.BindingContext[ds.Tables[0]].ResumeBinding();
                            this.Text = "Items";
							this.txtItemCode.Enabled = false;
                            setActionButtonStates(true);
                            oControlListener.Listen(this);

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
				this.txtItemCode.Focus();
                return;
            }
        }

        private void ItemUI_TextChanged(object sender, EventArgs e)
        {
      
            if (this.Text.IndexOf('*') > 0)
            {
                setOperationMode(OperationMode.EDIT);
                setActionButtonStates(false);
            }
            else
            {
                setActionButtonStates(true);
            }
        }
        public bool delete()
        {
            try
            {
                bool rowsAffected =true;
                oItemFacade = new MinibarItemFacade();
                rowsAffected = oItemFacade.Delete(ref items);
                return rowsAffected;
            }
            catch (Exception) { return false; }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
			if (MessageBox.Show("Delete this item \'" + this.txtItemCode.Text + "\'", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Text = "Items";

                oControlListener.StopListen(this);

				items.ItemCode = this.txtItemCode.Text;

                if (delete() )
                {
                    this.lstItem.SelectedItems[0].Remove();

                    if (this.lstItem.Items.Count > 0)
                    {
                        this.lstItem.Items[0].Selected = true;
                    }


                    oControlListener.Listen(this);

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            this.oControlListener.StopListen(this);
            this.pnlSearch.Visible = true;
            this.txtSearch.Focus();
        }

    //     Private Sub txtKeyword_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtKeyword.KeyPress
    //    If e.KeyChar = Chr(13) Then
    //        DesSelectAll()
    //        Me.ListView1.Focus()
    //        For Each item As ListViewItem In Me.ListView1.Items
    //            Dim i As Integer = item.SubItems.Count - 1
    //            For x As Integer = 0 To i
    //                If item.SubItems(x).Text.ToLower().IndexOf(Me.txtKeyword.Text.ToLower()) <> -1 Then
    //                    Me.ListView1.Items(item.Index).Selected = True
    //                    Me.ListView1.EnsureVisible(item.Index)
    //                    Return
    //                End If
    //            Next

    //        Next
    //    End If
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                deselect();
                this.lstItem.Focus();
                foreach(ListViewItem item in this.lstItem.Items)
                {
                    int i = item.SubItems.Count-1;
                    for (int x = 0;x<=i;x++)
                    {
                        if (item.SubItems[x].Text.ToLower().IndexOf(this.txtSearch.Text.ToLower())!=-1)
                        {
                            this.lstItem.Items[item.Index].Selected = true;
                            this.lstItem.EnsureVisible(item.Index);
                            this.pnlSearch.Visible = false;
                            return;
                        }
                    }
                }
                MessageBox.Show("No record match with the keyword entered!");
            }
        }
        private void deselect()
        {
            foreach (ListViewItem li in this.lstItem.Items)
            {
                int i = li.SubItems.Count - 1;
                for (int x = 0; x <= i ; x++)
                {
                    this.lstItem.Items[li.Index].Selected = false;
                }
            }
        }

        private void btnCloseSearch_Click(object sender, EventArgs e)
        {
            this.pnlSearch.Visible = false;
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            txtSearch_KeyPress(this.txtSearch, new KeyPressEventArgs((char)13));
        }

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		
		//private void btnNewCat_Click(object sender, EventArgs e)
		//{
		//    MinibarItemCategoryUI catUI = new MinibarItemCategoryUI();
		//    int catID = catUI.ShowCategoryUI(this);
		//    if (catID != 0)
		//    {
		//        cat = catFacade.getCategories();
		//        loadcombo(cat);
		//        this.cboCategories.SelectedValue = catID;
		//    }
		//}

    

    //End Sub
    //Private Sub DesSelectAll()
    //    For Each item As ListViewItem In Me.ListView1.Items
    //        Dim i As Integer = item.SubItems.Count - 1
    //        For x As Integer = 0 To i
    //            Me.ListView1.Items(item.Index).Selected = False
    //        Next

    //    Next
    //End Sub

     
    }
}