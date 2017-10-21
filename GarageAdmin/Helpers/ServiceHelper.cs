using GarageAdmin.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Helpers {
    public class ServiceHelper {

        public static void ListServiceMechanicsForReg() {
            String regNo;
            List<Service> serviceDetails = new List<Service>();
            char keyEntered;

            do {
                keyEntered = ' ';
                string heading = "Mechanics who serviced Car";
                MenuHelper.DisplayEnterReg(heading);
                regNo = Console.ReadLine().ToUpper().Trim();
                serviceDetails = ServicesService.GetServiceDetailsForCar(regNo, ref keyEntered);
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
                regNo = Console.ReadLine().ToUpper().Trim();
                serviceDetails = ServicesService.GetServiceDetailsForCar(regNo, ref keyEntered);
                if (serviceDetails.Count == 0) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (serviceDetails.Count == 0 && keyEntered != '0');

            if (serviceDetails.Count > 0) {
                ServiceDisplayHelper.DisplayPartsReplacedForAllServices(regNo, serviceDetails);
            }
        }

        public static void ListCarsLatestServiceBill() {
            Service service;
            char keyEntered;

            do {
                keyEntered = ' ';
                string heading = "Show bill for a Car's latest Service";
                MenuHelper.DisplayEnterReg(heading);
                String regNo = Console.ReadLine().ToUpper().Trim();
                service = ServicesService.GetServiceDetailsForCar(regNo, ref keyEntered)
                                         .LastOrDefault();
                if (service == null) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }
            } while (service == null && keyEntered != '0');

            if (service.Id != 0) {
                ServiceDisplayHelper.DisplayServiceDetails(service);
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
                string mechanicIdString = Console.ReadLine().Trim();

                serviceDetails = ServicesService.GetMechanicServiceDetails(ref staffId, mechanicIdString);
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

                service = ServicesService.GetServiceByIdString(serviceIdString);
                if (service.Id == 0) {
                    MenuHelper.DisplayReturnOrTryAgain();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                }    
            } while (service.Id == 0 && keyEntered != '0');

            if (service.Id != 0) {
                ServiceDisplayHelper.DisplayServiceDetails(service);
            }
        }

        private static void DisplayServicesForMechanic(List<Service> serviceDetails, int staffId) {
            if (serviceDetails.Count > 0) {
                ServiceDisplayHelper.DisplayServicesByMechanic(serviceDetails);
                MenuHelper.DisplayPressKeyToReturnToMainMenu();
            } else {
                var mechanic = MechanicsService.GetMechanic(staffId);
                MenuHelper.DisplayNoServicesForMechanic(mechanic);
            }
        }
    }
}