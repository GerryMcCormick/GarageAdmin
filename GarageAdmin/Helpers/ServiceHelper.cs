using GarageAdmin.Exceptions;
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
            bool validRegEntered;

            do {
                keyEntered = ' ';
                MenuHelper.DisplayEnterReg();
                regNo = Console.ReadLine().ToUpper().Trim();
                try {
                    ValidationHelper.ValidateRegNo(regNo);
                    ValidationHelper.ValidateCarExists(regNo);
                    validRegEntered = true;
                    serviceDetails = UnitOfWork.Services.GetCarServiceDetailsByReg(regNo).ToList();
                } catch (InvalidRegException regEx) {
                    Console.WriteLine($"\n\t{regEx.Message}");
                    validRegEntered = false;
                } catch (CarNotFoundException carEx) {
                    Console.WriteLine($"\n\t{carEx.Message}");
                    validRegEntered = false;
                }

                if (!validRegEntered) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (!validRegEntered && keyEntered != '0');

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
                staffId = -1;
                MenuHelper.DisplayEnterMechanicId();

                try {
                    staffId = ValidationHelper.ValidateStaffId(Console.ReadLine().Trim());
                    serviceDetails = UnitOfWork.Services.GetCarsServicedByMechanic(staffId).ToList();
                } catch (InvalidCastException icEx) {
                    Console.WriteLine($"\n\t{icEx.Message}");
                } catch (ArgumentException oorEx) {
                    Console.WriteLine($"\n\t{oorEx.Message}");
                } catch (MechanicNotFoundException mnfEx) {
                    Console.WriteLine($"\n\t{mnfEx.Message}");
                }

                if (staffId == -1) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (staffId == -1 && keyEntered != '0');

            if (staffId != -1) {
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