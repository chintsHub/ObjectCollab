using System.Data;
using System.Collections.Generic;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Manager;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.Engine
{
    public class OledbDataProvider : IDataProvider
    {
        private IOleDbDataObjectBO oleDbObj;
        private IOleDbDataAccessEngine exteranlDal;

        

        public OledbDataProvider(IOleDbDataObjectBO oleDbObject, IOleDbDataAccessEngine exteranlDal)
        {
            this.oleDbObj = oleDbObject;
            this.exteranlDal = exteranlDal;
        }


        
        public IList<IDataRowBO> GetDataRows()
        {
            DataTable externalData = null;
            using (IDbConnection connection = exteranlDal.GetConnection(oleDbObj.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    IDataAdapter da = exteranlDal.GetDataAdapter("select * from " + oleDbObj.ObjectName, connection);
                    DataSet ds = new DataSet();

                    //if (schemaOnly)
                    //    da.FillSchema(ds, SchemaType.Source);
                    //else
                    da.Fill(ds);

                    if (ds.Tables.Count > 0)
                        externalData = ds.Tables[0];
                }
                finally
                {
                    //imperative we close the connection. no need to dispose as the using takes care of it.
                    if (connection != null)
                        connection.Close();
                }
            }
            var returnValue = new List<IDataRowBO>();
            //construct datarow
            foreach(DataRow row in externalData.Rows)
            {
                var rowBo = new DataRowBO(row, oleDbObj);
                returnValue.Add(rowBo);
            }

            return returnValue;
        }
    }
}