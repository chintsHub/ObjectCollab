using System.Data;
using System.Collections.Generic;
using ObjectCollab.BusinessLayer.BusinessObjects;
using ObjectCollab.BusinessLayer.Manager;
using ObjectCollab.Domain;

namespace ObjectCollab.BusinessLayer.Engine
{
    public class OledbDataProvider : IDataProvider
    {
        
        private IOleDbDataAccessEngine exteranlDal;

        

        public OledbDataProvider(IOleDbDataAccessEngine exteranlDal)
        {
            
            this.exteranlDal = exteranlDal;
        }



        public IList<IOledbDataRowBO> GetDataRows(IOleDbDataObjectBO oleDbObject)
        {
            DataTable externalData = null;
            using (IDbConnection connection = exteranlDal.GetConnection(oleDbObject.Connection.ConnectionString))
            {
                try
                {
                    connection.Open();
                    IDataAdapter da = exteranlDal.GetDataAdapter("select * from " + oleDbObject.ObjectName, connection);
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
            var returnValue = new List<IOledbDataRowBO>();
            //construct datarow
            foreach(DataRow row in externalData.Rows)
            {
                var rowBo = new OledbDataRowBo(row, oleDbObject);
                returnValue.Add(rowBo);
            }

            return returnValue;
        }
    }
}