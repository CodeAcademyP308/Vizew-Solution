using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Vizew.WebUI.Migrations;
using Vizew.WebUI.Models.Entity;

namespace Vizew.WebUI.Models
{
    public class VizewDbContext : DbContext
    {
        internal const string schemaName = "dbo";
        public VizewDbContext()
            :base("name=cString")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<VizewDbContext,Configuration>());
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<VizewDatabaseGeneratedAttribute, string>("VizewDatabaseGenerated", (p, attributes) => attributes.Single().DefaultValueSql));
            modelBuilder.Conventions.Add(new AttributeToColumnAnnotationConvention<VizewSqlDefaultValueAttribute, string>("VizewSqlDefaultValue", (p, attributes) => attributes.Single().DefaultValueSql));

            SetSchema(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        void SetSchema(DbModelBuilder modelBuilder)
        {
            if (schemaName == "dbo")
                return;

            modelBuilder.Entity<Category>().ToTable("Category", schemaName);
            modelBuilder.Entity<News>().ToTable("News", schemaName);
            modelBuilder.Entity<ErrorHistory>().ToTable("News", schemaName);
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<News> News { get; set; }
        public DbSet<ErrorHistory> ErrorHistory { get; set; }
        public DbSet<Contact> Contact { get; set; }
    }
}