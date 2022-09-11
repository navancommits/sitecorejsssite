using Sitecore.Data;
using Sitecore.Data.Items;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReferenceDataIntegration.Repository
{
    public class ReferenceDataRepository
    {
        private readonly Database _masterDB;
        private readonly Database _webDb;
        private readonly Item _rootFolderItem;
        private readonly ID _rootFolderID = new ID("{AC188805-7114-48C0-84D8-958B25ADF2FF}");

        public ReferenceDataRepository()
        {
            _masterDB = Sitecore.Configuration.Factory.GetDatabase("master");
            _webDb = Sitecore.Configuration.Factory.GetDatabase("web");
            _rootFolderItem = _masterDB.GetItem(_rootFolderID);
        }
    }
}
