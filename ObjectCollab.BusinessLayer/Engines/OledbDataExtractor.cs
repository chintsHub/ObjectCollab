using System.Data;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Manager;

namespace ObjectCollab.BusinessLayer.Engine
{
    public class OledbDataExtractor : IDataExtractor
    {
        private IOleDbDataObjectBO oleDbObj;
        private IOleDbDataAccessEngine exteranlDal;

        

        public OledbDataExtractor(IOleDbDataObjectBO oleDbObject, IOleDbDataAccessEngine exteranlDal)
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