using System.Data.Entity;

namespace GarageAdmin.Core.Repositories {
    public interface IServicePartRepository {
        DbSet<ServicePart> GetPartsReplacedForAllServices(string carReg);

    }
}
