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

        public static List<Service> GetMechanicServiceDetails(ref int staffId, string mechanicIdString) {
            List<Service> services = new List<Service>();
            try {
                staffId = ValidationHelper.ValidateStaffIdString(mechanicIdString);
                services = UnitOfWork.Services.GetCarsServicedByMechanic(staffId).ToList();
            } catch (InvalidCastException icEx) {
                Console.WriteLine($"\n\t{icEx.Message}");
            } catch (ArgumentException oorEx) {
                Console.WriteLine($"\n\t{oorEx.Message}");
            } catch (MechanicNotFoundException mnfEx) {
                Console.WriteLine($"\n\t{mnfEx.Message}");
            }
            return services;
        }

        public static Service GetServiceByIdString(string serviceIdString) {
            Service service = new Service();
            try {
                int serviceId = ValidationHelper.ValidateServiceIdString(serviceIdString);
                service = GetServiceById(serviceId);
            } catch (InvalidCastException icEx) {
                Console.WriteLine($"\n\t{icEx.Message}");
            } catch (ArgumentException oorEx) {
                Console.WriteLine($"\n\t{oorEx.Message}");
            } catch (ServiceNotFoundException snfEx) {
                Console.WriteLine($"\n\t{snfEx.Message}");
            }
            return service;
        }

        public static List<Service> GetServiceDetailsForCar(string regNo, ref char keyEntered) {
            List<Service> services = new List<Service>();
            try {
                ValidationHelper.ValidateRegNo(regNo);
                services = UnitOfWork.Services.GetCarServiceDetailsByReg(regNo).ToList();
            } catch (InvalidRegException regEx) {
                Console.WriteLine($"\n\t{regEx.Message}");
            } catch (CarNotFoundException carEx) {
                Console.WriteLine($"\n\t{carEx.Message}");
            }
            return services;
        }

        public static Service GetServiceById(int serviceId) {
            return UnitOfWork.Services.GetService(serviceId);
        }
    }
}
