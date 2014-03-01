// --------------------------------------------------------------------------------------
// This file is for performing file/folder actions like writing, moving, copying, and
// deleting.
//
// The program will not started elevated. You must handle elevating the program in the 
// parent process. This is so the user is not given a UAC prompt when one is not needed.
//
// If the file/folder does not exist in the same directory, full paths to files and 
// folders are REQUIRED.
//
// Exit codes:
// -1: Uncaught exception
//  1: Unauthorized access
//  2: File/folder does not exist
//  3: Invalid arguments
// --------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace file_actions {
	class Program {
		static int Main(string[] args) {
			try {
				string dir = "";
				bool wasReadOnly = false;
				
				switch(args[0]) {
					case "write":
						// for changing text in text files
						// args[1] = "path\to\file" (string)
						// args[2] = "text to write" (string)

						if(File.Exists(args[1])) {
							// checks if the file is read-only
							// if it is, temporarily remove read-only flag
							if(File.GetAttributes(args[1]) == FileAttributes.ReadOnly) {
								File.SetAttributes(args[1], FileAttributes.Normal);
								wasReadOnly = true;
							}
						}

						// will write regardless of whether the file exists or not
						File.WriteAllText(args[1], args[2]);
						
						if(wasReadOnly) {
							File.SetAttributes(args[1], FileAttributes.ReadOnly);
						}

						break;
					case "create":
						// for creating new files and folders
						// args[1] = "file" or "folder" (string)
						//    if args[1] = "file" (string)
						//       args[2] = "file\to\create" (string)
						//       args[3] = "text to write to file" (string)
						//          (optional)
						//    if args[1] = "folder" (string)
						//       args[2] = "folder\to\create" (string)
						//    if args[1] = "both" (string)
						//       args[2] = "folder\to\create" (string)
						//       args[3] = "file\to\create" (string)
						//       args[4] = "text to write to file" (string)
						//          (optional)

						if(args[1].Contains("file")) {
							if(!File.Exists(args[2]) && args[3] == null) {
								File.Create(args[2]);
							}
							else if(args[3] != null) {
								// will write regardless of whether the file exists or not
								File.WriteAllText(args[2], args[3]);
							}
						}
						else if(args[1].Contains("folder")) {
							if(!Directory.Exists(args[2])) {
								Directory.CreateDirectory(args[2]);
							}
						}
						else if(args[1].Contains("both")) {
							if(!Directory.Exists(args[2])) {
								Directory.CreateDirectory(args[2]);
							}

							if(!File.Exists(args[3]) && args[4] == null) {
								File.Create(args[3]);
							}
							else if(args[4] != null) {
								// will write regardless of whether the file exists or not
								File.WriteAllText(args[3], args[4]);
							}
						}
						else {
							return 3;
						}

						break;
					case "delete":
						// for deleting files and folders
						// args[1] = "file" or "folder" (string)
						// args[2] = "path\or\file\to\delete" (string)

						if(args[1].Contains("file")) {
							// we do not want a FileNotFoundException, so we check if it exists
							if(File.Exists(args[2])) {
								File.Delete(args[2]);
							}
						}
						else if(args[1].Contains("folder")) {
							// we do not want a DirectoryNotFoundException, so we check if it exists
							if(Directory.Exists(args[2])) {
								Directory.Delete(args[2]);
							}
						}
						else {
							return 3;
						}

						break;
					case "copy":
						// for copying and moving files to another location
						// args[1] = delete original file (bool)
						// args[2] = "path\to\old\file" (string)
						// args[3] = "path\to\new\file" (string)

						// we do not want this to throw an exception, so we check if the
						// directory exists
						dir = args[3].Replace(args[3].Substring(args[3].LastIndexOf("\\")), "");
						if(!Directory.Exists(dir)) {
							Directory.CreateDirectory(dir);
						}

						if(File.Exists(args[3])) {
							if(File.GetAttributes(args[3]) == FileAttributes.ReadOnly) {
								File.SetAttributes(args[3], FileAttributes.Normal);
								wasReadOnly = true;
							}
						}

						// we want this to throw an exception if the file does not exist
						File.Copy(args[2], args[3], true);
						
						if(Convert.ToBoolean(args[1])) {
							File.Delete(args[2]);
						}

						if(wasReadOnly) {
							File.SetAttributes(args[3], FileAttributes.ReadOnly);
						}

						break;
				}

				return 0;
			}
			catch(Exception ex) {
				if(ex is UnauthorizedAccessException) {
					return 1;
				}
				else if(ex is FileNotFoundException ||
					ex is DirectoryNotFoundException) {
					return 2;
				}

				Debug.Print(ex.Message);
				return -1;
			}

		}

		// http://stackoverflow.com/questions/11660184/c-sharp-check-if-run-as-administrator
		/// <summary>
		/// Checks if the process is currently running as an administrator.
		/// </summary>
		/// <returns>If running as admin or not</returns>
		public static bool IsAdministrator() {
			var identity = WindowsIdentity.GetCurrent();
			var principal = new WindowsPrincipal(identity);
			return principal.IsInRole(WindowsBuiltInRole.Administrator);
		}
	}
}
