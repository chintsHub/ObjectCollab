using System.Data;

namespace ObjectCollab.BusinessLayer.Engine
{
    public interface IOleDbDataAccessEngine
    {
        IDbConnection GetConnection(string connectionString);
        IDataAdapter GetDataAdapter(string selectStatement, IDbConnection connection);
    }
}