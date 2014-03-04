using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Win32;

/*
 * TODO: add search feature
 * TODO: text export of server list
 */

namespace Switchex {
	public partial class frmMain: Form {
		frmOptions frmOptions = new frmOptions();
		frmProfiles frmProfiles = new frmProfiles();
		frmAdd frmAdd = new frmAdd();
		frmEdit frmEdit = new frmEdit();
		frmAbout frmAbout = new frmAbout();
		frmCreateRealmlist frmCreateRealmlist = new frmCreateRealmlist();

		#region Main Events
		public frmMain() {
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e) {
			string wowInstall = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);

			if(Properties.Settings.Default.firstRun) {
				using(RegistryKey key = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Blizzard Entertainment\World of Warcraft")) {
					// if the registry key does not exist or InstallPath is blank
					if(key == null || key.GetValue("InstallPath").ToString() == "") {
						CheckForMainProfile(wowInstall);
					}
					// if the registry key exists
					else if(key != null) {
						wowInstall = key.GetValue("InstallPath").ToString();

						CheckForMainProfile(wowInstall);

						if(!File.Exists(wowInstall + "\\Data\\enUS\\realmlist.wtf") && !File.Exists(wowInstall + "\\Data\\enGB\\realmlist.wtf")) {
							frmCreateRealmlist.ShowDialog();
						}
					}
				}

				Properties.Settings.Default.firstRun = false;
				Properties.Settings.Default.Save();
			}

			if(!Directory.Exists(Application.StartupPath + "\\Backups")) {
				Directory.CreateDirectory(Application.StartupPath + "\\Backups");
			}

			CheckForMainProfile(wowInstall);

			Globals.GetProfiles();

			AddProfilesToDropDown();

			dgvServers.DefaultCellStyle.SelectionBackColor = Color.Gainsboro;
			dgvServers.DefaultCellStyle.SelectionForeColor = Color.Black;

			LoadColumnWidths();
			LoadWindowSize();
			RefreshList();
		}

		private void dgvServers_CellContentClick(object sender, DataGridViewCellEventArgs e) {
			if(e.ColumnIndex == 3 && e.RowIndex != -1) {
				try {
					Process.Start(dgvServers.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
				}
				catch(Exception ex) {
					Globals.frmError.ShowDialog(ex);
				}
			}
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			frmAdd.ShowDialog();
			RefreshList();
		}

		private void btnEdit_Click(object sender, EventArgs e) {
			if(dgvServers.SelectedRows.Count > 0) {
				frmEdit.ShowDialog();
				RefreshList();
			}
			else {
				MessageBox.Show("There is no row selected.", "Error");
			}
		}

		private void btnSet_Click(object sender, EventArgs e) {
			if(dgvServers.SelectedRows.Count > 0) {
				try {
					Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == cmbProfiles.Text);

					if(profile != null) {
						string fileUS = profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf",
							fileGB = profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf",
							exec32 = profile.ProfilePath + "\\Wow.exe",
							exec64 = profile.ProfilePath + "\\Wow-64.exe",
							file = "",
							text = "";

						// If realmlist.wtf does not exist
						if(!File.Exists(fileUS) && !File.Exists(fileGB)) {
							frmCreateRealmlist.ShowDialog();
						}
						// If realmlist.wtf and WoW executables exist
						else {
							// If realmlist.wtf is in the US folder
							if(File.Exists(fileUS)) {
								file = fileUS;
							}
							// If realmlist.wtf is in the GB folder
							else if(File.Exists(fileGB)) {
								file = fileGB;
							}

							// Read from the file and replace text
							text = File.ReadAllText(file);
							text = text.Remove(14, text.Substring(14, text.IndexOf(Environment.NewLine) - 14).Length);
							text = text.Insert(14, dgvServers.SelectedRows[0].Cells[2].Value.ToString());

							// Write the replaced text to a local file
							File.WriteAllText(Application.StartupPath + "\\realmlist.wtf", text);

							// And move it to the correct directory
							string[] args = { "true", Application.StartupPath + "\\realmlist.wtf", file };
							int fileAction = Globals.RunActionsExecutable(Globals.FileAction.CopyFile, args);

							if(fileAction == 0) {
								// If they want to open WoW after setting a server
								if(Properties.Settings.Default.openWow) {
									OpenWow();
								}
								else {
									MessageBox.Show("Server changed successfully.", "Success");
								}

								ToolstripInfo(false);
							}
							else if(fileAction != 5) {
								MessageBox.Show("Could not set server.", "Error");
							}
						}
					}
					else {
						MessageBox.Show("Cannot find a World of Warcraft installation with your current profile.", "Error");
					}
				}
				catch(Exception ex) {
					if(!ex.Message.Contains("canceled by the user")) {
						Globals.frmError.ShowDialog(ex);
					}
				}
			}
			else {
				MessageBox.Show("There is no row selected.", "Error");
			}
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			if(dgvServers.SelectedRows.Count > 0) {
				DialogResult delete = MessageBox.Show("Are you sure you want to delete " + dgvServers.SelectedRows[0].Cells[1].Value + "?", "Delete", MessageBoxButtons.YesNo);

				if(delete == DialogResult.Yes) {
					DeleteServer(dgvServers.SelectedRows[0].Cells[1].Value.ToString(), dgvServers.SelectedRows[0].Cells[2].Value.ToString());
				}

				RefreshList();
			}
			else {
				MessageBox.Show("There are no rows selected.", "Error");
			}
		}

