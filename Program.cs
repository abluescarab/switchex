using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Switchex {
	static class Program {
		public static bool keepRunning { get; set; }

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() {
			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			keepRunning = true;
			while(keepRunning) {
				keepRunning = false;
				Application.Run(new frmMain());
			}
		}
	}
}
