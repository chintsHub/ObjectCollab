using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.BusinessLayer.Factory;

namespace ObjectCollab.BusinessLayer.Manager
{
    public interface IExternalDataManager
    {
        IDataRowBO[] LoadData(IDataObjectBO dataObj);

    }

    public class ExternalDataManager : IExternalDataManager
    {
        private IDataProvider dataProvider;

        public ExternalDataManager(IDataProvider dataProvider)
        {
            this.dataProvider = dataProvider;

            
        }

        public IDataRowBO[] LoadData(IDataObjectBO dataObj)
        {
            IDataExtractor dataExtractor = dataProvider.GetDataExtractor(dataObj);
            return dataExtractor.GetDataRows();
        }
    }
}