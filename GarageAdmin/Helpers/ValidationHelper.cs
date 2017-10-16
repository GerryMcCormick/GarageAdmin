using GarageAdmin.Exceptions;
using GarageAdmin.Services;
using System;
using System.Text.RegularExpressions;

namespace GarageAdmin.Helpers {
    public class ValidationHelper {

        private class EntityType {
            public static string MECHANIC = "Mechanic";
            public static string SERVICE = "Service";
        }

        public static void ValidateRegNo(string regNo) {
            Regex alphanumeric = new Regex("^[a-zA-Z0-9]*$");
            if (regNo.Length > 10 || regNo.Length < 5 || !alphanumeric.IsMatch(regNo)) {
                throw new InvalidRegException("Reg Number entered must be 5 - 10 alphanumeric characters");
            }
            CarExists(regNo);
        }

        public static int ValidateStaffIdString(string staffIdString) {
            int staffId = ValidateId(staffIdString, EntityType.MECHANIC);
            if (!MechanicExists(staffId)) {
                throw new MechanicNotFoundException("No Mechanic exists that matches the Staff ID entered");
            }
            return staffId;
        }

        public static int ValidateServiceIdString(string serviceIdString) {
            int serviceId = ValidateId(serviceIdString, EntityType.SERVICE);
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
            string message = $"{entityType} ID must be 1 - 4 digits, 1 - 9999";
            if (!int.TryParse(idString, out int id)) {
                throw new InvalidCastException(message);
            }
            if (id < 1 || id > 9999) {
                throw new ArgumentException(message);
            }

            return id;
        }

        private static void CarExists(string regNo) {
            var car = CarService.GetCar(regNo);
            if (car == null) {
                throw new CarNotFoundException("No car exists that matches the Reg Number entered");
            }
        }

        private static bool MechanicExists(int staffId) {
            var mechanic = MechanicsService.GetMechanic(staffId);
            return mechanic != null;
        }

        private static bool ServiceExists(int serviceId) {
            var service = ServicesService.GetServiceById(serviceId);
            return service != null;
        }
    }
}
