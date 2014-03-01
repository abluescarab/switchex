using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.IO;
//using System.Linq;
//using System.Security.Policy;
//using System.Security.Principal;
//using System.Security.AccessControl;
using System.Security;
using System.Security.Permissions;
//using System.Text;
//using System.Windows.Forms;

namespace Switchex {
	public class Globals {
		public static frmError frmError = new frmError();

		public static List<Profile> profiles = new List<Profile>();

		public enum FileAction {
			CreateFolder,
			DeleteFolder,
			CreateFile,
			WriteFile,
			CopyFile,
			DeleteFile,
			CreateBoth
		};

		public static bool blnUpdates = false,
			resetSettings = false;
		public static int rowCount = 0;
		public static string
			downloadVersion = null,
			selectedID = null,
			selectedName = null,
			selectedIP = null,
			selectedWebsite = null,
			selectedPatch = null,
			selectedRating = null,
			selectedNotes = null,
			selectedProfile = null,
			currentProfile = null,
			changelogFile = System.Windows.Forms.Application.StartupPath + "\\Resources\\changelog.txt",
			helpFile = System.Windows.Forms.Application.StartupPath + "\\Resources\\Switchex Help.html";

		public static int RunActionsExecutable(FileAction action, string[] args) {
			Process p = new Process();
			p.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
			p.StartInfo.FileName = "fileactions.exe";
			p.StartInfo.UseShellExecute = true;

			try {
				switch(action) {
					case FileAction.WriteFile:
						// args: change "path\to\file" "text to write"
						// note: can only be a text file (any extension)
						p.StartInfo.Arguments = "write \"" + args[0] + "\" \"\"" + args[1] + "\"\"";
						break;
					case FileAction.CreateBoth:
						// args: create both "path\to\folder" "path\to\file" ["text to write"]
						p.StartInfo.Arguments = "create both \"" + args[0] + "\" \"" + args[1] + "\"";

						if(args.Length > 2 && args[2] != null) {
							p.StartInfo.Arguments += " \"\"" + args[2] + "\"\"";
						}
						break;
					case FileAction.CreateFile:
						// args: create file "path\to\file" ["text to write"]
						// note: ["text to write"] is for text files (any extension)
						p.StartInfo.Arguments = "create file \"" + args[0] + "\"";

						if(args.Length > 1 && args[1] != null) {
							p.StartInfo.Arguments += " \"\"" + args[1] + "\"\"";
						}
						break;
					case FileAction.CreateFolder:
						// args: create folder "path\to\create"
						p.StartInfo.Arguments = "create folder \"" + args[0] + "\"";
						break;
					case FileAction.DeleteFile:
						// args: delete file "path\to\file"
						p.StartInfo.Arguments = "delete file \"" + args[0] + "\"";
						break;
					case FileAction.DeleteFolder:
						// args: delete folder "path\to\delete"
						p.StartInfo.Arguments = "delete folder \"" + args[0] + "\"";
						break;
					case FileAction.CopyFile:
						// args: copy "true/false" (delete source file) "file\to\copy" "path\to\new\location"
						p.StartInfo.Arguments = "copy " + args[0] + " \"" + args[1] + "\" \"" + args[2] + "\"";
						break;
				}

				p.Start();
				p.WaitForExit();

				if(p.ExitCode == 1) {
					p.StartInfo.Verb = "runas";
					p.Start();
					p.WaitForExit();

					if(p.ExitCode != 0) {
						return -1;
					}
				}

				return p.ExitCode;
			}
			catch(Exception ex) {
				if(ex.Message.Contains("canceled by the user")) {
					return 5;
				}

				return -1;
			}
		}

		/// <summary>
		/// Get all profiles and add them to a global list.
		/// </summary>
		public static void GetProfiles() {
			profiles.Clear();

			try {
				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(SqlCeCommand cmd = new SqlCeCommand("SELECT * FROM Profiles", conn)) {
						using(DataSet ds = new DataSet()) {
							using(SqlCeDataAdapter adapter = new SqlCeDataAdapter(cmd)) {
								adapter.SelectCommand = cmd;

								adapter.Fill(ds);

								foreach(DataRow row in ds.Tables[0].Rows) {
									profiles.Add(new Profile(false, Convert.ToInt32(row.ItemArray[0])));
								}

								Globals.profiles.Sort((x, y) => x.ProfileName.CompareTo(y.ProfileName));
							}
						}
					}
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}
	}
}
