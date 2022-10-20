namespace Jinisys.Hotel.AccountingInterface.Presentation
{
	partial class IntegrationSetupUI_ExactGlobe
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
			this.btnCostCenters = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.btnGLAccounts = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.btnJournalEntryCodes = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.btnTranCodeGLAccount = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnCostCenters
			// 
			this.btnCostCenters.Location = new System.Drawing.Point(328, 33);
			this.btnCostCenters.Name = "btnCostCenters";
			this.btnCostCenters.Size = new System.Drawing.Size(66, 31);
			this.btnCostCenters.TabIndex = 0;
			this.btnCostCenters.Text = "Setup";
			this.btnCostCenters.UseVisualStyleBackColor = true;
			this.btnCostCenters.Click += new System.EventHandler(this.btnCostCenters_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(21, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(295, 18);
			this.label1.TabIndex = 1;
			this.label1.Text = "Cost Centers . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . . " +
				".";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(21, 149);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(295, 18);
			this.label2.TabIndex = 3;
			this.label2.Text = "G/L Chart of Accounts . . . . . . . . . . . . . . . . . . . . . . . . . . .";
			// 
			// btnGLAccounts
			// 
			this.btnGLAccounts.Location = new System.Drawing.Point(328, 142);
			this.btnGLAccounts.Name = "btnGLAccounts";
			this.btnGLAccounts.Size = new System.Drawing.Size(66, 31);
			this.btnGLAccounts.TabIndex = 2;
			this.btnGLAccounts.Text = "Setup";
			this.btnGLAccounts.UseVisualStyleBackColor = true;
			this.btnGLAccounts.Click += new System.EventHandler(this.btnGLAccounts_Click);
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(21, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(295, 18);
			this.label3.TabIndex = 5;
			this.label3.Text = "Journal Entry Codes . . . . . . . . . . . . . . . . . . . . . . . . . . . . .";
			// 
			// btnJournalEntryCodes
			// 
			this.btnJournalEntryCodes.Location = new System.Drawing.Point(328, 89);
			this.btnJournalEntryCodes.Name = "btnJournalEntryCodes";
			this.btnJournalEntryCodes.Size = new System.Drawing.Size(66, 31);
			this.btnJournalEntryCodes.TabIndex = 4;
			this.btnJournalEntryCodes.Text = "Setup";
			this.btnJournalEntryCodes.UseVisualStyleBackColor = true;
			this.btnJournalEntryCodes.Click += new System.EventHandler(this.btnJournalEntryCodes_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(21, 205);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(295, 18);
			this.label4.TabIndex = 7;
			this.label4.Text = "Folio Plus™ Transaction Codes vs G/L Account Codes . .";
			// 
			// btnTranCodeGLAccount
			// 
			this.btnTranCodeGLAccount.Location = new System.Drawing.Point(328, 198);
			this.btnTranCodeGLAccount.Name = "btnTranCodeGLAccount";
			this.btnTranCodeGLAccount.Size = new System.Drawing.Size(66, 31);
			this.btnTranCodeGLAccount.TabIndex = 6;
			this.btnTranCodeGLAccount.Text = "Setup";
			this.btnTranCodeGLAccount.UseVisualStyleBackColor = true;
			this.btnTranCodeGLAccount.Click += new System.EventHandler(this.btnTranCodeGLAccount_Click);
			// 
			// IntegrationSetupUI_ExactGlobe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(415, 271);
			this.Controls.Add(this.btnTranCodeGLAccount);
			this.Controls.Add(this.btnJournalEntryCodes);
			this.Controls.Add(this.btnGLAccounts);
			this.Controls.Add(this.btnCostCenters);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "IntegrationSetupUI_ExactGlobe";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Exact Globe - Integration Setup";
			this.Load += new System.EventHandler(this.IntegrationSetupUI_ExactGlobe_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.Button btnCostCenters;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnGLAccounts;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnJournalEntryCodes;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button btnTranCodeGLAccount;
	}
}