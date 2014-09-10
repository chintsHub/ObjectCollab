using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;

namespace ObjectCollab.Domain.Mapper
{
    public class DataObjectMapper : BaseMapper
    {
        private const string tableName = "DataObject";

        protected EntityTypeConfiguration<DataObject> configuration;
        public DataObjectMapper(DbModelBuilder builder) :
            base(builder)
        {
            configuration = builder.Entity<DataObject>();
        }

        public override void RegisterMapping()
        {
            configuration.ToTable(tableName);
            configuration.HasKey(c => c.DataObjectId);
            configuration.Property(c => c.DataObjectLabel).IsRequired();
            configuration.Property(c => c.RowVersion).IsRowVersion();

            // configuration.HasRequired(c => c.Config).WithRequiredPrincipal(c => c.DataObject);
        }
    }
}