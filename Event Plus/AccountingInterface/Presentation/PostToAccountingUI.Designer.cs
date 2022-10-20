namespace Jinisys.Hotel.AccountingInterface.Presentation
{
    partial class PostToAccountingUI
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
            this.btnPost = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtBackOfficeName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtConnectionStr = new System.Windows.Forms.TextBox();
            this.lblConnectionLabel = new System.Windows.Forms.Label();
            this.txtSchedule = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.sfdExport = new System.Windows.Forms.SaveFileDialog();
            this.label2 = new System.Windows.Forms.Label();
            this.btnExportDebtors = new System.Windows.Forms.Button();
            this.dtpDateToBePosted = new System.Windows.Forms.DateTimePicker();
            this.chkIncludePostedTrans = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnPost
            // 
            this.btnPost.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPost.Location = new System.Drawing.Point(370, 310);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(116, 35);
            this.btnPost.TabIndex = 0;
            this.btnPost.Text = "Export Transactions";
            this.btnPost.UseVisualStyleBackColor = true;
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(268, 52);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(149, 20);
            this.txtVersion.TabIndex = 31;
            this.txtVersion.Text = "11i";
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(268, 30);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(171, 22);
            this.label5.TabIndex = 30;
            this.label5.Text = "Version";
            // 
            // txtBackOfficeName
            // 
            this.txtBackOfficeName.Location = new System.Drawing.Point(25, 52);
            this.txtBackOfficeName.Name = "txtBackOfficeName";
            this.txtBackOfficeName.ReadOnly = true;
            this.txtBackOfficeName.Size = new System.Drawing.Size(237, 20);
            this.txtBackOfficeName.TabIndex = 29;
            this.txtBackOfficeName.Text = "Navision";
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(25, 30);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(237, 22);
            this.label4.TabIndex = 28;
            this.label4.Text = "Back Office Name";
            // 
            // txtConnectionStr
            // 
            this.txtConnectionStr.Location = new System.Drawing.Point(25, 120);
            this.txtConnectionStr.Name = "txtConnectionStr";
            this.txtConnectionStr.ReadOnly = true;
            this.txtConnectionStr.Size = new System.Drawing.Size(461, 20);
            this.txtConnectionStr.TabIndex = 26;
            this.txtConnectionStr.Text = "DSN = ";
            // 
            // lblConnectionLabel
            // 
            this.lblConnectionLabel.Location = new System.Drawing.Point(25, 95);
            this.lblConnectionLabel.Name = "lblConnectionLabel";
            this.lblConnectionLabel.Size = new System.Drawing.Size(379, 22);
            this.lblConnectionLabel.TabIndex = 25;
            this.lblConnectionLabel.Text = "Connection String";
            // 
            // txtSchedule
            // 
            this.txtSchedule.Location = new System.Drawing.Point(25, 188);
            this.txtSchedule.Name = "txtSchedule";
            this.txtSchedule.ReadOnly = true;
            this.txtSchedule.Size = new System.Drawing.Size(461, 20);
            this.txtSchedule.TabIndex = 33;
            this.txtSchedule.Text = "Daily";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(25, 164);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(379, 22);
            this.label1.TabIndex = 32;
            this.label1.Text = "Scheduled Posting";
            // 
            // sfdExport
            // 
            this.sfdExport.DefaultExt = "*.xls";
            this.sfdExport.FileName = "Revenue Report";
            this.sfdExport.Title = "Select location";
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(25, 230);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 22);
            this.label2.TabIndex = 35;
            this.label2.Text = "Date to be posted";
            // 
            // btnExportDebtors
            // 
            this.btnExportDebtors.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportDebtors.Location = new System.Drawing.Point(248, 310);
            this.btnExportDebtors.Name = "btnExportDebtors";
            this.btnExportDebtors.Size = new System.Drawing.Size(116, 35);
            this.btnExportDebtors.TabIndex = 36;
            this.btnExportDebtors.Text = "Export Debtors";
            this.btnExportDebtors.UseVisualStyleBackColor = true;
            this.btnExportDebtors.Click += new System.EventHandler(this.btnExportDebtors_Click);
            // 
            // dtpDateToBePosted
            // 
            this.dtpDateToBePosted.Location = new System.Drawing.Point(25, 255);
            this.dtpDateToBePosted.Name = "dtpDateToBePosted";
            this.dtpDateToBePosted.Size = new System.Drawing.Size(200, 20);
            this.dtpDateToBePosted.TabIndex = 37;
            // 
            // chkIncludePostedTrans
            // 
            this.chkIncludePostedTrans.AutoSize = true;
            this.chkIncludePostedTrans.Location = new System.Drawing.Point(26, 280);
            this.chkIncludePostedTrans.Name = "chkIncludePostedTrans";
            this.chkIncludePostedTrans.Size = new System.Drawing.Size(167, 18);
            this.chkIncludePostedTrans.TabIndex = 39;
            this.chkIncludePostedTrans.Text = "Include \"Posted\" transactions";
            this.chkIncludePostedTrans.UseVisualStyleBackColor = true;
            // 
            // PostToAccountingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(511, 366);
            this.Controls.Add(this.chkIncludePostedTrans);
            this.Controls.Add(this.dtpDateToBePosted);
            this.Controls.Add(this.btnExportDebtors);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSchedule);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtBackOfficeName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtConnectionStr);
            this.Controls.Add(this.lblConnectionLabel);
            this.Controls.Add(this.btnPost);
            this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostToAccountingUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Post To Accounting";
            this.Load += new System.EventHandler(this.PostToAccountingUI_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnPost;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtBackOfficeName;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtConnectionStr;
		private System.Windows.Forms.Label lblConnectionLabel;
		private System.Windows.Forms.TextBox txtSchedule;
		private System.Windows.Forms.Label label1;
        private System.Windows.Forms.SaveFileDialog sfdExport;
		private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnExportDebtors;
        private System.Windows.Forms.DateTimePicker dtpDateToBePosted;
        private System.Windows.Forms.CheckBox chkIncludePostedTrans;
    }
}