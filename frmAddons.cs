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
		public string addonFolder = Properties.Settings.Default.gamePath + "Interface\\AddOns\\";

		public frmAddons() {
			InitializeComponent();
		}
		
		private void frmAddons_Load(object sender, EventArgs e) {
			if(Properties.Settings.Default.gamePath != "") {
				if(Directory.Exists(addonFolder)) {
					if(Directory.GetDirectories(addonFolder).Length > 0) {
						List<string> addons = new List<string>();

						foreach(string dir in Directory.GetDirectories(addonFolder)) {
							if(dir.IndexOf("Blizzard_") == -1) {
								addons.Add(dir.Substring(dir.LastIndexOf('\\') + 1));
							}
						}

						lbAddons.DataSource = addons;
					}
					else {
						lbAddons.Items.Add("You do not have any addons.");
					}
				}
				else {
					DialogResult result = MessageBox.Show("You do not have an addons folder. Would you like Switchex to create it?", "Addons", MessageBoxButtons.YesNo);

					if(result == DialogResult.Yes) {
						try {
							Directory.CreateDirectory(addonFolder);
						}
						catch(Exception ex) {
							MessageBox.Show(ex.Message, "Error");
						}
					}

					lbAddons.Items.Add("You do not have any addons.");
				}
			}
			else {
				lbAddons.Items.Add("The WoW path is not set.");
			}
		}

		private void txtSearch_TextChanged(object sender, EventArgs e) {
			if(lbAddons.FindString(txtSearch.Text) > -1) {
				if(txtSearch.BackColor == Color.Red) {
					txtSearch.BackColor = Color.FromName("Window");
				}

				lbAddons.SelectedIndex = lbAddons.FindString(txtSearch.Text);
			}
			else {
				txtSearch.BackColor = Color.Red;
			}
		}

		private void lbAddons_SelectedIndexChanged(object sender, EventArgs e) {
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

		private void btnDelete_Click(object sender, EventArgs e) {
			DialogResult result = MessageBox.Show("Are you sure you want to delete " + lbAddons.SelectedItem + " from your addons folder?", "Delete", MessageBoxButtons.YesNo);

			if(result == DialogResult.Yes) {
				try {
					Directory.Delete(addonFolder + lbAddons.SelectedItem, true);
					MessageBox.Show("Deletion of " + lbAddons.SelectedItem + " successful.", "Success");
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message, "Error");
				}
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
