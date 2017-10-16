using GarageAdmin.Core.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Persistance.Repositories {
    class ServiceRepository : IServiceRepository {

        private readonly GarageModelContainer _context;

        public ServiceRepository(GarageModelContainer context) {
            _context = context;
        }

        public Service GetServiceDetails(int serviceId) {
            return _context.Services
                           .Where(s => s.Id == serviceId)
                           .FirstOrDefault();
        }

        public IEnumerable<Service> GetCarServiceDetailsByReg(string regNo) {
            return _context.Services
                           .Where(s => s.Car.RegNumber == regNo)
                           .OrderBy(s => s.DateServiced); 
        }

        public IEnumerable<Service> GetCarsServicedByMechanic(int staffId) {
            return _context.Services
                           .Where(m => m.Mechanic.Id == staffId)
                           .OrderBy(s => s.DateServiced);
        }
    }
}
