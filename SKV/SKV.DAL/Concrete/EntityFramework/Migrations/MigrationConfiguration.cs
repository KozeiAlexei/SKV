using System.Data.Entity.Migrations;

namespace SKV.DAL.Concrete.EntityFramework.Migrations
{
    internal sealed class MigrationConfiguration : DbMigrationsConfiguration<DatabaseContext>
    {
        public MigrationConfiguration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DatabaseContext context)
        {
        }
    }
}
