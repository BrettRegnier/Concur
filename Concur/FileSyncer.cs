using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur
{
	public class FileSyncer
	{
		Folder source;
		Folder destination;

		public FileSyncer(string src, string des)
		{
			source = new Folder(src);
			destination = new Folder(des);
		}

		public void Load()
		{
			// load from sile
		}

		public void Save()
		{
			// save to file;
		}

		// return false for failure, return true for success
		public bool Sync()
		{
			foreach (FileInfo f in source.Files())
			{
				System.IO.File.Copy(f.FullName, destination.Path + f.Name, true);

			}

			return true;
		}
	}
}
