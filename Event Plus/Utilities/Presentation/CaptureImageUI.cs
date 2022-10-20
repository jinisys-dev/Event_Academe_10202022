using System.Diagnostics;
using System;
using System.Data;
using System.Collections;
using System.Windows.Forms;

namespace Jinisys.Hotel.Utilities.Presentation
{
	public class CaptureImageUI : Form
		{
		    #region " Windows Form Designer generated code "
			
			public CaptureImageUI()
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
			internal System.Windows.Forms.PictureBox picWebCamImage;
			internal System.Windows.Forms.SaveFileDialog sdfImage;
			internal System.Windows.Forms.Button btnPreview;
        internal System.Windows.Forms.Button btnCapture;
        private WebCam_Capture.WebCamCapture WebCamCapture;
			internal System.Windows.Forms.GroupBox GroupBox1;
        internal Button btnClose;
			internal System.Windows.Forms.Button btnSave;
			[System.Diagnostics.DebuggerStepThrough()]private void InitializeComponent()
			{
                System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CaptureImageUI));
                this.picWebCamImage = new System.Windows.Forms.PictureBox();
                this.sdfImage = new System.Windows.Forms.SaveFileDialog();
                this.btnPreview = new System.Windows.Forms.Button();
                this.btnCapture = new System.Windows.Forms.Button();
                this.WebCamCapture = new WebCam_Capture.WebCamCapture();
                this.GroupBox1 = new System.Windows.Forms.GroupBox();
                this.btnSave = new System.Windows.Forms.Button();
                this.btnClose = new System.Windows.Forms.Button();
                ((System.ComponentModel.ISupportInitialize)(this.picWebCamImage)).BeginInit();
                this.SuspendLayout();
                // 
                // picWebCamImage
                // 
                this.picWebCamImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
                this.picWebCamImage.Location = new System.Drawing.Point(7, 8);
                this.picWebCamImage.Name = "picWebCamImage";
                this.picWebCamImage.Size = new System.Drawing.Size(460, 382);
                this.picWebCamImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                this.picWebCamImage.TabIndex = 0;
                this.picWebCamImage.TabStop = false;
                // 
                // btnPreview
                // 
                this.btnPreview.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnPreview.Location = new System.Drawing.Point(195, 403);
                this.btnPreview.Name = "btnPreview";
                this.btnPreview.Size = new System.Drawing.Size(66, 31);
                this.btnPreview.TabIndex = 1;
                this.btnPreview.Text = "Pre&view";
                this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
                // 
                // btnCapture
                // 
                this.btnCapture.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnCapture.Location = new System.Drawing.Point(265, 403);
                this.btnCapture.Name = "btnCapture";
                this.btnCapture.Size = new System.Drawing.Size(66, 31);
                this.btnCapture.TabIndex = 2;
                this.btnCapture.Text = "&Capture";
                this.btnCapture.Click += new System.EventHandler(this.btnCapture_Click);
                // 
                // WebCamCapture
                // 
                this.WebCamCapture.CaptureHeight = 240;
                this.WebCamCapture.CaptureWidth = 320;
                this.WebCamCapture.FrameNumber = ((ulong)(0ul));
                this.WebCamCapture.Location = new System.Drawing.Point(115, 17);
                this.WebCamCapture.Name = "WebCamCapture";
                this.WebCamCapture.Size = new System.Drawing.Size(342, 252);
                this.WebCamCapture.TabIndex = 0;
                this.WebCamCapture.TimeToCapture_milliseconds = 100;
                this.WebCamCapture.ImageCaptured += new WebCam_Capture.WebCamCapture.WebCamEventHandler(this.WebCamCapture_ImageCaptured);
                // 
                // GroupBox1
                // 
                this.GroupBox1.Location = new System.Drawing.Point(2, -3);
                this.GroupBox1.Name = "GroupBox1";
                this.GroupBox1.Size = new System.Drawing.Size(471, 398);
                this.GroupBox1.TabIndex = 3;
                this.GroupBox1.TabStop = false;
                // 
                // btnSave
                // 
                this.btnSave.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnSave.Location = new System.Drawing.Point(335, 403);
                this.btnSave.Name = "btnSave";
                this.btnSave.Size = new System.Drawing.Size(66, 31);
                this.btnSave.TabIndex = 4;
                this.btnSave.Text = "&Save";
                this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
                // 
                // btnClose
                // 
                this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
                this.btnClose.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.btnClose.Location = new System.Drawing.Point(405, 403);
                this.btnClose.Name = "btnClose";
                this.btnClose.Size = new System.Drawing.Size(66, 31);
                this.btnClose.TabIndex = 5;
                this.btnClose.Text = "Cl&ose";
                this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
                // 
                // CaptureImageUI
                // 
                this.AcceptButton = this.btnCapture;
                this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
                this.CancelButton = this.btnClose;
                this.ClientSize = new System.Drawing.Size(476, 440);
                this.Controls.Add(this.btnClose);
                this.Controls.Add(this.btnSave);
                this.Controls.Add(this.btnCapture);
                this.Controls.Add(this.btnPreview);
                this.Controls.Add(this.picWebCamImage);
                this.Controls.Add(this.GroupBox1);
                this.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
                this.Name = "CaptureImageUI";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                this.Text = "Image Capture";
                this.Load += new System.EventHandler(this.CaptureImageUI_Load);
                ((System.ComponentModel.ISupportInitialize)(this.picWebCamImage)).EndInit();
                this.ResumeLayout(false);

			}
			
			#endregion

            #region Events

            private void btnPreview_Click(System.Object sender, System.EventArgs e)
			{
				try
				{
					System.UInt64 framenum = 0;
					this.WebCamCapture.TimeToCapture_milliseconds = 20;
					this.WebCamCapture.Start(framenum);
				}
				catch (Exception)
				{
					MessageBox.Show("No Webcam installed in this computer!", "WebCm error!",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
				}
			}
			
			private void btnCapture_Click(System.Object sender, System.EventArgs e)
			{
				this.WebCamCapture.Stop();
	        }
			
			private void CaptureImageUI_Load(System.Object sender, System.EventArgs e)
			{
				this.WebCamCapture.Height = this.picWebCamImage.Height;
				this.WebCamCapture.Width = this.picWebCamImage.Width;
			}

			private void WebCamCapture_ImageCaptured(object source, WebCam_Capture.WebcamEventArgs e)
			{
				this.picWebCamImage.Image = e.WebCamImage;
			}
			
			private void btnSave_Click(System.Object sender, System.EventArgs e)
			{
				sdfImage.Filter = "JPEG |*.jpg|GIF |*.gif|Bitmap |*.bmp";
				if (!System.Convert.ToBoolean(sdfImage.ShowDialog(this) == System.Windows.Forms.DialogResult.Cancel))
				{
					if (sdfImage.FileName != "")
					{
						this.picWebCamImage.Image.Save(sdfImage.FileName);
					}
				}
			}
    #endregion

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

		}
	
}
