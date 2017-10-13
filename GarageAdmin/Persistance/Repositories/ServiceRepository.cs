using GarageAdmin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace GarageAdmin.Persistance.Repositories {
    class ServiceRepository : IServiceRepository {

        private readonly GarageDbContext _context;

        public ServiceRepository(GarageDbContext context) {
            _context = context;
        }

        public Service GetServiceDetails(int serviceId) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Q2 requires a list of mechanics who serviced car ordered by service date,
        /// we can get that info from this method.
        /// </summary>
        public IEnumerable<Service> GetCarServiceDetails(string regNo) {
            return _context.Services
                           .Include(s => s.Mechanic)
                           .Include(s => s.Car)
                           .Where(c => c.Car.RegNumber == regNo)
                           .OrderBy(s => s.DateServiced); // order by date serviced
        }
    }
}
