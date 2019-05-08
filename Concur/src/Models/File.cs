using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Xml.Linq;

namespace Concur
{
	public class File
	{
		private FileInfo info;
		
		public string Name { get { return info.Name; } }
		public string FullName { get { return info.FullName; } }
		public string Path { get { return info.DirectoryName; } }

		public File(FileInfo f)
		{
			info = f;
		}

		public File(string fullPath)
		{
			FileInfo f = new FileInfo(fullPath);
		}

		public XElement ToXML()
		{
			// TODO
			throw new NotImplementedException();
		}
	}
}
