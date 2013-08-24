using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmOptions: Form {
		public static bool resetSettings = false;

		public frmOptions() {
			InitializeComponent();
		}

		private void frmOptions_Load(object sender, EventArgs e) {
			if(Properties.Settings.Default.bit64 == false) {
				rdo32bit.Checked = true;
			}
			else {
				rdo64bit.Checked = true;
			}

			if(Properties.Settings.Default.openWow == true) {
				chkOpenWow.Checked = true;
			}

			if(Properties.Settings.Default.updatesOnStartup == true) {
				chkUpdates.Checked = true;
			}
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void btnOK_Click(object sender, EventArgs e) {
			if(rdo32bit.Checked == true) {
				Properties.Settings.Default.bit64 = false;
				frmMain.executablePath = Properties.Settings.Default.gamePath + "Wow.exe";
			}
			else if(rdo64bit.Checked == true) {
				Properties.Settings.Default.bit64 = true;
				frmMain.executablePath = Properties.Settings.Default.gamePath + "Wow-64.exe";
			}

			Properties.Settings.Default.updatesOnStartup = chkUpdates.Checked;
			Properties.Settings.Default.openWow = chkOpenWow.Checked;

			if(dlgFolder.SelectedPath != null && dlgFolder.SelectedPath != "") {
				Properties.Settings.Default.gamePath = dlgFolder.SelectedPath + "\\";

				if(Properties.Settings.Default.bit64 == false) {
					frmMain.executablePath = Properties.Settings.Default.gamePath + "Wow.exe";
				}
				else {
					frmMain.executablePath = Properties.Settings.Default.gamePath + "Wow-64.exe";
				}

				if(Directory.Exists(Properties.Settings.Default.gamePath + "Data\\enUS")) {
					Properties.Settings.Default.installType = "enUS";
				}
				else if(Directory.Exists(Properties.Settings.Default.gamePath + "Data\\enGB")) {
					Properties.Settings.Default.installType = "enGB";
				}
			}
			if(dlgFile.FileName != null && dlgFile.FileName != "") {
				Properties.Settings.Default.realmPath = dlgFile.FileName;
			}

			Properties.Settings.Default.Save();

			Close();
		}

		private void btnWowPath_Click(object sender, EventArgs e) {
			dlgFolder.Description = "World of Warcraft Folder Path";
			dlgFolder.ShowDialog();
		}

		private void btnRealmlistPath_Click(object sender, EventArgs e) {
			if(Properties.Settings.Default.gamePath != null && Properties.Settings.Default.gamePath != "" &&
				Properties.Settings.Default.installType != "" && Properties.Settings.Default.installType != null) {
				dlgFile.InitialDirectory = Properties.Settings.Default.gamePath + "Data\\" + Properties.Settings.Default.installType;
			}
			else {
				dlgFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
			}

			dlgFile.Title = "Realmlist Path";
			dlgFile.Filter = "WTF files|*.wtf";

			dlgFile.ShowDialog();

			string file = dlgFile.FileName;

			if(file != "") {
				Properties.Settings.Default.realmPath = file;
			}
		}

		private void btnEmptyList_Click(object sender, EventArgs e) {
			if(frmMain.rowCount > 0) {
				DialogResult result = MessageBox.Show("Are you sure you wish to empty your server list? A backup will be created before wiping.", "Confirm Empty", MessageBoxButtons.YesNo);

				if(result == DialogResult.Yes) {
					try {
						backup(Application.StartupPath + "\\WoWServer.accdb", false);

						OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\WoWServer.accdb");
						OleDbCommand cmd = new OleDbCommand();

						cmd.Connection = conn;
						conn.Open();

						cmd.CommandText = "DELETE * FROM ServerInfo";

						cmd.ExecuteNonQuery();
						conn.Close();

						MessageBox.Show("Server list emptied successfully. Changes will be reflected when you close the Options window.", "Success");
					}
					catch(Exception ex) {
						MessageBox.Show(ex.Message, "Error");
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
				resetSettings = true;
				Properties.Settings.Default.Reset();
				Application.Restart();
			}
		}

		private void btnBackupRealmlist_Click(object sender, EventArgs e) {
			if(Properties.Settings.Default.realmPath != "" && Properties.Settings.Default.realmPath != null) {
				backup(Properties.Settings.Default.realmPath, true);
			}
			else {
				MessageBox.Show("Please set the location of your realmlist.wtf file.", "Error");
			}
		}

		private void btnBackupDatabase_Click(object sender, EventArgs e) {
			backup(Application.StartupPath + "\\WoWServer.accdb", true);
		}

		private void btnRestoreRealmlist_Click(object sender, EventArgs e) {
			if(Properties.Settings.Default.realmPath != "" && Properties.Settings.Default.realmPath != null) {
				restore(Properties.Settings.Default.realmPath);
			}
			else {
				MessageBox.Show("Please set the location of your realmlist.wtf file.", "Error");
			}
		}

		private void btnRestoreDatabase_Click(object sender, EventArgs e) {
			restore(Application.StartupPath + "\\WoWServer.accdb");
		}

		private void backup(string file, bool confirm) {
			try {
				string backupFile = file.Replace(file.Substring(file.IndexOf('.')), ".bak");

				if(File.Exists(backupFile) && confirm == true) {
					DialogResult result = MessageBox.Show("A backup already exists. Would you like to overwrite it?", "Confirm Overwrite", MessageBoxButtons.YesNo);

					if(result == DialogResult.Yes) {
						File.Delete(backupFile);
					}
				}
				else if(confirm == false) {
					File.Delete(backupFile);
				}

				File.Copy(file, backupFile);

				if(confirm == true) {
					MessageBox.Show("Backup successful.", "Success");
				}
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void restore(string file) {
			try {
				string backupFile = file.Replace(file.Substring(file.IndexOf('.')), ".bak");

				if(File.Exists(backupFile)) {
					if(File.Exists(file)) {
						File.Delete(file);
					}

					File.Copy(backupFile, file);
					File.Delete(backupFile);

					MessageBox.Show("Restore successful.", "Success");
				}
				else {
					MessageBox.Show("A backup does not exist.", "Error");
				}
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}
	}
}
