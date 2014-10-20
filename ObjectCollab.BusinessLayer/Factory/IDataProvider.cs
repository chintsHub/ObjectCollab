using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.BusinessLayer.Manager;

namespace ObjectCollab.BusinessLayer.Factory
{
    public interface IDataProvider
    {
        IDataExtractor GetDataExtractor(IDataObjectBO dataObject);
    }
}