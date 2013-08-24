namespace Switchex {
	partial class frmUpdates {
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing) {
			if(disposing && (components != null)) {
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent() {
			this.prgbar = new System.Windows.Forms.ProgressBar();
			this.lblFile = new System.Windows.Forms.Label();
			this.lblDownload = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// prgbar
			// 
			this.prgbar.Location = new System.Drawing.Point(13, 13);
			this.prgbar.Name = "prgbar";
			this.prgbar.Size = new System.Drawing.Size(341, 23);
			this.prgbar.TabIndex = 0;
			// 
			// lblFile
			// 
			this.lblFile.Location = new System.Drawing.Point(12, 39);
			this.lblFile.Name = "lblFile";
			this.lblFile.Size = new System.Drawing.Size(342, 16);
			this.lblFile.TabIndex = 1;
			this.lblFile.Text = "Progress";
			this.lblFile.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// lblDownload
			// 
			this.lblDownload.Location = new System.Drawing.Point(12, 55);
			this.lblDownload.Name = "lblDownload";
			this.lblDownload.Size = new System.Drawing.Size(342, 51);
			this.lblDownload.TabIndex = 2;
			this.lblDownload.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			// 
			// frmUpdates
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(366, 115);
			this.ControlBox = false;
			this.Controls.Add(this.lblDownload);
			this.Controls.Add(this.lblFile);
			this.Controls.Add(this.prgbar);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmUpdates";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update";
			this.Load += new System.EventHandler(this.frmUpdates_Load);
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.ProgressBar prgbar;
		private System.Windows.Forms.Label lblFile;
		private System.Windows.Forms.Label lblDownload;
	}
}