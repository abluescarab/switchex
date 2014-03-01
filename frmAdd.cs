using RatingControl;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Data.SqlServerCe;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmAdd : Form {
		private StarRatingControl ctlStarRating = new StarRatingControl();

		public frmAdd() {
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

		private void frmAdd_Load(object sender, EventArgs e) {
			if(txtName.Text == "") {
				txtName.BackColor = Color.LightYellow;
			}
			if(txtIP.Text == "") {
				txtIP.BackColor = Color.LightYellow;
			}
			if(txtWebsite.Text == "") {
				txtWebsite.BackColor = Color.LightYellow;
			}

			cmbProfiles.Items.Clear();

			foreach(Profile profile in Globals.profiles) {
				cmbProfiles.Items.Add(profile.ProfileName);
			}

			cmbProfiles.SelectedItem = Globals.profiles.SingleOrDefault(item => item.ProfileDefault == true).ProfileName;
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			if(txtName.Text != "" && txtIP.Text != "" && txtWebsite.Text != "") {
				AddServer();

				txtName.Text = "";
				txtIP.Text = "";
				txtWebsite.Text = "";
				txtPatch.Text = "N/A";
				txtNotes.Text = "None";
				ctlStarRating.SelectedStar = 0;
			}
			else {
				MessageBox.Show("Please ensure that the server name, IP, and website fields are filled out.");
			}
		}

		private void btnClose_Click(object sender, EventArgs e) {
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
		/// Add the server to the database.
		/// </summary>
		private void AddServer() {
			try {
				string patch = txtPatch.Text, notes = txtNotes.Text;

				if(patch == "") {
					patch = "N/A";
				}
				if(notes == "") {
					notes = "None";
				}

				using(SqlCeConnection conn = new SqlCeConnection(Properties.Settings.Default.switchexConnectionString)) {
					using(SqlCeCommand cmd = new SqlCeCommand("INSERT INTO Servers (ServerName, ServerIP, ServerWebsite, ServerPatch, ServerRating, " +
						"ServerNotes, ServerProfile) VALUES (@name, @ip, @website, @patch, @rating, @notes, @profile)", conn)) {
						cmd.Parameters.AddWithValue("@name", SqlDbType.Text).Value = txtName.Text;
						cmd.Parameters.AddWithValue("@ip", SqlDbType.Text).Value = txtIP.Text;
						cmd.Parameters.AddWithValue("@website", SqlDbType.Text).Value = txtWebsite.Text;
						cmd.Parameters.AddWithValue("@patch", SqlDbType.Text).Value = patch;
						cmd.Parameters.AddWithValue("@rating", SqlDbType.Int).Value = ctlStarRating.SelectedStar;
						cmd.Parameters.AddWithValue("@notes", SqlDbType.Text).Value = notes;
						cmd.Parameters.AddWithValue("@profile", SqlDbType.Text).Value = cmbProfiles.SelectedItem;

						conn.Open();
						cmd.ExecuteNonQuery();
					}
				}

				MessageBox.Show(txtName.Text + " successfully added.", "Success");
			}
			catch(Exception ex) {
				Globals.frmError.ShowDialog(ex);
			}
		}
	}
}
