using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.Domain.Domain;

namespace ObjectCollab.Domain.Mapper
{
    public class UserMapper : BaseMapper
    {
        private const string tableName = "User";

        protected EntityTypeConfiguration<User> configuration;
        public UserMapper(DbModelBuilder builder) :
            base(builder)
        {
            configuration = builder.Entity<User>();
        }

        public override void RegisterMapping()
        {
            configuration.ToTable(tableName);
            configuration.HasKey(c => c.UserId);
            configuration.Property(c => c.UserName).IsRequired();
            configuration.Property(c => c.Role).IsRequired();
            configuration.Property(c => c.RowVersion).IsRowVersion();

            //configuration.HasMany(c => c.UserRoles).WithRequired(p => p.User).HasForeignKey(p => p.UserId); 
            //configuration
            //    .HasMany(u => u.Roles)
            //    .WithMany(r => r.Users)
            //    .Map(x =>
            //    {
            //        x.ToTable("OC_UserRole");
            //        x.MapLeftKey("UserId");
            //        x.MapRightKey("RoleId");
            //    });


        }
    }
}
