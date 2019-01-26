using System.IO;
using System.Threading.Tasks;

namespace Concur
{
	public class FileSyncer
	{
		static int count;
		Folder source;
		Folder destination;
		public string ID { get; private set; }
		public string LastSync { get; private set; }

		public FileSyncer()
		{
			count++;
			ID = (00000 + count).ToString();
			source = null;
			destination = null;
			LastSync = "Never";
		}

		public FileSyncer(string id, string src, string des, string lastSync = "")
		{
			ID = id;
			source = new Folder(src);
			destination = new Folder(des);

			if (lastSync == "")
				LastSync = "Never";
			else
				LastSync = lastSync;
		}

		// return false for failure, return true for success
		public bool Sync()
		{

			// TODO check which file is newer and then replace between the two based on file age
			if (source != null && destination != null)
			{
				foreach (FileInfo f in source.Files())
				{
					System.IO.File.Copy(f.FullName, destination.Path + f.Name, true);

				}
				return true;
			}
			return false;
		}

		public Folder Source()
		{
			return source;
		}

		public void Source(string pth)
		{
			source = new Folder(pth);
		}

		public Folder Destination()
		{
			return destination;
		}

		public void Destination(string pth)
		{
			destination = new Folder(pth);
		}
	}
}
