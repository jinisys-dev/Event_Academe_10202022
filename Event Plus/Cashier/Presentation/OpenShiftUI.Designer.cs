namespace Jinisys.Hotel.Cashier.Presentation
{
    partial class OpenShiftUI
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
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OpenShiftUI));
			this.label1 = new System.Windows.Forms.Label();
			this.lblTransactionDate = new System.Windows.Forms.Label();
			this.label4 = new System.Windows.Forms.Label();
			this.label6 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.label10 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.panel1 = new System.Windows.Forms.Panel();
			this.txtOpeningBalance = new System.Windows.Forms.TextBox();
			this.txtBeginningBalance = new System.Windows.Forms.TextBox();
			this.txtOpeningAdjustment = new System.Windows.Forms.TextBox();
			this.btnOk = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblLoggedUser = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.lblDrawerNo = new System.Windows.Forms.Label();
			this.lblShiftCode = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(47, 89);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(90, 14);
			this.label1.TabIndex = 0;
			this.label1.Text = "Cash Terminal # :";
			// 
			// lblTransactionDate
			// 
			this.lblTransactionDate.AutoSize = true;
			this.lblTransactionDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblTransactionDate.Location = new System.Drawing.Point(181, 62);
			this.lblTransactionDate.Name = "lblTransactionDate";
			this.lblTransactionDate.Size = new System.Drawing.Size(70, 14);
			this.lblTransactionDate.TabIndex = 3;
			this.lblTransactionDate.Text = "12-Jan-2006";
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(47, 62);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(95, 14);
			this.label4.TabIndex = 2;
			this.label4.Text = "Transaction Date :";
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(47, 117);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(63, 14);
			this.label6.TabIndex = 4;
			this.label6.Text = "Shift Code :";
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(26, 77);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(102, 14);
			this.label8.TabIndex = 11;
			this.label8.Text = "Beginning Balance :";
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(26, 50);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(110, 14);
			this.label10.TabIndex = 9;
			this.label10.Text = "Opening Adjustment :";
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(26, 22);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(95, 14);
			this.label12.TabIndex = 7;
			this.label12.Text = "Opening Balance :";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.Add(this.txtOpeningBalance);
			this.panel1.Controls.Add(this.txtBeginningBalance);
			this.panel1.Controls.Add(this.txtOpeningAdjustment);
			this.panel1.Controls.Add(this.label12);
			this.panel1.Controls.Add(this.label8);
			this.panel1.Controls.Add(this.label10);
			this.panel1.Location = new System.Drawing.Point(29, 166);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(363, 115);
			this.panel1.TabIndex = 13;
			// 
			// txtOpeningBalance
			// 
			this.txtOpeningBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtOpeningBalance.Location = new System.Drawing.Point(232, 19);
			this.txtOpeningBalance.Name = "txtOpeningBalance";
			this.txtOpeningBalance.ReadOnly = true;
			this.txtOpeningBalance.Size = new System.Drawing.Size(100, 20);
			this.txtOpeningBalance.TabIndex = 15;
			this.txtOpeningBalance.Text = "0.00";
			this.txtOpeningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtBeginningBalance
			// 
			this.txtBeginningBalance.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtBeginningBalance.Location = new System.Drawing.Point(232, 74);
			this.txtBeginningBalance.Name = "txtBeginningBalance";
			this.txtBeginningBalance.ReadOnly = true;
			this.txtBeginningBalance.Size = new System.Drawing.Size(100, 20);
			this.txtBeginningBalance.TabIndex = 14;
			this.txtBeginningBalance.Text = "0.00";
			this.txtBeginningBalance.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// txtOpeningAdjustment
			// 
			this.txtOpeningAdjustment.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.txtOpeningAdjustment.Location = new System.Drawing.Point(232, 47);
			this.txtOpeningAdjustment.Name = "txtOpeningAdjustment";
			this.txtOpeningAdjustment.Size = new System.Drawing.Size(100, 20);
			this.txtOpeningAdjustment.TabIndex = 13;
			this.txtOpeningAdjustment.Text = "0.00";
			this.txtOpeningAdjustment.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.txtOpeningAdjustment.TextChanged += new System.EventHandler(this.txtOpeningAdjustment_TextChanged);
			// 
			// btnOk
			// 
			this.btnOk.Location = new System.Drawing.Point(249, 309);
			this.btnOk.Name = "btnOk";
			this.btnOk.Size = new System.Drawing.Size(66, 31);
			this.btnOk.TabIndex = 15;
			this.btnOk.Text = "&Ok";
			this.btnOk.UseVisualStyleBackColor = true;
			this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(328, 309);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(66, 31);
			this.btnCancel.TabIndex = 16;
			this.btnCancel.Text = "Cl&ose";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblLoggedUser
			// 
			this.lblLoggedUser.AutoSize = true;
			this.lblLoggedUser.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblLoggedUser.Location = new System.Drawing.Point(181, 35);
			this.lblLoggedUser.Name = "lblLoggedUser";
			this.lblLoggedUser.Size = new System.Drawing.Size(43, 14);
			this.lblLoggedUser.TabIndex = 18;
			this.lblLoggedUser.Text = "Admin";
			// 
			// label7
			// 
			this.label7.AutoSize = true;
			this.label7.Location = new System.Drawing.Point(47, 35);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(50, 14);
			this.label7.TabIndex = 17;
			this.label7.Text = "Cashier :";
			// 
			// lblDrawerNo
			// 
			this.lblDrawerNo.AutoSize = true;
			this.lblDrawerNo.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblDrawerNo.Location = new System.Drawing.Point(181, 89);
			this.lblDrawerNo.Name = "lblDrawerNo";
			this.lblDrawerNo.Size = new System.Drawing.Size(13, 14);
			this.lblDrawerNo.TabIndex = 19;
			this.lblDrawerNo.Text = "0";
			// 
			// lblShiftCode
			// 
			this.lblShiftCode.AutoSize = true;
			this.lblShiftCode.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold);
			this.lblShiftCode.ForeColor = System.Drawing.Color.Red;
			this.lblShiftCode.Location = new System.Drawing.Point(181, 117);
			this.lblShiftCode.Name = "lblShiftCode";
			this.lblShiftCode.Size = new System.Drawing.Size(13, 14);
			this.lblShiftCode.TabIndex = 20;
			this.lblShiftCode.Text = "0";
			// 
			// OpenShiftUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(420, 361);
			this.Controls.Add(this.lblShiftCode);
			this.Controls.Add(this.lblDrawerNo);
			this.Controls.Add(this.lblLoggedUser);
			this.Controls.Add(this.label7);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.btnOk);
			this.Controls.Add(this.panel1);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.lblTransactionDate);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label1);
			this.Font = new System.Drawing.Font("Arial", 8.25F);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "OpenShiftUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Open Shift";
			this.Load += new System.EventHandler(this.OpenShiftUI_Load);
			this.panel1.ResumeLayout(false);
			this.panel1.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblTransactionDate;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtOpeningBalance;
        private System.Windows.Forms.TextBox txtBeginningBalance;
		private System.Windows.Forms.TextBox txtOpeningAdjustment;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label lblLoggedUser;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label lblDrawerNo;
		private System.Windows.Forms.Label lblShiftCode;
    }
}