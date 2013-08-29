using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
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

namespace Switchex {
	public partial class frmMain: Form {
		frmOptions frmOptions = new frmOptions();
		frmAdd frmAdd = new frmAdd();
		frmEdit frmEdit = new frmEdit();
		frmAbout frmAbout = new frmAbout();

		public static bool blnUpdates = false;
		public static string
			downloadVersion = null, executablePath = null,
			currentName = null, currentIP = null, currentWebsite = null, currentPatch = null,
			currentRating = null, currentNotes = null;
		public static int rowCount = 0;

		public static string changelogFile = Application.StartupPath + "\\Resources\\changelog.txt",
			helpFile = Application.StartupPath + "\\Resources\\Switchex Help.html";

		#region Main Events
		public frmMain() {
			InitializeComponent();
		}

		private void frmMain_Load(object sender, EventArgs e) {
			if(Properties.Settings.Default.firstRun == true) {
				using(RegistryKey Key = Registry.LocalMachine.OpenSubKey(@"HKEY_LOCAL_MACHINE\SOFTWARE\Blizzard Entertainment\World of Warcraft")) {
					if(Key != null) {
						Properties.Settings.Default.gamePath = Key.GetValue("InstallPath").ToString() + "\\";
						//Registry.GetValue("HKEY_LOCAL_MACHINE\\SOFTWARE\\Blizzard Entertainment\\World of Warcraft", "InstallPath", "null").ToString();

						if(Properties.Settings.Default.gamePath == null) {
							MessageBox.Show("Cannot find your World of Warcraft installation. Please set the location manually through the Options window.", "Error");
						}
						else {
							executablePath = Properties.Settings.Default.gamePath + "Wow.exe";

							if(File.Exists(Properties.Settings.Default.gamePath + "Data\\enUS\\realmlist.wtf")) {
								Properties.Settings.Default.realmPath = Properties.Settings.Default.gamePath + "Data\\enUS\\realmlist.wtf";
								Properties.Settings.Default.installType = "enUS";
							}
							else if(File.Exists(Properties.Settings.Default.gamePath + "Data\\enGB\\realmlist.wtf")) {
								Properties.Settings.Default.realmPath = Properties.Settings.Default.gamePath + "Data\\enGB\\realmlist.wtf";
								Properties.Settings.Default.installType = "enGB";
							}
							else {
								MessageBox.Show("Cannot find your realmlist.wtf file. Please set the location manually through the Options window.", "Cannot Find Realmlist.wtf");
							}
						}
					}
					else {
						MessageBox.Show("Cannot find your World of Warcraft installation. Please set the location manually through the Options window.", "Error");
					}
				}

				Properties.Settings.Default.firstRun = false;
			}
			else {
				if(Properties.Settings.Default.bit64 == false) {
					executablePath = Properties.Settings.Default.gamePath + "Wow.exe";
				}
				else {
					executablePath = Properties.Settings.Default.gamePath + "Wow-64.exe";
				}
			}

			if(Properties.Settings.Default.realmPath != "" && !File.Exists(Properties.Settings.Default.realmPath) &&
				Properties.Settings.Default.gamePath != null && Properties.Settings.Default.gamePath != "") {
				DialogResult createList = MessageBox.Show("Realmlist.wtf does not exist. Would you like to create it?", "Realmlist.wtf Creation", MessageBoxButtons.YesNo);

				if(createList == DialogResult.Yes) {
					if(Properties.Settings.Default.installType == "enUS") {
						File.WriteAllText(Properties.Settings.Default.realmPath,
							"set realmlist us.logon.worldofwarcraft.com" + Environment.NewLine +
							"set patchlist enUS.patch.battle.net" + Environment.NewLine +
							"set realmlistbn \"\"" + Environment.NewLine +
							"set portal us");
					}
					else if(Properties.Settings.Default.installType == "enGB") {
						File.WriteAllText(Properties.Settings.Default.realmPath,
							"set realmlist eu.logon.worldofwarcraft.com\n" + Environment.NewLine +
							"set patchlist enGB.patch.battle.net:1119/patch\n" + Environment.NewLine +
							"set realmlistbn \"\"\n" + Environment.NewLine +
							"set portal eu");
					}
				}
			}

			refreshList();
			loadColumnWidths();
			loadWindowSize();
		}

		private void frmMain_Resize(object sender, EventArgs e) {
			Properties.Settings.Default.windowSize = Width + " " + Height;
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			frmAdd.ShowDialog();
			refreshList();
		}

