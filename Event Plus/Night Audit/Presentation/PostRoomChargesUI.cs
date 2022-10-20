
using System;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Windows.Forms;

using Jinisys.Hotel.NightAudit.BusinessLayer;
using Jinisys.Hotel.BusinessSharedClasses;

namespace Jinisys.Hotel.NightAudit.Presentation
{
    public class PostRoomChargesUI : Jinisys.Hotel.UIFramework.MiscellaneousUI
    {


        #region " Windows Form Designer generated code "

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
        public System.Windows.Forms.GroupBox GroupBox3;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.Button btnPost;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label4;
        internal System.Windows.Forms.Label Label5;
        internal System.Windows.Forms.Button btnCancel;
        internal System.Windows.Forms.Label Label7;
        internal System.Windows.Forms.Label Label3;
        internal System.Windows.Forms.Label Label6;
        internal System.Windows.Forms.Label Label8;
        internal Label lblPostingDate;
        internal System.Windows.Forms.Label Label9;
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            this.GroupBox3 = new System.Windows.Forms.GroupBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.Label9 = new System.Windows.Forms.Label();
            this.Label3 = new System.Windows.Forms.Label();
            this.Label6 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.Label5 = new System.Windows.Forms.Label();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnPost = new System.Windows.Forms.Button();
            this.Label7 = new System.Windows.Forms.Label();
            this.lblPostingDate = new System.Windows.Forms.Label();
            this.GroupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // GroupBox3
            // 
            this.GroupBox3.Controls.Add(this.Label7);
            this.GroupBox3.Controls.Add(this.lblPostingDate);
            this.GroupBox3.Controls.Add(this.Label8);
            this.GroupBox3.Controls.Add(this.Label9);
            this.GroupBox3.Controls.Add(this.Label3);
            this.GroupBox3.Controls.Add(this.Label6);
            this.GroupBox3.Controls.Add(this.btnCancel);
            this.GroupBox3.Controls.Add(this.Label5);
            this.GroupBox3.Controls.Add(this.Label4);
            this.GroupBox3.Controls.Add(this.Label2);
            this.GroupBox3.Controls.Add(this.Label1);
            this.GroupBox3.Controls.Add(this.btnPost);
            this.GroupBox3.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.GroupBox3.Location = new System.Drawing.Point(4, -1);
            this.GroupBox3.Name = "GroupBox3";
            this.GroupBox3.Size = new System.Drawing.Size(314, 301);
            this.GroupBox3.TabIndex = 75;
            this.GroupBox3.TabStop = false;
            // 
            // Label8
            // 
            this.Label8.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Label8.Location = new System.Drawing.Point(38, 100);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(24, 16);
            this.Label8.TabIndex = 18;
            this.Label8.Text = "ü";
            // 
            // Label9
            // 
            this.Label9.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label9.Location = new System.Drawing.Point(72, 103);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(208, 18);
            this.Label9.TabIndex = 17;
            this.Label9.Text = "Post Recurring Charges";
            // 
            // Label3
            // 
            this.Label3.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Label3.Location = new System.Drawing.Point(38, 135);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(24, 16);
            this.Label3.TabIndex = 15;
            this.Label3.Text = "ü";
            // 
            // Label6
            // 
            this.Label6.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label6.Location = new System.Drawing.Point(72, 137);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(208, 18);
            this.Label6.TabIndex = 14;
            this.Label6.Text = "Set Occupied Rooms DIRTY";
            // 
            // btnCancel
            // 
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Location = new System.Drawing.Point(238, 262);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(66, 31);
            this.btnCancel.TabIndex = 7;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // Label5
            // 
            this.Label5.Font = new System.Drawing.Font("Wingdings", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(2)));
            this.Label5.Location = new System.Drawing.Point(38, 58);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(24, 16);
            this.Label5.TabIndex = 5;
            this.Label5.Text = "ü";
            // 
            // Label4
            // 
            this.Label4.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label4.Location = new System.Drawing.Point(16, 186);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(280, 16);
            this.Label4.TabIndex = 4;
            this.Label4.Text = "NOTE: Folios already posted lately would be skipped.";
            // 
            // Label2
            // 
            this.Label2.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(72, 59);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(208, 29);
            this.Label2.TabIndex = 2;
            this.Label2.Text = "Post Room Charges to all In House Guest.";
            // 
            // Label1
            // 
            this.Label1.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(17, 24);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(64, 16);
            this.Label1.TabIndex = 1;
            this.Label1.Text = "Processes :";
            // 
            // btnPost
            // 
            this.btnPost.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnPost.Location = new System.Drawing.Point(238, 228);
            this.btnPost.Name = "btnPost";
            this.btnPost.Size = new System.Drawing.Size(66, 31);
            this.btnPost.TabIndex = 0;
            this.btnPost.Text = "&Post";
            this.btnPost.Click += new System.EventHandler(this.btnPost_Click);
            // 
            // Label7
            // 
            this.Label7.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label7.Location = new System.Drawing.Point(16, 240);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(65, 15);
            this.Label7.TabIndex = 4;
            this.Label7.Text = "Audit Date :";
            // 
            // lblPostingDate
            // 
            this.lblPostingDate.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostingDate.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblPostingDate.Location = new System.Drawing.Point(86, 240);
            this.lblPostingDate.Name = "lblPostingDate";
            this.lblPostingDate.Size = new System.Drawing.Size(130, 18);
            this.lblPostingDate.TabIndex = 19;
            this.lblPostingDate.Text = "January 20, 2007";
            // 
            // PostRoomChargesUI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(322, 303);
            this.Controls.Add(this.GroupBox3);
            this.Name = "PostRoomChargesUI";
            this.Text = "Post Room Charges";
            this.Load += new System.EventHandler(this.PostRoomChargesUI_Load);
            this.GroupBox3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        #region " VARIABLES "

        private PostRoomChargesFacade oPostRoomChargesFacade;

        #endregion

        #region " CONSTRUCTORS "

        public PostRoomChargesUI()
        {
            //This call is required by the Windows Form Designer.
            InitializeComponent();
        }

        #endregion

        #region " EVENTS "

        private void btnPost_Click(System.Object sender, System.EventArgs e)
        {
            oPostRoomChargesFacade = new PostRoomChargesFacade();
            if (oPostRoomChargesFacade.initializePostRoomCharges() == true )
            {

                this.Close();
            }

        }

       
        private void btnCancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }

        private void PostRoomChargesUI_Load(object sender, System.EventArgs e)
        {
            this.lblPostingDate.Text = string.Format("{0:MMMM dd, yyyy}",DateTime.Parse(Jinisys.Hotel.BusinessSharedClasses.GlobalVariables.gAuditDate) );
        }

        #endregion

    }
}