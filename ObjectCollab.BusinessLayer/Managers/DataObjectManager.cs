using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engines;
using ObjectCollab.BusinessLayer.Manager;

namespace ObjectCollab.BusinessLayer.Managers
{
    public interface IDataObjectManager
    {
        IOledbDataRowBO[] GetOleDbData(int dataObjectId);
    }

    public class DataObjectManager : IDataObjectManager
    {
        private IExternalDataManager externalDataManager;
        private IOleDbObjectEngine engine;

        public DataObjectManager(IExternalDataManager externalDataManager, IOleDbObjectEngine engine)
        {
            this.externalDataManager = externalDataManager;
            this.engine = engine;
        }

        public IOledbDataRowBO[] GetOleDbData(int dataObjectId)
        {
            var dataObject =  engine.GetOleDbObjectById(dataObjectId);

            var retVal = externalDataManager.LoadOleDbData(dataObject);
            return retVal.ToArray();
        }
    }
}
