using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.DAL
{
    public interface IObjectCollabDAL
    {
        IAppDbContext GetDataContext();
    }

    public class ObjectCollabDAL : IObjectCollabDAL
    {
        private string _connectionString;

        public ObjectCollabDAL(string connectionString)
        {
            _connectionString = connectionString;
        }
        IAppDbContext IObjectCollabDAL.GetDataContext()
        {
            if (string.IsNullOrEmpty(_connectionString))
                return null;

            var context = new ObjectCollabContext(_connectionString);
            return context;
        }
    }
}
