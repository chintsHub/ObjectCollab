using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Enums
{
    public enum ConnectionType
    {
        SqlClient,
        MicrosoftOracle,
        OracleODP,
        ODBC,
        OleDb
    }

    public enum OledbProvider
    {
        SQL = 1,
        Oracle = 2
    }

  

    public enum DataObjectType
    {
        Oledb = 1
    }

    public enum Role
    {
        SystemAdmin,
        Admin,
        Analyst
    }
}
