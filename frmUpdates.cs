using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmUpdates: Form {
		string downloadLocation = Application.StartupPath;

		public frmUpdates() {
			InitializeComponent();
		}

		private void frmUpdates_Load(object sender, EventArgs e) {
			lblDownload.Text = "Downloaded: 0KB out of 0KB\nProgress: 0%";

			WebClient webClient = new WebClient();
			string downloadFile = "Switchex_" + frmMain.downloadVersion + "_SETUP.exe";
			
			if(!Directory.Exists(downloadLocation)) {
				Directory.CreateDirectory(downloadLocation);
			}

			if(!File.Exists(Application.StartupPath + "\\" + downloadFile)) {
				prgbar.Value = 0;
				lblFile.Text = "File: " + downloadFile;

				webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(_DownloadFileCompleted);
				webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(_DownloadProgressChanged);
				webClient.DownloadFileAsync(new Uri("https://github.com/abluescarab/Switchex/releases/download/" + frmMain.downloadVersion + "/" + downloadFile), downloadLocation + "\\" + downloadFile);
			}
			else {
				DialogResult result = MessageBox.Show("Downloaded file already exists. Close Switchex and install updates?", "Update", MessageBoxButtons.YesNo);

				if(result == DialogResult.Yes) {
					Application.Exit();
					Process.Start(Application.StartupPath + "\\Switchex_" + frmMain.downloadVersion + "_SETUP.exe");
				}
				else {
					Close();
				}
			}
		}

		private void _DownloadFileCompleted(object sender, AsyncCompletedEventArgs e) {
			frmMain frmMain = new frmMain();

			DialogResult result = MessageBox.Show("Download has finished. Close Switchex and install updates? (This will overwrite your current database.)",
				"Download Complete", MessageBoxButtons.YesNo);

			Close();

			if(result == DialogResult.Yes) {
				Application.Exit();
				Process.Start(Application.StartupPath + "\\Switchex_" + frmMain.downloadVersion + "_SETUP.exe");
			}
		}

		private void _DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e) {
			try {
				prgbar.Value = e.ProgressPercentage;

				decimal downloadedKB = e.BytesReceived / 1000;
				decimal totalKB = e.TotalBytesToReceive / 1000;

				lblDownload.Text = "Downloaded: " + downloadedKB + "KB out of " + totalKB + "KB\nProgress: " + e.ProgressPercentage.ToString() + "%";
			}
			catch(Exception ex) {
				MessageBox.Show(ex.Message, "Error");
			}
		}
	}
}
