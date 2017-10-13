using System;
using System.Data.Entity;

namespace GarageAdmin.Persistance {
    public class GarageDbContext : GarageModelContainer {

        public override DbSet<Car> Cars { get; set; }
        public override DbSet<CarOwner> CarOwners { get; set; }
        public override DbSet<Service> Services { get; set; }
        public override DbSet<Invoice> Invoices { get; set; }
        public override DbSet<ServicePart> ServiceParts { get; set; }
        public override DbSet<Mechanic> Mechanics { get; set; }
        public override DbSet<Part> Parts { get; set; }

        public GarageDbContext() : base() { }

        public static GarageDbContext Create() {
            return new GarageDbContext();
        }

    }
}
