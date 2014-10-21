using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.BusinessLayer.Manager;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.Factory
{
    public interface IDataProvider
    {
        IDataExtractor GetDataExtractor(IDataObject dataObject);
    }
}