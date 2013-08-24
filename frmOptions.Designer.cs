namespace Switchex {
	partial class frmOptions {
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
			this.gpbLocations = new System.Windows.Forms.GroupBox();
			this.btnRealmlistPath = new System.Windows.Forms.Button();
			this.btnWowPath = new System.Windows.Forms.Button();
			this.gpbMisc = new System.Windows.Forms.GroupBox();
			this.btnResetSettings = new System.Windows.Forms.Button();
			this.btnEmptyList = new System.Windows.Forms.Button();
			this.Restore = new System.Windows.Forms.GroupBox();
			this.btnBackupDatabase = new System.Windows.Forms.Button();
			this.btnBackupRealmlist = new System.Windows.Forms.Button();
			this.gpbRestore = new System.Windows.Forms.GroupBox();
			this.btnRestoreDatabase = new System.Windows.Forms.Button();
			this.btnRestoreRealmlist = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.dlgFile = new System.Windows.Forms.OpenFileDialog();
			this.dlgFolder = new System.Windows.Forms.FolderBrowserDialog();
			this.gpbInstall = new System.Windows.Forms.GroupBox();
			this.rdo64bit = new System.Windows.Forms.RadioButton();
			this.rdo32bit = new System.Windows.Forms.RadioButton();
			this.chkOpenWow = new System.Windows.Forms.CheckBox();
			this.chkUpdates = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.gpbLocations.SuspendLayout();
			this.gpbMisc.SuspendLayout();
			this.Restore.SuspendLayout();
			this.gpbRestore.SuspendLayout();
			this.gpbInstall.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbLocations
			// 
			this.gpbLocations.CausesValidation = false;
			this.gpbLocations.Controls.Add(this.btnRealmlistPath);
			this.gpbLocations.Controls.Add(this.btnWowPath);
			this.gpbLocations.Location = new System.Drawing.Point(12, 107);
			this.gpbLocations.Name = "gpbLocations";
			this.gpbLocations.Size = new System.Drawing.Size(180, 81);
			this.gpbLocations.TabIndex = 1;
			this.gpbLocations.TabStop = false;
			this.gpbLocations.Text = "Locations";
			// 
			// btnRealmlistPath
			// 
			this.btnRealmlistPath.Image = global::Switchex.Properties.Resources.wrench;
			this.btnRealmlistPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRealmlistPath.Location = new System.Drawing.Point(6, 50);
			this.btnRealmlistPath.Name = "btnRealmlistPath";
			this.btnRealmlistPath.Size = new System.Drawing.Size(168, 25);
			this.btnRealmlistPath.TabIndex = 1;
			this.btnRealmlistPath.Text = "Realmlist Path";
			this.btnRealmlistPath.UseVisualStyleBackColor = true;
			this.btnRealmlistPath.Click += new System.EventHandler(this.btnRealmlistPath_Click);
			// 
			// btnWowPath
			// 
			this.btnWowPath.Image = global::Switchex.Properties.Resources.wrench_orange;
			this.btnWowPath.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnWowPath.Location = new System.Drawing.Point(6, 19);
			this.btnWowPath.Name = "btnWowPath";
			this.btnWowPath.Size = new System.Drawing.Size(168, 25);
			this.btnWowPath.TabIndex = 0;
			this.btnWowPath.Text = "WoW Folder Path";
			this.btnWowPath.UseVisualStyleBackColor = true;
			this.btnWowPath.Click += new System.EventHandler(this.btnWowPath_Click);
			// 
			// gpbMisc
			// 
			this.gpbMisc.Controls.Add(this.btnResetSettings);
			this.gpbMisc.Controls.Add(this.btnEmptyList);
			this.gpbMisc.Location = new System.Drawing.Point(12, 194);
			this.gpbMisc.Name = "gpbMisc";
			this.gpbMisc.Size = new System.Drawing.Size(180, 81);
			this.gpbMisc.TabIndex = 2;
			this.gpbMisc.TabStop = false;
			this.gpbMisc.Text = "Miscellaneous";
			// 
			// btnResetSettings
			// 
			this.btnResetSettings.Image = global::Switchex.Properties.Resources.arrow_undo;
			this.btnResetSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnResetSettings.Location = new System.Drawing.Point(6, 50);
			this.btnResetSettings.Name = "btnResetSettings";
			this.btnResetSettings.Size = new System.Drawing.Size(168, 25);
			this.btnResetSettings.TabIndex = 1;
			this.btnResetSettings.Text = "Reset Settings";
			this.btnResetSettings.UseVisualStyleBackColor = true;
			this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
			// 
			// btnEmptyList
			// 
			this.btnEmptyList.Image = global::Switchex.Properties.Resources.table_delete;
			this.btnEmptyList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEmptyList.Location = new System.Drawing.Point(6, 19);
			this.btnEmptyList.Name = "btnEmptyList";
			this.btnEmptyList.Size = new System.Drawing.Size(168, 25);
			this.btnEmptyList.TabIndex = 0;
			this.btnEmptyList.Text = "Empty Server List";
			this.btnEmptyList.UseVisualStyleBackColor = true;
			this.btnEmptyList.Click += new System.EventHandler(this.btnEmptyList_Click);
			// 
			// Restore
			// 
			this.Restore.Controls.Add(this.btnBackupDatabase);
			this.Restore.Controls.Add(this.btnBackupRealmlist);
			this.Restore.Location = new System.Drawing.Point(199, 35);
			this.Restore.Name = "Restore";
			this.Restore.Size = new System.Drawing.Size(179, 81);
			this.Restore.TabIndex = 3;
			this.Restore.TabStop = false;
			this.Restore.Text = "Backup";
			// 
			// btnBackupDatabase
			// 
			this.btnBackupDatabase.Image = global::Switchex.Properties.Resources.table_save;
			this.btnBackupDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBackupDatabase.Location = new System.Drawing.Point(6, 50);
			this.btnBackupDatabase.Name = "btnBackupDatabase";
			this.btnBackupDatabase.Size = new System.Drawing.Size(167, 25);
			this.btnBackupDatabase.TabIndex = 1;
			this.btnBackupDatabase.Text = "Backup Database";
			this.btnBackupDatabase.UseVisualStyleBackColor = true;
			this.btnBackupDatabase.Click += new System.EventHandler(this.btnBackupDatabase_Click);
			// 
			// btnBackupRealmlist
			// 
			this.btnBackupRealmlist.Image = global::Switchex.Properties.Resources.page_save;
			this.btnBackupRealmlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBackupRealmlist.Location = new System.Drawing.Point(6, 19);
			this.btnBackupRealmlist.Name = "btnBackupRealmlist";
			this.btnBackupRealmlist.Size = new System.Drawing.Size(167, 25);
			this.btnBackupRealmlist.TabIndex = 0;
			this.btnBackupRealmlist.Text = "Backup Realmlist.wtf";
			this.btnBackupRealmlist.UseVisualStyleBackColor = true;
			this.btnBackupRealmlist.Click += new System.EventHandler(this.btnBackupRealmlist_Click);
			// 
			// gpbRestore
			// 
			this.gpbRestore.Controls.Add(this.btnRestoreDatabase);
			this.gpbRestore.Controls.Add(this.btnRestoreRealmlist);
			this.gpbRestore.Location = new System.Drawing.Point(198, 122);
			this.gpbRestore.Name = "gpbRestore";
			this.gpbRestore.Size = new System.Drawing.Size(180, 81);
			this.gpbRestore.TabIndex = 4;
			this.gpbRestore.TabStop = false;
			this.gpbRestore.Text = "Restore";
			// 
			// btnRestoreDatabase
			// 
			this.btnRestoreDatabase.Image = global::Switchex.Properties.Resources.database_table;
			this.btnRestoreDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRestoreDatabase.Location = new System.Drawing.Point(6, 50);
			this.btnRestoreDatabase.Name = "btnRestoreDatabase";
			this.btnRestoreDatabase.Size = new System.Drawing.Size(168, 25);
			this.btnRestoreDatabase.TabIndex = 1;
			this.btnRestoreDatabase.Text = "Restore Database";
			this.btnRestoreDatabase.UseVisualStyleBackColor = true;
			this.btnRestoreDatabase.Click += new System.EventHandler(this.btnRestoreDatabase_Click);
			// 
			// btnRestoreRealmlist
			// 
			this.btnRestoreRealmlist.Image = global::Switchex.Properties.Resources.page_white_text;
			this.btnRestoreRealmlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRestoreRealmlist.Location = new System.Drawing.Point(6, 19);
			this.btnRestoreRealmlist.Name = "btnRestoreRealmlist";
			this.btnRestoreRealmlist.Size = new System.Drawing.Size(168, 25);
			this.btnRestoreRealmlist.TabIndex = 0;
			this.btnRestoreRealmlist.Text = "Restore Realmlist.wtf";
			this.btnRestoreRealmlist.UseVisualStyleBackColor = true;
			this.btnRestoreRealmlist.Click += new System.EventHandler(this.btnRestoreRealmlist_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(291, 244);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(87, 31);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// gpbInstall
			// 
			this.gpbInstall.Controls.Add(this.rdo64bit);
			this.gpbInstall.Controls.Add(this.rdo32bit);
			this.gpbInstall.Location = new System.Drawing.Point(12, 35);
			this.gpbInstall.Name = "gpbInstall";
			this.gpbInstall.Size = new System.Drawing.Size(180, 66);
			this.gpbInstall.TabIndex = 0;
			this.gpbInstall.TabStop = false;
			this.gpbInstall.Text = "Installation ";
			// 
			// rdo64bit
			// 
			this.rdo64bit.AutoSize = true;
			this.rdo64bit.Location = new System.Drawing.Point(6, 43);
			this.rdo64bit.Name = "rdo64bit";
			this.rdo64bit.Size = new System.Drawing.Size(120, 17);
			this.rdo64bit.TabIndex = 1;
			this.rdo64bit.TabStop = true;
			this.rdo64bit.Text = "64-bit (Wow-64.exe)";
			this.rdo64bit.UseVisualStyleBackColor = true;
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
			// 
			// chkOpenWow
			// 
			this.chkOpenWow.AutoSize = true;
			this.chkOpenWow.Location = new System.Drawing.Point(199, 12);
			this.chkOpenWow.Name = "chkOpenWow";
			this.chkOpenWow.Size = new System.Drawing.Size(173, 17);
			this.chkOpenWow.TabIndex = 1;
			this.chkOpenWow.Text = "Open WoW after setting server";
			this.chkOpenWow.UseVisualStyleBackColor = true;
			// 
			// chkUpdates
			// 
			this.chkUpdates.AutoSize = true;
			this.chkUpdates.Checked = global::Switchex.Properties.Settings.Default.updatesOnStartup;
			this.chkUpdates.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chkUpdates.Location = new System.Drawing.Point(12, 12);
			this.chkUpdates.Name = "chkUpdates";
			this.chkUpdates.Size = new System.Drawing.Size(160, 17);
			this.chkUpdates.TabIndex = 0;
			this.chkUpdates.Text = "Check for updates at startup";
			this.chkUpdates.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(198, 244);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(87, 31);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// frmOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(390, 287);
			this.Controls.Add(this.btnOK);
			this.Controls.Add(this.gpbInstall);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.gpbRestore);
			this.Controls.Add(this.Restore);
			this.Controls.Add(this.chkOpenWow);
			this.Controls.Add(this.gpbMisc);
			this.Controls.Add(this.gpbLocations);
			this.Controls.Add(this.chkUpdates);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.Load += new System.EventHandler(this.frmOptions_Load);
			this.gpbLocations.ResumeLayout(false);
			this.gpbMisc.ResumeLayout(false);
			this.Restore.ResumeLayout(false);
			this.gpbRestore.ResumeLayout(false);
			this.gpbInstall.ResumeLayout(false);
			this.gpbInstall.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.CheckBox chkUpdates;
		private System.Windows.Forms.GroupBox gpbLocations;
		private System.Windows.Forms.Button btnRealmlistPath;
		private System.Windows.Forms.Button btnWowPath;
		private System.Windows.Forms.GroupBox gpbMisc;
		private System.Windows.Forms.CheckBox chkOpenWow;
		private System.Windows.Forms.GroupBox Restore;
		private System.Windows.Forms.GroupBox gpbRestore;
		private System.Windows.Forms.Button btnBackupRealmlist;
		private System.Windows.Forms.Button btnBackupDatabase;
		private System.Windows.Forms.Button btnEmptyList;
		private System.Windows.Forms.Button btnRestoreRealmlist;
		private System.Windows.Forms.Button btnRestoreDatabase;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.OpenFileDialog dlgFile;
		private System.Windows.Forms.Button btnResetSettings;
		private System.Windows.Forms.FolderBrowserDialog dlgFolder;
		private System.Windows.Forms.GroupBox gpbInstall;
		private System.Windows.Forms.RadioButton rdo32bit;
		private System.Windows.Forms.RadioButton rdo64bit;
		private System.Windows.Forms.Button btnOK;
	}
}