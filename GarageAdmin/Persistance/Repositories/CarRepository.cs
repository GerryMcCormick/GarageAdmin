using GarageAdmin.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Persistance.Repositories {
    public class CarRepository : ICarRepository {

        private GarageModelContainer _context;

        public CarRepository(GarageModelContainer context) {
            _context = context;
        }

        public Car GetCar(string regNo) {
            IEnumerable<Car> cars = from c in _context.Cars
                                    where c.RegNumber == regNo
                                    select c;

            return cars.FirstOrDefault();
        }

        public IEnumerable<Car> GetCarsServicedByMechanic(int mechanicId) {
            throw new NotImplementedException();
        }
    }
}
