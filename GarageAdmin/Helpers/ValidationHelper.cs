using GarageAdmin.Exceptions;
using GarageAdmin.Persistance.Repositories;
using System;
using System.Text.RegularExpressions;

namespace GarageAdmin.Helpers {
    public class ValidationHelper {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(new GarageModelContainer());
            }
        }

        public static void ValidateCarExists(string regNo) {
            var car = UnitOfWork.Cars.GetCar(regNo);

            if (car == null) {
                throw new CarNotFoundException("No car exists that matches the Reg Number entered");
            }
        }

        public static void ValidateRegNo(string regNo) {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            if (regNo.Length > 10 || regNo.Length < 5 || !alphanumeric.IsMatch(regNo)) {
                throw new InvalidRegException("Reg Number entered must be 5 - 10 alphanumeric characters");
            }
        }

        public static bool MechanicExists(int staffId) {
            var mechanic = UnitOfWork.Mechanics.GetMechanic(staffId);
            return mechanic != null;
        }

        public static int ValidateStaffId(string staffIdString) {
            if (!int.TryParse(staffIdString, out int staffId)) {
                throw new InvalidCastException("Mechanic's Staff ID must be 1 - 4 digits");
            }
            if (staffId < 0 || staffId > 9999) {
                throw new ArgumentException("Mechanic's Staff ID must be 1 - 4 digits");
            }
            if (!MechanicExists(staffId)) {
                throw new MechanicNotFoundException("No Mechanic exists that matches the Staff ID entered");
            }

            return staffId;
        }
    }
}
