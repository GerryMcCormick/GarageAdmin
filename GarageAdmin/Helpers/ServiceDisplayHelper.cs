using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Helpers {
    public class ServiceDisplayHelper {

        public static void DisplayMechanicsWhoServicedCar(string regNo, List<Service> serviceDetails) {
            Console.Clear();
            Console.WriteLine($"\n\t\t\t\tMechanics Who Serviced car {regNo}");

            foreach (var service in serviceDetails) {
                Console.WriteLine($"\n\t\t{Formatters.FormatServiceDate(service.DateServiced)} " +
                    $"{service.Mechanic.Forename} {service.Mechanic.Surname}");
            }
        }

        public static void DisplayPartsReplacedForAllServices(string regNo, List<Service> serviceDetails) {
            Console.Clear();
            Console.WriteLine($"\n\t\t\t\tParts replaced for car {regNo}'s Services");

            foreach (var service in serviceDetails) {
                Console.WriteLine($"\n\t\tService Date: {Formatters.FormatServiceDate(service.DateServiced)} \n" +
                    $"\t\tMechanic: {service.Mechanic.Forename} {service.Mechanic.Surname}");
                DisplayServiceParts(service);
            }
            MenuHelper.DisplayPressKeyToReturnToMainMenu();
        }

        public static void DisplayServiceDetails(Service service) {
            Console.Clear();
            Console.WriteLine($"\n\t\t\t\tService ID: {Formatters.FormatId(service.Id)}");
            Console.WriteLine($"\t\t\t\tService Date: {Formatters.FormatServiceDate(service.DateServiced)}");
            Console.WriteLine($"\n\t\tCar: {service.Car.RegNumber}\n");
            DisplayServiceParts(service);
            MenuHelper.DisplayPressKeyToReturnToMainMenu();
        }

        public static void DisplayServicesByMechanic(List<Service> serviceDetails) {
            Console.Clear();
            Mechanic mechanic = serviceDetails.ElementAt(0).Mechanic;
            Console.WriteLine($"\n\t\t\t\tCars Serviced By {mechanic.Forename} {mechanic.Surname}");

            foreach (var service in serviceDetails) {
                Console.WriteLine($"\n\t\tCar: \t\t\t{service.Car.RegNumber} {service.Car.Make} {service.Car.Model} " +
                                  $"\n\t\tServiced On: \t\t{Formatters.FormatServiceDate(service.DateServiced)}" +
                                  $"\n\t\tOwner Telephone Number: {service.Car.CarOwner.TelNumber}");
            }
        }

        private static void DisplayServiceParts(Service service) {
            if (service.ServiceParts.Count > 0) {
                Console.WriteLine("\n\t\tParts Replaced:");
                foreach (var servicePart in service.ServiceParts) {
                    DisplayServicePart(servicePart);
                }
            } else {
                Console.WriteLine("\n\t\t\tNo Parts were replaced during this Service");
            }
        }

        private static void DisplayServicePart(ServicePart servicePart) {
            Console.WriteLine($"\t\t\tPart ID:          {Formatters.FormatId(servicePart.Part.Id)}" +
                            $"\n\t\t\tSupplier Part ID: {servicePart.Part.SupplierPartNumber}" +
                            $"\n\t\t\tPart Name:        {servicePart.Part.PartName} " +
                            $"\n\t\t\tPrice per Unit:   £{Formatters.FormatPrice(servicePart.Part.Price)} " +
                            $"\n\t\t\tQuantity:         {servicePart.Quantity}\n");
        }
    }
}