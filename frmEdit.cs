using RatingControl;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmEdit: Form {
		StarRatingControl ctlStarRating = new StarRatingControl();

		public frmEdit() {
			InitializeComponent();

			// Initialize star rating control
			ctlStarRating.Top = 119;
			ctlStarRating.Left = 67;
			ctlStarRating.Height = 18;
			ctlStarRating.Width = 100;
			ctlStarRating.StarSpacing = 5;
			ctlStarRating.GradientBackground = false;
			ctlStarRating.BackColor = Color.FromName("Control");
			ctlStarRating.SelectedColor = Color.FromArgb(255, 255, 208, 0);
			ctlStarRating.HoverColor = Color.Yellow;
			ctlStarRating.TabIndex = 4;
			ctlStarRating.BringToFront();

			// Add it to the form
			Controls.Add(ctlStarRating);
		}

		private void frmEdit_Load(object sender, EventArgs e) {
			txtName.Text = Globals.selectedName;
			txtIP.Text = Globals.selectedIP;
			txtWebsite.Text = Globals.selectedWebsite;
			txtPatch.Text = Globals.selectedPatch;
			txtNotes.Text = Globals.selectedNotes;
			ctlStarRating.SelectedStar = Convert.ToInt32(Globals.selectedRating);

			cmbProfiles.Items.Clear();

			foreach(Profile profile in Globals.profiles) {
				cmbProfiles.Items.Add(profile.ProfileName);
			}

			cmbProfiles.SelectedItem = Globals.selectedProfile;
		}

		private void btnOK_Click(object sender, EventArgs e) {
			EditServer();
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void txtName_TextChanged(object sender, EventArgs e) {
			if(txtName.Text == "") {
				txtName.BackColor = Color.LightYellow;
			}
			else {
				txtName.BackColor = Color.FromName("Window");
			}
		}

		private void txtIP_TextChanged(object sender, EventArgs e) {
			if(txtIP.Text == "") {
				txtIP.BackColor = Color.LightYellow;
			}
			else {
				txtIP.BackColor = Color.FromName("Window");
			}
		}

		private void txtWebsite_TextChanged(object sender, EventArgs e) {
			if(txtWebsite.Text == "") {
				txtWebsite.BackColor = Color.LightYellow;
			}
			else {
				txtWebsite.BackColor = Color.FromName("Window");
			}
		}

		/// <summary>
		/// Edit the server.
		/// </summary>
		private void EditServer() {
			if(txtName.Text != "" && txtIP.Text != "" && txtWebsite.Text != "") {
				try {
					using(frmMain frmMain = new frmMain()) {
						using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
							using(SqlCeCommand cmd = new SqlCeCommand("UPDATE Servers SET ServerName=@name, ServerIP=@ip, ServerWebsite=@website, " +
								"ServerPatch=@patch, ServerRating=@rating, ServerNotes=@notes, ServerProfile=@profile WHERE ID=@id", conn)) {
								string patch = txtPatch.Text,
								notes = txtNotes.Text;

								if(patch == "") {
									patch = "N/A";
								}
								if(notes == "") {
									notes = "None";
								}

								cmd.Parameters.AddWithValue("@name", txtName.Text);
								cmd.Parameters.AddWithValue("@ip", txtIP.Text);
								cmd.Parameters.AddWithValue("@website", txtWebsite.Text);
								cmd.Parameters.AddWithValue("@patch", patch);
								cmd.Parameters.AddWithValue("@rating", ctlStarRating.SelectedStar);
								cmd.Parameters.AddWithValue("@notes", notes);
								cmd.Parameters.AddWithValue("@profile", cmbProfiles.SelectedItem);
								cmd.Parameters.AddWithValue("@id", Globals.selectedID);

								conn.Open();
								cmd.ExecuteNonQuery();
							}
						}
					}
				}
				catch(Exception ex) {
					Globals.frmError.ShowDialog(ex);
				}
			}
			else {
				MessageBox.Show("Please ensure that the server name, IP, and website fields are filled out.");
			}
		}
	}
}
