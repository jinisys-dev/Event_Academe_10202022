namespace Jinisys.Hotel.Cashier.Presentation
{
    partial class CityLedgerUI
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lvwCityLedgerSummary = new System.Windows.Forms.ListView();
            this.ColumnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.ColumnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.btnViewDetails = new System.Windows.Forms.Button();
            this.btnPayment = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblTotalDebits = new System.Windows.Forms.Label();
            this.lblTotalCredits = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // lvwCityLedgerSummary
            // 
            this.lvwCityLedgerSummary.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColumnHeader1,
            this.ColumnHeader2,
            this.ColumnHeader3,
            this.ColumnHeader4,
            this.columnHeader5});
            this.lvwCityLedgerSummary.FullRowSelect = true;
            this.lvwCityLedgerSummary.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lvwCityLedgerSummary.Location = new System.Drawing.Point(9, 17);
            this.lvwCityLedgerSummary.Name = "lvwCityLedgerSummary";
            this.lvwCityLedgerSummary.Size = new System.Drawing.Size(525, 304);
            this.lvwCityLedgerSummary.TabIndex = 3;
            this.lvwCityLedgerSummary.UseCompatibleStateImageBehavior = false;
            this.lvwCityLedgerSummary.View = System.Windows.Forms.View.Details;
            // 
            // ColumnHeader1
            // 
            this.ColumnHeader1.Text = "CompanyID";
            this.ColumnHeader1.Width = 82;
            // 
            // ColumnHeader2
            // 
            this.ColumnHeader2.Text = "Name";
            this.ColumnHeader2.Width = 182;
            // 
            // ColumnHeader3
            // 
            this.ColumnHeader3.Text = "Debit";
            this.ColumnHeader3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader3.Width = 86;
            // 
            // ColumnHeader4
            // 
            this.ColumnHeader4.Text = "Credit";
            this.ColumnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColumnHeader4.Width = 82;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "Balance";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 72;
            // 
            // btnViewDetails
            // 
            this.btnViewDetails.Location = new System.Drawing.Point(12, 373);
            this.btnViewDetails.Name = "btnViewDetails";
            this.btnViewDetails.Size = new System.Drawing.Size(107, 31);
            this.btnViewDetails.TabIndex = 4;
            this.btnViewDetails.Text = "&View Details";
            this.btnViewDetails.UseVisualStyleBackColor = true;
            this.btnViewDetails.Click += new System.EventHandler(this.btnViewDetails_Click);
            // 
            // btnPayment
            // 
            this.btnPayment.Location = new System.Drawing.Point(131, 373);
            this.btnPayment.Name = "btnPayment";
            this.btnPayment.Size = new System.Drawing.Size(74, 31);
            this.btnPayment.TabIndex = 5;
            this.btnPayment.Text = "&Payment";
            this.btnPayment.UseVisualStyleBackColor = true;
            this.btnPayment.Click += new System.EventHandler(this.btnPayment_Click);
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(216, 373);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(74, 31);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 331);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 14);
            this.label1.TabIndex = 7;
            this.label1.Text = "Totals :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTotalDebits
            // 
            this.lblTotalDebits.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalDebits.ForeColor = System.Drawing.Color.Red;
            this.lblTotalDebits.Location = new System.Drawing.Point(278, 331);
            this.lblTotalDebits.Name = "lblTotalDebits";
            this.lblTotalDebits.Size = new System.Drawing.Size(81, 14);
            this.lblTotalDebits.TabIndex = 8;
            this.lblTotalDebits.Text = "0.00";
            this.lblTotalDebits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTotalCredits
            // 
            this.lblTotalCredits.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalCredits.ForeColor = System.Drawing.Color.Red;
            this.lblTotalCredits.Location = new System.Drawing.Point(369, 331);
            this.lblTotalCredits.Name = "lblTotalCredits";
            this.lblTotalCredits.Size = new System.Drawing.Size(66, 14);
            this.lblTotalCredits.TabIndex = 9;
            this.lblTotalCredits.Text = "0.00";
            this.lblTotalCredits.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CityLedgerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(543, 418);
            this.Controls.Add(this.lblTotalCredits);
            this.Controls.Add(this.lblTotalDebits);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnPayment);
            this.Controls.Add(this.btnViewDetails);
            this.Controls.Add(this.lvwCityLedgerSummary);
            this.Font = new System.Drawing.Font("Arial", 8.25F);
            this.Name = "CityLedgerUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "City Ledger";
            this.Load += new System.EventHandler(this.CityLedgerUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lvwCityLedgerSummary;
        internal System.Windows.Forms.ColumnHeader ColumnHeader1;
        internal System.Windows.Forms.ColumnHeader ColumnHeader2;
        internal System.Windows.Forms.ColumnHeader ColumnHeader3;
        internal System.Windows.Forms.ColumnHeader ColumnHeader4;
        private System.Windows.Forms.Button btnViewDetails;
        private System.Windows.Forms.Button btnPayment;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTotalDebits;
        private System.Windows.Forms.Label lblTotalCredits;
        private System.Windows.Forms.ColumnHeader columnHeader5;
    }
}