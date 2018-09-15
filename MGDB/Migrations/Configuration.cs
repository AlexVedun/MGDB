namespace MGDB.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MGDB.Models.MGDBModelContainer>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MGDB.Models.MGDBModelContainer";
        }

        protected override void Seed(MGDB.Models.MGDBModelContainer context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }
    }
}
