using System;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Switchex {
	public class Profile {
		public static int newProfileID { get; set; }

		public string ProfileName { get; set; }
		public string ProfilePath { get; set; }
		public string ProfileDesc { get; set; }
		public int ProfileType { get; set; }
		public bool ProfileDefault { get; set; }
		public int ProfileID { get; set; }

		public Profile(bool isNew, int id) {
			try {
				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(SqlCeCommand cmd = new SqlCeCommand("", conn)) {
						if(isNew) {
							int nextNew = 1;

							conn.Open();

							foreach(Profile profile in Globals.profiles) {
								if(profile.ProfileName.Contains("New Profile ") && profile.ProfileName.Length >= 13) {
									if(Convert.ToInt32(profile.ProfileName.Substring(12)) == nextNew) {
										nextNew = Convert.ToInt32(profile.ProfileName.Substring(12)) + 1;
									}
								}
							}

							ProfileName = "New Profile " + nextNew;
							ProfilePath = Environment.GetFolderPath(Environment.SpecialFolder.ProgramFiles);
							ProfileDesc = "A blank profile.";
							ProfileType = 32;

							cmd.CommandText = "INSERT INTO Profiles (ProfileName, ProfilePath, ProfileDescription, ProfileType) " +
								"VALUES (@name, @path, @desc, @type)";

							cmd.Parameters.AddWithValue("@name", ProfileName);
							cmd.Parameters.AddWithValue("@path", ProfilePath);
							cmd.Parameters.AddWithValue("@desc", ProfileDesc);
							cmd.Parameters.AddWithValue("@type", ProfileType);
							cmd.ExecuteNonQuery();

							cmd.CommandText = "SELECT @@IDENTITY";
							ProfileID = Convert.ToInt32(cmd.ExecuteScalar());
						}
						else {
							cmd.CommandText = "SELECT * FROM Profiles WHERE ID=@id";
							cmd.Parameters.AddWithValue("@id", id);

							using(DataSet ds = new DataSet()) {
								using(SqlCeDataAdapter adapter = new SqlCeDataAdapter(cmd)) {
									adapter.SelectCommand = cmd;

									adapter.Fill(ds);

									foreach(DataRow row in ds.Tables[0].Rows) {
										ProfileID = Convert.ToInt32(row.ItemArray[0]);
										ProfileName = row.ItemArray[1].ToString();
										ProfilePath = row.ItemArray[2].ToString();
										ProfileDesc = row.ItemArray[3].ToString();
										ProfileType = Convert.ToInt32(row.ItemArray[4]);
										ProfileDefault = (bool)row.ItemArray[5];
									}
								}
							}
						}
					}
				}
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}

		/// <summary>
		/// Edit the profile.
		/// </summary>
		/// <param name="id">The ID of the profile</param>
		/// <param name="name">The name of the profile (Optional)</param>
		/// <param name="path">The path of the profile (Optional)</param>
		/// <param name="desc">The description of the profile (Optional)</param>
		/// <param name="type">The type of profile (Optional)</param>
		/// <param name="isDefault">If the profile is the default or not (Optional)</param>
		public void EditProfile(int id, string name = null, string path = null, string desc = null, int type = 0, bool isDefault = false) {
			string oldName = null;

			if(name != null) {
				oldName = ProfileName;
				ProfileName = name;
			}
			if(path != null)
				ProfilePath = path;
			if(desc != null)
				ProfileDesc = desc;
			if(type != 0)
				ProfileType = type;
			ProfileDefault = isDefault;

			try {
				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(SqlCeCommand cmd = new SqlCeCommand("UPDATE Profiles SET ProfileName=@name, ProfilePath=@path, ProfileDescription=@desc, " +
							"ProfileType=@type, ProfileDefault=@default WHERE ID=@id", conn)) {
						cmd.Parameters.AddWithValue("@name", ProfileName);
						cmd.Parameters.AddWithValue("@path", ProfilePath);
						cmd.Parameters.AddWithValue("@desc", ProfileDesc);
						cmd.Parameters.AddWithValue("@type", ProfileType);
						cmd.Parameters.AddWithValue("@default", (ProfileDefault ? 1 : 0));
						cmd.Parameters.AddWithValue("@id", id);

						conn.Open();
						cmd.ExecuteNonQuery();

						if(name != null && oldName != null) {
							cmd.CommandText = "UPDATE Servers SET ServerProfile=@name WHERE ServerProfile=@old";
							cmd.Parameters.AddWithValue("@old", oldName);

							cmd.ExecuteNonQuery();
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