		private void btnEdit_Click(object sender, EventArgs e) {
			if(dgvServers.SelectedRows.Count > 0) {
				currentName = dgvServers.SelectedRows[0].Cells[1].Value.ToString();
				currentIP = dgvServers.SelectedRows[0].Cells[2].Value.ToString();
				currentWebsite = dgvServers.SelectedRows[0].Cells[3].Value.ToString();
				currentPatch = dgvServers.SelectedRows[0].Cells[4].Value.ToString();
				currentRating = dgvServers.SelectedRows[0].Cells[5].Value.ToString();
				currentNotes = dgvServers.SelectedRows[0].Cells[6].Value.ToString();

				frmEdit.ShowDialog();
				refreshList();
			}
			else {
				MessageBox.Show("There is no row selected.", "Error");
			}
		}

		private void btnSet_Click(object sender, EventArgs e) {
			if(dgvServers.SelectedRows.Count > 0) {
				try {
					string text = File.ReadAllText(Properties.Settings.Default.realmPath);
					text = text.Remove(14, text.Substring(14, text.IndexOf(Environment.NewLine) - 14).Length);
					text = text.Insert(14, dgvServers.SelectedRows[0].Cells[2].Value.ToString());

					File.WriteAllText(Properties.Settings.Default.realmPath, text);

					if(Properties.Settings.Default.openWow == true) {
						Process.Start(executablePath);
					}
					else {
						MessageBox.Show("Server changed successfully.", "Success");
					}

					toolstripInfo();
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message, "Error");
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
					deleteServer(dgvServers.SelectedRows[0].Cells[1].Value.ToString());
				}

				refreshList();
			}
			else {
				MessageBox.Show("There are no rows selected.", "Error");
			}
		}

