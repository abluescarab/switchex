namespace Switchex {
	partial class frmEdit {
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
			this.txtNotes = new System.Windows.Forms.TextBox();
			this.txtPatch = new System.Windows.Forms.TextBox();
			this.txtWebsite = new System.Windows.Forms.TextBox();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblNotes = new System.Windows.Forms.Label();
			this.lblRating = new System.Windows.Forms.Label();
			this.lblPatch = new System.Windows.Forms.Label();
			this.lblWebsite = new System.Windows.Forms.Label();
			this.lblIP = new System.Windows.Forms.Label();
			this.lblName = new System.Windows.Forms.Label();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.cmbProfiles = new System.Windows.Forms.ComboBox();
			this.lblProfile = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtNotes
			// 
			this.txtNotes.Location = new System.Drawing.Point(67, 146);
			this.txtNotes.Multiline = true;
			this.txtNotes.Name = "txtNotes";
			this.txtNotes.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtNotes.Size = new System.Drawing.Size(189, 71);
			this.txtNotes.TabIndex = 25;
			// 
			// txtPatch
			// 
			this.txtPatch.Location = new System.Drawing.Point(67, 92);
			this.txtPatch.Name = "txtPatch";
			this.txtPatch.Size = new System.Drawing.Size(189, 20);
			this.txtPatch.TabIndex = 23;
			// 
			// txtWebsite
			// 
			this.txtWebsite.Location = new System.Drawing.Point(67, 65);
			this.txtWebsite.Name = "txtWebsite";
			this.txtWebsite.Size = new System.Drawing.Size(189, 20);
			this.txtWebsite.TabIndex = 22;
			this.txtWebsite.TextChanged += new System.EventHandler(this.txtWebsite_TextChanged);
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(67, 38);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(189, 20);
			this.txtIP.TabIndex = 21;
			this.txtIP.TextChanged += new System.EventHandler(this.txtIP_TextChanged);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(67, 12);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(189, 20);
			this.txtName.TabIndex = 20;
			this.txtName.TextChanged += new System.EventHandler(this.txtName_TextChanged);
			// 
			// lblNotes
			// 
			this.lblNotes.AutoSize = true;
			this.lblNotes.Location = new System.Drawing.Point(12, 148);
			this.lblNotes.Name = "lblNotes";
			this.lblNotes.Size = new System.Drawing.Size(38, 13);
			this.lblNotes.TabIndex = 19;
			this.lblNotes.Text = "Notes:";
			// 
			// lblRating
			// 
			this.lblRating.AutoSize = true;
			this.lblRating.Location = new System.Drawing.Point(12, 122);
			this.lblRating.Name = "lblRating";
			this.lblRating.Size = new System.Drawing.Size(41, 13);
			this.lblRating.TabIndex = 18;
			this.lblRating.Text = "Rating:";
			// 
			// lblPatch
			// 
			this.lblPatch.AutoSize = true;
			this.lblPatch.Location = new System.Drawing.Point(12, 95);
			this.lblPatch.Name = "lblPatch";
			this.lblPatch.Size = new System.Drawing.Size(38, 13);
			this.lblPatch.TabIndex = 17;
			this.lblPatch.Text = "Patch:";
			// 
			// lblWebsite
			// 
			this.lblWebsite.AutoSize = true;
			this.lblWebsite.Location = new System.Drawing.Point(12, 68);
			this.lblWebsite.Name = "lblWebsite";
			this.lblWebsite.Size = new System.Drawing.Size(49, 13);
			this.lblWebsite.TabIndex = 16;
			this.lblWebsite.Text = "Website:";
			// 
			// lblIP
			// 
			this.lblIP.AutoSize = true;
			this.lblIP.Location = new System.Drawing.Point(12, 41);
			this.lblIP.Name = "lblIP";
			this.lblIP.Size = new System.Drawing.Size(20, 13);
			this.lblIP.TabIndex = 15;
			this.lblIP.Text = "IP:";
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(12, 15);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 14;
			this.lblName.Text = "Name:";
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.Location = new System.Drawing.Point(62, 256);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(94, 26);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(162, 256);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 26);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			// 
			// cmbProfiles
			// 
			this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProfiles.FormattingEnabled = true;
			this.cmbProfiles.Location = new System.Drawing.Point(67, 223);
			this.cmbProfiles.Name = "cmbProfiles";
			this.cmbProfiles.Size = new System.Drawing.Size(189, 21);
			this.cmbProfiles.TabIndex = 1004;
			// 
			// lblProfile
			// 
			this.lblProfile.AutoSize = true;
			this.lblProfile.Location = new System.Drawing.Point(12, 225);
			this.lblProfile.Name = "lblProfile";
			this.lblProfile.Size = new System.Drawing.Size(39, 13);
			this.lblProfile.TabIndex = 1003;
			this.lblProfile.Text = "Profile:";
			// 
			// frmEdit
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(268, 294);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.cmbProfiles);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.lblProfile);
			this.Controls.Add(this.txtNotes);
			this.Controls.Add(this.txtPatch);
			this.Controls.Add(this.txtWebsite);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.lblNotes);
			this.Controls.Add(this.lblRating);
			this.Controls.Add(this.lblPatch);
			this.Controls.Add(this.lblWebsite);
			this.Controls.Add(this.lblIP);
			this.Controls.Add(this.lblName);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmEdit";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Edit Server";
			this.Load += new System.EventHandler(this.frmEdit_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.TextBox txtNotes;
		private System.Windows.Forms.TextBox txtPatch;
		private System.Windows.Forms.TextBox txtWebsite;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblNotes;
		private System.Windows.Forms.Label lblRating;
		private System.Windows.Forms.Label lblPatch;
		private System.Windows.Forms.Label lblWebsite;
		private System.Windows.Forms.Label lblIP;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ComboBox cmbProfiles;
		private System.Windows.Forms.Label lblProfile;
	}
}