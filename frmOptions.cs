using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

// TODO: separate backups for different profiles

namespace Switchex {
	public partial class frmOptions: Form {
		public frmOptions() {
			InitializeComponent();
		}

		private void frmOptions_Load(object sender, EventArgs e) {
			if(Properties.Settings.Default.openWow) {
				chkOpenWow.Checked = true;
			}

			if(Properties.Settings.Default.updatesOnStartup) {
				chkUpdates.Checked = true;
			}

			if(Properties.Settings.Default.deleteServersAfterProfile) {
				chkDeleteServers.Checked = true;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e) {
			Properties.Settings.Default.updatesOnStartup = chkUpdates.Checked;
			Properties.Settings.Default.openWow = chkOpenWow.Checked;
			Properties.Settings.Default.deleteServersAfterProfile = chkDeleteServers.Checked;

			Properties.Settings.Default.Save();

			Close();
		}

		private void btnEmptyList_Click(object sender, EventArgs e) {
			if(Globals.rowCount > 0) {
				DialogResult result = MessageBox.Show("Are you sure you wish to empty your server list? A backup will be created before emptying it.", "Confirm Empty", MessageBoxButtons.YesNo);

				if(result == DialogResult.Yes) {
					try {
						BackupFile(Application.StartupPath + "\\switchex.sdf", false);

						using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
							using(SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Servers", conn)) {
								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}

						MessageBox.Show("Server list emptied successfully. Changes will be reflected when you close the Options window.", "Success");
					}
					catch(Exception ex) {
						Globals.frmError.ShowDialog(ex);
					}
				}
			}
			else {
				MessageBox.Show("The server list is empty. Please add more servers by clicking the Add button.", "Error");
			}
		}

		private void btnResetSettings_Click(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show("Are you sure you want to reset all program settings? This will restart Switchex.", "Confirmation", MessageBoxButtons.YesNo);

			if(result == DialogResult.Yes) {
				Globals.resetSettings = true;
				Properties.Settings.Default.Reset();

				// TODO: get program restart working
				Program.keepRunning = true;
				this.Close();
			}
		}

		private void btnBackupRealmlist_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);
			
			if(profile != null) {
				if(File.Exists(profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf")) {
					BackupFile(profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf", true);
				}
				else if(File.Exists(profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf")) {
					BackupFile(profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf", true);
				}
				else {
					MessageBox.Show("Cannot find realmlist.wtf with your current profile.", "Error");
				}
			}
			else {
				MessageBox.Show("Cannot find realmlist.wtf with your current profile.", "Error");
			}
		}

		private void btnBackupDatabase_Click(object sender, EventArgs e) {
			BackupFile(Application.StartupPath + "\\switchex.sdf", true);
		}

		private void btnRestoreRealmlist_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);

			if(profile != null) {
				if(Directory.Exists(profile.ProfilePath + "\\Data\\enUS")) {
					RestoreFile(profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf");
				}
				else if(Directory.Exists(profile.ProfilePath + "\\Data\\enGB")) {
					RestoreFile(profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf");
				}
				else {
					MessageBox.Show("Cannot find realmlist.wtf with your current profile.", "Error");
				}
			}
			else {
				MessageBox.Show("Cannot find realmlist.wtf with your current profile.", "Error");
			}
		}

		private void btnRestoreDatabase_Click(object sender, EventArgs e) {
			RestoreFile(Application.StartupPath + "\\switchex.sdf");
		}

		/// <summary>
		/// Backs up a file.
		/// </summary>
		/// <param name="file">The file path</param>
		/// <param name="confirm">Display an overwrite confirmation or not</param>
		private void BackupFile(string file, bool confirm) {
			try {
				string backupFile = file.Replace(file.Substring(0, file.LastIndexOf("\\") + 1),
					Application.StartupPath + "\\Backups\\").Replace(file.Substring(file.IndexOf('.')), ".bak");
				string[] args = { "false", file, backupFile };
				int fileAction = 0;

				if(File.Exists(backupFile) && confirm) {
					DialogResult result = MessageBox.Show("A backup already exists. Would you like to overwrite it?", "Confirm Overwrite", MessageBoxButtons.YesNo);

					if(result != DialogResult.Yes) {
						return;
					}
				}

				fileAction = Globals.RunActionsExecutable(Globals.FileAction.CopyFile, args);

				if(confirm) {
					if(fileAction == 0) {
						MessageBox.Show("Backup successful.", "Success");
					}
					else if(fileAction == 2) {
						MessageBox.Show("Realmlist.wtf does not exist. Cannot back up.", "Error");
					}
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Restores the file.
		/// </summary>
		/// <param name="file">The file path</param>
		private void RestoreFile(string file) {
			try {
				string backupFile = file.Replace(file.Substring(0, file.LastIndexOf("\\") + 1),
					Application.StartupPath + "\\Backups\\").Replace(file.Substring(file.IndexOf('.')), ".bak");

				string[] args = { "true", backupFile, file };
				int fileAction = 0;

				fileAction = Globals.RunActionsExecutable(Globals.FileAction.CopyFile, args);

				if(fileAction == 0) {
					MessageBox.Show("Restore successful.", "Success");
				}
				else if(fileAction == 2) {
					MessageBox.Show("A backup does not exist.", "Error");
				}
				else {
					MessageBox.Show("A backup could not be restored.", "Error");
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}
	}
}
