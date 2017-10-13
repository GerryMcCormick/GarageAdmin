using System.Collections.Generic;

namespace GarageAdmin.Core.Repositories {
    public interface IMechanicRepository {

        IEnumerable<Mechanic> GetMechanics();
        Mechanic GetMechanic(int staffId);
    }
}
