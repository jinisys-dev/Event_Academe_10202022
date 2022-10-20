namespace Jinisys.Hotel.Reservation.Presentation
{
    partial class ContractUI
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
            this.btnViewContract = new System.Windows.Forms.Button();
            this.btnUploadContract = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ContractUploadFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnViewContract
            // 
            this.btnViewContract.Location = new System.Drawing.Point(174, 19);
            this.btnViewContract.Name = "btnViewContract";
            this.btnViewContract.Size = new System.Drawing.Size(89, 37);
            this.btnViewContract.TabIndex = 6;
            this.btnViewContract.Text = "View Contract";
            this.btnViewContract.UseVisualStyleBackColor = true;
            this.btnViewContract.Click += new System.EventHandler(this.btnViewLOP_Click);
            // 
            // btnUploadContract
            // 
            this.btnUploadContract.Location = new System.Drawing.Point(43, 19);
            this.btnUploadContract.Name = "btnUploadContract";
            this.btnUploadContract.Size = new System.Drawing.Size(107, 37);
            this.btnUploadContract.TabIndex = 5;
            this.btnUploadContract.Text = "Upload Contract";
            this.btnUploadContract.UseVisualStyleBackColor = true;
            this.btnUploadContract.Click += new System.EventHandler(this.btnUploadLOP_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewContract);
            this.groupBox1.Controls.Add(this.btnUploadContract);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(312, 70);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // ContractUploadFileDialog
            // 
            this.ContractUploadFileDialog.FileName = "openFileDialog1";
            // 
            // ContractUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 70);
            this.Controls.Add(this.groupBox1);
            this.Name = "ContractUI";
            this.Text = "Contract";
            this.Load += new System.EventHandler(this.ContractUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnViewContract;
        private System.Windows.Forms.Button btnUploadContract;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.OpenFileDialog ContractUploadFileDialog;
    }
}