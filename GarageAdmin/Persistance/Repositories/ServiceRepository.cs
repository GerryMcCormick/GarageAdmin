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

        public Service GetCarServiceDetails(int serviceId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Q2 requires a list of mechanics who serviced car ordered by service date,
        /// we can get that info from this method.
        /// </summary>
        public IEnumerable<Service> GetCarServiceDetailsByReg(string regNo) {
            return _context.Services
                           .Include(s => s.Mechanic)
                           .Include(s => s.Car)
                           .Where(c => c.Car.RegNumber == regNo)
                           .OrderBy(s => s.DateServiced); // order by date serviced
        }

        /// <summary>
        /// Q3
        /// </summary>
        public IEnumerable<Service> GetCarsServicedByMechanic(int staffId) {
            IEnumerable<Service> services = _context.Services
                .Include(s => s.Mechanic).Where(m => m.MechanicId == staffId)
                .Include(s => s.Car)
                .OrderBy(s => s.DateServiced);

            return services;
        }
    }
}
