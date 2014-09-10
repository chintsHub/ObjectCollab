using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using ObjectCollab.Domain.Domain;

namespace ObjectCollab.Domain.Mapper
{
    public class ColumnDefinitionMapper : BaseMapper
    {
        private const string tableName = "ColumnDefinition";

        protected EntityTypeConfiguration<ColumnDefinition> configuration;
        public ColumnDefinitionMapper(DbModelBuilder builder) :
            base(builder)
        {
            configuration = builder.Entity<ColumnDefinition>();
        }

        public override void RegisterMapping()
        {
            configuration.ToTable(tableName);
            configuration.HasKey(c => c.ColumnId);
            configuration.Property(c => c.RowVersion).IsRowVersion();
            configuration.Property(c => c.SourceColumn).IsRequired();
            configuration.Property(c => c.Label).IsRequired();

            configuration.HasRequired(c => c.OleDbDataObject).WithMany(o => o.ColumnDefinitions)
                .HasForeignKey(c => c.OleDbDataObjectId)
                .WillCascadeOnDelete(true);


        }
    }
}