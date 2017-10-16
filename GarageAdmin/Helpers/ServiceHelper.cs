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

        public static void ListServiceMechanicsForReg() {
            String regNo;
            List<Service> serviceDetails = new List<Service>();
            char keyEntered;

            do {
                keyEntered = ' ';
                string heading = "Mechanics who serviced Car";
                MenuHelper.DisplayEnterReg(heading);

                serviceDetails = TryGetServiceDetailsForCar(out regNo, ref keyEntered);
                if (serviceDetails.Count == 0) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (serviceDetails.Count == 0 && keyEntered != '0');

            if (serviceDetails.Count > 0) {
                ServiceDisplayHelper.DisplayMechanicsWhoServicedCar(regNo, serviceDetails);
                MenuHelper.DisplayPressKeyToReturnToMainMenu();
            }
        }

        public static void ListPartsReplacedInCar() {
            String regNo;
            List<Service> serviceDetails;
            char keyEntered;

            do {
                keyEntered = ' ';
                string heading = "Parts replaced during Car's Services";
                MenuHelper.DisplayEnterReg(heading);

                serviceDetails = TryGetServiceDetailsForCar(out regNo, ref keyEntered);
                if (serviceDetails.Count == 0) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (serviceDetails.Count == 0 && keyEntered != '0');

            if (serviceDetails.Count > 0) {
                ServiceDisplayHelper.DisplayPartsReplacedForAllServices(regNo, serviceDetails);
            }
        }

        public static void ListServicesByAMechanic() {
            List<Service> serviceDetails = new List<Service>();
            char keyEntered;
            int staffId;

            do {
                keyEntered = ' ';
                staffId = -1;
                MenuHelper.DisplayEnterMechanicId();

                serviceDetails = TryGetMechanicServiceDetails(ref staffId);
                if (staffId == -1) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (staffId == -1 && keyEntered != '0');

            if (staffId != -1) {
                DisplayServicesForMechanic(serviceDetails, staffId);
            }
        }

        public static void ListDetailsForAService() {
            Service service = new Service();
            char keyEntered;

            do {
                keyEntered = ' ';
                MenuHelper.DisplayEnterServiceId();
                string serviceIdString = Console.ReadLine().Trim();

                service = TryGetService(serviceIdString);
                if (service.Id == 0) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (service.Id == 0 && keyEntered != '0');

            if (service.Id != 0) {
                ServiceDisplayHelper.DisplayServiceDetails(service);
            }
        }

        private static List<Service> TryGetMechanicServiceDetails(ref int staffId) {
            List<Service> serviceDetails = new List<Service>();
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
            return serviceDetails;
        }

        private static Service TryGetService(string serviceIdString) {
            Service service = new Service();
            try {
                int serviceId = ValidationHelper.ValidateServiceId(serviceIdString);
                service = UnitOfWork.Services.GetServiceDetails(serviceId);
            } catch (InvalidCastException icEx) {
                Console.WriteLine($"\n\t{icEx.Message}");
            } catch (ArgumentException oorEx) {
                Console.WriteLine($"\n\t{oorEx.Message}");
            } catch (ServiceNotFoundException snfEx) {
                Console.WriteLine($"\n\t{snfEx.Message}");
            }

            return service;
        }

        private static void DisplayServicesForMechanic(List<Service> serviceDetails, int staffId) {
            if (serviceDetails.Count > 0) {
                ServiceDisplayHelper.DisplayServicesByMechanic(serviceDetails);
                MenuHelper.DisplayPressKeyToReturnToMainMenu();
            } else {
                var mechanic = UnitOfWork.Mechanics.GetMechanic(staffId);
                MenuHelper.DisplayNoServicesForMechanic(mechanic);
            }
        }

        private static List<Service> TryGetServiceDetailsForCar(out string regNo, ref char keyEntered) {
            List<Service> serviceDetails = new List<Service>();
            regNo = Console.ReadLine().ToUpper().Trim();
            try {
                ValidationHelper.ValidateRegNo(regNo);
                serviceDetails = UnitOfWork.Services.GetCarServiceDetailsByReg(regNo).ToList();
            } catch (InvalidRegException regEx) {
                Console.WriteLine($"\n\t{regEx.Message}");
            } catch (CarNotFoundException carEx) {
                Console.WriteLine($"\n\t{carEx.Message}");
            }

            return serviceDetails;
        }
    }
}