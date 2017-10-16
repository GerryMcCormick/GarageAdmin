using GarageAdmin.Exceptions;
using GarageAdmin.Helpers;
using GarageAdmin.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Services {
    public class ServicesService {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(new GarageModelContainer());
            }
        }

        public static List<Service> GetMechanicServiceDetails(ref int staffId) {
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

        public static Service GetService(string serviceIdString) {
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

        public static List<Service> GetServiceDetailsForCar(out string regNo, ref char keyEntered) {
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
