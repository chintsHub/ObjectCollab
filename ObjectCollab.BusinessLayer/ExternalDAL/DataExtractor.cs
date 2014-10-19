using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
//using System.Data.OracleClient;
using ObjectCollab.BusinessLayer.BusinessObjects;

namespace ObjectCollab.BusinessLayer.ExternalDAL
{
    public interface IDataProvider
    {
        IDataExtractor GetDataExtractor(IDataObjectBO dataObject);
    }

    public interface IDataExtractor
    {
        IDataRowBO[] GetDataRows();
    }

    public class DataProvider : IDataProvider
    {

        public IDataExtractor GetDataExtractor(IDataObjectBO dataObject)
        {
            IDataExtractor retVal = null;
           if(dataObject.GetType() == typeof(OleDbDataObjectBO))
           {
              retVal = new OledbDataExtractor(dataObject as OleDbDataObjectBO, new OleDbDataAccessManager());
           }

             return retVal;
        }

       
    }

    public class OledbDataExtractor : IDataExtractor
    {
        private IOleDbDataObjectBO oleDbObj;
        private IOleDbDataAccessManager exteranlDal;

        

        public OledbDataExtractor(IOleDbDataObjectBO oleDbObject, IOleDbDataAccessManager exteranlDal)
        {
            oleDbObj = oleDbObject;
            this.exteranlDal = exteranlDal;
        }


        
        public IDataRowBO[] GetDataRows()
        {
 	        IDbConnection connection = exteranlDal.GetConnection(oleDbObj.Connection.ConnectionString);

            return null;
        }
    }
}

