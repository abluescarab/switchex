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
			string date = GetLine(Application.StartupPath + "\\readme.txt", 3).Remove(0, 6);

			lblDate.Text = "Date: " + date;
			lblCurrentVersion.Text = "Current: " + Application.ProductVersion;
			lblUpdateVersion.Text = "Update: " + Globals.downloadVersion;

			txtReadme.Text = File.ReadAllText(Application.StartupPath + "\\readme.txt").Replace("\n", Environment.NewLine);
		}

		private void btnYes_Click(object sender, EventArgs e) {
			frmUpdates frmUpdates = new frmUpdates();
			Close();
			frmUpdates.ShowDialog();
		}

		private void btnNo_Click(object sender, EventArgs e) {
			Close();
		}

		/// <summary>
		/// Get the specified line from the text file.
		/// </summary>
		/// <param name="filename">The file</param>
		/// <param name="line">The desired line</param>
		/// <returns></returns>
		string GetLine(string filename, int line) {
			using(var sr = new StreamReader(filename)) {
				for(int i = 1; i < line; i++) {
					sr.ReadLine();
				}

				return sr.ReadLine();
			}
		}
	}
}
