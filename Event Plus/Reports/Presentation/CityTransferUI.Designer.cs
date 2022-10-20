namespace Jinisys.Hotel.Reports.Presentation
{
    partial class CityTransferUI
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
System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CityTransferUI));
this.btnShow = new System.Windows.Forms.Button();
this.btnClose = new System.Windows.Forms.Button();
this.btnPrint = new System.Windows.Forms.Button();
this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
this.label1 = new System.Windows.Forms.Label();
this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
this.label2 = new System.Windows.Forms.Label();
this.grdTransactions = new C1.Win.C1FlexGrid.C1FlexGrid();
((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).BeginInit();
this.SuspendLayout();
// 
// btnShow
// 
this.btnShow.Location = new System.Drawing.Point(445, 42);
this.btnShow.Name = "btnShow";
this.btnShow.Size = new System.Drawing.Size(66, 33);
this.btnShow.TabIndex = 10;
this.btnShow.Text = "&Show";
this.btnShow.UseVisualStyleBackColor = true;
this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
// 
// btnClose
// 
this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
this.btnClose.Location = new System.Drawing.Point(590, 42);
this.btnClose.Name = "btnClose";
this.btnClose.Size = new System.Drawing.Size(66, 33);
this.btnClose.TabIndex = 9;
this.btnClose.Text = "Cl&ose";
this.btnClose.UseVisualStyleBackColor = true;
this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
// 
// btnPrint
// 
this.btnPrint.Location = new System.Drawing.Point(518, 42);
this.btnPrint.Name = "btnPrint";
this.btnPrint.Size = new System.Drawing.Size(66, 33);
this.btnPrint.TabIndex = 8;
this.btnPrint.Text = "&Print";
this.btnPrint.UseVisualStyleBackColor = true;
this.btnPrint.Click += new System.EventHandler(this.btnPrint_Click);
// 
// dtpStartDate
// 
this.dtpStartDate.CustomFormat = "ddd. MMM dd, yyyy";
this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpStartDate.Location = new System.Drawing.Point(28, 55);
this.dtpStartDate.Name = "dtpStartDate";
this.dtpStartDate.Size = new System.Drawing.Size(131, 20);
this.dtpStartDate.TabIndex = 7;
// 
// label1
// 
this.label1.Location = new System.Drawing.Point(25, 35);
this.label1.Name = "label1";
this.label1.Size = new System.Drawing.Size(79, 17);
this.label1.TabIndex = 6;
this.label1.Text = "Start Date :";
// 
// dtpEndDate
// 
this.dtpEndDate.CustomFormat = "ddd. MMM dd, yyyy";
this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
this.dtpEndDate.Location = new System.Drawing.Point(197, 55);
this.dtpEndDate.Name = "dtpEndDate";
this.dtpEndDate.Size = new System.Drawing.Size(131, 20);
this.dtpEndDate.TabIndex = 12;
// 
// label2
// 
this.label2.Location = new System.Drawing.Point(194, 35);
this.label2.Name = "label2";
this.label2.Size = new System.Drawing.Size(79, 17);
this.label2.TabIndex = 11;
this.label2.Text = "End Date :";
// 
// grdTransactions
// 
this.grdTransactions.AutoGenerateColumns = false;
this.grdTransactions.AutoResize = false;
this.grdTransactions.Cols.Count = 7;
this.grdTransactions.ColumnInfo = resources.GetString("grdTransactions.ColumnInfo");
this.grdTransactions.ExtendLastCol = true;
this.grdTransactions.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None;
this.grdTransactions.Location = new System.Drawing.Point(12, 110);
this.grdTransactions.Name = "grdTransactions";
this.grdTransactions.Rows.Count = 9;
this.grdTransactions.Size = new System.Drawing.Size(657, 415);
this.grdTransactions.StyleInfo = resources.GetString("grdTransactions.StyleInfo");
this.grdTransactions.TabIndex = 186;
// 
// CityTransferUI
// 
this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
this.CancelButton = this.btnClose;
this.ClientSize = new System.Drawing.Size(681, 534);
this.Controls.Add(this.grdTransactions);
this.Controls.Add(this.dtpEndDate);
this.Controls.Add(this.label2);
this.Controls.Add(this.btnShow);
this.Controls.Add(this.btnClose);
this.Controls.Add(this.btnPrint);
this.Controls.Add(this.dtpStartDate);
this.Controls.Add(this.label1);
this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
this.Name = "CityTransferUI";
this.Text = "City Transfer Transactions";
((System.ComponentModel.ISupportInitialize)(this.grdTransactions)).EndInit();
this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label2;
        internal C1.Win.C1FlexGrid.C1FlexGrid grdTransactions;
    }
}