using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.BusinessLayer.Factory;
using ObjectCollab.Domain;
using System.Collections.Generic;
using IDataProvider = ObjectCollab.BusinessLayer.Engine.IDataProvider;

namespace ObjectCollab.BusinessLayer.Manager
{
    public class ExternalDataManager : IExternalDataManager
    {
        private IDataProviderFactory dataProvider;

        public ExternalDataManager(IDataProviderFactory dataProvider)
        {
            this.dataProvider = dataProvider;

            
        }

        public IList<IDataRowBO> LoadData(IDataObjectBO dataObj)
        {
            IDataProvider dataProvider = this.dataProvider.GetDataProvider(dataObj);
            return dataProvider.GetDataRows();
        }
    }
}