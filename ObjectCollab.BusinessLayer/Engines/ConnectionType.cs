using System.Collections.Generic;
using System.Text;
//using System.Data.OracleClient;
using ObjectCollab.BusinessLayer.Manager;

namespace ObjectCollab.BusinessLayer.Engine
{
    public  enum ConnectionType
    {
        SqlClient,
        MicrosoftOracle,
        OracleODP,
        ODBC,
        OleDb
    }
}
