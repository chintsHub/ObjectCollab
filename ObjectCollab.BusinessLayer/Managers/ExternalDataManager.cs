using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.BusinessLayer.Factory;
using ObjectCollab.Domain;
using System.Collections.Generic;

namespace ObjectCollab.BusinessLayer.Manager
{
    public interface IExternalDataManager
    {
        IList<IDataRowBO> LoadData(IDataObject dataObj);

    }

    public class ExternalDataManager : IExternalDataManager
    {
        private IDataProvider dataProvider;

        public ExternalDataManager(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;

            
        }

        public IList<IDataRowBO> LoadData(IDataObject dataObj)
        {
            IDataExtractor dataExtractor = dataProvider.GetDataExtractor(dataObj);
            return dataExtractor.GetDataRows();
        }
    }
}