		private void btnOpenWow_Click(object sender, EventArgs e) {
			OpenWow();
		}

		private void btnCheckOnline_Click(object sender, EventArgs e) {
			CheckOnline();
		}

		private void btnAddons_Click(object sender, EventArgs e) {
			frmAddons frmAddons = new frmAddons();

			try {
				frmAddons.ShowDialog();
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		private void cmbProfiles_DropDownItemClicked(object sender, ToolStripItemClickedEventArgs e) {
			if(e.ClickedItem != null) {
				cmbProfiles.Text = e.ClickedItem.Text;
			}
		}

		private void cmbProfiles_TextChanged(object sender, EventArgs e) {
			Properties.Settings.Default.currentProfile = cmbProfiles.Text;
			Globals.currentProfile = cmbProfiles.Text;

			if(cmbProfiles.Text == "All") {
				btnSet.Enabled = false;
				btnOpenWow.Enabled = false;
				btnAddons.Enabled = false;

				fileGameFolder.Enabled = false;
				fileAddonsFolder.Enabled = false;
				fileOpenRealmlist.Enabled = false;
			}
			else {
				btnSet.Enabled = true;
				btnOpenWow.Enabled = true;
				btnAddons.Enabled = true;

				fileGameFolder.Enabled = true;
				fileAddonsFolder.Enabled = true;
				fileOpenRealmlist.Enabled = true;
			}

			RefreshList();
		}

		private void btnExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			if(!Globals.resetSettings) {
				Properties.Settings.Default.currentProfile = cmbProfiles.Text;
				Properties.Settings.Default.windowSize = Width + "," + Height;

				Properties.Settings.Default.columnWidths = 
					dgvServers.Columns[0].Width + "," + 
					dgvServers.Columns[1].Width + "," + 
					dgvServers.Columns[2].Width + "," + 
					dgvServers.Columns[3].Width + "," + 
					dgvServers.Columns[4].Width + "," + 
					dgvServers.Columns[5].Width + "," + 
					dgvServers.Columns[6].Width + "," +
					dgvServers.Columns[7].Width;

				Properties.Settings.Default.Save();
			}
		}

		private void dgvServers_SelectionChanged(object sender, EventArgs e) {
			if(dgvServers.Rows.Count > 0) {
				if(dgvServers.SelectedRows.Count > 0) {
					Globals.selectedName = dgvServers.SelectedRows[0].Cells[1].Value.ToString();
					Globals.selectedIP = dgvServers.SelectedRows[0].Cells[2].Value.ToString();
					Globals.selectedWebsite = dgvServers.SelectedRows[0].Cells[3].Value.ToString();
					Globals.selectedPatch = dgvServers.SelectedRows[0].Cells[4].Value.ToString();
					Globals.selectedRating = dgvServers.SelectedRows[0].Cells[5].Value.ToString();
					Globals.selectedNotes = dgvServers.SelectedRows[0].Cells[6].Value.ToString();
					Globals.selectedProfile = dgvServers.SelectedRows[0].Cells[7].Value.ToString();
					Globals.selectedID = dgvServers.SelectedRows[0].Cells[8].Value.ToString();
				}
				else {
					Globals.selectedName = null;
					Globals.selectedIP = null;
					Globals.selectedWebsite = null;
					Globals.selectedPatch = null;
					Globals.selectedRating = null;
					Globals.selectedNotes = null;
					Globals.selectedProfile = null;
					Globals.selectedID = null;
				}
			}
		}
		#endregion

		#region File Menu
		private void fileOptions_Click(object sender, EventArgs e) {
			frmOptions.ShowDialog();
			RefreshList();
		}
		
		private void fileProfiles_Click(object sender, EventArgs e) {
			frmProfiles.ShowDialog();
			AddProfilesToDropDown();
			RefreshList();
		}

		private void fileGameFolder_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);

