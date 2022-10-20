namespace Integrations.Presentation
{
    partial class SyncSAP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SyncSAP));
            this.btnGetPayments = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.txtFolioID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnGLAccounts = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnGetPayments
            // 
            this.btnGetPayments.Location = new System.Drawing.Point(12, 147);
            this.btnGetPayments.Name = "btnGetPayments";
            this.btnGetPayments.Size = new System.Drawing.Size(349, 52);
            this.btnGetPayments.TabIndex = 0;
            this.btnGetPayments.Text = "GET PAYMENTS";
            this.btnGetPayments.UseVisualStyleBackColor = true;
            this.btnGetPayments.Click += new System.EventHandler(this.btnGetPayments_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(349, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // txtFolioID
            // 
            this.txtFolioID.Location = new System.Drawing.Point(74, 121);
            this.txtFolioID.Name = "txtFolioID";
            this.txtFolioID.Size = new System.Drawing.Size(156, 20);
            this.txtFolioID.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 124);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Event ID: ";
            // 
            // btnGLAccounts
            // 
            this.btnGLAccounts.Location = new System.Drawing.Point(12, 205);
            this.btnGLAccounts.Name = "btnGLAccounts";
            this.btnGLAccounts.Size = new System.Drawing.Size(349, 52);
            this.btnGLAccounts.TabIndex = 0;
            this.btnGLAccounts.Text = "G/L ACCOUNTS";
            this.btnGLAccounts.UseVisualStyleBackColor = true;
            this.btnGLAccounts.Click += new System.EventHandler(this.btnGLAccounts_Click);
            // 
            // SyncSAP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(373, 327);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtFolioID);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.btnGLAccounts);
            this.Controls.Add(this.btnGetPayments);
            this.MaximumSize = new System.Drawing.Size(389, 365);
            this.MinimumSize = new System.Drawing.Size(389, 365);
            this.Name = "SyncSAP";
            this.Text = "SyncSAP";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnGetPayments;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.TextBox txtFolioID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnGLAccounts;
    }
}