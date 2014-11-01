using System;
using System.Data;

using ObjectCollab.Enums;

namespace ObjectCollab.BusinessLayer.Engine
{
    internal class OleDbDataAccessEngine : IOleDbDataAccessEngine
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

        public IDataAdapter GetDataAdapter(string selectStatement, IDbConnection connection)
        {
            ConnectionType thisConnectionType = CheckConnectionType(connection.ConnectionString);

            #region Now generate the connection
            IDbDataAdapter adapter = null;

            switch (thisConnectionType)
            {
                case ConnectionType.SqlClient:
                    adapter = new System.Data.SqlClient.SqlDataAdapter(selectStatement, (System.Data.SqlClient.SqlConnection)connection);
                    break;

                case ConnectionType.OleDb:
                    adapter = new System.Data.OleDb.OleDbDataAdapter(selectStatement, (System.Data.OleDb.OleDbConnection)connection);
                    break;
                case ConnectionType.MicrosoftOracle:
                    //adapter = new System.Data.OracleClient.OracleDataAdapter(selectStatement, (System.Data.OracleClient.OracleConnection)connection);
                   // break;

                default:
                    //TODO : make error message part of configuration.
                    throw new ApplicationException(string.Format("ConnectionType '{0}' requested from the Database Manager is not yet supported", thisConnectionType.ToString()));
            }
            #endregion

            return adapter;
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