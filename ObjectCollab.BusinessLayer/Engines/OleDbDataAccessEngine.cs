using System;
using System.Data;
using ObjectCollab.BusinessLayer.Engine;

namespace ObjectCollab.BusinessLayer.Engine
{
    public class OleDbDataAccessEngine : IOleDbDataAccessEngine
    {
       


        public  IDbConnection GetConnection(string connectionString)
        {

            ConnectionType thisConnectionType = CheckConnectionType(connectionString);

            #region Now generate the connection
            IDbConnection connection = null;

            switch (thisConnectionType)
            {
                case ConnectionType.SqlClient:
                    connection = new System.Data.SqlClient.SqlConnection(connectionString);
                    break;

                case ConnectionType.OleDb:
                    connection = new System.Data.OleDb.OleDbConnection(connectionString);
                    break;
                case ConnectionType.MicrosoftOracle:
                    //connection = new System.Data.OracleClient.OracleConnection(connectionString);
                    break;

                default:
                    //TODO : make error message part of configuration.
                    throw new ApplicationException(string.Format("ConnectionType '{0}' requested from the Database Manager is not yet supported", thisConnectionType.ToString()));
            }
            #endregion

            return connection;
        }

        private ConnectionType CheckConnectionType(string connectionString)
        {
            #region Work out what type of connection we should provide

            ConnectionType thisConnectionType = connectionString.ToLower().Contains("provider") ? ConnectionType.OleDb : ConnectionType.SqlClient; //default.

            if (connectionString.Contains("MSDAORA.1"))
                thisConnectionType = ConnectionType.MicrosoftOracle;
           
            #endregion

            return thisConnectionType;
        }
    }
}