using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using ObjectCollab.DAL;

namespace ObjectCollab.Migration
{
    public class ObjectCollabMigrator
    {
        private readonly string _connectionString;

        public ObjectCollabMigrator(string connectionString)
        {
            this._connectionString = connectionString;
        }

        public void MigrateDatabase()
        {
            var context = new ObjectCollabContext(_connectionString);
            var migration = new ObjectCollabMigration<ObjectCollabContext, ObjectCollabConfiguration>(_connectionString);
            migration.InitializeDatabase(context);
            Database.SetInitializer<ObjectCollabContext>(migration);

            //var migration1 =
            //    new MigrateDatabaseToLatestVersion<ObjectCollabContext, ObjectCollabConfiguration>(true);
            //Database.SetInitializer<ObjectCollabContext>(migration1);

        }

    }

    public class ObjectCollabMigration<TContext, TConfiguration> : IDatabaseInitializer<TContext>
        where TContext : ObjectCollabContext
        where TConfiguration : DbMigrationsConfiguration<TContext>, new()
    {
        private readonly DbMigrationsConfiguration migrationConfiguration;

        public ObjectCollabMigration(string connectionString)
        {
            migrationConfiguration = new TConfiguration();
            migrationConfiguration.TargetDatabase = new DbConnectionInfo(connectionString, "System.Data.SqlClient");
        }


        public void InitializeDatabase(TContext context)
        {
            //if (context == null)
            //{
            //    throw new ArgumentException("Context passed to InitializeDatabase can not be null");
            //}
            //if (Database.Exists(context.Database.Connection.ConnectionString) && !context.Database.CompatibleWithModel(true))
            //    throw new ArgumentException("Database exist but not matching the current model. Please upgrade app.");

            //if (!Database.Exists(context.Database.Connection.ConnectionString))
            //{
            //    var migrator = new DbMigrator(migrationConfiguration);
            //    migrator.Update();
            //}
        }


    }


    internal class ObjectCollabConfiguration : DbMigrationsConfiguration<ObjectCollabContext>
    {
        public ObjectCollabConfiguration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ObjectCollabContext context)
        {

            //Assumption for Seeding data : Seeding data will only be inserted for empty database. The assumption here
            //is - if there is record in AssetCategoryGroup, the seeding data will not be inserted.

            string fileName = "";
#if DEBUG
            fileName = "ObjectCollab.Migration.SeedingSQL.SeedData.sql";
#else
                    fileName = "ObjectCollab.Migration.SeedingSQL.SeedData.sql";
#endif

            string commandText;
            Assembly thisAssembly = Assembly.GetExecutingAssembly();
            using (Stream s = thisAssembly.GetManifestResourceStream(
                fileName))
            {
                using (StreamReader sr = new StreamReader(s))
                {
                    commandText = sr.ReadToEnd();
                }
            }
            context.Database.CommandTimeout = 300;
            context.Database.ExecuteSqlCommand(commandText);
        }
    }
}
