using System.Collections.Generic;
using ObjectCollab.BusinessLayer.BusinessObjects;

namespace ObjectCollab.BusinessLayer.Manager
{
    public interface IExternalDataManager
    {
        IList<IOledbDataRowBO> LoadOleDbData(IOleDbDataObjectBO dataObj);

    }
}