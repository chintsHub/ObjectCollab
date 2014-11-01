using System;
using System.Collections.Generic;
using System.Text;
//using System.Data.OracleClient;
using ObjectCollab.BusinessLayer.BusinessObjects;

namespace ObjectCollab.BusinessLayer.Engine
{
    public interface IDataProvider
    {
        IList<IDataRowBO> GetDataRows();
    }
}

