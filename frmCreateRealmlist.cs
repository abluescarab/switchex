using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Switchex {
	public partial class frmCreateRealmlist : Form {
		public frmCreateRealmlist() {
			InitializeComponent();
		}

		private void frmCreateRealmlist_Load(object sender, EventArgs e) {
			btnUS.DialogResult = DialogResult.Yes;
			btnEU.DialogResult = DialogResult.Yes;
			btnNo.DialogResult = DialogResult.No;
		}

		private void btnUS_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);

			string[] args = {
				profile.ProfilePath + "\\Data\\enUS",
				profile.ProfilePath + "\\Data\\enUS\\realmlist.wtf",
				"set realmlist us.logon.worldofwarcraft.com" + Environment.NewLine +
				"set patchlist enUS.patch.battle.net" + Environment.NewLine +
				"set realmlistbn \"\"" + Environment.NewLine +
				"set portal us"
			};
			Globals.RunActionsExecutable(Globals.FileAction.CreateBoth, args);

			Close();
		}

		private void btnEU_Click(object sender, EventArgs e) {
			Profile profile = Globals.profiles.SingleOrDefault(item => item.ProfileName == Globals.currentProfile);

			string[] args = {
				profile.ProfilePath + "\\Data\\enGB",
				profile.ProfilePath + "\\Data\\enGB\\realmlist.wtf",
				"set realmlist eu.logon.worldofwarcraft.com\n" + Environment.NewLine +
				"set patchlist enGB.patch.battle.net:1119/patch\n" + Environment.NewLine +
				"set realmlistbn \"\"\n" + Environment.NewLine +
				"set portal eu"
			};
			Globals.RunActionsExecutable(Globals.FileAction.CreateBoth, args);

			Close();
		}

		private void btnNo_Click(object sender, EventArgs e) {
			Close();
		}
	}
}
