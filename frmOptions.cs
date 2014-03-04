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
using System.Xml;
using System.Xml.Linq;

/* TODO: separate backups for different profiles
 * TODO: load servers into objects
 */

namespace Switchex {
	public partial class frmOptions: Form {
		frmError frmError = new frmError();

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

			dlgSaveFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
			dlgOpenFile.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
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

		private void btnExportServers_Click(object sender, EventArgs e) {
			dlgSaveFile.FileName = "wowservers.xml";

			if(dlgSaveFile.ShowDialog() == DialogResult.OK && dlgSaveFile.FileName != "") {
				ExportServersXml(dlgSaveFile.FileName);
			}
		}

		private void btnExportProfiles_Click(object sender, EventArgs e) {
			dlgSaveFile.FileName = "wowprofiles.xml";

			if(dlgSaveFile.ShowDialog() == DialogResult.OK && dlgSaveFile.FileName != "") {
				ExportProfilesXml(dlgSaveFile.FileName);
			}
		}

		private void btnImportServers_Click(object sender, EventArgs e) {
			if(dlgOpenFile.ShowDialog() == DialogResult.OK && dlgOpenFile.FileName != "") {
				ImportServersXml(dlgOpenFile.FileName);
			}
		}

		private void btnImportProfiles_Click(object sender, EventArgs e) {
			if(dlgOpenFile.ShowDialog() == DialogResult.OK && dlgOpenFile.FileName != "") {
				ImportProfilesXml(dlgOpenFile.FileName);
			}
		}

		#region Functions
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
						MessageBox.Show("File does not exist. Cannot back up.", "Error");
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

