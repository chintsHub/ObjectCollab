using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.BusinessLayer.Engines;
using ObjectCollab.BusinessLayer.Manager;

namespace ObjectCollab.BusinessLayer.Managers
{
    public interface IDataObjectManager
    {
        void GetDataForDataObject(int dataObjectId);
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

        public void GetDataForDataObject(int dataObjectId)
        {
            engine.GetDataObjectById(dataObjectId);

            //externalDataManager.LoadData();
        }
    }
}
