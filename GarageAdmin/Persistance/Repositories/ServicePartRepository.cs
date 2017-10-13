using GarageAdmin.Core.Repositories;
using System;
using System.Data.Entity;

namespace GarageAdmin.Persistance.Repositories {
    class ServicePartRepository : IServicePartRepository {

        private readonly GarageModelContainer _context;

        public ServicePartRepository(GarageModelContainer context) {
            _context = context;
        }

        public DbSet<ServicePart> GetPartsReplacedForAllServices(string carReg) {
            throw new NotImplementedException();
        }
    }
}
