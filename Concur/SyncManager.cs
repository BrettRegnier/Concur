using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Concur
{
	// This will need parallelization on the sync function
	class SyncManager
	{
		List<FileSyncer> fileSyncers;

		public void LoadAllFileSync()
		{

		}

		public void SaveAllFileSync()
		{

		}

		public void SyncAll()
		{
			foreach (FileSyncer fileSyncer in fileSyncers)
			{
				fileSyncer.Sync();
			}
		}

		public void RegisterSync(string src, string des)
		{

		}
	}
}
