using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.Domain;
using ObjectCollab.Domain.Domain;

namespace ObjectCollab.DAL
{
    public interface IAppDbContext : IDisposable
    {
        IDbSet<DataObject> DataObjects { get; set; }
        IDbSet<OleDbDataObject> OleDbDataObjects { get; set; }
        IDbSet<DataObjectGroup> DataObjectGroups { get; set; }
        IDbSet<OledbConnection> OledbConnections { get; set; }
        
        IDbSet<User> Users { get; set; }

        int SaveChanges();
    }

    public class ObjectCollabContext : DbContext, IAppDbContext
    {
        private readonly string _connectionString;

        public IDbSet<DataObject> DataObjects { get; set; }
        public IDbSet<OleDbDataObject> OleDbDataObjects { get; set; }
        public IDbSet<DataObjectGroup> DataObjectGroups { get; set; }
        public IDbSet<OledbConnection> OledbConnections { get; set; }
        
        public IDbSet<User> Users { get; set; }

        public ObjectCollabContext()
        { }

        public ObjectCollabContext(string connectionString)
            : base(connectionString)
        {

            this._connectionString = connectionString;

        }



        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapperType = typeof(ObjectCollab.Domain.Mapper.BaseMapper);
            var mapperAssembly = mapperType.Assembly;
            var mappers = mapperAssembly.GetTypes().Where(t => mapperType.IsAssignableFrom(t) && t != mapperType);
            foreach (var m in mappers.Select(mapper => (ObjectCollab.Domain.Mapper.BaseMapper)Activator.CreateInstance(mapper, modelBuilder)))
            {
                m.RegisterMapping();

            }

            base.OnModelCreating(modelBuilder);


        }

        protected int SaveChages()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException validationException)
            {
                throw validationException;
            }
        }


    }
}
