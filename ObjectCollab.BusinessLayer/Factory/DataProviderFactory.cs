using System;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.Domain;
using ObjectCollab.Enums;


namespace ObjectCollab.BusinessLayer.Factory
{
    public class DataProviderFactory : IDataProviderFactory
    {

        public Engine.IDataProvider GetDataProvider(IDataObjectBO dataObject)
        {
            Engine.IDataProvider retVal = null;
            if (dataObject.DataObjectType == DataObjectType.Oledb)
            {
                retVal = new OledbDataProvider(dataObject as IOleDbDataObjectBO, new OleDbDataAccessEngine());
            }

            return retVal;
        }

       
    }
}