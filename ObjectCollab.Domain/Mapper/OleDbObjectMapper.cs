using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;


namespace ObjectCollab.Domain.Mapper
{
    public class OleDbObjectMapper : BaseMapper
    {
        private const string tableName = "OleDbObject";

        protected EntityTypeConfiguration<OleDbDataObject> configuration;
        public OleDbObjectMapper(DbModelBuilder builder) :
            base(builder)
        {
            configuration = builder.Entity<OleDbDataObject>();
        }

        public override void RegisterMapping()
        {
            configuration.ToTable(tableName);
            configuration.HasKey(c => c.Id);
            configuration.Property(c => c.ObjectName).IsRequired();

            configuration.HasRequired(c => c.Connection)
                .WithMany().HasForeignKey(c => c.ConnectionId).WillCascadeOnDelete(false);


        }
    }
}