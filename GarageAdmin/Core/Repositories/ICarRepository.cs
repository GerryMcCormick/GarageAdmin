using System.Collections.Generic;

namespace GarageAdmin.Core.Repositories {
    public interface ICarRepository {
        Car GetCar(string regNo);
        IEnumerable<Car> GetCarsServicedByMechanic(int mechanicId); 
    }
}
