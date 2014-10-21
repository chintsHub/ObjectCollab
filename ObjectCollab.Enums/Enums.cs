using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Enums
{
    public enum OledbProvider
    {
        SQL,
        Oracle
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
