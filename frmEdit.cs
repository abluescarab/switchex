using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmEdit: Form {
		public frmEdit() {
			InitializeComponent();
		}

		private void frmEdit_Load(object sender, EventArgs e) {
			frmMain frmMain = new frmMain();

			txtName.Text = frmMain.currentName;
			txtIP.Text = frmMain.currentIP;
			txtWebsite.Text = frmMain.currentWebsite;
			txtPatch.Text = frmMain.currentPatch;
			txtRating.Text = frmMain.currentRating;
			txtNotes.Text = frmMain.currentNotes;
		}

		private void btnOK_Click(object sender, EventArgs e) {
			editServer();
			Close();
		}

		private void btnCancel_Click(object sender, EventArgs e) {
			Close();
		}

		private void editServer() {
			if(txtName.Text != "" && txtIP.Text != "" && txtWebsite.Text != "") {
				try {
					frmMain frmMain = new frmMain();
					OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\WoWServer.accdb");
					OleDbCommand cmd = new OleDbCommand();

					string name = txtName.Text;
					string ip = txtIP.Text;
					string website = txtWebsite.Text;
					string patch = txtPatch.Text;
					string rating = txtRating.Text;
					string notes = txtNotes.Text;

					if(patch == "") {
						patch = "N/A";
					}
					if(rating == "") {
						rating = "None";
					}
					if(notes == "") {
						notes = "None";
					}

					cmd.Connection = conn;
					conn.Open();

					cmd.CommandText = "UPDATE ServerInfo SET ServerName='" + name + "', ServerIP='" + ip + "', ServerWebsite='" + website +
						"', ServerPatch='" + patch + "', ServerRating='" + rating + "', ServerNotes='" + notes + "' WHERE ServerName='" + frmMain.currentName + "'";

					cmd.ExecuteNonQuery();
					conn.Close();
				}
				catch(Exception ex) {
					MessageBox.Show(ex.Message, "Error");
				}
			}
			else {
				MessageBox.Show("Please ensure that the server name, IP, and website fields are filled out.");
			}
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
	}
}
