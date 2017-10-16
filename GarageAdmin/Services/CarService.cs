using GarageAdmin.Persistance.Repositories;

namespace GarageAdmin.Services {
    public class CarService {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(new GarageModelContainer());
            }
        }

        public static Car GetCar(string regNo) {
            return UnitOfWork.Cars.GetCar(regNo);
        }
    }
}
