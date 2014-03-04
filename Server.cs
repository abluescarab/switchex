using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Switchex {
	public class Server {
		public int ServerID { get; set; }
		public string ServerName { get; set; }
		public string ServerIP { get; set; }
		public string ServerWebsite { get; set; }
		public string ServerPatch { get; set; }
		public int ServerRating { get; set; }
		public string ServerNotes { get; set; }
		public string ServerProfile { get; set; }

		public Server(int id, string name, string ip, string site, string patch,
			int rating, string notes, string profile) {
				ServerID = id;
				ServerName = name;
				ServerIP = ip;
				ServerWebsite = site;
				ServerPatch = patch;
				ServerRating = rating;
				ServerNotes = notes;
				ServerProfile = profile;
		}
	}
}
