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
        IDataRowBO[] GetDataForDataObject(int dataObjectId);
    }
    
    public class DataObjectManager
    {
        private IExternalDataManager externalDataManager;
        private IDataObjectEngine engine;

        public DataObjectManager(IExternalDataManager externalDataManager, IDataObjectEngine engine)
        {
            this.externalDataManager = externalDataManager;
            this.engine = engine;
        }

        public IDataRowBO[] GetDataForDataObject(int dataObjectId)
        {
            var dataObject =  engine.GetDataObjectById(dataObjectId);

            var retVal = externalDataManager.LoadData(dataObject);
            return retVal.ToArray();
        }
    }
}
