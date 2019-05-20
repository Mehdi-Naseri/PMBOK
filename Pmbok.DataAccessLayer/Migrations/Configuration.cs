using System.Data.Entity.Migrations;
using Pmbok.DataAccessLayer.DataContext;


namespace Pmbok.DataAccessLayer.Migrations
{
    internal sealed class Configuration : DbMigrationsConfiguration<Pmbok.DataAccessLayer.DataContext.PmbokDBContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
        }

        protected override void Seed(Pmbok.DataAccessLayer.DataContext.PmbokDBContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data. E.g.
            //
            //    context.People.AddOrUpdate(
            //      p => p.FullName,
            //      new Person { FullName = "Andrew Peters" },
            //      new Person { FullName = "Brice Lambson" },
            //      new Person { FullName = "Rowan Miller" }
            //    );
            //

            SeedIdentity seedIdentity = new SeedIdentity();
            seedIdentity.CreateAdminUserAndRole();
            seedIdentity.AddRoles();

            SeedPmbokDb seedPmbokDb = new SeedPmbokDb();
            seedPmbokDb.AddProjectDocumentsNames();
        }
    }
}
