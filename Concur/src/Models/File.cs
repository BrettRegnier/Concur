using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur
{
	class File
	{
		string name;
		string path;
		
		public File(string pth, string nme)
		{
			name = nme;
			path = pth;
		}

		public string Name()
		{
			return name;
		}

		public string FullName()
		{
			return path + "\\" + name;
		}

		public string Path()
		{
			return path;
		}
	}
}
