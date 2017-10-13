using GarageAdmin.Persistance;
using GarageAdmin.Persistance.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GarageAdmin.Helpers {
    public class MechanicsHelper {

        private static UnitOfWork UnitOfWork {
            get {
                return new UnitOfWork(GarageDbContext.Create());
            }
        }

        public static void ListMechanics() {
            var mechanics = UnitOfWork.Mechanics
                                      .GetMechanics()
                                      .ToList();

            if (mechanics.Count > 0) {
                DisplayAllMechanics(mechanics);
            } else {
                Console.WriteLine("\n\n\t\tNo Mechanics found.");
            }

            MenuHelper.DisplayPressKeyToReturnToMainMenu();
        }
        
        private static void DisplayAllMechanics(List<Mechanic> mechanics) {
            Console.WriteLine("\n\n\t\t\t\t\tMechanics\n");

            foreach (var mechanic in mechanics) {
                Console.WriteLine($"\tName: {mechanic.Forename} {mechanic.Surname}\tStaff ID: {mechanic.Id}");
            }
        }
    }
}
