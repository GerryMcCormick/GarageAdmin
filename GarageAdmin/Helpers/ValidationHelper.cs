using GarageAdmin.Persistance.Repositories;
using System.Text.RegularExpressions;

namespace GarageAdmin.Helpers {
    public class ValidationHelper {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(new GarageModelContainer());
            }
        }

        public static bool InvalidRegDataEntered(string regNo) {
            return !IsValidRegNo(regNo) || !CarExists(regNo);
        }

        public static bool CarExists(string regNo) {
            var car = UnitOfWork.Cars.GetCar(regNo);
            return car != null;
        }

        public static bool IsValidRegNo(string regNo) {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            return regNo.Length <= 10 && regNo.Length >= 5 && alphanumeric.IsMatch(regNo);
        }

        public static bool MechanicExists(int staffId) {
            var mechanic = UnitOfWork.Mechanics.GetMechanic(staffId);
            return mechanic != null;
        }

        public static bool ValidStaffIdNumberEntered(int staffId) {
            return staffId > 0 & staffId < 10000;
        }
    }
}
