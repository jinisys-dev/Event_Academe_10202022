using System.Diagnostics;
using Microsoft.VisualBasic;
using System;
using System.Data;
using System.Collections;
using MySql.Data.MySqlClient;

using System.Windows.Forms;


using Jinisys.Hotel.Reservation.BusinessLayer;


namespace Jinisys.Hotel.Cashier.Presentation
{
    public class PostToLedgerUI : Jinisys.Hotel.UIFramework.TransactionUI
    {


        #region " Windows Form Designer generated code "

        public PostToLedgerUI()
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
        internal System.Windows.Forms.RadioButton rdoDateRange;
        internal System.Windows.Forms.RadioButton rdobyMonth;
        internal System.Windows.Forms.RadioButton rdoByDate;
        internal System.Windows.Forms.ComboBox cboMonth;
        internal System.Windows.Forms.DateTimePicker dtpDate;
        internal System.Windows.Forms.ComboBox cboYear;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.GroupBox grpFromTo;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Label lblFrom;
        internal System.Windows.Forms.DateTimePicker dtpTo;
        internal System.Windows.Forms.DateTimePicker dtpFrom;
        internal System.Windows.Forms.GroupBox grpByMonth;
        internal System.Windows.Forms.GroupBox grpByDate;
        internal System.Windows.Forms.Button btnPostToLedger;
        internal System.Windows.Forms.GroupBox grpPostingOptions;
        internal System.Windows.Forms.Button btnClose;
        internal System.Windows.Forms.Label Label4;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.grpPostingOptions = new System.Windows.Forms.GroupBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.grpByDate = new System.Windows.Forms.GroupBox();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.grpFromTo = new System.Windows.Forms.GroupBox();
            this.lblFrom = new System.Windows.Forms.Label();
            this.dtpTo = new System.Windows.Forms.DateTimePicker();
            this.dtpFrom = new System.Windows.Forms.DateTimePicker();
            this.Label1 = new System.Windows.Forms.Label();
            this.rdoByDate = new System.Windows.Forms.RadioButton();
            this.rdoByDate.CheckedChanged += new System.EventHandler(rdoByDate_CheckedChanged);
            this.rdobyMonth = new System.Windows.Forms.RadioButton();
            this.rdobyMonth.CheckedChanged += new System.EventHandler(rdobyMonth_CheckedChanged);
            this.rdoDateRange = new System.Windows.Forms.RadioButton();
            this.rdoDateRange.CheckedChanged += new System.EventHandler(rdoDateRange_CheckedChanged);
            this.grpByMonth = new System.Windows.Forms.GroupBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.cboMonth = new System.Windows.Forms.ComboBox();
            this.cboMonth.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboMonth_KeyPress);
            this.cboYear = new System.Windows.Forms.ComboBox();
            this.cboYear.KeyPress += new System.Windows.Forms.KeyPressEventHandler(cboYear_KeyPress);
            this.Label2 = new System.Windows.Forms.Label();
            this.btnPostToLedger = new System.Windows.Forms.Button();
            this.btnPostToLedger.Click += new System.EventHandler(btnPostToLedger_Click);
            this.btnClose = new System.Windows.Forms.Button();
            this.btnClose.Click += new System.EventHandler(btnClose_Click);
            this.grpPostingOptions.SuspendLayout();
            this.grpByDate.SuspendLayout();
            this.grpFromTo.SuspendLayout();
            this.grpByMonth.SuspendLayout();
            this.SuspendLayout();
            //
            //grpPostingOptions
            //
            this.grpPostingOptions.Controls.Add(this.Label4);
            this.grpPostingOptions.Controls.Add(this.grpByDate);
            this.grpPostingOptions.Controls.Add(this.grpFromTo);
            this.grpPostingOptions.Controls.Add(this.rdoByDate);
            this.grpPostingOptions.Controls.Add(this.rdobyMonth);
            this.grpPostingOptions.Controls.Add(this.rdoDateRange);
            this.grpPostingOptions.Controls.Add(this.grpByMonth);
            this.grpPostingOptions.Location = new System.Drawing.Point(4, -2);
            this.grpPostingOptions.Name = "grpPostingOptions";
            this.grpPostingOptions.Size = new System.Drawing.Size(420, 162);
            this.grpPostingOptions.TabIndex = 0;
            this.grpPostingOptions.TabStop = false;
            //
            //Label4
            //
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(8, 12);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(184, 16);
            this.Label4.TabIndex = 8;
            this.Label4.Text = "Posting Options";
            //
            //grpByDate
            //
            this.grpByDate.Controls.Add(this.dtpDate);
            this.grpByDate.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpByDate.Location = new System.Drawing.Point(96, 108);
            this.grpByDate.Name = "grpByDate";
            this.grpByDate.Size = new System.Drawing.Size(312, 40);
            this.grpByDate.TabIndex = 7;
            this.grpByDate.TabStop = false;
            //
            //dtpDate
            //
            this.dtpDate.CustomFormat = "dd-MMM-yy";
            this.dtpDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpDate.Location = new System.Drawing.Point(8, 12);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(112, 20);
            this.dtpDate.TabIndex = 6;
            //
            //grpFromTo
            //
            this.grpFromTo.Controls.Add(this.lblFrom);
            this.grpFromTo.Controls.Add(this.dtpTo);
            this.grpFromTo.Controls.Add(this.dtpFrom);
            this.grpFromTo.Controls.Add(this.Label1);
            this.grpFromTo.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpFromTo.Location = new System.Drawing.Point(96, 28);
            this.grpFromTo.Name = "grpFromTo";
            this.grpFromTo.Size = new System.Drawing.Size(312, 40);
            this.grpFromTo.TabIndex = 1;
            this.grpFromTo.TabStop = false;
            //
            //lblFrom
            //
            this.lblFrom.Location = new System.Drawing.Point(7, 16);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(40, 16);
            this.lblFrom.TabIndex = 13;
            this.lblFrom.Text = "From";
            //
            //dtpTo
            //
            this.dtpTo.CustomFormat = "dd-MMM-yy";
            this.dtpTo.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpTo.Location = new System.Drawing.Point(191, 14);
            this.dtpTo.Name = "dtpTo";
            this.dtpTo.Size = new System.Drawing.Size(88, 20);
            this.dtpTo.TabIndex = 12;
            //
            //dtpFrom
            //
            this.dtpFrom.CustomFormat = "dd-MMM-yy";
            this.dtpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpFrom.Location = new System.Drawing.Point(47, 14);
            this.dtpFrom.Name = "dtpFrom";
            this.dtpFrom.Size = new System.Drawing.Size(105, 20);
            this.dtpFrom.TabIndex = 11;
            //
            //Label1
            //
            this.Label1.Location = new System.Drawing.Point(159, 16);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(40, 16);
            this.Label1.TabIndex = 14;
            this.Label1.Text = "To";
            //
            //rdoByDate
            //
            this.rdoByDate.Location = new System.Drawing.Point(16, 124);
            this.rdoByDate.Name = "rdoByDate";
            this.rdoByDate.Size = new System.Drawing.Size(64, 24);
            this.rdoByDate.TabIndex = 2;
            this.rdoByDate.Text = "By Date";
            //
            //rdobyMonth
            //
            this.rdobyMonth.Location = new System.Drawing.Point(16, 76);
            this.rdobyMonth.Name = "rdobyMonth";
            this.rdobyMonth.Size = new System.Drawing.Size(72, 24);
            this.rdobyMonth.TabIndex = 1;
            this.rdobyMonth.Text = "By Month";
            //
            //rdoDateRange
            //
            this.rdoDateRange.Checked = true;
            this.rdoDateRange.Location = new System.Drawing.Point(11, 36);
            this.rdoDateRange.Name = "rdoDateRange";
            this.rdoDateRange.Size = new System.Drawing.Size(96, 24);
            this.rdoDateRange.TabIndex = 0;
            this.rdoDateRange.TabStop = true;
            this.rdoDateRange.Text = "Date Range";
            //
            //grpByMonth
            //
            this.grpByMonth.Controls.Add(this.Label3);
            this.grpByMonth.Controls.Add(this.cboMonth);
            this.grpByMonth.Controls.Add(this.cboYear);
            this.grpByMonth.Controls.Add(this.Label2);
            this.grpByMonth.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.grpByMonth.Location = new System.Drawing.Point(96, 68);
            this.grpByMonth.Name = "grpByMonth";
            this.grpByMonth.Size = new System.Drawing.Size(312, 40);
            this.grpByMonth.TabIndex = 1;
            this.grpByMonth.TabStop = false;
            //
            //Label3
            //
            this.Label3.Location = new System.Drawing.Point(157, 15);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(40, 16);
            this.Label3.TabIndex = 13;
            this.Label3.Text = "Year";
            //
            //cboMonth
            //
            this.cboMonth.Items.AddRange(new object[] { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" });
            this.cboMonth.Location = new System.Drawing.Point(48, 12);
            this.cboMonth.Name = "cboMonth";
            this.cboMonth.Size = new System.Drawing.Size(104, 22);
            this.cboMonth.TabIndex = 5;
            this.cboMonth.Text = "January";
            //
            //cboYear
            //
            this.cboYear.Location = new System.Drawing.Point(197, 12);
            this.cboYear.Name = "cboYear";
            this.cboYear.Size = new System.Drawing.Size(80, 22);
            this.cboYear.TabIndex = 11;
            this.cboYear.Text = "2000";
            //
            //Label2
            //
            this.Label2.Location = new System.Drawing.Point(8, 15);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(40, 16);
            this.Label2.TabIndex = 12;
            this.Label2.Text = "Month";
            //
            //btnPostToLedger
            //
            this.btnPostToLedger.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPostToLedger.Location = new System.Drawing.Point(272, 166);
            this.btnPostToLedger.Name = "btnPostToLedger";
            this.btnPostToLedger.Size = new System.Drawing.Size(72, 29);
            this.btnPostToLedger.TabIndex = 1;
            this.btnPostToLedger.Text = "Post";
            //
            //btnClose
            //
            this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClose.Location = new System.Drawing.Point(352, 166);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(72, 29);
            this.btnClose.TabIndex = 2;
            this.btnClose.Text = "Close";
            //
            //PostToLedgerUI
            //
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(429, 199);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPostToLedger);
            this.Controls.Add(this.grpPostingOptions);
            this.Name = "PostToLedgerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post transactions to Ledger";
            this.grpPostingOptions.ResumeLayout(false);
            this.grpByDate.ResumeLayout(false);
            this.grpFromTo.ResumeLayout(false);
            this.grpByMonth.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private MySqlConnection localConnection;

        public PostToLedgerUI(MySqlConnection con)
        {
            InitializeComponent();
            initializedComboYear();
            localConnection = con;
        }
        private void cboMonth_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }
        private void initializedComboYear()
        {
            int yr;
            for (yr = 2000; yr <= DateTime.Now.Year + 50; yr++)
            {
                this.cboYear.Items.Add(yr);
            }
        }

