using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur
{
	public class Folder
	{
		string name;
		List<string> files;
		List<string> folders;

		public Folder(string nm)
		{
			name = nm;
			files = new List<string>();
			folders = new List<string>();
		}

		public string Name()
		{
			return name;
		}

		public List<string> Files()
		{
			if (files.Count == 0)
			{
				// Get files
			}

			return files;
		}

		public List<string> Folders()
		{
			if (folders.Count == 0)
			{
				// Get folders
			}

			return folders;
		}

		public Dictionary<string, List<string>> Contents()
		{
			Dictionary<string, List<string>> dic = new Dictionary<string, List<string>>
			{
				{ "files", Files() },
				{ "Folders", Folders() }
			};

			return dic;
		}

	}
}
