using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using Jinisys.Hotel.Reservation.BusinessLayer;
using Jinisys.Hotel.Reservation.DataAccessLayer;
using Jinisys.Hotel.BusinessSharedClasses;
using MySql.Data.MySqlClient;
using Jinisys.Hotel.ConfigurationHotel.BusinessLayer;

using System.Windows.Forms;

namespace Jinisys.Hotel.Cashier
{
	namespace Presentation
	{
		public class Payment : Jinisys.Hotel.UIFramework.Maintenance2UI
		{
			
			
			#region " Windows Form Designer generated code "
			
			public Payment()
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
			internal System.Windows.Forms.Panel Panel1;
			internal System.Windows.Forms.Label Label1;
			internal System.Windows.Forms.Label Label2;
			internal System.Windows.Forms.Label Label3;
			internal System.Windows.Forms.Label Label4;
			internal System.Windows.Forms.Label Label5;
			internal System.Windows.Forms.Label Label6;
			internal System.Windows.Forms.Label Label7;
			internal System.Windows.Forms.Label Label11;
			internal System.Windows.Forms.Label Label8;
			internal System.Windows.Forms.Label lbl;
			internal System.Windows.Forms.Button btnSave;
			internal System.Windows.Forms.Button btnCancel;
			internal System.Windows.Forms.RadioButton rdoCash;
			internal System.Windows.Forms.RadioButton rdoCard;
			internal System.Windows.Forms.RadioButton rdoCheque;
			internal System.Windows.Forms.TextBox txtDate;
			internal System.Windows.Forms.TextBox txtGuestName;
			internal System.Windows.Forms.TextBox txtMemo;
			internal System.Windows.Forms.TextBox txtAmount;
			internal System.Windows.Forms.TextBox txtRefNo;
			internal System.Windows.Forms.TextBox txtFolioID;
			internal System.Windows.Forms.TextBox txtChequeN0;
			internal System.Windows.Forms.TextBox txtCardNo;
			internal System.Windows.Forms.ComboBox cboCurrency;
			internal System.Windows.Forms.Label Label9;
			internal System.Windows.Forms.Label Label10;
			internal System.Windows.Forms.TextBox txtCurrencyAmount;
			internal System.Windows.Forms.TextBox txtConversionRate;
			internal System.Windows.Forms.Label Label12;
			internal System.Windows.Forms.ComboBox cboCardType;
			internal System.Windows.Forms.ComboBox cboBankCode;
			internal System.Windows.Forms.GroupBox GroupBox1;
			internal System.Windows.Forms.GroupBox pnlCreditCard;
			internal System.Windows.Forms.GroupBox pnlCheque;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
				System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(Payment));
				this.rdoCash = new System.Windows.Forms.RadioButton();
				this.rdoCash.CheckedChanged += new System.EventHandler(rdoCash_CheckedChanged);
				this.rdoCard = new System.Windows.Forms.RadioButton();
				this.rdoCard.CheckedChanged += new System.EventHandler(rdoCard_CheckedChanged);
				this.rdoCheque = new System.Windows.Forms.RadioButton();
				this.rdoCheque.CheckedChanged += new System.EventHandler(rdoCheque_CheckedChanged);
				this.Panel1 = new System.Windows.Forms.Panel();
				this.Label2 = new System.Windows.Forms.Label();
				this.txtDate = new System.Windows.Forms.TextBox();
				this.txtDate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtDate_KeyPress);
				this.Label12 = new System.Windows.Forms.Label();
				this.txtConversionRate = new System.Windows.Forms.TextBox();
				this.txtConversionRate.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtConversionRate_KeyPress);
				this.txtCurrencyAmount = new System.Windows.Forms.TextBox();
				this.txtCurrencyAmount.TextChanged += new System.EventHandler(txtCurrencyAmount_TextChanged);
				this.txtCurrencyAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtCurrencyAmount_KeyPress);
				this.Label10 = new System.Windows.Forms.Label();
				this.Label9 = new System.Windows.Forms.Label();
				this.cboCurrency = new System.Windows.Forms.ComboBox();
				this.cboCurrency.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboCurrency_KeyPress);
				this.cboCurrency.SelectedIndexChanged += new System.EventHandler(cboCurrency_SelectedIndexChanged);
				this.Label6 = new System.Windows.Forms.Label();
				this.txtGuestName = new System.Windows.Forms.TextBox();
				this.txtGuestName.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtGuestName_KeyPress);
				this.Label4 = new System.Windows.Forms.Label();
				this.txtMemo = new System.Windows.Forms.TextBox();
				this.Label5 = new System.Windows.Forms.Label();
				this.txtAmount = new System.Windows.Forms.TextBox();
				this.txtAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtAmount_KeyPress);
				this.Label3 = new System.Windows.Forms.Label();
				this.txtRefNo = new System.Windows.Forms.TextBox();
				this.Label1 = new System.Windows.Forms.Label();
				this.txtFolioID = new System.Windows.Forms.TextBox();
				this.txtFolioID.KeyPress += new System.Windows.Forms.KeyPressEventHandler(txtFolioID_KeyPress);
				this.cboBankCode = new System.Windows.Forms.ComboBox();
				this.Label7 = new System.Windows.Forms.Label();
				this.Label11 = new System.Windows.Forms.Label();
				this.txtChequeN0 = new System.Windows.Forms.TextBox();
				this.cboCardType = new System.Windows.Forms.ComboBox();
				this.Label8 = new System.Windows.Forms.Label();
				this.lbl = new System.Windows.Forms.Label();
				this.txtCardNo = new System.Windows.Forms.TextBox();
				this.btnSave = new System.Windows.Forms.Button();
				this.btnSave.Click += new System.EventHandler(btnSave_Click);
				this.btnCancel = new System.Windows.Forms.Button();
				this.btnCancel.Click += new System.EventHandler(btnCancel_Click);
				this.GroupBox1 = new System.Windows.Forms.GroupBox();
				this.pnlCreditCard = new System.Windows.Forms.GroupBox();
				this.pnlCheque = new System.Windows.Forms.GroupBox();
				this.Panel1.SuspendLayout();
				this.GroupBox1.SuspendLayout();
				this.pnlCreditCard.SuspendLayout();
				this.pnlCheque.SuspendLayout();
				this.SuspendLayout();
				//
				//rdoCash
				//
				this.rdoCash.Checked = true;
				this.rdoCash.Cursor = System.Windows.Forms.Cursors.Hand;
				this.rdoCash.Location = new System.Drawing.Point(10, 13);
				this.rdoCash.Name = "rdoCash";
				this.rdoCash.Size = new System.Drawing.Size(54, 19);
				this.rdoCash.TabIndex = 2;
				this.rdoCash.TabStop = true;
				this.rdoCash.Text = "Cash";
				//
				//rdoCard
				//
				this.rdoCard.Cursor = System.Windows.Forms.Cursors.Hand;
				this.rdoCard.Location = new System.Drawing.Point(82, 13);
				this.rdoCard.Name = "rdoCard";
				this.rdoCard.Size = new System.Drawing.Size(54, 19);
				this.rdoCard.TabIndex = 2;
				this.rdoCard.Text = "Card";
				//
				//rdoCheque
				//
				this.rdoCheque.Cursor = System.Windows.Forms.Cursors.Hand;
				this.rdoCheque.Location = new System.Drawing.Point(154, 13);
				this.rdoCheque.Name = "rdoCheque";
				this.rdoCheque.Size = new System.Drawing.Size(64, 19);
				this.rdoCheque.TabIndex = 2;
				this.rdoCheque.Text = "Cheque";
				//
				//Panel1
				//
				this.Panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
				this.Panel1.Controls.Add(this.Label2);
				this.Panel1.Controls.Add(this.txtDate);
				this.Panel1.Controls.Add(this.rdoCash);
				this.Panel1.Controls.Add(this.rdoCard);
				this.Panel1.Controls.Add(this.rdoCheque);
				this.Panel1.Location = new System.Drawing.Point(8, 9);
				this.Panel1.Name = "Panel1";
				this.Panel1.Size = new System.Drawing.Size(433, 45);
				this.Panel1.TabIndex = 4;
				//
				//Label2
				//
				this.Label2.Location = new System.Drawing.Point(255, 15);
				this.Label2.Name = "Label2";
				this.Label2.Size = new System.Drawing.Size(43, 14);
				this.Label2.TabIndex = 11;
				this.Label2.Text = "Date :";
				//
				//txtDate
				//
				this.txtDate.BackColor = System.Drawing.Color.FromArgb(((byte) (255)), ((byte) (255)), ((byte) (192)));
				this.txtDate.Location = new System.Drawing.Point(304, 12);
				this.txtDate.Name = "txtDate";
				this.txtDate.Size = new System.Drawing.Size(112, 20);
				this.txtDate.TabIndex = 10;
				this.txtDate.Text = "";
				//
				//Label12
				//
				this.Label12.Location = new System.Drawing.Point(120, 104);
				this.Label12.Name = "Label12";
				this.Label12.Size = new System.Drawing.Size(96, 14);
				this.Label12.TabIndex = 23;
				this.Label12.Text = "Conversion Rate";
				//
				//txtConversionRate
				//
				this.txtConversionRate.BackColor = System.Drawing.SystemColors.InactiveBorder;
				this.txtConversionRate.Location = new System.Drawing.Point(120, 120);
				this.txtConversionRate.Name = "txtConversionRate";
				this.txtConversionRate.Size = new System.Drawing.Size(88, 20);
				this.txtConversionRate.TabIndex = 22;
				this.txtConversionRate.Text = "";
				//
				//txtCurrencyAmount
				//
				this.txtCurrencyAmount.Location = new System.Drawing.Point(216, 120);
				this.txtCurrencyAmount.Name = "txtCurrencyAmount";
				this.txtCurrencyAmount.Size = new System.Drawing.Size(96, 20);
				this.txtCurrencyAmount.TabIndex = 21;
				this.txtCurrencyAmount.Text = "";
				//
				//Label10
				//
				this.Label10.Location = new System.Drawing.Point(32, 104);
				this.Label10.Name = "Label10";
				this.Label10.Size = new System.Drawing.Size(56, 14);
				this.Label10.TabIndex = 20;
				this.Label10.Text = "Currency";
				//
				//Label9
				//
				this.Label9.Location = new System.Drawing.Point(224, 104);
				this.Label9.Name = "Label9";
				this.Label9.Size = new System.Drawing.Size(104, 14);
				this.Label9.TabIndex = 19;
				this.Label9.Text = "Currency Amt.";
				//
				//cboCurrency
				//
				this.cboCurrency.Location = new System.Drawing.Point(8, 119);
				this.cboCurrency.Name = "cboCurrency";
				this.cboCurrency.Size = new System.Drawing.Size(104, 22);
				this.cboCurrency.TabIndex = 18;
				this.cboCurrency.Text = "PHP";
				//
				//Label6
				//
				this.Label6.Location = new System.Drawing.Point(8, 40);
				this.Label6.Name = "Label6";
				this.Label6.Size = new System.Drawing.Size(43, 14);
				this.Label6.TabIndex = 17;
				this.Label6.Text = "Name";
				//
				//txtGuestName
				//
				this.txtGuestName.Location = new System.Drawing.Point(64, 40);
				this.txtGuestName.Name = "txtGuestName";
				this.txtGuestName.Size = new System.Drawing.Size(368, 20);
				this.txtGuestName.TabIndex = 16;
				this.txtGuestName.Text = "";
				//
				//Label4
				//
				this.Label4.Location = new System.Drawing.Point(8, 152);
				this.Label4.Name = "Label4";
				this.Label4.Size = new System.Drawing.Size(43, 14);
				this.Label4.TabIndex = 15;
				this.Label4.Text = "MEMO";
				//
				//txtMemo
				//
				this.txtMemo.Location = new System.Drawing.Point(8, 168);
				this.txtMemo.Name = "txtMemo";
				this.txtMemo.Size = new System.Drawing.Size(424, 20);
				this.txtMemo.TabIndex = 14;
				this.txtMemo.Text = "";
				//
				//Label5
				//
				this.Label5.Location = new System.Drawing.Point(328, 104);
				this.Label5.Name = "Label5";
				this.Label5.Size = new System.Drawing.Size(80, 14);
				this.Label5.TabIndex = 13;
				this.Label5.Text = "Base Amount";
				//
				//txtAmount
				//
				this.txtAmount.BackColor = System.Drawing.SystemColors.InactiveBorder;
				this.txtAmount.Location = new System.Drawing.Point(320, 120);
				this.txtAmount.Name = "txtAmount";
				this.txtAmount.Size = new System.Drawing.Size(112, 20);
				this.txtAmount.TabIndex = 12;
				this.txtAmount.Text = "";
				//
				//Label3
				//
				this.Label3.Location = new System.Drawing.Point(8, 64);
				this.Label3.Name = "Label3";
				this.Label3.Size = new System.Drawing.Size(43, 14);
				this.Label3.TabIndex = 11;
				this.Label3.Text = "Ref. # :";
				//
				//txtRefNo
				//
				this.txtRefNo.Location = new System.Drawing.Point(8, 80);
				this.txtRefNo.Name = "txtRefNo";
				this.txtRefNo.Size = new System.Drawing.Size(144, 20);
				this.txtRefNo.TabIndex = 10;
				this.txtRefNo.Text = "";
				//
				//Label1
				//
				this.Label1.Location = new System.Drawing.Point(8, 16);
				this.Label1.Name = "Label1";
				this.Label1.Size = new System.Drawing.Size(43, 14);
				this.Label1.TabIndex = 9;
				this.Label1.Text = "Folio Id";
				//
				//txtFolioID
				//
				this.txtFolioID.Location = new System.Drawing.Point(64, 16);
				this.txtFolioID.Name = "txtFolioID";
				this.txtFolioID.Size = new System.Drawing.Size(98, 20);
				this.txtFolioID.TabIndex = 8;
				this.txtFolioID.Text = "";
				//
				//cboBankCode
				//
				this.cboBankCode.Location = new System.Drawing.Point(95, 54);
				this.cboBankCode.Name = "cboBankCode";
				this.cboBankCode.Size = new System.Drawing.Size(112, 22);
				this.cboBankCode.TabIndex = 19;
				//
				//Label7
				//
				this.Label7.Location = new System.Drawing.Point(23, 54);
				this.Label7.Name = "Label7";
				this.Label7.Size = new System.Drawing.Size(65, 12);
				this.Label7.TabIndex = 17;
				this.Label7.Text = "Bank";
				//
				//Label11
				//
				this.Label11.Location = new System.Drawing.Point(23, 22);
				this.Label11.Name = "Label11";
				this.Label11.Size = new System.Drawing.Size(65, 12);
				this.Label11.TabIndex = 9;
				this.Label11.Text = "Cheque No";
				//
				//txtChequeN0
				//
				this.txtChequeN0.Location = new System.Drawing.Point(95, 22);
				this.txtChequeN0.Name = "txtChequeN0";
				this.txtChequeN0.Size = new System.Drawing.Size(186, 20);
				this.txtChequeN0.TabIndex = 8;
				this.txtChequeN0.Text = "";
				//
				//cboCardType
				//
				this.cboCardType.Location = new System.Drawing.Point(96, 56);
				this.cboCardType.Name = "cboCardType";
				this.cboCardType.Size = new System.Drawing.Size(112, 22);
				this.cboCardType.TabIndex = 19;
				//
				//Label8
				//
				this.Label8.Location = new System.Drawing.Point(24, 56);
				this.Label8.Name = "Label8";
				this.Label8.Size = new System.Drawing.Size(65, 16);
				this.Label8.TabIndex = 17;
				this.Label8.Text = "Card Type";
				//
				//lbl
				//
				this.lbl.Location = new System.Drawing.Point(24, 24);
				this.lbl.Name = "lbl";
				this.lbl.Size = new System.Drawing.Size(65, 16);
				this.lbl.TabIndex = 9;
				this.lbl.Text = "Card No.";
				//
				//txtCardNo
				//
				this.txtCardNo.Location = new System.Drawing.Point(96, 24);
				this.txtCardNo.Name = "txtCardNo";
				this.txtCardNo.Size = new System.Drawing.Size(186, 20);
				this.txtCardNo.TabIndex = 8;
				this.txtCardNo.Text = "";
				//
				//btnSave
				//
				this.btnSave.Cursor = System.Windows.Forms.Cursors.Default;
				this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.btnSave.Location = new System.Drawing.Point(312, 360);
				this.btnSave.Name = "btnSave";
				this.btnSave.Size = new System.Drawing.Size(66, 31);
				this.btnSave.TabIndex = 19;
				this.btnSave.Text = "&Save";
				//
				//btnCancel
				//
				this.btnCancel.Cursor = System.Windows.Forms.Cursors.Default;
				this.btnCancel.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.btnCancel.Location = new System.Drawing.Point(384, 360);
				this.btnCancel.Name = "btnCancel";
				this.btnCancel.Size = new System.Drawing.Size(66, 31);
				this.btnCancel.TabIndex = 20;
				this.btnCancel.Text = "&Cancel";
				//
				//GroupBox1
				//
				this.GroupBox1.Controls.Add(this.Label10);
				this.GroupBox1.Controls.Add(this.txtCurrencyAmount);
				this.GroupBox1.Controls.Add(this.txtConversionRate);
				this.GroupBox1.Controls.Add(this.Label12);
				this.GroupBox1.Controls.Add(this.Label1);
				this.GroupBox1.Controls.Add(this.txtRefNo);
				this.GroupBox1.Controls.Add(this.Label3);
				this.GroupBox1.Controls.Add(this.txtAmount);
				this.GroupBox1.Controls.Add(this.Label5);
				this.GroupBox1.Controls.Add(this.txtMemo);
				this.GroupBox1.Controls.Add(this.Label4);
				this.GroupBox1.Controls.Add(this.txtGuestName);
				this.GroupBox1.Controls.Add(this.Label6);
				this.GroupBox1.Controls.Add(this.txtFolioID);
				this.GroupBox1.Controls.Add(this.cboCurrency);
				this.GroupBox1.Controls.Add(this.Label9);
				this.GroupBox1.Location = new System.Drawing.Point(8, 54);
				this.GroupBox1.Name = "GroupBox1";
				this.GroupBox1.Size = new System.Drawing.Size(440, 210);
				this.GroupBox1.TabIndex = 24;
				this.GroupBox1.TabStop = false;
				//
				//pnlCreditCard
				//
				this.pnlCreditCard.Controls.Add(this.cboCardType);
				this.pnlCreditCard.Controls.Add(this.Label8);
				this.pnlCreditCard.Controls.Add(this.lbl);
				this.pnlCreditCard.Controls.Add(this.txtCardNo);
				this.pnlCreditCard.Location = new System.Drawing.Point(8, 264);
				this.pnlCreditCard.Name = "pnlCreditCard";
				this.pnlCreditCard.Size = new System.Drawing.Size(440, 88);
				this.pnlCreditCard.TabIndex = 25;
				this.pnlCreditCard.TabStop = false;
				//
				//pnlCheque
				//
				this.pnlCheque.Controls.Add(this.cboBankCode);
				this.pnlCheque.Controls.Add(this.Label7);
				this.pnlCheque.Controls.Add(this.Label11);
				this.pnlCheque.Controls.Add(this.txtChequeN0);
				this.pnlCheque.Location = new System.Drawing.Point(8, 264);
				this.pnlCheque.Name = "pnlCheque";
				this.pnlCheque.Size = new System.Drawing.Size(440, 88);
				this.pnlCheque.TabIndex = 26;
				this.pnlCheque.TabStop = false;
				//
				//Payment
				//
				this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
				this.ClientSize = new System.Drawing.Size(456, 399);
				this.Controls.Add(this.GroupBox1);
				this.Controls.Add(this.btnCancel);
				this.Controls.Add(this.btnSave);
				this.Controls.Add(this.Panel1);
				this.Controls.Add(this.pnlCheque);
				this.Controls.Add(this.pnlCreditCard);
				this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (0)));
				this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
				this.MinimizeBox = false;
				this.Name = "Payment";
				this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
				this.Text = "Payments";
				this.Panel1.ResumeLayout(false);
				this.GroupBox1.ResumeLayout(false);
				this.pnlCreditCard.ResumeLayout(false);
				this.pnlCheque.ResumeLayout(false);
				this.ResumeLayout(false);
				
			}
			
			#endregion
			private MySqlConnection localConnection;
			private string FolioID;
			private string Guest;

			private string PaymentType = "CASH";

			// Private FolioTransactions As New Jinisys.Hotel.Reservation.BusinessLayer.FolioTransactons
			private Jinisys.Hotel.Reservation.BusinessLayer.FolioTransactionFacade FolioTransactionFacade;
			private CurrencyCode Currency;
			private CurrencyCodeFacade CurrencyDAO;
			private System.Windows.Forms.TextBox txtFolID;
			public Payment(MySqlConnection con, System.Windows.Forms.TextBox txtFID, string guests)
			{
				InitializeComponent();
				
				localConnection = con;
				CurrencyDAO = new CurrencyCodeFacade();
				Currency = (CurrencyCode)CurrencyDAO.loadObject();
				FolioTransactionFacade = new Jinisys.Hotel.Reservation.BusinessLayer.FolioTransactionFacade( );
				FolioID = txtFID.Text;
				txtFolID = txtFID;
				Guest = guests;
				this.cboCurrency.DataSource = Currency.Tables["CurrencyCode"];
				this.cboCurrency.ValueMember = "currencycode";
				this.txtDate.Text = string.Format("{0:MM/dd/yyyy}", DateTime.Now);
				this.txtFolioID.Text = FolioID;
				this.txtGuestName.Text = guests;
				lodDataToComboBox();
			}
			private void txtDate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			
			private void rdoCard_CheckedChanged(System.Object sender, System.EventArgs e)
			{
				if (rdoCard.Checked)
				{
					this.pnlCreditCard.Enabled = true;
					this.pnlCheque.Visible = false;
					this.pnlCreditCard.Visible = true;
				}
				else
				{
					this.pnlCreditCard.Enabled = false;
					this.pnlCheque.Visible = true;
					this.pnlCreditCard.Visible = false;
				}
				PaymentType = "CREDIT CARD";
			}
			
			private void rdoCash_CheckedChanged(System.Object sender, System.EventArgs e)
			{
				this.pnlCheque.Enabled = false;
				this.pnlCreditCard.Enabled = false;
			}
			
			private void rdoCheque_CheckedChanged(System.Object sender, System.EventArgs e)
			{
				if (rdoCheque.Checked)
				{
					this.pnlCheque.Enabled = true;
					this.pnlCreditCard.Visible = false;
					this.pnlCheque.Visible = true;
				}
				else
				{
					this.pnlCheque.Enabled = false;
					this.pnlCreditCard.Visible = true;
					this.pnlCheque.Visible = false;
				}
				PaymentType = "CHEQUE";
			}
			private void txtFolioID_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			private void txtGuestName_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			//Needs to be reviewed in the part of terminal id
			private void btnSave_Click(System.Object sender, System.EventArgs e)
			{
				SaveEntry();
			}
			
			public void SaveEntry()
			{
				if (this.txtCurrencyAmount.Text == "")
				{
					MessageBox.Show("Invalid Currency Amount", "Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
					this.txtCurrencyAmount.Focus();
					return;
					
				}
				else if (System.Convert.ToDouble(this.txtCurrencyAmount.Text) <= 0)
				{
					
				}
				FolioTransaction FolioTransaction = new FolioTransaction();
				FolioTransaction.FolioID = FolioID;
				FolioTransaction.TransactionDate = System.Convert.ToDateTime(string.Format("{0:yyyy-MM-dd hh:mm:ss}", DateTime.Now));
				FolioTransaction.Memo = txtMemo.Text;
				FolioTransaction.AcctSide = "CREDIT";
				FolioTransaction.CurrencyCode = cboCurrency.Text;
				FolioTransaction.ConversionRate = decimal.Parse(txtConversionRate.Text);
				FolioTransaction.CurrencyAmount = decimal.Parse(txtCurrencyAmount.Text);
				FolioTransaction.BaseAmount = decimal.Parse(txtAmount.Text);
				FolioTransaction.UpdatedBy = GlobalVariables.gLoggedOnUser;
				FolioTransaction.UpdateTime = System.Convert.ToDateTime(string.Format("{0:hh:mm:ss}", DateTime.Now));
				FolioTransaction.RouteSequence = "FILLER";
				FolioTransaction.TerminalID = GlobalVariables.gTerminalID.ToString();
				FolioTransaction.ReferenceNo = txtRefNo.Text;
				// FolioTransaction.p = PaymentType
				
				//Select Case PaymentType
				//    Case "CASH"
				//        FolioTransaction.TransactionCode = "4300"
				//    Case "CREDIT CARD"
				//        FolioTransaction.TransactionCode = "2100"
				//        FolioTransaction.CreditCardNo = txtCardNo.Text
				//        FolioTransaction.CreditCardType = cboCardType.Text
				//    Case "CHEQUE"
				//        FolioTransaction.TransactionCode = "2200"
				//        FolioTransaction.ChequeNo = txtChequeN0.Text
				//        FolioTransaction.BankCode = Me.cboBankCode.Text
				//End Select
			//FolioTransactionFacade.InsertFolioTransaction(FolioTransaction);
				//Dim txtHelper As New Jinisys.Hotel.BusinessSharedClasses.TextBoxHelper
				txtFolID.Text = FolioID;
				this.Hide();
			}
			private void cboCurrency_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			
			private void cboCurrency_SelectedIndexChanged(System.Object sender, System.EventArgs e)
			{
				//Currency = CurrencyDAO.GetCurrency(Me.cboCurrency.Text)
				this.txtConversionRate.Text = Currency.Tables["CurrencyCode"].Rows[0]["conversionrate"].ToString();
				
			}
			
			private void txtCurrencyAmount_TextChanged(System.Object sender, System.EventArgs e)
			{
				//if (Information.IsNumeric(this.txtCurrencyAmount.Text))
				//{
				//    this.txtAmount.Text = Strings.Format(double.Parse(this.txtConversionRate.Text) * double.Parse(this.txtCurrencyAmount.Text), GlobalVariables.gCurrencyFormat);
				//}
			}
			//this is temporary to make payments work
			private void lodDataToComboBox()
			{
				DataTable dtTable;
				dtTable = FolioTransactionFacade.GetData("CREDITCARD");
				this.cboCardType.DataSource = dtTable;
				this.cboCardType.ValueMember = "Code";
				DataTable dttable1;
				dttable1 = FolioTransactionFacade.GetData("CHEQUE");
				this.cboBankCode.DataSource = dttable1;
				this.cboBankCode.ValueMember = "Code";
				
			}
			///''''''''''
			private void btnCancel_Click(System.Object sender, System.EventArgs e)
			{
				this.Close();
			}
			private void trapLetters(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				switch (e.KeyChar)
				{
					case '\r':
						e.Handled = false;
						break;
						
					case '\b':
						e.Handled = false;
						break;
						
					default:
						if (e.KeyChar == '.')
						{
							
							e.Handled = false;
							break;
						}
						if (e.KeyChar >= '0'& e.KeyChar <= '9')
						{
							e.Handled = false;
							break;
							
						}
						
						e.Handled = true;
						break;
				}
			}
			private void txtCurrencyAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				trapLetters(sender, e);
			}
			
			private void txtConversionRate_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			
			private void txtAmount_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
			{
				e.Handled = true;
			}
			
			
		}
	}
	
}