		private void btnOpenWebsite_Click(object sender, EventArgs e) {
			if(dgvServers.SelectedRows.Count > 0) {
				try {
					for(int i = 0; i < dgvServers.SelectedRows.Count; i++) {
						Process.Start(dgvServers.SelectedRows[i].Cells[3].Value.ToString());
					}
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message, "Error");
				}
			}
			else {
				MessageBox.Show("There is no row selected.", "Error");
			}
		}

		private void btnOpenWow_Click(object sender, EventArgs e) {
			if(executablePath != null) {
				try {
					Process.Start(executablePath);
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message, "Error");
				}
			}
			else {
				MessageBox.Show("The WoW path is not set.", "Error");
			}
		}

		private void btnCheckOnline_Click(object sender, EventArgs e) {
			checkOnline();
		}

		private void btnAddons_Click(object sender, EventArgs e) {
			frmAddons frmAddons = new frmAddons();

			try {
				frmAddons.ShowDialog();
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void btnExit_Click(object sender, EventArgs e) {
			Application.Exit();
		}

		private void frmMain_FormClosing(object sender, FormClosingEventArgs e) {
			if(frmOptions.resetSettings == false) {
				Properties.Settings.Default.windowSize = Width + " " + Height;
				Properties.Settings.Default.columnWidths = dgvServers.Columns[0].Width + " " + dgvServers.Columns[1].Width + " " + dgvServers.Columns[2].Width +
					" " + dgvServers.Columns[3].Width + " " + dgvServers.Columns[4].Width + " " + dgvServers.Columns[5].Width + " " + dgvServers.Columns[6].Width;
				Properties.Settings.Default.Save();
			}
		}
		#endregion

		#region File Menu
		private void fileOptions_Click(object sender, EventArgs e) {
			frmOptions.ShowDialog();
			refreshList();
		}

		private void fileGameFolder_Click(object sender, EventArgs e) {
			if(Properties.Settings.Default.gamePath == "" && Properties.Settings.Default.gamePath != "") {
				MessageBox.Show("Cannot find your World of Warcraft installation. If WoW is installed, please manually set the path in the Options window.", "Error");
			}
			else {
				Process.Start(Properties.Settings.Default.gamePath);
			}
		}

		private void fileAddonsFolder_Click(object sender, EventArgs e) {
			string addonsPath = Properties.Settings.Default.gamePath + "Interface\\Addons\\";

			if(Directory.Exists(addonsPath)) {
				Process.Start(addonsPath);
			}
			else {
				MessageBox.Show("Cannot find your World of Warcraft addons folder. Please set your addons folder manually in the Options window.", "Error");
			}
		}

		private void fileOpenRealmlist_Click(object sender, EventArgs e) {
			if(Properties.Settings.Default.realmPath != "" && Properties.Settings.Default.realmPath != null) {
				Process.Start("notepad.exe", Properties.Settings.Default.realmPath);
			}
			else {
				MessageBox.Show("Cannot find your realmlist.wtf file. Please set the location manually through the Options window.", "Error");
			}
		}

		private void fileRefresh_Click(object sender, EventArgs e) {
			refreshList();
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
			blnUpdates = true;
			checkUpdates();
		}

		private void helpChangelog_Click(object sender, EventArgs e) {
			try {
				Process.Start("notepad.exe", changelogFile);
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void helpHelpTopics_Click(object sender, EventArgs e) {
			try {
				Process.Start(helpFile);
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void helpAbout_Click(object sender, EventArgs e) {
			frmAbout.ShowDialog();
		}
		#endregion

		#region Methods
		private void checkUpdates() {
			Cursor = Cursors.WaitCursor;

			frmConfirmUpdate frmConfirmUpdate = new frmConfirmUpdate();

			string versionFile = Application.StartupPath + "\\version.txt";
			string readmeFile = Application.StartupPath + "\\readme.txt";
			string currentVersion = Application.ProductVersion;

			WebClient webClient = new WebClient();

			if(File.Exists(versionFile)) {
				File.Delete(versionFile);
			}

			webClient.DownloadFile("http://switchex.abluescarab.us/updates/version.txt", versionFile);

			downloadVersion = File.ReadAllText(versionFile);

			if(compareVersions(currentVersion, downloadVersion) >= 0) {
				if(frmMain.blnUpdates == true) {
					MessageBox.Show("There are no updates available at this time.", "Updates");
				}
			}
			else if(compareVersions(currentVersion, downloadVersion) == -1) {
				Debug.Print("http://switchex.abluescarab.us/updates/" + downloadVersion + ".txt");
				webClient.DownloadFile("http://switchex.abluescarab.us/updates/" + downloadVersion + ".txt", readmeFile);
				frmConfirmUpdate.ShowDialog();
			}

			File.Delete(versionFile);
			File.Delete(readmeFile);

			blnUpdates = false;

			Cursor = Cursors.Default;
		}

		private void refreshList() {
			try {
				OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\WoWServer.accdb");
				DataTable dt = new DataTable();
				OleDbDataAdapter adapter = new OleDbDataAdapter("SELECT * FROM ServerInfo", conn);

				dgvServers.Rows.Clear();
				adapter.Fill(dt);

				foreach(DataRow row in dt.Rows) {
					dgvServers.Rows.Add(null, row.ItemArray[1], row.ItemArray[2], row.ItemArray[3], row.ItemArray[4], row.ItemArray[5], row.ItemArray[6]);
				}

				rowCount = dgvServers.Rows.Count;

				toolstripInfo();
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void loadColumnWidths() {
			string[] widths = Properties.Settings.Default.columnWidths.Split(' ');

			for(int i = 0; i < dgvServers.ColumnCount; i++) {
				dgvServers.Columns[i].Width = Convert.ToInt32(widths[i]);
			}
		}

		private void loadWindowSize() {
			string[] setting = Properties.Settings.Default.windowSize.Split(' ');
			Width = Convert.ToInt32(setting[0]);
			Height = Convert.ToInt32(setting[1]);
		}

		private void toolstripInfo() {
			try {
				if(Properties.Settings.Default.gamePath != null && Properties.Settings.Default.gamePath != "" &&
					Properties.Settings.Default.realmPath != null && Properties.Settings.Default.realmPath != "") {
					string currentPatch = FileVersionInfo.GetVersionInfo(executablePath).FileVersion;
					string currentServer = null;

					using(StreamReader realmFile = new StreamReader(Properties.Settings.Default.realmPath)) {
						string line = realmFile.ReadLine();
						currentServer = line.Substring(14);
					}

					if(currentPatch != null) {
						currentPatch = currentPatch.Replace(", ", ".");
						lblCurrentPatch.Text = "Patch " + currentPatch;
					}
					else {
						lblCurrentPatch.Text = "No patch specified.";
					}

					if(currentServer != null) {
						lblCurrentServer.Text = currentServer;
					}
					else {
						lblCurrentServer.Text = "No server specified.";
					}
				}
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void deleteServer(string serverName) {
			try {
				OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\WoWServer.accdb");
				OleDbCommand cmd = new OleDbCommand();

				cmd.Connection = conn;
				conn.Open();

				cmd.CommandText = "DELETE FROM ServerInfo WHERE ServerName='" + dgvServers.SelectedRows[0].Cells[1].Value.ToString() + "' AND ServerIP='" +
					dgvServers.SelectedRows[0].Cells[2].Value.ToString() + "'";

				cmd.ExecuteNonQuery();
				conn.Close();

				MessageBox.Show(dgvServers.SelectedRows[0].Cells[1].Value.ToString() + " deleted successfully.", "Success");
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}

		private void checkOnline() {
			if(dgvServers.Rows.Count > 0) {
				Cursor = Cursors.WaitCursor;

				int curRow = 0, rowCount = dgvServers.RowCount;
				bool rtn;

				while(curRow < rowCount) {
					dgvServers.Rows[curRow].Selected = true;

					rtn = pingServer(dgvServers.SelectedRows[0].Cells[2].Value.ToString());

					if(rtn == true) {
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

		public bool pingServer(string address) {
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

		public int compareVersions(String versionStart, String versionCompare) {
			Version vStart = new Version(versionStart);
			Version vComp = new Version(versionCompare);

			int answer = vStart.CompareTo(vComp);

			return answer;
		}
		#endregion
	}
}
