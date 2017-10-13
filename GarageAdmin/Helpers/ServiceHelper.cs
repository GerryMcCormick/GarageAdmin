using GarageAdmin.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Helpers {
    public class ServiceHelper {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(new GarageModelContainer());
            }
        }

        public static void ListCarServiceDetailsByReg() {
            String regNo;
            List<Service> serviceDetails = new List<Service>();
            char keyEntered;
            bool validRegNo;

            do {
                validRegNo = false;
                keyEntered = ' ';

                MenuHelper.DisplayEnterReg();
                regNo = Console.ReadLine().ToUpper().Trim();
                validRegNo = ValidationHelper.IsValidRegNo(regNo);

                if (!validRegNo) {
                    MenuHelper.DisplayInvalidRegEntered();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                } else {

                    if (ValidationHelper.CarExists(regNo)) {
                        serviceDetails = UnitOfWork.Services.GetCarServiceDetailsByReg(regNo).ToList();
                    } else {
                        MenuHelper.DisplayCarDoesNotExist();
                        char.TryParse(Console.ReadLine(), out keyEntered);
                    }
                }
            } while (ValidationHelper.InvalidRegDataEntered(regNo) && keyEntered != '0');

            if (serviceDetails.Count > 0) {
                DisplayMechanicsWhoServicedCar(regNo, serviceDetails);
                MenuHelper.DisplayPressKeyToReturnToMainMenu();
            }
        }

        public static void ListCarServiceDetailsByMechanic() {
            List<Service> serviceDetails = new List<Service>();
            char keyEntered;
            int staffId;

            do {
                keyEntered = ' ';

                MenuHelper.DisplayEnterMechanicId();
                bool staffIdIsNumber = int.TryParse(Console.ReadLine().Trim(), out staffId);

                if (staffIdIsNumber && ValidationHelper.ValidStaffIdNumberEntered(staffId)) {

                    if (ValidationHelper.MechanicExists(staffId)) {
                        serviceDetails = UnitOfWork.Services.GetCarsServicedByMechanic(staffId).ToList();
                    } else {
                        MenuHelper.DisplayMechanicDoesNotExist();
                        char.TryParse(Console.ReadLine(), out keyEntered);
                    }
                } else {
                    // Mechanic's Staff ID couldn't be parsed to an int
                    MenuHelper.DisplayInvalidMechanicIdEntered();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (!ValidationHelper.MechanicExists(staffId) && keyEntered != '0');

            if (keyEntered != '0') {
                DisplayServicesForMechanic(serviceDetails, staffId);
            }
        }

        private static void DisplayServicesForMechanic(List<Service> serviceDetails, int staffId) {
            if (serviceDetails.Count > 0) {
                DisplayServicesByMechanic(serviceDetails);
                MenuHelper.DisplayPressKeyToReturnToMainMenu();
            } else {
                var mechanic = UnitOfWork.Mechanics.GetMechanic(staffId);
                MenuHelper.DisplayNoServicesForMechanic(mechanic);
            }
        }

        private static void DisplayServicesByMechanic(List<Service> serviceDetails) {
            Console.Clear();
            Mechanic mechanic = serviceDetails.ElementAt(0).Mechanic;
            Console.WriteLine($"\n\t\t\t\tCars Serviced By {mechanic.Forename} {mechanic.Surname}");

            foreach (var service in serviceDetails) {
                string serviceDate = service.DateServiced.ToLocalTime().ToShortDateString();
                Console.WriteLine($"\n\t\tCar: \t\t\t{service.Car.RegNumber} {service.Car.Make} {service.Car.Model} " +
                                  $"\n\t\tServiced On: \t\t{serviceDate}" +
                                  $"\n\t\tOwner Telephone Number: {service.Car.CarOwner.TelNumber}");
            }
        }

        private static void DisplayMechanicsWhoServicedCar(string regNo, List<Service> serviceDetails) {
            Console.Clear();
            Console.WriteLine($"\n\t\t\t\tMechanics Who Serviced car {regNo}");
            
            foreach (var service in serviceDetails) {
                string serviceDate = service.DateServiced.ToLocalTime().ToShortDateString();
                Console.WriteLine($"\n\t\t{serviceDate} {service.Mechanic.Forename} {service.Mechanic.Surname}");
            }
        }
    }
}