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
        private IDataProvider oledbDataProvider;

        public ExternalDataManager(IDataProvider oledbDataProvider)
        {
            this.oledbDataProvider = oledbDataProvider;

            
        }

        public IList<IOledbDataRowBO> LoadOleDbData(IOleDbDataObjectBO dataObj)
        {

            return oledbDataProvider.GetDataRows(dataObj);
        }
    }
}