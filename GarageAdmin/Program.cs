using GarageAdmin.Helpers;
using System;

namespace GarageAdmin {
    class Program {

        enum MenuOption {
            Quit,
            ListMechanics,
            ListServiceMechanicsForReg,
            ListServicesByAMechanic,
            ListDetailsForAService,
            ListPartsReplacedInCar
        }

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
                            MenuHelper.Quit();
                            break;
                        case MenuOption.ListMechanics:
                            MechanicsHelper.ListMechanics();
                            break;
                        case MenuOption.ListServiceMechanicsForReg:
                            ServiceHelper.ListServiceMechanicsForReg();
                            break;
                        case MenuOption.ListServicesByAMechanic:
                            ServiceHelper.ListServicesByAMechanic();
                            break;
                        case MenuOption.ListDetailsForAService:
                            ServiceHelper.ListDetailsForAService();
                            break;
                        case MenuOption.ListPartsReplacedInCar:
                            ServiceHelper.ListPartsReplacedInCar();
                            break;
                    }
                } else {
                    MenuHelper.DisplayInvalidMenuOptionSelected();
                } 
            } while (selection != MenuOption.Quit || !validSelection);
        }
    }
}