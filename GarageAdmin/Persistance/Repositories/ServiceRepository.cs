using GarageAdmin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
                           .Include(s => s.Mechanic)
                           .Include(s => s.Car)
                           .Where(c => c.Car.RegNumber == regNo)
                           .OrderBy(s => s.DateServiced); 
        }

        public IEnumerable<Service> GetCarsServicedByMechanic(int staffId) {
            return _context.Services
                           .Include(s => s.Mechanic).Where(m => m.MechanicId == staffId)
                           .Include(s => s.Car)
                           .OrderBy(s => s.DateServiced);
        }
    }
}
