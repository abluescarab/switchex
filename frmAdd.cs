using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmAdd: Form {
		public frmAdd() {
			InitializeComponent();
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
		}

		private void btnAdd_Click(object sender, EventArgs e) {
			if(txtName.Text != "" && txtIP.Text != "" && txtWebsite.Text != "") {
				addServer();

				txtName.Text = "";
				txtIP.Text = "";
				txtWebsite.Text = "";
				txtPatch.Text = "N/A";
				txtRating.Text = "None";
				txtNotes.Text = "None";
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

		private void addServer() {
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

				cmd.CommandText = "INSERT INTO ServerInfo (ServerName, ServerIP, ServerWebsite, ServerPatch, ServerRating, ServerNotes) VALUES ('" + name +
					"', '" + ip + "', '" + website + "', '" + patch + "', '" + rating + "', '" + notes + "')";

				cmd.ExecuteNonQuery();
				conn.Close();

				MessageBox.Show(name + " successfully added.", "Success");
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}
	}
}
