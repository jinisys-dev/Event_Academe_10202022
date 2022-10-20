namespace Jinisys.Hotel.Reservation.Presentation
{
	partial class EndorsementUI
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
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClose = new System.Windows.Forms.Button();
			this.txtAuditDate = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtShiftCode = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTerminalNo = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtLoggedUser = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.txtEndorsementDescription = new System.Windows.Forms.TextBox();
			this.label5 = new System.Windows.Forms.Label();
			this.txtStatus = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.pnlAcknowledgement = new System.Windows.Forms.Panel();
			this.txtUpdateTime = new System.Windows.Forms.TextBox();
			this.label12 = new System.Windows.Forms.Label();
			this.txtEndorsementRemarks = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.txtAcknowledgeBy = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.txtAcknowledgeAtTerminalNo = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtAcknowledgeAtShiftCode = new System.Windows.Forms.TextBox();
			this.label11 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.txtEndorsementId = new System.Windows.Forms.TextBox();
			this.pnlAcknowledgement.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Location = new System.Drawing.Point(342, 343);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(66, 33);
			this.btnSave.TabIndex = 12;
			this.btnSave.Text = "&Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClose
			// 
			this.btnClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnClose.Location = new System.Drawing.Point(415, 343);
			this.btnClose.Name = "btnClose";
			this.btnClose.Size = new System.Drawing.Size(66, 33);
			this.btnClose.TabIndex = 13;
			this.btnClose.Text = "&Close";
			this.btnClose.UseVisualStyleBackColor = true;
			this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
			// 
			// txtAuditDate
			// 
			this.txtAuditDate.BackColor = System.Drawing.SystemColors.Control;
			this.txtAuditDate.Location = new System.Drawing.Point(105, 33);
			this.txtAuditDate.Name = "txtAuditDate";
			this.txtAuditDate.ReadOnly = true;
			this.txtAuditDate.Size = new System.Drawing.Size(176, 20);
			this.txtAuditDate.TabIndex = 0;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(26, 36);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(60, 14);
			this.label2.TabIndex = 4;
			this.label2.Text = "Date/Time :";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtShiftCode
			// 
			this.txtShiftCode.BackColor = System.Drawing.SystemColors.Control;
			this.txtShiftCode.Location = new System.Drawing.Point(105, 68);
			this.txtShiftCode.Name = "txtShiftCode";
			this.txtShiftCode.ReadOnly = true;
			this.txtShiftCode.Size = new System.Drawing.Size(41, 20);
			this.txtShiftCode.TabIndex = 2;
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(26, 71);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(63, 14);
			this.label1.TabIndex = 6;
			this.label1.Text = "Shift Code :";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtTerminalNo
			// 
			this.txtTerminalNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtTerminalNo.Location = new System.Drawing.Point(105, 103);
			this.txtTerminalNo.Name = "txtTerminalNo";
			this.txtTerminalNo.ReadOnly = true;
			this.txtTerminalNo.Size = new System.Drawing.Size(41, 20);
			this.txtTerminalNo.TabIndex = 3;
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(26, 106);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(66, 14);
			this.label3.TabIndex = 8;
			this.label3.Text = "Terminal No.";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtLoggedUser
			// 
			this.txtLoggedUser.BackColor = System.Drawing.SystemColors.Control;
			this.txtLoggedUser.Location = new System.Drawing.Point(105, 138);
			this.txtLoggedUser.Name = "txtLoggedUser";
			this.txtLoggedUser.ReadOnly = true;
			this.txtLoggedUser.Size = new System.Drawing.Size(89, 20);
			this.txtLoggedUser.TabIndex = 4;
			// 
			// label4
			// 
			this.label4.AutoSize = true;
			this.label4.Location = new System.Drawing.Point(26, 141);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(75, 14);
			this.label4.TabIndex = 10;
			this.label4.Text = "Logged User :";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEndorsementDescription
			// 
			this.txtEndorsementDescription.Location = new System.Drawing.Point(105, 173);
			this.txtEndorsementDescription.Multiline = true;
			this.txtEndorsementDescription.Name = "txtEndorsementDescription";
			this.txtEndorsementDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEndorsementDescription.Size = new System.Drawing.Size(376, 94);
			this.txtEndorsementDescription.TabIndex = 5;
			// 
			// label5
			// 
			this.label5.AutoSize = true;
			this.label5.Location = new System.Drawing.Point(26, 176);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(70, 14);
			this.label5.TabIndex = 12;
			this.label5.Text = "Endorsement";
			this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtStatus
			// 
			this.txtStatus.BackColor = System.Drawing.SystemColors.Control;
			this.txtStatus.Location = new System.Drawing.Point(350, 33);
			this.txtStatus.Name = "txtStatus";
			this.txtStatus.ReadOnly = true;
			this.txtStatus.Size = new System.Drawing.Size(131, 20);
			this.txtStatus.TabIndex = 1;
			this.txtStatus.TextChanged += new System.EventHandler(this.txtStatus_TextChanged);
			// 
			// label6
			// 
			this.label6.AutoSize = true;
			this.label6.Location = new System.Drawing.Point(299, 36);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(44, 14);
			this.label6.TabIndex = 14;
			this.label6.Text = "Status :";
			this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// pnlAcknowledgement
			// 
			this.pnlAcknowledgement.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.pnlAcknowledgement.Controls.Add(this.txtUpdateTime);
			this.pnlAcknowledgement.Controls.Add(this.label12);
			this.pnlAcknowledgement.Controls.Add(this.txtEndorsementRemarks);
			this.pnlAcknowledgement.Controls.Add(this.label8);
			this.pnlAcknowledgement.Controls.Add(this.txtAcknowledgeBy);
			this.pnlAcknowledgement.Controls.Add(this.label9);
			this.pnlAcknowledgement.Controls.Add(this.txtAcknowledgeAtTerminalNo);
			this.pnlAcknowledgement.Controls.Add(this.label10);
			this.pnlAcknowledgement.Controls.Add(this.txtAcknowledgeAtShiftCode);
			this.pnlAcknowledgement.Controls.Add(this.label11);
			this.pnlAcknowledgement.Controls.Add(this.label7);
			this.pnlAcknowledgement.Location = new System.Drawing.Point(20, 292);
			this.pnlAcknowledgement.Name = "pnlAcknowledgement";
			this.pnlAcknowledgement.Size = new System.Drawing.Size(478, 24);
			this.pnlAcknowledgement.TabIndex = 6;
			// 
			// txtUpdateTime
			// 
			this.txtUpdateTime.BackColor = System.Drawing.SystemColors.Control;
			this.txtUpdateTime.Location = new System.Drawing.Point(303, 72);
			this.txtUpdateTime.Name = "txtUpdateTime";
			this.txtUpdateTime.ReadOnly = true;
			this.txtUpdateTime.Size = new System.Drawing.Size(148, 20);
			this.txtUpdateTime.TabIndex = 10;
			// 
			// label12
			// 
			this.label12.AutoSize = true;
			this.label12.Location = new System.Drawing.Point(208, 75);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(60, 14);
			this.label12.TabIndex = 22;
			this.label12.Text = "Date/Time :";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtEndorsementRemarks
			// 
			this.txtEndorsementRemarks.Location = new System.Drawing.Point(97, 110);
			this.txtEndorsementRemarks.Multiline = true;
			this.txtEndorsementRemarks.Name = "txtEndorsementRemarks";
			this.txtEndorsementRemarks.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtEndorsementRemarks.Size = new System.Drawing.Size(354, 75);
			this.txtEndorsementRemarks.TabIndex = 11;
			// 
			// label8
			// 
			this.label8.AutoSize = true;
			this.label8.Location = new System.Drawing.Point(18, 113);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(49, 14);
			this.label8.TabIndex = 20;
			this.label8.Text = "Remarks";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAcknowledgeBy
			// 
			this.txtAcknowledgeBy.BackColor = System.Drawing.SystemColors.Control;
			this.txtAcknowledgeBy.Location = new System.Drawing.Point(303, 46);
			this.txtAcknowledgeBy.Name = "txtAcknowledgeBy";
			this.txtAcknowledgeBy.ReadOnly = true;
			this.txtAcknowledgeBy.Size = new System.Drawing.Size(148, 20);
			this.txtAcknowledgeBy.TabIndex = 8;
			// 
			// label9
			// 
			this.label9.AutoSize = true;
			this.label9.Location = new System.Drawing.Point(208, 49);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(96, 14);
			this.label9.TabIndex = 18;
			this.label9.Text = "Acknowledge By :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAcknowledgeAtTerminalNo
			// 
			this.txtAcknowledgeAtTerminalNo.BackColor = System.Drawing.SystemColors.Control;
			this.txtAcknowledgeAtTerminalNo.Location = new System.Drawing.Point(97, 75);
			this.txtAcknowledgeAtTerminalNo.Name = "txtAcknowledgeAtTerminalNo";
			this.txtAcknowledgeAtTerminalNo.ReadOnly = true;
			this.txtAcknowledgeAtTerminalNo.Size = new System.Drawing.Size(41, 20);
			this.txtAcknowledgeAtTerminalNo.TabIndex = 9;
			// 
			// label10
			// 
			this.label10.AutoSize = true;
			this.label10.Location = new System.Drawing.Point(18, 78);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(66, 14);
			this.label10.TabIndex = 16;
			this.label10.Text = "Terminal No.";
			this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// txtAcknowledgeAtShiftCode
			// 
			this.txtAcknowledgeAtShiftCode.BackColor = System.Drawing.SystemColors.Control;
			this.txtAcknowledgeAtShiftCode.Location = new System.Drawing.Point(97, 46);
			this.txtAcknowledgeAtShiftCode.Name = "txtAcknowledgeAtShiftCode";
			this.txtAcknowledgeAtShiftCode.ReadOnly = true;
			this.txtAcknowledgeAtShiftCode.Size = new System.Drawing.Size(41, 20);
			this.txtAcknowledgeAtShiftCode.TabIndex = 7;
			// 
			// label11
			// 
			this.label11.AutoSize = true;
			this.label11.Location = new System.Drawing.Point(18, 49);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(63, 14);
			this.label11.TabIndex = 14;
			this.label11.Text = "Shift Code :";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label7
			// 
			this.label7.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(224)))), ((int)(((byte)(192)))));
			this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
			this.label7.Dock = System.Windows.Forms.DockStyle.Top;
			this.label7.Location = new System.Drawing.Point(0, 0);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(476, 22);
			this.label7.TabIndex = 13;
			this.label7.Text = "A C K N O W L E D G E M E N T ";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// txtEndorsementId
			// 
			this.txtEndorsementId.Location = new System.Drawing.Point(106, 6);
			this.txtEndorsementId.Name = "txtEndorsementId";
			this.txtEndorsementId.Size = new System.Drawing.Size(40, 20);
			this.txtEndorsementId.TabIndex = 14;
			this.txtEndorsementId.Visible = false;
			// 
			// EndorsementUI
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnClose;
			this.ClientSize = new System.Drawing.Size(524, 396);
			this.Controls.Add(this.txtEndorsementId);
			this.Controls.Add(this.btnClose);
			this.Controls.Add(this.btnSave);
			this.Controls.Add(this.pnlAcknowledgement);
			this.Controls.Add(this.txtStatus);
			this.Controls.Add(this.label6);
			this.Controls.Add(this.txtEndorsementDescription);
			this.Controls.Add(this.label5);
			this.Controls.Add(this.txtLoggedUser);
			this.Controls.Add(this.label4);
			this.Controls.Add(this.txtTerminalNo);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.txtShiftCode);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.txtAuditDate);
			this.Controls.Add(this.label2);
			this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "EndorsementUI";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Endorsement";
			this.Activated += new System.EventHandler(this.EndorsementUI_Activated);
			this.pnlAcknowledgement.ResumeLayout(false);
			this.pnlAcknowledgement.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClose;
		private System.Windows.Forms.TextBox txtAuditDate;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtShiftCode;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTerminalNo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtLoggedUser;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.TextBox txtEndorsementDescription;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox txtStatus;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Panel pnlAcknowledgement;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox txtEndorsementRemarks;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.TextBox txtAcknowledgeBy;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtAcknowledgeAtTerminalNo;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox txtAcknowledgeAtShiftCode;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox txtEndorsementId;
		private System.Windows.Forms.TextBox txtUpdateTime;
		private System.Windows.Forms.Label label12;
	}
}