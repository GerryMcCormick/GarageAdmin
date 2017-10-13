using GarageAdmin.Core.Repositories;
using System;
using System.Data.Entity;

namespace GarageAdmin.Persistance.Repositories {
    class ServicePartRepository : IServicePartRepository {

        private readonly GarageDbContext _context;

        public ServicePartRepository(GarageDbContext context) {
            _context = context;
        }

        public DbSet<ServicePart> GetPartsReplacedForAllServices(string carReg) {
            throw new NotImplementedException();
        }
    }
}
