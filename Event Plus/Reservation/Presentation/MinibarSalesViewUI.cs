using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Collections;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;
using Jinisys.Hotel.Reservation.BusinessLayer;

using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.Reservation.Presentation
{
    public partial class MinibarSalesViewUI : Form
    {
        public MinibarSalesViewUI()
        {
            InitializeComponent();
        }
        private Jinisys.Hotel.Reservation.BusinessLayer.MinibarSaleFacade sf = new Jinisys.Hotel.Reservation.BusinessLayer.MinibarSaleFacade();
        private DataSet dsSales;
        private DataView salesDataView;
        private void ViewUI_Load(object sender, EventArgs e)
        {
			try
			{
				dsSales = sf.getSales(DateTime.Now, DateTime.Now);
				this.salesDataView = dsSales.Tables["Housekeepers"].DefaultView;
				buildTree();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Transaction failed.\r\nError message: " + ex.Message, "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
        }
        private void refreshDataset()
        {
            dsSales = sf.getSales(this.dateTimePicker1.Value,this.dateTimePicker2.Value);
        }
        private void buildTree()
        {
            this.salesTree.Nodes.Clear();
            DataTable table = dsSales.Tables[0];
            DataRow[] childRows;
            DataRelation relation = table.ChildRelations[0];               
                    foreach (DataRow row in table.Rows)
                    {
                        TreeNode hkNode = new TreeNode(row["name"].ToString());
                        hkNode.Name = "Housekeepers";
                        hkNode.Tag = row[0].ToString();
                        childRows = row.GetChildRows(relation);
                        foreach (DataRow r in childRows)
                        {
                            String sale = "Room # " + r["Room No."].ToString() + ", Date : " + string.Format("{0:MM/dd/yyyy}", r["Sales Date"]) + ", Amount : " + r["Amount"].ToString();
                            TreeNode saleNode = new TreeNode(sale);
                            saleNode.Name = "Sales";
                            saleNode.Tag = r[0].ToString();
                            hkNode.Nodes.Add(saleNode);
                        }
                        this.salesTree.Nodes.Add(hkNode);
                    }
              
        }

        private void salesTree_AfterSelect(object sender, TreeViewEventArgs e)
        {
           
        }

        private void salesTree_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
         
                    DataTable dtHK = dsSales.Tables[e.Node.Name];
                    DataRelation relation = dtHK.ChildRelations[0];
                    DataRow row = dtHK.Rows.Find(e.Node.Tag);
                    DataRow[] childRows = row.GetChildRows(relation);
                    setRightPanelDisplay(childRows);

                    if (e.Node.Name == "Housekeepers")
                        this.lblListHeader.Text = "Sales";
                    else
                        this.lblListHeader.Text = "Sales Details";
                        
        }
        private void setRightPanelDisplay(DataRow[] drCol)
        {
            this.lvwSalesDetails.Clear();
            DataRow r1 = drCol[0];
            if (r1 == null) return;
            for (int i = 0; i < r1.Table.Columns.Count; i++)
            {
                ColumnHeader colHead = new ColumnHeader();
                colHead.Text = r1.Table.Columns[i].ColumnName;
                
                this.lvwSalesDetails.Columns.Add(colHead);
            }
            foreach(DataRow r in drCol)
            {
                ListViewItem li = new ListViewItem(r[0].ToString());
                for (int i = 1; i < this.lvwSalesDetails.Columns.Count; i++)
                {
                    li.SubItems.Add(r[i].ToString());
                    
                }
                this.lvwSalesDetails.Items.Add(li);
            }
            foreach(ColumnHeader h in this.lvwSalesDetails.Columns)
            {

                h.Width = -2;
            
            }
        }
        private void voidSalesDetails()
        {
            int transID = int.Parse(this.lvwSalesDetails.SelectedItems[0].Text);
            bool success = sf.voidSaleDetail(transID);
            if (success)
            {
                removeRowInDataset("SalesDetails", this.lvwSalesDetails.SelectedIndices[0]);
                this.lvwSalesDetails.Items.RemoveAt(this.lvwSalesDetails.SelectedIndices[0]);
                MessageBox.Show("Line item successfully voided!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void voidSales()
        {
            int salesID = int.Parse(this.lvwSalesDetails.SelectedItems[0].Text);
            bool success = sf.voidSales(salesID);
            if (success)
            {
                refreshDataset();
                buildTree();
                this.lvwSalesDetails.Items.Clear();
                this.salesTree.ExpandAll();
                MessageBox.Show("Line item successfully voided!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void btnVoid_Click(object sender, EventArgs e)
        {
            if (this.lblListHeader.Text == "") return;
            if (this.lvwSalesDetails.SelectedItems.Count > 0)
            {
				HousekeepingPinUI pinUI = new HousekeepingPinUI();
                bool ok = pinUI.ShoPinUI();

				if (ok)
				{
					if (lblListHeader.Text == "Sales Details")
						voidSalesDetails();
					else
						voidSales();
				}
				else
				{
					MessageBox.Show("Invalid Pin Code!", "Invalid Pin", MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
            }
        }
        private void removeRowInDataset(String table, int rowIndex)
        {
            dsSales.Tables[table].Rows.RemoveAt(rowIndex);
            dsSales.AcceptChanges();
        }
        
        private void lblListHeader_TextChanged(object sender, EventArgs e)
        {
            if (this.lblListHeader.Text == "Sales Details" || this.lblListHeader.Text == "Sales")
                this.btnVoid.Enabled = true;
            else
                this.btnVoid.Enabled = false;
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            refreshDataset();
            buildTree();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		private void MinibarSalesViewUI_Activated(object sender, EventArgs e)
		{
			this.WindowState = FormWindowState.Maximized;
		}


    
      
    }
}