using System.Collections.Generic;

namespace GarageAdmin.Core.Repositories {
    public interface IServiceRepository {

        Service GetServiceDetails(int serviceId);
        IEnumerable<Service> GetCarServiceDetails(string regNo);
    }
}
