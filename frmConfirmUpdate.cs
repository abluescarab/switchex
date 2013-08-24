using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmConfirmUpdate: Form {
		public frmConfirmUpdate() {
			InitializeComponent();
		}

		private void frmConfirmUpdate_Load(object sender, EventArgs e) {
			lblUpdate.Text = "Update available!\n\nCurrent: " + Application.ProductVersion + "\nUpdate: " + frmMain.downloadVersion + 
				"\n\nDownload the update?";

			txtReadme.Text = File.ReadAllText(Application.StartupPath + "\\readme.txt");
		}

		private void btnYes_Click(object sender, EventArgs e) {
			frmUpdates frmUpdates = new frmUpdates();
			Close();
			frmUpdates.ShowDialog();
		}

		private void btnNo_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
