using GarageAdmin.Helpers;
using System;

namespace GarageAdmin {

    enum MenuOption {
        Quit, ListMechanics, ListServicesByReg, ListServicesByMechanic
    }

    class Program {

        static void Main(string[] args) {
            MenuOption selection;
            bool validSelection;

            do {
                MenuHelper.DisplayMenu();
                validSelection = MenuOption.TryParse(Console.ReadLine(), out selection);

                if (validSelection) {
                    Console.Clear();

                    switch (selection) {
                        case MenuOption.Quit: 
                            MenuHelper.Quit(); break;
                        case MenuOption.ListMechanics:
                            MechanicsHelper.ListMechanics();
                            break;
                        case MenuOption.ListServicesByReg:
                            ServiceHelper.ListCarServiceDetailsByReg();
                            break;
                        case MenuOption.ListServicesByMechanic:
                            ServiceHelper.ListCarServiceDetailsByMechanic();
                            break;
                    }
                } else {
                    MenuHelper.DisplayInvalidMenuOptionSelected();
                } 
            } while (selection != MenuOption.Quit || !validSelection);
        }
    }
}