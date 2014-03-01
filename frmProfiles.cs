using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmProfiles : Form {
		bool _wasChanged = false;
		const int MAX_PROFILES = 10;
		int selectedID = -1;
		int profileCount = 0;

		bool WasChanged {
			get { return _wasChanged; }
			set {
				if(_wasChanged != value) {
					_wasChanged = value;
				}

				if(_wasChanged) {
					btnSave.Enabled = true;
					btnClear.Enabled = true;
				}
				else {
					btnSave.Enabled = false;
					btnClear.Enabled = false;
				}
			}
		}

		public frmProfiles() {
			InitializeComponent();
		}

		private void frmProfiles_Load(object sender, EventArgs e) {
			LoadAllProfiles();
		}

		private void cmbProfiles_SelectedIndexChanged(object sender, EventArgs e) {
			txtName.TextChanged += new EventHandler(Textbox_TextChanged);
			txtPath.TextChanged += new EventHandler(Textbox_TextChanged);
			txtDescription.TextChanged += new EventHandler(Textbox_TextChanged);

			LoadSelectedProfile();
		}

		private void Textbox_TextChanged(object sender, EventArgs e) {
			TextBox textbox = sender as TextBox;

			if((textbox.SelectedText == textbox.Text) && (textbox.Text != "")) return;

			if(!WasChanged) {
				WasChanged = true;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			AddNewProfile();
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			DeleteSelectedProfile();
		}

		private void btnSave_Click(object sender, EventArgs e) {
			EditSelectedProfile();
		}

		private void btnClear_Click(object sender, EventArgs e) {
			LoadSelectedProfile();
		}

		private void btnBrowse_Click(object sender, EventArgs e) {
			if(txtPath.Text != "" && Directory.Exists(txtPath.Text)) {
				dlgFolder.SelectedPath = txtPath.Text;

				DialogResult result = dlgFolder.ShowDialog();

				if(result == DialogResult.OK) {
					txtPath.Text = dlgFolder.SelectedPath;
				}
			}
		}

		private void btnDone_Click(object sender, EventArgs e) {
			if(WasChanged) {
				if(MessageBox.Show("You have unsaved changes. Would you like to save?", "Save", MessageBoxButtons.YesNo) == DialogResult.Yes) {
					EditSelectedProfile();
				}
			}

			Globals.GetProfiles();
			Close();
		}

		private void chkDefault_CheckedChanged(object sender, EventArgs e) {
			if(!WasChanged) {
				WasChanged = true;
			}
		}

		private void rdo32bit_CheckedChanged(object sender, EventArgs e) {
			if(!WasChanged) {
				WasChanged = true;
			}
		}

		private void rdo64bit_CheckedChanged(object sender, EventArgs e) {
			if(!WasChanged) {
				WasChanged = true;
			}
		}

		/// <summary>
		/// Load all the profiles from the database.
		/// </summary>
		private void LoadAllProfiles() {
			cmbProfiles.Items.Clear();
			Globals.GetProfiles();

			foreach(Profile profile in Globals.profiles) {
				cmbProfiles.Items.Add(profile.ProfileName);
			}

			if(cmbProfiles.Items.Count > 0) {
				cmbProfiles.SelectedIndex = 0;
			}

			profileCount = Globals.profiles.Count;
		}

		/// <summary>
		/// Load information for the selected profile from the database.
		/// </summary>
		private void LoadSelectedProfile() {
			try {
				txtName.Text = cmbProfiles.SelectedItem.ToString();

				Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == txtName.Text);

				txtPath.Text = profile.ProfilePath;
				txtDescription.Text = profile.ProfileDesc;

				if(profile.ProfileType == 32) {
					rdo32bit.Checked = true;
				}
				else {
					rdo64bit.Checked = true;
				}

				chkDefault.Checked = profile.ProfileDefault;

				selectedID = profile.ProfileID;
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}

			WasChanged = false;
		}

		/// <summary>
		/// Add a new blank profile to the database.
		/// </summary>
		private void AddNewProfile() {
			if(profileCount < MAX_PROFILES) {
				Globals.profiles.Add(new Profile(true, -1));
				string selectProfile = Globals.profiles[Globals.profiles.Count - 1].ProfileName;
				LoadAllProfiles();
				cmbProfiles.SelectedItem = selectProfile;

				WasChanged = false;
			}
			else {
				MessageBox.Show("You can only have 10 profiles.", "Error");
			}
		}

		/// <summary>
		/// Edit an existing profile and update it in the database.
		/// </summary>
		private void EditSelectedProfile() {
			bool changedDefault = false;
			int defaultID = -1;

			if(txtName.Text == "All") {
				MessageBox.Show("That word is reserved. You cannot name a profile \"All\".", "Error");
			}
			else {
				try {
					if(Globals.profiles.SingleOrDefault(item => item.ProfileName == txtName.Text && item.ProfileID != selectedID) != null) {
						MessageBox.Show("You cannot have two profiles with the same name. Please choose a different name.", "Error");
					}
					else {
						if(!chkDefault.Checked && cmbProfiles.Items.Count == 1) {
							chkDefault.Checked = true;
							changedDefault = true;
						}
						else if(chkDefault.Checked) {
							defaultID = Globals.profiles.SingleOrDefault(item => item.ProfileDefault == true).ProfileID;
							Globals.profiles.SingleOrDefault(item => item.ProfileDefault == true).EditProfile(defaultID, isDefault: false);
						}

						Globals.profiles.SingleOrDefault(item => item.ProfileID == selectedID).EditProfile(selectedID, txtName.Text, txtPath.Text, 
							txtDescription.Text, (rdo32bit.Checked ? 32 : 64), chkDefault.Checked);

						int currentRow = cmbProfiles.SelectedIndex;
						LoadAllProfiles();
						cmbProfiles.SelectedIndex = currentRow;

						if(!changedDefault) {
							MessageBox.Show(txtName.Text + " edited successfully.", "Success");
						}
						else {
							MessageBox.Show(txtName.Text + " edited successfully, but was kept as the default profile. You need to have a default profile.", "Success");
						}

						WasChanged = false;
					}
				}
				catch(Exception ex) {
					Globals.frmError.ShowDialog(ex);
				}
			}
		}

		/// <summary>
		/// Deleted the selected profile.
		/// </summary>
		private void DeleteSelectedProfile() {
			if(cmbProfiles.Items.Count > 1) {
				bool changeDefault = false;
				string name = txtName.Text;

				try {
					DialogResult result = MessageBox.Show("Are you sure you want to delete " + name + "?", "Delete", MessageBoxButtons.YesNo);

					if(result == DialogResult.Yes) {
						using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
							using(SqlCeCommand cmd = new SqlCeCommand("DELETE FROM Profiles WHERE ID=@id", conn)) {
								cmd.Parameters.AddWithValue("@id", selectedID);

								conn.Open();
								// deletes the profile from the database
								cmd.ExecuteNonQuery();

								// gets the profile from the list
								Profile delProfile = Globals.profiles.SingleOrDefault(item => item.ProfileID == selectedID);

								// if the profile was the default, reassign the default
								if(delProfile.ProfileDefault) {
									changeDefault = true;
								}

								// then remove it
								Globals.profiles.Remove(delProfile);

								if(changeDefault) {
									Globals.profiles[0].EditProfile(Globals.profiles[0].ProfileID, isDefault: true);
								}

								// if user selects to delete servers with their profile
								if(Properties.Settings.Default.deleteServersAfterProfile) {
									cmd.CommandText = "DELETE FROM Servers WHERE ServerProfile=@profile";
									cmd.Parameters.AddWithValue("@profile", name);
									cmd.ExecuteNonQuery();

									MessageBox.Show(name + " and all of its servers deleted.", "Delete Profile");
								}
								else {
									cmd.CommandText = "UPDATE Servers SET ServerProfile=@new WHERE ServerProfile=@profile";
									cmd.Parameters.AddWithValue("@new", Globals.profiles.SingleOrDefault(
										item => item.ProfileDefault == true && item.ProfileName != name).ProfileName);
									cmd.Parameters.AddWithValue("@profile", name);
									cmd.ExecuteNonQuery();

									MessageBox.Show(name + " deleted. Its servers have moved to profile \"" +
										Globals.profiles.SingleOrDefault(item => item.ProfileDefault == true).ProfileName + "\".", "Delete Profile");
								}
							}

							LoadAllProfiles();
						}
					}
				}
				catch(Exception ex) {
					Globals.frmError.ShowDialog(ex);
				}
			}
			else {
				MessageBox.Show("You cannot delete your last profile.", "Delete Profile");
			}
		}
	}
}
