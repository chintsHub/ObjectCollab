using System;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Engine;
using ObjectCollab.Domain;
using ObjectCollab.Enums;


namespace ObjectCollab.BusinessLayer.Factory
{
    public class DataProvider : IDataProvider
    {

        public IDataExtractor GetDataExtractor(IDataObjectBO dataObject)
        {
            IDataExtractor retVal = null;
            if (dataObject.DataObjectType == DataObjectType.Oledb)
            {
                retVal = new OledbDataExtractor(dataObject as IOleDbDataObjectBO, new OleDbDataAccessEngine());
            }

            return retVal;
        }

       
    }
}