using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using ObjectCollab.Domain.Domain;

namespace ObjectCollab.Domain.Mapper
{
    public class OleDbConnectionMapper : BaseMapper
    {
        private const string tableName = "OleDbConnection";

        protected EntityTypeConfiguration<OledbConnection> configuration;
        public OleDbConnectionMapper(DbModelBuilder builder) :
            base(builder)
        {
            configuration = builder.Entity<OledbConnection>();
        }

        public override void RegisterMapping()
        {
            configuration.ToTable(tableName);
            configuration.HasKey(c => c.ConnectionId);
            configuration.Property(c => c.RowVersion).IsRowVersion();
            configuration.Property(c => c.ConnectionName).IsRequired();
            configuration.Property(c => c.ConnectionString).IsRequired();
            configuration.Property(c => c.Provider).IsRequired();

        }
    }
}