        private void cboYear_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = true;
        }

        private void rdoDateRange_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            optionsSelectedChange();
        }
        private void optionsSelectedChange()
        {
            if (this.rdoDateRange.Checked)
            {
                this.grpFromTo.Enabled = true;
                this.grpByMonth.Enabled = false;
                this.grpByDate.Enabled = false;
            }
            else if (this.rdobyMonth.Checked)
            {
                this.grpFromTo.Enabled = false;
                this.grpByMonth.Enabled = true;
                this.grpByDate.Enabled = false;
            }
            else if (this.rdoByDate.Enabled)
            {
                this.grpFromTo.Enabled = false;
                this.grpByMonth.Enabled = false;
                this.grpByDate.Enabled = true;
            }
        }

        private void rdobyMonth_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            optionsSelectedChange();
        }

        private void rdoByDate_CheckedChanged(System.Object sender, System.EventArgs e)
        {
            optionsSelectedChange();
        }

        private void btnPostToLedger_Click(System.Object sender, System.EventArgs e)
        {
            SaveEntry();
        }

        public void SaveEntry()
        {
            string msg = "Post to ledger the tansactions ";
            if (this.rdoDateRange.Checked)
            {
                msg += "from date " + this.dtpDate.Text + " to " + this.dtpTo.Text + " ?";
            }
            else if (this.rdobyMonth.Checked)
            {
                msg += "for the month of " + this.cboMonth.Text + " year " + this.cboYear.Text + " ?";
            }
            else if (this.rdoByDate.Checked)
            {
                msg += " dated " + this.dtpDate.Text;
            }

            FolioTransactionFacade folioTransactionFacade = new FolioTransactionFacade();

            DialogResult rsp = MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question);


            //if ( rsp  == DialogResult.Yes )
            //{
            //    if (this.rdoDateRange.Checked)
            //    {
            //        folioTransactionFacade.PostToLedger(this.dtpFrom.Value, this.dtpTo.Value);
            //    }
            //    else if(this.rdobyMonth.Checked)
            //    {
            //        folioTransactionFacade.PostToLedger(this.cboMonth.SelectedIndex + 1, Int32.Parse(this.cboYear.Text));
            //    }
            //    else if(this.rdoByDate.Checked)
            //    {
            //        folioTransactionFacade.PostToLedger(this.dtpDate.Value);
            //    }

            //}
            //rsp =  Message(msg, MsgBoxStyle.Question + MsgBoxStyle.YesNo, "Post to Ledger")
            //If rsp = MsgBoxResult.Yes Then
            //    If Me.rdoDateRange.Checked Then
            //        folioTransactionFacade.PostToLedger(Me.dtpFrom.Value, Me.dtpTo.Value)
            //    ElseIf Me.rdobyMonth.Checked Then
            //        folioTransactionFacade.PostToLedger(Me.cboMonth.SelectedIndex + 1, Integer.Parse(Me.cboYear.Text))
            //    ElseIf Me.rdoByDate.Checked Then
            //        folioTransactionFacade.PostToLedger(Me.dtpDate.Value)
            //    End If
            //End If
        }
        private void btnClose_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }



    }
}