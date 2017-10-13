using GarageAdmin.Persistance;
using GarageAdmin.Persistance.Repositories;
using System.Text.RegularExpressions;

namespace GarageAdmin.Helpers {
    public class ValidationHelper {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(GarageDbContext.Create());
            }
        }

        public static bool InvalidDataEntered(bool validRegNo, bool carExists) {
            return !validRegNo || !carExists;
        }

        public static bool CarExists(string regNo) {
            var car = UnitOfWork.Cars.GetCar(regNo);
            return car != null;
        }

        public static bool IsValidRegNo(string regNo) {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            return regNo.Length <= 10 && regNo.Length >= 5 && alphanumeric.IsMatch(regNo);
        }
    }
}