		/// <summary>
		/// Exports servers to a specified XML file.
		/// </summary>
		/// <param name="filename">File to export to</param>
		private void ExportServersXml(string filename) {
			try {
				XmlWriterSettings ws = new XmlWriterSettings();
				ws.Indent = true;
				ws.IndentChars = "\t";
				ws.NewLineOnAttributes = true;

				using(XmlWriter w = XmlWriter.Create(filename, ws)) {
					w.WriteStartDocument();
					w.WriteStartElement("Servers");
					w.WriteAttributeString("provider", "Switchex");
					w.WriteAttributeString("version", Application.ProductVersion);

					foreach(Server server in Globals.servers) {
						w.WriteStartElement("Server");

						w.WriteElementString("Name", server.ServerName);
						w.WriteElementString("IP", server.ServerIP);
						w.WriteElementString("Website", server.ServerWebsite);
						w.WriteElementString("Patch", server.ServerPatch);
						w.WriteElementString("Rating", server.ServerRating.ToString());
						w.WriteElementString("Notes", server.ServerNotes);
						w.WriteElementString("Profile", server.ServerProfile);

						w.WriteEndElement();
					}

					w.WriteEndElement();
					w.WriteEndDocument();
				}

				MessageBox.Show("Exported servers successfully!", "Success");
			}
			catch(Exception ex) {
				frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Exports profiles to a specified XML file.
		/// </summary>
		/// <param name="filename">File to export to</param>
		private void ExportProfilesXml(string filename) {
			try {
				XmlWriterSettings ws = new XmlWriterSettings();
				ws.Indent = true;
				ws.IndentChars = "\t";
				ws.NewLineOnAttributes = true;

				using(XmlWriter w = XmlWriter.Create(filename, ws)) {
					w.WriteStartDocument();
					w.WriteStartElement("Profiles");
					w.WriteAttributeString("provider", "Switchex");
					w.WriteAttributeString("version", Application.ProductVersion);

					foreach(Profile profile in Globals.profiles) {
						w.WriteStartElement("Profile");
						w.WriteAttributeString("default", profile.ProfileDefault.ToString());
						w.WriteAttributeString("type", profile.ProfileType.ToString());

						w.WriteElementString("Name", profile.ProfileName);
						w.WriteElementString("Path", profile.ProfilePath);
						w.WriteElementString("Description", profile.ProfileDesc);

						w.WriteEndElement();
					}

					w.WriteEndElement();
					w.WriteEndDocument();
				}

				MessageBox.Show("Exported profiles successfully!", "Success");
			}
			catch(Exception ex) {
				frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Imports servers from a specified XML file.
		/// </summary>
		/// <param name="filename">File to import from</param>
		private void ImportServersXml(string filename) {
			try {
				XDocument doc = XDocument.Load(filename);

				if(doc.Root.Attribute("provider").Value != "Switchex") {
					MessageBox.Show("The selected file does not contain any servers managed by Switchex.", "Import Failed");
				}
				else {
					var xmlServers = doc.Descendants("Server");
					
					foreach(var item in xmlServers) {
						using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
							using(SqlCeCommand cmd = new SqlCeCommand("INSERT INTO Servers (ServerName, ServerIP, ServerWebsite, ServerPatch, ServerRating, " +
								"ServerNotes, ServerProfile) VALUES (@name, @ip, @website, @patch, @rating, @notes, @profile)", conn)) {
								cmd.Parameters.AddWithValue("@name", SqlDbType.Text).Value = item.Element("Name").Value;
								cmd.Parameters.AddWithValue("@ip", SqlDbType.Text).Value = item.Element("IP").Value;
								cmd.Parameters.AddWithValue("@website", SqlDbType.Text).Value = item.Element("Website").Value;
								cmd.Parameters.AddWithValue("@patch", SqlDbType.Text).Value = item.Element("Patch").Value;
								cmd.Parameters.AddWithValue("@rating", SqlDbType.Int).Value = Convert.ToInt32(item.Element("Rating").Value);
								cmd.Parameters.AddWithValue("@notes", SqlDbType.Text).Value = item.Element("Notes").Value;

								if(Globals.profiles.Any(prof => prof.ProfileName == item.Element("Profile").Value)) {
									cmd.Parameters.AddWithValue("@profile", SqlDbType.Text).Value = item.Element("Profile").Value;
								}
								else {
									cmd.Parameters.AddWithValue("@profile",
										Globals.profiles.SingleOrDefault(p => p.ProfileDefault).ProfileName);
								}

								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}
					}

					MessageBox.Show("Imported servers successfully!", "Success");
				}
			}
			catch(Exception ex) {
				frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Imports profiles from a specified XML file.
		/// </summary>
		/// <param name="filename">File to import from</param>
		private void ImportProfilesXml(string filename) {
			List<string> skipped = new List<string>();
			int imported = 0;
			
			try {
				XDocument doc = XDocument.Load(filename);

				if(doc.Root.Attribute("provider").Value != "Switchex") {
					MessageBox.Show("The selected file does not contain any Switchex profiles.", "Import Failed");
				}
				else {
					var xmlProfiles = doc.Descendants("Profile");

					foreach(var item in xmlProfiles) {
						if(!Globals.profiles.Any(p => p.ProfileName == item.Element("Name").Value)) {
							using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
								using(SqlCeCommand cmd = new SqlCeCommand("INSERT INTO Profiles (ProfileName, ProfilePath, ProfileDescription, ProfileType) " +
									"VALUES (@name, @path, @desc, @type)", conn)) {
									cmd.Parameters.AddWithValue("@name", item.Element("Name").Value);
									cmd.Parameters.AddWithValue("@path", item.Element("Path").Value);
									cmd.Parameters.AddWithValue("@desc", item.Element("Description").Value);
									cmd.Parameters.AddWithValue("@type", item.Attribute("type").Value);

									conn.Open();
									cmd.ExecuteNonQuery();
								}
							}

							imported++;
						}
						else {
							skipped.Add(item.Element("Name").Value);
						}
					}

					if(skipped.Count == 0) {
						MessageBox.Show("Imported profiles successfully!", "Success");
					}
					else {
						string s = "Imported " + imported + " profiles. The following profiles already exist:\n\n";

						foreach(string item in skipped) {
							s += item + "\n";
						}

						MessageBox.Show(s, "Success");
					}
				}
			}
			catch(Exception ex) {
				frmError.ShowDialog(ex);
			}
		}
		#endregion
	}
}
