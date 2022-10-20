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
    public partial class MinibarItemCategoryUI : Form
    {
        public MinibarItemCategoryUI()
        {
           
            InitializeComponent();
          
        }
        private MinibarItemCategoryFacade oCategoryFacade = new MinibarItemCategoryFacade();
        private MinibarItemCategory category = null;
        private DataSet ds = new DataSet("Categories");
        private ControlListener oControlListener = new ControlListener();
        private DatasetBinder oDatasetBinder = new DatasetBinder();
        enum OperationMode { ADD, EDIT };
        private OperationMode mOperationMode;
        private int CurrPos = 0;
       
        private void ItemUI_Load(object sender, EventArgs e)
        {
            category = oCategoryFacade.getCategories();
            category.TableName = "minibar_category";
            if (loadList())
            {
                ds.Tables.Add(category);
                object obj = (object)ds;
                oDatasetBinder.BindControls(this, ref obj, new ArrayList());

            }
          
            this.txtCategoryID.Enabled = false;
           
            this.setActionButtonStates(true);
            oControlListener.Listen(this);
           
        }
        private bool dialogDisplay = false;
        private int catid;
        public int ShowCategoryUI(Form owner)
        {
            dialogDisplay = true;
            base.ShowDialog(owner);
            return catid;
        }
        private bool loadList()
        {
            try
            {
                this.lstCategories.Items.Clear();
                foreach (DataRow row in category.Rows)
                {
                    ListViewItem li = new ListViewItem(row["CategoryID"].ToString());
                    li.SubItems.Add(row["CategoryName"].ToString());
                    this.lstCategories.Items.Add(li);
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
            this.txtCategoryID.Enabled = true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (mOperationMode.Equals(OperationMode.ADD))
            {
                //if (this.lstCategories.Rows > 1)
                //{
                //    this.lstCategories.Items.= 1;
                //}
            }
            else
            {
                this.BindingContext[ds.Tables[0]].CancelCurrentEdit();
            }
            this.BindingContext[ds.Tables[0]].ResumeBinding();
            this.Text = "Categories";
            this.txtCategoryID.Enabled = false;
            setActionButtonStates(true);
            oControlListener.Listen(this);
        }
        private void updatePosition()
        {
            this.BindingContext[category].Position = CurrPos;
            this.Refresh();
        }
        private bool assignEntityValues()
        {
            category.CategoryID = int.Parse(this.txtCategoryID.Text);
            category.CategoryName = this.txtCategoryName.Text;
           
            return true;
        }
        private void lstCategories_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                oControlListener.StopListen(this);
                if (this.lstCategories.SelectedItems != null)
                {
                    CurrPos = this.lstCategories.SelectedItems[0].Index;
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
            if (this.txtCategoryID.Text.Trim().Length > 0)
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
                MinibarItemCategoryFacade oCategoryFacade = new MinibarItemCategoryFacade();
                rowsAdded = oCategoryFacade.Save(ref category);
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
        
        public bool update()
        {
            try
            {
                bool rowsAffected=false;
                MinibarItemCategoryFacade oCategoryFacade = new MinibarItemCategoryFacade();
                rowsAffected = oCategoryFacade.Update(ref category);
                return rowsAffected;
            }
            catch (Exception ex)
            {
				MessageBox.Show("Database Update Error.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error );
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
                            MessageBox.Show("New Category successfully added.", "Categories ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            if (dialogDisplay)
                            {
                                catid = category.CategoryID;
                                this.Close();
                            }
                            loadList();

                            // >> Resume Binding
                            this.BindingContext[ds.Tables[0]].ResumeBinding();
                            this.Text = "Categories";

                            //mode = "";
                            this.txtCategoryID.Enabled = false;

                            setActionButtonStates(true);
                            oControlListener.Listen(this);

                        }
                        else
                        {
                            MessageBox.Show("No rows added", "Database Insert Error");
                        }

                        break;
                    case OperationMode.EDIT:
                        if (update())
                        {
                            MessageBox.Show("Category successfully updated.", "Category", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadList();
                            this.BindingContext[ds.Tables[0]].ResumeBinding();
                            this.Text = "Categories";
                            this.txtCategoryID.Enabled = false;
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
                //MessageBox.Show("Please input currency code!", "Save Error");
                this.txtCategoryID.Focus();
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
                oCategoryFacade = new MinibarItemCategoryFacade();
                rowsAffected = oCategoryFacade.Delete(ref category);
                return rowsAffected;
            }
            catch (Exception) { return false; }
        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Delete this item \'" + this.txtCategoryID.Text + "\'", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                this.Text = "Categories";

                oControlListener.StopListen(this);

                category.CategoryID = int.Parse(this.txtCategoryID.Text);

                if (delete() )
                {
                    this.lstCategories.SelectedItems[0].Remove();

                    if (this.lstCategories.Items.Count > 0)
                    {
                        this.lstCategories.Items[0].Selected = true;
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

   
        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((int)e.KeyChar == 13)
            {
                deselect();
                this.lstCategories.Focus();
                foreach(ListViewItem item in this.lstCategories.Items)
                {
                    int i = item.SubItems.Count-1;
                    for (int x = 0;x<=i;x++)
                    {
                        if (item.SubItems[x].Text.ToLower().IndexOf(this.txtSearch.Text.ToLower())!=-1)
                        {
                            this.lstCategories.Items[item.Index].Selected = true;
                            this.lstCategories.EnsureVisible(item.Index);
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
            foreach (ListViewItem li in this.lstCategories.Items)
            {
                int i = li.SubItems.Count - 1;
                for (int x = 0; x <= i ; x++)
                {
                    this.lstCategories.Items[li.Index].Selected = false;
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

        private void gbxCommands_Enter(object sender, EventArgs e)
        {

        }

        private void GroupBox3_Enter(object sender, EventArgs e)
        {

        }

		private void btnClose_Click(object sender, EventArgs e)
		{
			this.Close();
		}
 

     
    }
}