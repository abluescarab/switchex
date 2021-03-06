﻿namespace Switchex {
	partial class frmConfirmUpdate {
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
			this.btnNo = new System.Windows.Forms.Button();
			this.btnYes = new System.Windows.Forms.Button();
			this.txtReadme = new System.Windows.Forms.TextBox();
			this.lblUpdate = new System.Windows.Forms.Label();
			this.lblCurrentVersion = new System.Windows.Forms.Label();
			this.lblDate = new System.Windows.Forms.Label();
			this.lblDownload = new System.Windows.Forms.Label();
			this.lblUpdateVersion = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnNo
			// 
			this.btnNo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnNo.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnNo.Location = new System.Drawing.Point(203, 252);
			this.btnNo.Name = "btnNo";
			this.btnNo.Size = new System.Drawing.Size(75, 31);
			this.btnNo.TabIndex = 0;
			this.btnNo.Text = "No";
			this.btnNo.UseVisualStyleBackColor = true;
			this.btnNo.Click += new System.EventHandler(this.btnNo_Click);
			// 
			// btnYes
			// 
			this.btnYes.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.btnYes.Location = new System.Drawing.Point(122, 252);
			this.btnYes.Name = "btnYes";
			this.btnYes.Size = new System.Drawing.Size(75, 31);
			this.btnYes.TabIndex = 1;
			this.btnYes.Text = "Yes";
			this.btnYes.UseVisualStyleBackColor = true;
			this.btnYes.Click += new System.EventHandler(this.btnYes_Click);
			// 
			// txtReadme
			// 
			this.txtReadme.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.txtReadme.Location = new System.Drawing.Point(12, 116);
			this.txtReadme.Multiline = true;
			this.txtReadme.Name = "txtReadme";
			this.txtReadme.ReadOnly = true;
			this.txtReadme.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtReadme.Size = new System.Drawing.Size(266, 130);
			this.txtReadme.TabIndex = 3;
			// 
			// lblUpdate
			// 
			this.lblUpdate.AutoSize = true;
			this.lblUpdate.Location = new System.Drawing.Point(12, 9);
			this.lblUpdate.Name = "lblUpdate";
			this.lblUpdate.Size = new System.Drawing.Size(114, 13);
			this.lblUpdate.TabIndex = 4;
			this.lblUpdate.Text = "An update is available!";
			// 
			// lblCurrentVersion
			// 
			this.lblCurrentVersion.AutoSize = true;
			this.lblCurrentVersion.Location = new System.Drawing.Point(12, 48);
			this.lblCurrentVersion.Name = "lblCurrentVersion";
			this.lblCurrentVersion.Size = new System.Drawing.Size(47, 13);
			this.lblCurrentVersion.TabIndex = 5;
			this.lblCurrentVersion.Text = "Current: ";
			// 
			// lblDate
			// 
			this.lblDate.AutoSize = true;
			this.lblDate.Location = new System.Drawing.Point(12, 35);
			this.lblDate.Name = "lblDate";
			this.lblDate.Size = new System.Drawing.Size(36, 13);
			this.lblDate.TabIndex = 6;
			this.lblDate.Text = "Date: ";
			// 
			// lblDownload
			// 
			this.lblDownload.Location = new System.Drawing.Point(12, 87);
			this.lblDownload.Name = "lblDownload";
			this.lblDownload.Size = new System.Drawing.Size(266, 26);
			this.lblDownload.TabIndex = 7;
			this.lblDownload.Text = "Download the update? It will download to the program\'s install location.";
			// 
			// lblUpdateVersion
			// 
			this.lblUpdateVersion.AutoSize = true;
			this.lblUpdateVersion.Location = new System.Drawing.Point(12, 61);
			this.lblUpdateVersion.Name = "lblUpdateVersion";
			this.lblUpdateVersion.Size = new System.Drawing.Size(48, 13);
			this.lblUpdateVersion.TabIndex = 8;
			this.lblUpdateVersion.Text = "Update: ";
			// 
			// frmConfirmUpdate
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnNo;
			this.ClientSize = new System.Drawing.Size(290, 295);
			this.ControlBox = false;
			this.Controls.Add(this.lblUpdateVersion);
			this.Controls.Add(this.lblDownload);
			this.Controls.Add(this.lblDate);
			this.Controls.Add(this.lblCurrentVersion);
			this.Controls.Add(this.lblUpdate);
			this.Controls.Add(this.txtReadme);
			this.Controls.Add(this.btnYes);
			this.Controls.Add(this.btnNo);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "frmConfirmUpdate";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Update Available";
			this.Load += new System.EventHandler(this.frmConfirmUpdate_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button btnNo;
		private System.Windows.Forms.Button btnYes;
		private System.Windows.Forms.TextBox txtReadme;
		private System.Windows.Forms.Label lblUpdate;
		private System.Windows.Forms.Label lblCurrentVersion;
		private System.Windows.Forms.Label lblDate;
		private System.Windows.Forms.Label lblDownload;
		private System.Windows.Forms.Label lblUpdateVersion;
	}
}