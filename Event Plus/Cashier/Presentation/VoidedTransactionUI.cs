using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using System.Windows.Forms;
using MySql.Data.MySqlClient;


namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class VoidedTransactionUI : Jinisys.Hotel.UIFramework.Maintenance2UI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public VoidedTransactionUI()
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
			internal System.Windows.Forms.Button btnOk;
			internal System.Windows.Forms.Button btnClose;
			internal ListView lvwVoidedTransactions;
			internal ColumnHeader colTransDateA;
			private ColumnHeader colTransPostingDateA;
			internal ColumnHeader colTransCodeA;
			internal ColumnHeader colTransMemoA;
			internal ColumnHeader colTransDocSourceA;
			private ColumnHeader colTransRefNoA;
			internal ColumnHeader colTransBaseAmountA;
			internal ColumnHeader colTransTaxA;
			internal ColumnHeader colTransServiceChargeA;
			private ColumnHeader colTransGrossAmountA;
			internal ColumnHeader colTransDiscountA;
			internal ColumnHeader colTransNetAmountA;
			private ColumnHeader colTransStaffA;
			private ColumnHeader colTransNetBaseAmountA;
			private ColumnHeader columnHeader21;
			internal System.Windows.Forms.CheckBox chkAll;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(VoidedTransactionUI));
				this.btnOk = new System.Windows.Forms.Button();
				this.btnClose = new System.Windows.Forms.Button();
				this.chkAll = new System.Windows.Forms.CheckBox();
				this.lvwVoidedTransactions = new System.Windows.Forms.ListView();
				this.colTransDateA = new System.Windows.Forms.ColumnHeader();
				this.colTransPostingDateA = new System.Windows.Forms.ColumnHeader();
				this.colTransCodeA = new System.Windows.Forms.ColumnHeader();
				this.colTransMemoA = new System.Windows.Forms.ColumnHeader();
				this.colTransDocSourceA = new System.Windows.Forms.ColumnHeader();
				this.colTransRefNoA = new System.Windows.Forms.ColumnHeader();
				this.colTransBaseAmountA = new System.Windows.Forms.ColumnHeader();
				this.colTransTaxA = new System.Windows.Forms.ColumnHeader();
				this.colTransServiceChargeA = new System.Windows.Forms.ColumnHeader();
				this.colTransGrossAmountA = new System.Windows.Forms.ColumnHeader();
				this.colTransDiscountA = new System.Windows.Forms.ColumnHeader();
				this.colTransNetAmountA = new System.Windows.Forms.ColumnHeader();
				this.colTransStaffA = new System.Windows.Forms.ColumnHeader();
				this.colTransNetBaseAmountA = new System.Windows.Forms.ColumnHeader();
				this.columnHeader21 = new System.Windows.Forms.ColumnHeader();
				this.SuspendLayout();
				// 
				// btnOk
				// 
				this.btnOk.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnOk.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnOk.Location = new System.Drawing.Point(652, 350);
				this.btnOk.Name = "btnOk";
				this.btnOk.Size = new System.Drawing.Size(66, 31);
				this.btnOk.TabIndex = 91;
				this.btnOk.Text = "&Ok";
				this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
				// 
				// btnClose
				// 
				this.btnClose.Cursor = System.Windows.Forms.Cursors.Hand;
				this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
				this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.btnClose.Location = new System.Drawing.Point(722, 350);
				this.btnClose.Name = "btnClose";
				this.btnClose.Size = new System.Drawing.Size(66, 31);
				this.btnClose.TabIndex = 92;
				this.btnClose.Text = "Cl&ose";
				this.btnClose.Click += new System.EventHandler(this.btnCancel_Click);
				// 
				// chkAll
				// 
				this.chkAll.Location = new System.Drawing.Point(14, 342);
				this.chkAll.Name = "chkAll";
				this.chkAll.Size = new System.Drawing.Size(110, 21);
				this.chkAll.TabIndex = 94;
				this.chkAll.Text = "&Check All";
				this.chkAll.CheckedChanged += new System.EventHandler(this.chkAll_CheckedChanged);
				// 
				// lvwVoidedTransactions
				// 
				this.lvwVoidedTransactions.CheckBoxes = true;
				this.lvwVoidedTransactions.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colTransDateA,
            this.colTransPostingDateA,
            this.colTransCodeA,
            this.colTransMemoA,
            this.colTransDocSourceA,
            this.colTransRefNoA,
            this.colTransBaseAmountA,
            this.colTransTaxA,
            this.colTransServiceChargeA,
            this.colTransGrossAmountA,
            this.colTransDiscountA,
            this.colTransNetAmountA,
            this.colTransStaffA,
            this.colTransNetBaseAmountA,
            this.columnHeader21});
				this.lvwVoidedTransactions.FullRowSelect = true;
				this.lvwVoidedTransactions.Location = new System.Drawing.Point(12, 18);
				this.lvwVoidedTransactions.Name = "lvwVoidedTransactions";
				this.lvwVoidedTransactions.Size = new System.Drawing.Size(776, 317);
				this.lvwVoidedTransactions.TabIndex = 95;
				this.lvwVoidedTransactions.UseCompatibleStateImageBehavior = false;
				this.lvwVoidedTransactions.View = System.Windows.Forms.View.Details;
				// 
				// colTransDateA
				// 
				this.colTransDateA.Text = "Date";
				this.colTransDateA.Width = 75;
				// 
				// colTransPostingDateA
				// 
				this.colTransPostingDateA.Text = "Posting Date";
				this.colTransPostingDateA.Width = 0;
				// 
				// colTransCodeA
				// 
				this.colTransCodeA.Text = "Code";
				this.colTransCodeA.Width = 40;
				// 
				// colTransMemoA
				// 
				this.colTransMemoA.Text = "Memo";
				this.colTransMemoA.Width = 139;
				// 
				// colTransDocSourceA
				// 
				this.colTransDocSourceA.Text = "Source";
				this.colTransDocSourceA.Width = 72;
				// 
				// colTransRefNoA
				// 
				this.colTransRefNoA.Text = "Ref. No.";
				this.colTransRefNoA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
				this.colTransRefNoA.Width = 75;
				// 
				// colTransBaseAmountA
				// 
				this.colTransBaseAmountA.Text = "Amount";
				this.colTransBaseAmountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.colTransBaseAmountA.Width = 72;
				// 
				// colTransTaxA
				// 
				this.colTransTaxA.Text = "Tax";
				this.colTransTaxA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.colTransTaxA.Width = 59;
				// 
				// colTransServiceChargeA
				// 
				this.colTransServiceChargeA.Text = "Srvc Chrg";
				this.colTransServiceChargeA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.colTransServiceChargeA.Width = 0;
				// 
				// colTransGrossAmountA
				// 
				this.colTransGrossAmountA.Text = "Gross Amt.";
				this.colTransGrossAmountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.colTransGrossAmountA.Width = 70;
				// 
				// colTransDiscountA
				// 
				this.colTransDiscountA.Text = "Discount";
				this.colTransDiscountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.colTransDiscountA.Width = 54;
				// 
				// colTransNetAmountA
				// 
				this.colTransNetAmountA.Text = "Net Amount";
				this.colTransNetAmountA.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
				this.colTransNetAmountA.Width = 70;
				// 
				// colTransStaffA
				// 
				this.colTransStaffA.Text = "Staff";
				this.colTransStaffA.Width = 46;
				// 
				// colTransNetBaseAmountA
				// 
				this.colTransNetBaseAmountA.Text = "Net Base Amount";
				this.colTransNetBaseAmountA.Width = 0;
				// 
				// columnHeader21
				// 
				this.columnHeader21.Text = "TransactionNo";
				this.columnHeader21.Width = 0;
				// 
				// VoidedTransactionUI
				// 
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.CancelButton = this.btnClose;
				this.ClientSize = new System.Drawing.Size(798, 398);
				this.Controls.Add(this.lvwVoidedTransactions);
				this.Controls.Add(this.chkAll);
				this.Controls.Add(this.btnClose);
				this.Controls.Add(this.btnOk);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
				this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
				this.Name = "VoidedTransactionUI";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
				this.Text = "Voided Folio Transactions";
				this.ResumeLayout(false);

			}
			
			#endregion
			
			
			private string mAccountId;
			private string mFolioId;
			private Control mCtrl;
			private MySqlConnection localConnection;
			private FolioTransactionFacade oFolioTransFacade;
			public VoidedTransactionUI(MySqlConnection connection, string folioId, string accountId, string roomId, Control ctrl)
			{
				InitializeComponent();
				
				this.Text = "Voided Folio Transactions - " + roomId;
				localConnection = connection;
				mFolioId = folioId;
				mAccountId = accountId;
				mCtrl = ctrl;
				
				getVoidedTransactions(folioId);
			}
			
			private FolioTransaction oFolioTrans;
			public void getVoidedTransactions(string folioId)
			{
				oFolioTransFacade = new FolioTransactionFacade();
				oFolioTrans = new FolioTransaction();
				oFolioTrans = oFolioTransFacade.GetVoidedFolioTransactions(folioId);
				
				DataRow dt;
				this.lvwVoidedTransactions.Items.Clear();
				foreach (DataRow tempLoopVar_dt in oFolioTrans.Tables[0].Rows)
				{
					dt = tempLoopVar_dt;

					decimal _totalTax = decimal.Parse( dt["governmenttax"].ToString()) + decimal.Parse( dt["localtax"].ToString() );


					DateTime _tranDate = DateTime.Parse( dt["transactionDate"].ToString() );

					ListViewItem lst = new ListViewItem(_tranDate.ToShortDateString());
					lst.SubItems.Add(dt["postingDate"].ToString());
					lst.SubItems.Add(dt["transactioncode"].ToString());
					lst.SubItems.Add(dt["memo"].ToString());
					lst.SubItems.Add(dt["TransactionSource"].ToString());
					lst.SubItems.Add(dt["ReferenceNo"].ToString());
					lst.SubItems.Add(dt["baseamount"].ToString());

					lst.SubItems.Add(_totalTax.ToString("N"));
					lst.SubItems.Add(dt["servicecharge"].ToString());
					lst.SubItems.Add(dt["grossAmount"].ToString());
					lst.SubItems.Add(dt["discount"].ToString());
					lst.SubItems.Add(dt["netamount"].ToString());

					lst.SubItems.Add(dt["updatedBy"].ToString());
					lst.SubItems.Add(dt["netbaseAmount"].ToString());
					lst.SubItems.Add(dt["folioTransactionNo"].ToString());

					if (dt["auditFlag"].ToString() == "1")
					{
						lst.BackColor = System.Drawing.Color.Gainsboro;
					}
					else
					{
						lst.BackColor = System.Drawing.Color.White;
					}

					//this.lvwVoidedTrans.Items.Add(lst);

					this.lvwVoidedTransactions.Items.Add(lst);
				}
			}
			
			private void chkAll_CheckedChanged(System.Object sender, System.EventArgs e)
			{
				if (chkAll.CheckState == CheckState.Checked)
				{
					ListViewItem lvItem;
					foreach (ListViewItem tempLoopVar_lvItem in this.lvwVoidedTransactions.Items)
					{
						lvItem = tempLoopVar_lvItem;
						lvItem.Checked = true;
					}
				}
				else
				{
					ListViewItem lvItem;
					foreach (ListViewItem tempLoopVar_lvItem in this.lvwVoidedTransactions.Items)
					{
						lvItem = tempLoopVar_lvItem;
						lvItem.Checked = false;
					}
				}
			}
			
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
			
			private void btnOk_Click(System.Object sender, System.EventArgs e)
			{
				SaveEntry();
			}
			
			public void SaveEntry()
			{
				foreach (ListViewItem lvItem in this.lvwVoidedTransactions.Items)
				{
					if (lvItem.BackColor == System.Drawing.Color.Gainsboro && lvItem.Checked == true)
					{
						MessageBox.Show("A posted transaction is selected.\r\nRecall is not allowed for posted transactions.", "Folio Plus", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
						return;
					}
				}

				foreach (ListViewItem lvItem in this.lvwVoidedTransactions.Items)
				{
					if (lvItem.Checked == true)
					{
						int _folioTransactionNo = int.Parse( lvItem.SubItems[14].Text );

						FolioTransaction _oFolioTrans = oFolioTransFacade.getFolioTransactionByTransactionNo(_folioTransactionNo);

						_oFolioTrans.ReferenceNo = _oFolioTrans.ReferenceNo.Replace("(VOID)", "");
						
                        MySqlTransaction myTransaction = GlobalVariables.gPersistentConnection.BeginTransaction();
						if (oFolioTransFacade.RecallFolioTransaction(_oFolioTrans, ref myTransaction))
                        {
                            myTransaction.Commit();
                        }
                        else
                        {
                            myTransaction.Rollback();
                        }
						
						
					}
				}
				
				string temp = mCtrl.Text;
				mCtrl.Text = "";
				mCtrl.Text = temp;
				this.Close();
				
			}
		}
	}
}
