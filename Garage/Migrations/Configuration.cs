namespace Garage.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Garage.DB.Databas>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Garage.DB.Databas context)
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

            context.Nyheter.AddOrUpdate(new Models.NyhetModel { �mne="Ett", Inneh�ll="F�rsta post"},
                new Models.NyhetModel { �mne="tv�", Inneh�ll="andra post"},
                new Models.NyhetModel { �mne="tre", Inneh�ll="tredje post"},
                new Models.NyhetModel { �mne="fyra", Inneh�ll="fj�rde post"},
                new Models.NyhetModel { �mne="fem", Inneh�ll="femte post"}
                );
        }
    }
}
