using System.Collections.Generic;
using ObjectCollab.BusinessLayer.BusinessObjects;

namespace ObjectCollab.BusinessLayer.Manager
{
    public interface IExternalDataManager
    {
        IList<IDataRowBO> LoadData(IDataObjectBO dataObj);

    }
}