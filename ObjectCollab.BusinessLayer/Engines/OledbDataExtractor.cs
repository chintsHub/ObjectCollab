using System.Data;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Manager;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.Engine
{
    public class OledbDataExtractor : IDataExtractor
    {
        private IOleDbDataObject oleDbObj;
        private IOleDbDataAccessEngine exteranlDal;

        

        public OledbDataExtractor(IOleDbDataObject oleDbObject, IOleDbDataAccessEngine exteranlDal)
        {
            this.oleDbObj = oleDbObject;
            this.exteranlDal = exteranlDal;
        }


        
        public IDataRowBO[] GetDataRows()
        {
            
            IDbConnection connection = exteranlDal.GetConnection(oleDbObj.Connection.ConnectionString);

            return null;
        }
    }
}