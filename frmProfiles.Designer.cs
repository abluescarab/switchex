namespace Switchex {
	partial class frmProfiles {
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
			this.cmbProfiles = new System.Windows.Forms.ComboBox();
			this.btnAdd = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtPath = new System.Windows.Forms.TextBox();
			this.btnBrowse = new System.Windows.Forms.Button();
			this.btnSave = new System.Windows.Forms.Button();
			this.btnClear = new System.Windows.Forms.Button();
			this.tlpChanges = new System.Windows.Forms.TableLayoutPanel();
			this.btnDone = new System.Windows.Forms.Button();
			this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.btnDelete = new System.Windows.Forms.Button();
			this.lblName = new System.Windows.Forms.Label();
			this.lblLocation = new System.Windows.Forms.Label();
			this.lblDescription = new System.Windows.Forms.Label();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.gpbType = new System.Windows.Forms.GroupBox();
			this.rdo64bit = new System.Windows.Forms.RadioButton();
			this.rdo32bit = new System.Windows.Forms.RadioButton();
			this.chkDefault = new System.Windows.Forms.CheckBox();
			this.tlpChanges.SuspendLayout();
			this.gpbType.SuspendLayout();
			this.SuspendLayout();
			// 
			// cmbProfiles
			// 
			this.cmbProfiles.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbProfiles.FormattingEnabled = true;
			this.cmbProfiles.Location = new System.Drawing.Point(12, 14);
			this.cmbProfiles.Name = "cmbProfiles";
			this.cmbProfiles.Size = new System.Drawing.Size(268, 21);
			this.cmbProfiles.TabIndex = 0;
			this.cmbProfiles.SelectedIndexChanged += new System.EventHandler(this.cmbProfiles_SelectedIndexChanged);
			// 
			// btnAdd
			// 
			this.btnAdd.Image = global::Switchex.Properties.Resources.add;
			this.btnAdd.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnAdd.Location = new System.Drawing.Point(286, 12);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(108, 25);
			this.btnAdd.TabIndex = 1;
			this.btnAdd.Text = "Add New...";
			this.btnAdd.UseVisualStyleBackColor = true;
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(82, 43);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(281, 20);
			this.txtName.TabIndex = 3;
			// 
			// txtPath
			// 
			this.txtPath.Location = new System.Drawing.Point(82, 71);
			this.txtPath.Name = "txtPath";
			this.txtPath.Size = new System.Drawing.Size(200, 20);
			this.txtPath.TabIndex = 4;
			// 
			// btnBrowse
			// 
			this.btnBrowse.Location = new System.Drawing.Point(288, 69);
			this.btnBrowse.Name = "btnBrowse";
			this.btnBrowse.Size = new System.Drawing.Size(75, 25);
			this.btnBrowse.TabIndex = 5;
			this.btnBrowse.Text = "Browse...";
			this.btnBrowse.UseVisualStyleBackColor = true;
			this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
			// 
			// btnSave
			// 
			this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnSave.Enabled = false;
			this.btnSave.Location = new System.Drawing.Point(3, 3);
			this.btnSave.Name = "btnSave";
			this.btnSave.Size = new System.Drawing.Size(91, 25);
			this.btnSave.TabIndex = 0;
			this.btnSave.Text = "Save";
			this.btnSave.UseVisualStyleBackColor = true;
			this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
			// 
			// btnClear
			// 
			this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnClear.Location = new System.Drawing.Point(100, 3);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(91, 25);
			this.btnClear.TabIndex = 1;
			this.btnClear.Text = "Clear Changes";
			this.btnClear.UseVisualStyleBackColor = true;
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// tlpChanges
			// 
			this.tlpChanges.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpChanges.ColumnCount = 3;
			this.tlpChanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpChanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpChanges.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
			this.tlpChanges.Controls.Add(this.btnSave, 0, 0);
			this.tlpChanges.Controls.Add(this.btnDone, 2, 0);
			this.tlpChanges.Controls.Add(this.btnClear, 1, 0);
			this.tlpChanges.Location = new System.Drawing.Point(215, 126);
			this.tlpChanges.Name = "tlpChanges";
			this.tlpChanges.RowCount = 1;
			this.tlpChanges.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
			this.tlpChanges.Size = new System.Drawing.Size(293, 31);
			this.tlpChanges.TabIndex = 10;
			// 
			// btnDone
			// 
			this.btnDone.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnDone.Image = global::Switchex.Properties.Resources.accept;
			this.btnDone.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDone.Location = new System.Drawing.Point(197, 3);
			this.btnDone.Name = "btnDone";
			this.btnDone.Size = new System.Drawing.Size(93, 25);
			this.btnDone.TabIndex = 2;
			this.btnDone.Text = "Done";
			this.btnDone.UseVisualStyleBackColor = true;
			this.btnDone.Click += new System.EventHandler(this.btnDone_Click);
			// 
			// dlgFolder
			// 
			this.dlgFolder.Description = "WoW Folder";
			this.dlgFolder.ShowNewFolderButton = false;
			// 
			// btnDelete
			// 
			this.btnDelete.Image = global::Switchex.Properties.Resources.cross;
			this.btnDelete.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnDelete.Location = new System.Drawing.Point(400, 12);
			this.btnDelete.Name = "btnDelete";
			this.btnDelete.Size = new System.Drawing.Size(108, 25);
			this.btnDelete.TabIndex = 2;
			this.btnDelete.Text = "Delete";
			this.btnDelete.UseVisualStyleBackColor = true;
			this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
			// 
			// lblName
			// 
			this.lblName.AutoSize = true;
			this.lblName.Location = new System.Drawing.Point(13, 46);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(38, 13);
			this.lblName.TabIndex = 12;
			this.lblName.Text = "Name:";
			// 
			// lblLocation
			// 
			this.lblLocation.AutoSize = true;
			this.lblLocation.Location = new System.Drawing.Point(13, 75);
			this.lblLocation.Name = "lblLocation";
			this.lblLocation.Size = new System.Drawing.Size(51, 13);
			this.lblLocation.TabIndex = 13;
			this.lblLocation.Text = "Location:";
			// 
			// lblDescription
			// 
			this.lblDescription.AutoSize = true;
			this.lblDescription.Location = new System.Drawing.Point(13, 103);
			this.lblDescription.Name = "lblDescription";
			this.lblDescription.Size = new System.Drawing.Size(63, 13);
			this.lblDescription.TabIndex = 15;
			this.lblDescription.Text = "Description:";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(82, 100);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(281, 20);
			this.txtDescription.TabIndex = 6;
			// 
			// gpbType
			// 
			this.gpbType.Controls.Add(this.rdo64bit);
			this.gpbType.Controls.Add(this.rdo32bit);
			this.gpbType.Location = new System.Drawing.Point(369, 43);
			this.gpbType.Name = "gpbType";
			this.gpbType.Size = new System.Drawing.Size(139, 77);
			this.gpbType.TabIndex = 7;
			this.gpbType.TabStop = false;
			this.gpbType.Text = "Type";
			// 
			// rdo64bit
			// 
			this.rdo64bit.AutoSize = true;
			this.rdo64bit.Location = new System.Drawing.Point(6, 42);
			this.rdo64bit.Name = "rdo64bit";
			this.rdo64bit.Size = new System.Drawing.Size(120, 17);
			this.rdo64bit.TabIndex = 1;
			this.rdo64bit.TabStop = true;
			this.rdo64bit.Text = "64-bit (Wow-64.exe)";
			this.rdo64bit.UseVisualStyleBackColor = true;
			this.rdo64bit.CheckedChanged += new System.EventHandler(this.rdo64bit_CheckedChanged);
			// 
			// rdo32bit
			// 
			this.rdo32bit.AutoSize = true;
			this.rdo32bit.Location = new System.Drawing.Point(6, 19);
			this.rdo32bit.Name = "rdo32bit";
			this.rdo32bit.Size = new System.Drawing.Size(105, 17);
			this.rdo32bit.TabIndex = 0;
			this.rdo32bit.TabStop = true;
			this.rdo32bit.Text = "32-bit (Wow.exe)";
			this.rdo32bit.UseVisualStyleBackColor = true;
			this.rdo32bit.CheckedChanged += new System.EventHandler(this.rdo32bit_CheckedChanged);
			// 
			// chkDefault
			// 
			this.chkDefault.AutoSize = true;
			this.chkDefault.Location = new System.Drawing.Point(82, 126);
			this.chkDefault.Name = "chkDefault";
			this.chkDefault.Size = new System.Drawing.Size(91, 17);
			this.chkDefault.TabIndex = 9;
			this.chkDefault.Text = "Default profile";
			this.chkDefault.UseVisualStyleBackColor = true;
			this.chkDefault.CheckedChanged += new System.EventHandler(this.chkDefault_CheckedChanged);
			// 
			// frmProfiles
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(520, 169);
			this.Controls.Add(this.chkDefault);
			this.Controls.Add(this.gpbType);
			this.Controls.Add(this.lblDescription);
			this.Controls.Add(this.txtDescription);
			this.Controls.Add(this.lblLocation);
			this.Controls.Add(this.lblName);
			this.Controls.Add(this.btnDelete);
			this.Controls.Add(this.tlpChanges);
			this.Controls.Add(this.btnBrowse);
			this.Controls.Add(this.txtPath);
			this.Controls.Add(this.txtName);
			this.Controls.Add(this.btnAdd);
			this.Controls.Add(this.cmbProfiles);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmProfiles";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Manage Profiles";
			this.Load += new System.EventHandler(this.frmProfiles_Load);
			this.tlpChanges.ResumeLayout(false);
			this.gpbType.ResumeLayout(false);
			this.gpbType.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.ComboBox cmbProfiles;
		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtPath;
		private System.Windows.Forms.Button btnBrowse;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button btnClear;
		private System.Windows.Forms.TableLayoutPanel tlpChanges;
		private System.Windows.Forms.Button btnDone;
		private System.Windows.Forms.FolderBrowserDialog dlgFolder;
		private System.Windows.Forms.Button btnDelete;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblLocation;
		private System.Windows.Forms.Label lblDescription;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.GroupBox gpbType;
		private System.Windows.Forms.RadioButton rdo32bit;
		private System.Windows.Forms.RadioButton rdo64bit;
		private System.Windows.Forms.CheckBox chkDefault;
	}
}