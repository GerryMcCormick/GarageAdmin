using GarageAdmin.Persistance.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Services {
    public class MechanicsService {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(new GarageModelContainer());
            }
        }

        public static Mechanic GetMechanic(int staffId) {
            return UnitOfWork.Mechanics.GetMechanic(staffId);
        }

        public static List<Mechanic> GetMechanics() {
            return UnitOfWork.Mechanics.GetMechanics().ToList();
        }
    }
}
