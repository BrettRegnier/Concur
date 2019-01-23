using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur
{
	public class Folder
	{
		string path;
		string name;
		List<string> files;
		List<string> folders;

		public Folder(string pth)
		{
			int index = path.LastIndexOf(@"\");

			path = pth;
			name = path.Substring(index, pth.Length - index);

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
				DirectoryInfo d = new DirectoryInfo(path);
				FileInfo[] fils = d.GetFiles();
				foreach (FileInfo f in fils)
					files.Add(f.Name);
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
