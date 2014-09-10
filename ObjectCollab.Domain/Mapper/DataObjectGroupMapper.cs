using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectCollab.Domain.Mapper
{
    public class DataObjectGroupMapper : BaseMapper
    {
        private const string tableName = "DataObjectHierarchy";

        protected EntityTypeConfiguration<DataObjectGroup> configuration;
        public DataObjectGroupMapper(DbModelBuilder builder) :
            base(builder)
        {
            configuration = builder.Entity<DataObjectGroup>();
        }

        public override void RegisterMapping()
        {
            configuration.ToTable(tableName);
            configuration.HasKey(c => c.Id);
            configuration.Property(c => c.RowVersion).IsRowVersion();
            configuration.Property(c => c.Name).IsRequired();

            configuration.HasMany(c => c.DataObjects)
                .WithRequired(c => c.Group)
                .HasForeignKey(c => c.GroupId);

            configuration.HasOptional(c => c.ParentGroup)
                .WithMany(c => c.ChildrenGroups)
                .HasForeignKey(c => c.ParentId);

        }
    }
}
