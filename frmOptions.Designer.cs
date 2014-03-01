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
			this.chkOpenWow = new System.Windows.Forms.CheckBox();
			this.chkUpdates = new System.Windows.Forms.CheckBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.tlpOkCancel = new System.Windows.Forms.TableLayoutPanel();
			this.gpbGeneral = new System.Windows.Forms.GroupBox();
			this.chkDeleteServers = new System.Windows.Forms.CheckBox();
			this.gpbMisc.SuspendLayout();
			this.Restore.SuspendLayout();
			this.gpbRestore.SuspendLayout();
			this.tlpOkCancel.SuspendLayout();
			this.gpbGeneral.SuspendLayout();
			this.SuspendLayout();
			// 
			// gpbMisc
			// 
			this.gpbMisc.Controls.Add(this.btnResetSettings);
			this.gpbMisc.Controls.Add(this.btnEmptyList);
			this.gpbMisc.Location = new System.Drawing.Point(12, 106);
			this.gpbMisc.Name = "gpbMisc";
			this.gpbMisc.Size = new System.Drawing.Size(185, 81);
			this.gpbMisc.TabIndex = 2;
			this.gpbMisc.TabStop = false;
			this.gpbMisc.Text = "Miscellaneous";
			// 
			// btnResetSettings
			// 
			this.btnResetSettings.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnResetSettings.Image = global::Switchex.Properties.Resources.arrow_undo;
			this.btnResetSettings.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnResetSettings.Location = new System.Drawing.Point(6, 50);
			this.btnResetSettings.Name = "btnResetSettings";
			this.btnResetSettings.Size = new System.Drawing.Size(173, 25);
			this.btnResetSettings.TabIndex = 1;
			this.btnResetSettings.Text = "Reset Settings";
			this.btnResetSettings.UseVisualStyleBackColor = true;
			this.btnResetSettings.Click += new System.EventHandler(this.btnResetSettings_Click);
			// 
			// btnEmptyList
			// 
			this.btnEmptyList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnEmptyList.Image = global::Switchex.Properties.Resources.table_delete;
			this.btnEmptyList.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnEmptyList.Location = new System.Drawing.Point(6, 19);
			this.btnEmptyList.Name = "btnEmptyList";
			this.btnEmptyList.Size = new System.Drawing.Size(173, 25);
			this.btnEmptyList.TabIndex = 0;
			this.btnEmptyList.Text = "Empty Server List";
			this.btnEmptyList.UseVisualStyleBackColor = true;
			this.btnEmptyList.Click += new System.EventHandler(this.btnEmptyList_Click);
			// 
			// Restore
			// 
			this.Restore.Controls.Add(this.btnBackupDatabase);
			this.Restore.Controls.Add(this.btnBackupRealmlist);
			this.Restore.Location = new System.Drawing.Point(203, 12);
			this.Restore.Name = "Restore";
			this.Restore.Size = new System.Drawing.Size(185, 81);
			this.Restore.TabIndex = 3;
			this.Restore.TabStop = false;
			this.Restore.Text = "Backup";
			// 
			// btnBackupDatabase
			// 
			this.btnBackupDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBackupDatabase.Image = global::Switchex.Properties.Resources.table_save;
			this.btnBackupDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBackupDatabase.Location = new System.Drawing.Point(6, 50);
			this.btnBackupDatabase.Name = "btnBackupDatabase";
			this.btnBackupDatabase.Size = new System.Drawing.Size(173, 25);
			this.btnBackupDatabase.TabIndex = 1;
			this.btnBackupDatabase.Text = "Backup Database";
			this.btnBackupDatabase.UseVisualStyleBackColor = true;
			this.btnBackupDatabase.Click += new System.EventHandler(this.btnBackupDatabase_Click);
			// 
			// btnBackupRealmlist
			// 
			this.btnBackupRealmlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnBackupRealmlist.Image = global::Switchex.Properties.Resources.page_save;
			this.btnBackupRealmlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnBackupRealmlist.Location = new System.Drawing.Point(6, 19);
			this.btnBackupRealmlist.Name = "btnBackupRealmlist";
			this.btnBackupRealmlist.Size = new System.Drawing.Size(173, 25);
			this.btnBackupRealmlist.TabIndex = 0;
			this.btnBackupRealmlist.Text = "Backup Realmlist.wtf";
			this.btnBackupRealmlist.UseVisualStyleBackColor = true;
			this.btnBackupRealmlist.Click += new System.EventHandler(this.btnBackupRealmlist_Click);
			// 
			// gpbRestore
			// 
			this.gpbRestore.Controls.Add(this.btnRestoreDatabase);
			this.gpbRestore.Controls.Add(this.btnRestoreRealmlist);
			this.gpbRestore.Location = new System.Drawing.Point(203, 93);
			this.gpbRestore.Name = "gpbRestore";
			this.gpbRestore.Size = new System.Drawing.Size(185, 81);
			this.gpbRestore.TabIndex = 4;
			this.gpbRestore.TabStop = false;
			this.gpbRestore.Text = "Restore";
			// 
			// btnRestoreDatabase
			// 
			this.btnRestoreDatabase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRestoreDatabase.Image = global::Switchex.Properties.Resources.database_table;
			this.btnRestoreDatabase.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRestoreDatabase.Location = new System.Drawing.Point(6, 50);
			this.btnRestoreDatabase.Name = "btnRestoreDatabase";
			this.btnRestoreDatabase.Size = new System.Drawing.Size(173, 25);
			this.btnRestoreDatabase.TabIndex = 1;
			this.btnRestoreDatabase.Text = "Restore Database";
			this.btnRestoreDatabase.UseVisualStyleBackColor = true;
			this.btnRestoreDatabase.Click += new System.EventHandler(this.btnRestoreDatabase_Click);
			// 
			// btnRestoreRealmlist
			// 
			this.btnRestoreRealmlist.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnRestoreRealmlist.Image = global::Switchex.Properties.Resources.page_white_text;
			this.btnRestoreRealmlist.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
			this.btnRestoreRealmlist.Location = new System.Drawing.Point(6, 19);
			this.btnRestoreRealmlist.Name = "btnRestoreRealmlist";
			this.btnRestoreRealmlist.Size = new System.Drawing.Size(173, 25);
			this.btnRestoreRealmlist.TabIndex = 0;
			this.btnRestoreRealmlist.Text = "Restore Realmlist.wtf";
			this.btnRestoreRealmlist.UseVisualStyleBackColor = true;
			this.btnRestoreRealmlist.Click += new System.EventHandler(this.btnRestoreRealmlist_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(103, 3);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(94, 27);
			this.btnCancel.TabIndex = 6;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// chkOpenWow
			// 
			this.chkOpenWow.AutoSize = true;
			this.chkOpenWow.Location = new System.Drawing.Point(6, 42);
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
			this.chkUpdates.Location = new System.Drawing.Point(6, 19);
			this.chkUpdates.Name = "chkUpdates";
			this.chkUpdates.Size = new System.Drawing.Size(160, 17);
			this.chkUpdates.TabIndex = 0;
			this.chkUpdates.Text = "Check for updates at startup";
			this.chkUpdates.UseVisualStyleBackColor = true;
			// 
			// btnOK
			// 
			this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
			this.btnOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnOK.Location = new System.Drawing.Point(3, 3);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(94, 27);
			this.btnOK.TabIndex = 7;
			this.btnOK.Text = "OK";
			this.btnOK.UseVisualStyleBackColor = true;
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// tlpOkCancel
			// 
			this.tlpOkCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
			this.tlpOkCancel.ColumnCount = 2;
			this.tlpOkCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOkCancel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOkCancel.Controls.Add(this.btnOK, 0, 0);
			this.tlpOkCancel.Controls.Add(this.btnCancel, 1, 0);
			this.tlpOkCancel.Location = new System.Drawing.Point(188, 193);
			this.tlpOkCancel.Name = "tlpOkCancel";
			this.tlpOkCancel.RowCount = 1;
			this.tlpOkCancel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
			this.tlpOkCancel.Size = new System.Drawing.Size(200, 33);
			this.tlpOkCancel.TabIndex = 8;
			// 
			// gpbGeneral
			// 
			this.gpbGeneral.Controls.Add(this.chkDeleteServers);
			this.gpbGeneral.Controls.Add(this.chkUpdates);
			this.gpbGeneral.Controls.Add(this.chkOpenWow);
			this.gpbGeneral.Location = new System.Drawing.Point(12, 12);
			this.gpbGeneral.Name = "gpbGeneral";
			this.gpbGeneral.Size = new System.Drawing.Size(185, 88);
			this.gpbGeneral.TabIndex = 9;
			this.gpbGeneral.TabStop = false;
			this.gpbGeneral.Text = "General";
			// 
			// chkDeleteServers
			// 
			this.chkDeleteServers.AutoSize = true;
			this.chkDeleteServers.Location = new System.Drawing.Point(6, 65);
			this.chkDeleteServers.Name = "chkDeleteServers";
			this.chkDeleteServers.Size = new System.Drawing.Size(170, 17);
			this.chkDeleteServers.TabIndex = 2;
			this.chkDeleteServers.Text = "Delete servers with their profile";
			this.chkDeleteServers.UseVisualStyleBackColor = true;
			// 
			// frmOptions
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(400, 238);
			this.Controls.Add(this.gpbGeneral);
			this.Controls.Add(this.tlpOkCancel);
			this.Controls.Add(this.gpbRestore);
			this.Controls.Add(this.Restore);
			this.Controls.Add(this.gpbMisc);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "frmOptions";
			this.ShowIcon = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Options";
			this.Load += new System.EventHandler(this.frmOptions_Load);
			this.gpbMisc.ResumeLayout(false);
			this.Restore.ResumeLayout(false);
			this.gpbRestore.ResumeLayout(false);
			this.tlpOkCancel.ResumeLayout(false);
			this.gpbGeneral.ResumeLayout(false);
			this.gpbGeneral.PerformLayout();
			this.ResumeLayout(false);

		}

		#endregion

		private System.Windows.Forms.CheckBox chkUpdates;
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
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TableLayoutPanel tlpOkCancel;
		private System.Windows.Forms.GroupBox gpbGeneral;
		private System.Windows.Forms.CheckBox chkDeleteServers;
	}
}