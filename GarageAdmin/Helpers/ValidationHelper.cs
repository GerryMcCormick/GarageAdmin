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

        public static void ValidateRegNo(string regNo) {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            if (regNo.Length > 10 || regNo.Length < 5 || !alphanumeric.IsMatch(regNo)) {
                throw new InvalidRegException("Reg Number entered must be 5 - 10 alphanumeric characters");
            }
            ValidateCarExists(regNo);
        }

        public static void ValidateCarExists(string regNo) {
            var car = UnitOfWork.Cars.GetCar(regNo);

            if (car == null) {
                throw new CarNotFoundException("No car exists that matches the Reg Number entered");
            }
        }

        public static bool MechanicExists(int staffId) {
            var mechanic = UnitOfWork.Mechanics.GetMechanic(staffId);
            return mechanic != null;
        }

        public static bool ServiceExists(int serviceId) {
            var service = UnitOfWork.Services.GetServiceDetails(serviceId);
            return service != null;
        }

        public static int ValidateStaffId(string staffIdString) {
            int staffId = ValidateId(staffIdString, "Mechanic");
            if (!MechanicExists(staffId)) {
                throw new MechanicNotFoundException("No Mechanic exists that matches the Staff ID entered");
            }

            return staffId;
        }

        public static int ValidateServiceId(string serviceIdString) {
            int serviceId = ValidateId(serviceIdString, "Service");
            if (!ServiceExists(serviceId)) {
                throw new ServiceNotFoundException("No Service exists that matches the Service ID entered");
            }

            return serviceId;
        }

        /// <summary>
        /// Validates a Mechanic or Service ID.
        /// </summary>
        /// <param name="idString">The ID as a string.</param>
        /// <param name="entityType">Either "Mechanic" or "Service".</param>
        /// <returns>If successful the ID is returned as an int.</returns>
        private static int ValidateId(string idString, string entityType) {
            if (!int.TryParse(idString, out int id)) {
                throw new InvalidCastException($"{entityType} ID must be 1 - 4 digits, 1 - 9999");
            }
            if (id < 1 || id > 9999) {
                throw new ArgumentException($"{entityType} ID must be 1 - 4 digits, 1 - 9999");
            }

            return id;
        }
    }
}
