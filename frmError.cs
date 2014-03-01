using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmError : Form {
		public frmError() {
			InitializeComponent();
		}

		public void ShowDialog(Exception ex) {
			rtbError.Text = ex.Message;
			rtbError.Focus();
			ShowDialog();
		}

		private void frmError_Load(object sender, EventArgs e) {
			BringToFront();
		}

		private void lblContact_Click(object sender, EventArgs e) {
			Process.Start("http://www.abluescarab.us/contact.php?subject=Switchex Error&message=" + rtbError.Text + "&version=" + Application.ProductVersion);
		}

		private void lblContact_MouseEnter(object sender, EventArgs e) {
			Cursor = Cursors.Hand;
		}

		private void lblContact_MouseLeave(object sender, EventArgs e) {
			Cursor = Cursors.Default;
		}

		private void btnCopy_Click(object sender, EventArgs e) {
			Clipboard.SetText(rtbError.Text);
		}

		private void btnOK_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
