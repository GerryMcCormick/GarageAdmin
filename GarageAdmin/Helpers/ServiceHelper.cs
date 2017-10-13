using GarageAdmin.Persistance;
using GarageAdmin.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Helpers {
    public class ServiceHelper {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(GarageDbContext.Create());
            }
        }

        public static void ListServiceDetailsForCar() {
            String regNo;
            List<Service> serviceDetails = new List<Service>();
            char keyEntered;
            bool carExists, validRegNo;

            do {
                carExists = false;
                validRegNo = false;
                keyEntered = ' ';

                MenuHelper.DisplayEnterReg();
                regNo = Console.ReadLine().ToUpper().Trim();

                validRegNo = ValidationHelper.IsValidRegNo(regNo);

                if (!validRegNo) {
                    MenuHelper.DisplayInvalidRegEntered();
                    char.TryParse(Console.ReadLine(), out keyEntered);
                } else {
                    carExists = ValidationHelper.CarExists(regNo);

                    if (carExists) {
                        serviceDetails = UnitOfWork.Services
                                                   .GetCarServiceDetails(regNo)
                                                   .ToList();
                    } else {
                        MenuHelper.DisplayCarDoesNotExist();
                        char.TryParse(Console.ReadLine(), out keyEntered);
                    }
                }

            } while (ValidationHelper.InvalidDataEntered(validRegNo, carExists) && keyEntered != '0');

            if (serviceDetails.Count > 0) {
                DisplayMechanicsWhoServicedCar(regNo, serviceDetails);
                MenuHelper.DisplayPressKeyToReturnToMainMenu();
            }
        }

        private static void DisplayMechanicsWhoServicedCar(string regNo, List<Service> serviceDetails) {
            Console.Clear();
            Console.WriteLine($"\n\t\t\t\tMechanics Who Serviced car {regNo}");
            foreach (var service in serviceDetails) {
                Console.WriteLine($"\n\n\t\t{service.DateServiced} {service.Mechanic.Forename} {service.Mechanic.Surname}");
            }
        }
    }
}