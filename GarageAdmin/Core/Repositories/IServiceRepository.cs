using System.Collections.Generic;

namespace GarageAdmin.Core.Repositories {
    public interface IServiceRepository {

        Service GetService(int serviceId);
        IEnumerable<Service> GetCarsServicedByMechanic(int staffId);
        IEnumerable<Service> GetCarServiceDetailsByReg(string regNo);
    }
}
