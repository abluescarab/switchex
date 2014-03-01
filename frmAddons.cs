using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmAddons: Form {
		bool _hasAddons = false;

		bool HasAddons {
			get { return _hasAddons; }
			set {
				if(_hasAddons != value) {
					_hasAddons = value;
				}

				if(_hasAddons) {
					if(lbAddons.DataSource == null) {
						lbAddons.Items.Clear();
					}

					lbAddons.Enabled = true;

					txtSearch.Enabled = true;
				}
				else {
					lbAddons.Items.Clear();
					lbAddons.Enabled = false;

					txtSearch.ResetText();
					txtSearch.Enabled = false;

					foreach(Control c in Controls) {
						if(c is TextBox && c.Text != "") {
							c.ResetText();
						}
					}
				}
			}
		}

		List<string> addons = new List<string>();
		List<string> filteredAddons = new List<string>();

		public string addonFolder = null;

		bool wasClicked = true;

		public frmAddons() {
			InitializeComponent();
		}
		
		private void frmAddons_Load(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);
			
			// if the profile exists
			if(profile != null) {
				addonFolder = profile.ProfilePath + "\\Interface\\AddOns\\";

				// if the addons folder exists in the profile
				if(Directory.Exists(addonFolder)) {
					RefreshAddons();
				}
				// if the addons folder does not exist in the profile
				else {
					DialogResult result = MessageBox.Show("You do not have an addons folder. Would you like to create it?", "Addons", MessageBoxButtons.YesNo);

					if(result == DialogResult.Yes) {
						string[] args = { addonFolder };
						Globals.RunActionsExecutable(Globals.FileAction.CreateFolder, args);

						HasAddons = false;
						lbAddons.Items.Add("No addons installed.");
					}
					else {
						HasAddons = false;
						lbAddons.Items.Add("No addons folder detected.");
					}
				}
			}
			// if the profile does not exist or there is a problem
			else {
				HasAddons = false;
				lbAddons.Items.Add("Cannot find a WoW installation in your current profile.");
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e) {
			if(txtSearch.TextLength > 0) {
				filteredAddons = addons.Where(x => x.Length >= txtSearch.TextLength &&
					x.Substring(0, txtSearch.TextLength) == txtSearch.Text).ToList();
				lbAddons.DataSource = filteredAddons;

				if(lbAddons.Items.Count == 0) {
					txtSearch.BackColor = Color.LightYellow;
				}
				else {
					txtSearch.BackColor = Color.FromName("Window");
				}
			}
			else {
				txtSearch.BackColor = Color.FromName("Window");
				lbAddons.DataSource = addons;
			}
		}

		private void lbAddons_SelectedIndexChanged(object sender, EventArgs e) {
			if(wasClicked) {
				LoadSelectedAddon();
			}
		}

		private void btnDelete_Click(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show("Are you sure you want to delete " + lbAddons.SelectedItem + " from your addons folder?", "Delete", MessageBoxButtons.YesNo);

			if(result == DialogResult.Yes) {
				try {
					string name = lbAddons.SelectedItem.ToString();
					string[] args = { addonFolder + name };

					if(Globals.RunActionsExecutable(Globals.FileAction.DeleteFolder, args) == 0) {
						RefreshAddons();
						MessageBox.Show("Deletion of " + name + " successful.", "Success");
					}
					else {
						MessageBox.Show("Could not delete folder.", "Error");
					}
				}
				catch(Exception ex) {
					Globals.frmError.ShowDialog(ex);
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// Refresh the addons list.
		/// </summary>
		private void RefreshAddons() {
			wasClicked = false;
			lbAddons.DataSource = null;
			lbAddons.Items.Clear();
			addons.Clear();

			if(Directory.GetDirectories(addonFolder).Length > 0) {
				foreach(string dir in Directory.GetDirectories(addonFolder)) {
					if(dir.IndexOf("Blizzard_") == -1) {
						addons.Add(dir.Substring(dir.LastIndexOf('\\') + 1));
					}
				}

				lbAddons.DataSource = addons;

				if(!HasAddons) {
					HasAddons = true;
				}

				LoadSelectedAddon();
			}
			else {
				if(HasAddons) {
					HasAddons = false;
				}

				lbAddons.Items.Add("No addons installed.");
			}

			wasClicked = true;
		}

		/// <summary>
		/// Load information for the selected addon.
		/// </summary>
		private void LoadSelectedAddon() {
			Cursor = Cursors.WaitCursor;

			string name = lbAddons.SelectedItem.ToString();
			string selectedAddon = addonFolder + name + "\\" + name + ".toc";

			if(File.Exists(selectedAddon)) {
				string addonFile = File.ReadAllText(selectedAddon);
				string[] addonText = addonFile.Split('\n');

				txtName.Text = name;

				string description = Array.Find(addonText, element => element.StartsWith("## Notes:"));

				if(description != null) {
					description = description.Substring(description.IndexOf(":") + 1).Trim();
					txtDescription.Text = description;
				}
				else {
					txtDescription.Text = "No description specified.";
				}

				string author = Array.Find(addonText, element => element.StartsWith("## Author:"));

				if(author != null) {
					author = author.Substring(author.IndexOf(":") + 1).Trim();
					txtAuthor.Text = author;
				}
				else {
					txtAuthor.Text = "No author specified.";
				}

				string version = Array.Find(addonText, element => element.StartsWith("## Version:"));

				if(version != null) {
					version = version.Substring(version.IndexOf(":") + 1).Trim();
					txtVersion.Text = version;
				}
				else {
					txtVersion.Text = "No version specified.";
				}
			}
			else {
				txtName.Text = name;
				txtDescription.Text = "No description specified.";
				txtAuthor.Text = "No author specified.";
				txtVersion.Text = "No version specified.";
			}

			if(Directory.Exists(addonFolder + name)) {
				txtInstalled.Text = Directory.GetCreationTime(addonFolder + name).ToShortDateString();
			}
			else {
				txtName.Text = "No name.";
				txtInstalled.Text = "No installation date.";
			}

			Cursor = Cursors.Default;
		}
	}
}