			if(profile != null) {
				Process.Start(profile.ProfilePath);
			}
			else {
				MessageBox.Show("Cannot find a World of Warcraft installation with the current profile.", "Error");
			}
		}

		private void fileAddonsFolder_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);

			if(profile != null) {
				string addonsPath = profile.ProfilePath + "\\Interface\\Addons\\";

				if(Directory.Exists(addonsPath)) {
					Process.Start(addonsPath);
				}
				else {
					MessageBox.Show("Cannot find a World of Warcraft addons folder with the current profile.", "Error");
				}
			}
			else {
				MessageBox.Show("Cannot find a World of Warcraft addons folder with the current profile.", "Error");
			}
		}

		private void fileOpenRealmlist_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);

			if(profile != null) {
				if(File.Exists(profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf")) {
					Process.Start("notepad.exe", profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf");
				}
				else if(File.Exists(profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf")) {
					Process.Start("notepad.exe", profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf");
				}
				else {
					if(frmCreateRealmlist.ShowDialog() == DialogResult.Yes) {
						if(File.Exists(profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf")) {
							Process.Start("notepad.exe", profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf");
						}
						else if(File.Exists(profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf")) {
							Process.Start("notepad.exe", profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf");
						}
					}
				}
			}
			else {
				MessageBox.Show("Cannot find realmlist.wtf with your current profile.", "Error");
			}
		}

		private void fileRefresh_Click(object sender, EventArgs e) {
			RefreshList();
		}

		private void fileExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}
		#endregion

		#region Server Lists Menu
		private void slGamesTop100_Click(object sender, EventArgs e) {
			Process.Start("http://www.gtop100.com/");
		}

		private void slTop100Arena_Click(object sender, EventArgs e) {
			Process.Start("http://wow.top100arena.com/");
		}

		private void slXtremeTop100_Click(object sender, EventArgs e) {
			Process.Start("http://xtremetop100.com/world-of-warcraft");
		}

		private void slGameSites200_Click(object sender, EventArgs e) {
			Process.Start("http://www.gamesites200.com/wowprivate/");
		}

		private void slMmorpgTL_Click(object sender, EventArgs e) {
			Process.Start("http://www.mmorpgtoplist.com/world-of-warcraft");
		}

		private void slWowServers_Click(object sender, EventArgs e) {
			Process.Start("http://wows.top-site-list.com/");
		}

		private void slTop1000_Click(object sender, EventArgs e) {
			Process.Start("http://wow.top-site-list.com/");
		}
		#endregion

		#region Guides and Wikis Menu
		private void webWowWiki_Click(object sender, EventArgs e) {
			Process.Start("http://www.wowwiki.com/");
		}

		private void webThottbot_Click(object sender, EventArgs e) {
			Process.Start("http://thottbot.com/");
		}

		private void webZamWow_Click(object sender, EventArgs e) {
			Process.Start("http://wow.allakhazam.com/");
		}

		private void webGotWarcraft_Click(object sender, EventArgs e) {
			Process.Start("http://gotwarcraft.com/");
		}

		private void webFreeWarcraftGuides_Click(object sender, EventArgs e) {
			Process.Start("http://freewarcraftguides.com/");
		}

		private void webOnlineMultiplayer_Click(object sender, EventArgs e) {
			Process.Start("http://www.online-multiplayer.com/wow/");
		}

		private void webWowProfessions_Click(object sender, EventArgs e) {
			Process.Start("http://www.wow-professions.com/");
		}

		private void webWowPopular_Click(object sender, EventArgs e) {
			Process.Start("http://www.wowpopular.com/");
		}
		#endregion

		#region Help Menu
		private void helpWebSwitchex_Click(object sender, EventArgs e) {
			Process.Start("http://switchex.abluescarab.us/");
		}

		private void helpWebAbluescarab_Click(object sender, EventArgs e) {
			Process.Start("http://www.abluescarab.us/");
		}

		private void helpWebSourceForge_Click(object sender, EventArgs e) {
			Process.Start("http://sourceforge.net/projects/switchex/");
		}

		private void helpWebGitHub_Click(object sender, EventArgs e) {
			Process.Start("http://github.com/abluescarab/Switchex/releases");
		}

		private void helpWebWow_Click(object sender, EventArgs e) {
			Process.Start("http://us.battle.net/wow/en/");
		}

		private void helpWebBattlenet_Click(object sender, EventArgs e) {
			Process.Start("http://us.battle.net/en/");
		}

		private void helpUpdates_Click(object sender, EventArgs e) {
			Globals.blnUpdates = true;
			CheckUpdates();
		}

		private void helpChangelog_Click(object sender, EventArgs e) {
			try {
				Process.Start("notepad.exe", Globals.changelogFile);
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		private void helpHelpTopics_Click(object sender, EventArgs e) {
			try {
				Process.Start(Globals.helpFile);
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		private void helpAbout_Click(object sender, EventArgs e) {
			frmAbout.ShowDialog();
		}
		#endregion

		#region Methods
		/// <summary>
		/// Check for updates and open the updates confirmation form.
		/// </summary>
		private void CheckUpdates() {
			Cursor = Cursors.WaitCursor;

			frmConfirmUpdate frmConfirmUpdate = new frmConfirmUpdate();

			string versionFile = Application.StartupPath + "\\version.txt";
			string readmeFile = Application.StartupPath + "\\readme.txt";
			string currentVersion = Application.ProductVersion;

			WebClient webClient = new WebClient();

			if(File.Exists(versionFile)) {
				File.Delete(versionFile);
			}

			webClient.DownloadFile("http://www.abluescarab.us/updates/switchex/version.txt", versionFile);

			Globals.downloadVersion = File.ReadAllText(versionFile);

			if(Globals.CompareVersions(currentVersion, Globals.downloadVersion) >= 0) {
				if(Globals.blnUpdates) {
					MessageBox.Show("There are no updates available at this time.", "Updates");
				}
			}
			else if(Globals.CompareVersions(currentVersion, Globals.downloadVersion) == -1) {
				webClient.DownloadFile("http://www.abluescarab.us/updates/switchex/" + Globals.downloadVersion + ".txt", readmeFile);
				frmConfirmUpdate.ShowDialog();
			}

			File.Delete(versionFile);
			File.Delete(readmeFile);

			Globals.blnUpdates = false;

			Cursor = Cursors.Default;
		}

		/// <summary>
		/// Refresh the server list.
		/// </summary>
		private void RefreshList() {
			try {
				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(DataTable dt = new DataTable()) {
						using(SqlCeDataAdapter adapter = new SqlCeDataAdapter("SELECT * FROM Servers", conn)) {
							Globals.servers.Clear(); 
							dgvServers.Rows.Clear();
							adapter.Fill(dt);

							foreach(DataRow row in dt.Rows) {
								Globals.servers.Add(new Server(
									Convert.ToInt32(row.ItemArray[0]),
									row.ItemArray[1].ToString(),
									row.ItemArray[2].ToString(),
									row.ItemArray[3].ToString(),
									row.ItemArray[4].ToString(),
									Convert.ToInt32(row.ItemArray[5]),
									row.ItemArray[6].ToString(),
									row.ItemArray[7].ToString()));
							}

							if(cmbProfiles.Text != "All") {
								var query = Globals.servers.Where(item => item.ServerProfile == cmbProfiles.Text);

								foreach(Server server in query) {
									dgvServers.Rows.Add(null, server.ServerName, server.ServerIP,
										server.ServerWebsite, server.ServerPatch, server.ServerRating,
										server.ServerNotes, server.ServerProfile, server.ServerID);
								}
							}
							else {
								foreach(Server server in Globals.servers) {
									dgvServers.Rows.Add(null, server.ServerName, server.ServerIP,
										server.ServerWebsite, server.ServerPatch, server.ServerRating,
										server.ServerNotes, server.ServerProfile, server.ServerID);
								}
							}
						}
					}
				}

				Globals.rowCount = dgvServers.Rows.Count;

				if(cmbProfiles.Text != "All") {
					ToolstripInfo(false);
				}
				else {
					ToolstripInfo(true);
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Load column widths from user settings.
		/// </summary>
		private void LoadColumnWidths() {
			string[] widths = { "43", "133", "100", "133", "60", "63", "133", "133" };

			if(Properties.Settings.Default.columnWidths.Contains(' ')) {
				widths = Properties.Settings.Default.columnWidths.Split(' ');
			}
			else if(Properties.Settings.Default.columnWidths.Contains(',')) {
				widths = Properties.Settings.Default.columnWidths.Split(',');
			}
			
			for(int i = 0; i < widths.Count(); i++) {
				dgvServers.Columns[i].Width = Convert.ToInt32(widths[i]);
			}
		}

		/// <summary>
		/// Load the window size from user settings.
		/// </summary>
		private void LoadWindowSize() {
			string[] size = { "914", "410" };

			if(Properties.Settings.Default.windowSize.Contains(' ')) {
				size = Properties.Settings.Default.windowSize.Split(' ');
			}
			else if(Properties.Settings.Default.windowSize.Contains(',')) {
				size = Properties.Settings.Default.windowSize.Split(',');
			}

			Width = Convert.ToInt32(size[0]);
			Height = Convert.ToInt32(size[1]);
		}
		
		/// <summary>
		/// Update the toolstrip information based on the current profile.
		/// </summary>
		/// <param name="clear">Clear all information or not</param>
		private void ToolstripInfo(bool clear) {
			if(!clear) {
				try {
					Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == cmbProfiles.Text);

					if(profile != null) {
						string exec32 = profile.ProfilePath + "\\Wow.exe",
						exec64 = profile.ProfilePath + "\\Wow-64.exe",
						realmUS = profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf",
						realmGB = profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf",
						currentPatch = null,
						currentServer = null;

						if(File.Exists(exec32)) {
							currentPatch = FileVersionInfo.GetVersionInfo(exec32).FileVersion;
						}
						else if(File.Exists(exec64)) {
							currentPatch = FileVersionInfo.GetVersionInfo(exec64).FileVersion;
						}

						if(File.Exists(realmUS)) {
							using(StreamReader realmlist = new StreamReader(realmUS)) {
								string line = realmlist.ReadLine();

								if(line != null && line.Length > 0) {
									currentServer = line.Substring(14);
								}
							}
						}
						else if(File.Exists(realmGB)) {
							using(StreamReader realmlist = new StreamReader(realmGB)) {
								string line = realmlist.ReadLine();

								if(line != null && line.Length > 0) {
									currentServer = line.Substring(14);
								}
							}
						}

						if(currentPatch != null) {
							currentPatch = currentPatch.Replace(", ", ".");
							statusPatch.Text = "Patch " + currentPatch;
						}
						else {
							statusPatch.Text = "No patch specified.";
						}

						if(currentServer != null) {
							statusServer.Text = currentServer;
						}
						else {
							statusServer.Text = "No server specified.";
						}

						statusLocation.Text = profile.ProfilePath;
					}
				}
				catch(Exception ex) {
					Globals.frmError.ShowDialog(ex);
				}
			}
			else {
				statusPatch.Text = "No patch specified.";
				statusServer.Text = "No server specified.";
				statusLocation.Text = "None.";
			}
		}

		/// <summary>
		/// Delete a server from the server list.
		/// </summary>
		/// <param name="serverName">The server name</param>
		/// <param name="serverIP">The server IP</param>
		private void DeleteServer(string serverName, string serverIP) {
			try {
				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Servers WHERE ID=@id", conn)) {
						cmd.Parameters.AddWithValue("@id", dgvServers.SelectedRows[0].Cells[8].Value.ToString());

						conn.Open();
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show(serverName + " deleted successfully.", "Deletion Success");
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Check if all servers are online.
		/// </summary>
		private void CheckOnline() {
			try {
				if(dgvServers.Rows.Count > 0) {
					Cursor = Cursors.WaitCursor;

					int curRow = 0, rowCount = dgvServers.RowCount;
					bool rtn;

					while(curRow < rowCount) {
						dgvServers.Rows[curRow].Selected = true;

						rtn = PingServer(dgvServers.SelectedRows[0].Cells[2].Value.ToString());

						if(rtn) {
							dgvServers.SelectedRows[0].Cells[0].Value = CheckState.Checked;
						}
						else {
							dgvServers.SelectedRows[0].Cells[0].Value = CheckState.Unchecked;
						}
						dgvServers.ClearSelection();

						curRow += 1;
					}

					Cursor = Cursors.Default;
				}
				else {
					MessageBox.Show("The server list is empty. Please add more servers by clicking the Add button.", "Error");
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Check if the Main profile exists. If it does not and there are no other profiles, create it.
		/// </summary>
		private void CheckForMainProfile(string path) {
			try {
				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Profiles", conn)) {
						using(DataSet ds = new DataSet()) {
							using(SqlCeDataAdapter adapter = new SqlCeDataAdapter(cmd)) {
								adapter.SelectCommand = cmd;

								adapter.Fill(ds);

								if(ds.Tables[0].Rows.Count == 0) {
									cmd.CommandText = "INSERT INTO Profiles (ProfileName, ProfilePath, ProfileDescription, ProfileType, ProfileDefault) " +
										"VALUES ('Main', @path, 'Main profile.', 32, 1)";
									cmd.Parameters.AddWithValue("@path", path);

									conn.Open();
									cmd.ExecuteNonQuery();

									Properties.Settings.Default.currentProfile = "Main";
								}
							}
						}
					}
				}

				Globals.GetProfiles();
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Add all the profiles to the dropdown in the statusStrip.
		/// </summary>
		private void AddProfilesToDropDown() {
			try {
				cmbProfiles.DropDownItems.Clear();
				cmbProfiles.DropDownItems.Add("All");

				foreach(Profile profile in Globals.profiles) {
					cmbProfiles.DropDownItems.Add(profile.ProfileName);
				}

				if(Globals.profiles.SingleOrDefault(item => item.ProfileName == Properties.Settings.Default.currentProfile) == null) {
					cmbProfiles.Text = cmbProfiles.DropDownItems[0].Text;
				}
				else {
					cmbProfiles.Text = Properties.Settings.Default.currentProfile;
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Opens World of Warcraft.
		/// </summary>
		private void OpenWow() {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == cmbProfiles.Text);

			if(profile != null) {
				string exec32 = profile.ProfilePath + "\\Wow.exe",
					exec64 = profile.ProfilePath + "\\Wow-64.exe";

				// If the current profile calls Wow.exe
				if(profile.ProfileType == 32) {
					if(File.Exists(exec32)) {
						Process.Start(exec32);
					}
					else {
						MessageBox.Show("Wow.exe does not exist in your profile location. Are you sure it is " +
							"a valid World of Warcraft installation?", "Error");
					}
				}
				// If the current profile calls Wow-64.exe
				else {
					if(File.Exists(exec64)) {
						Process.Start(exec64);
					}
					else {
						MessageBox.Show("Wow-64.exe does not exist in your profile location. Are you sure it is " +
							"a valid World of Warcraft installation?", "Error");
					}
				}
			}
			else {
				MessageBox.Show("Cannot find World of Warcraft executables with the current profile.", "Error");
			}
		}

		/// <summary>
		/// Ping a server to see if it's online.
		/// </summary>
		/// <param name="address">The IP of the server</param>
		/// <returns></returns>
		public bool PingServer(string address) {
			Ping ping = new Ping();
			PingReply pingReply;

			try {
				pingReply = ping.Send(address, 1000);

				if(pingReply.Status == IPStatus.Success) {
					return true;
				}
				else {
					return false;
				}
			}
			catch {
				return false;
			}
		}
		#endregion
	}
}
