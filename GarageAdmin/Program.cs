using GarageAdmin.Helpers;
using System;

namespace GarageAdmin {
    class Program {

        private enum Menu {
            Quit,
            ListMechanics,
            ListServiceMechanicsForReg,
            ListServicesByAMechanic,
            ListDetailsForAService,
            ListPartsReplacedInCar,
            ListCarsLatestServiceBill
        }

        static void Main(string[] args) {
            Menu selection;
            bool validSelection;

            do {
                MenuHelper.DisplayMenu();
                validSelection = Menu.TryParse(Console.ReadLine(), out selection);

                if (validSelection) {
                    Console.Clear();
                    RunMenuOption(selection);
                } else {
                    MenuHelper.DisplayInvalidMenuOptionSelected();
                } 
            } while (selection != Menu.Quit || !validSelection);
        }

        private static void RunMenuOption(Menu selection) {
            switch (selection) {
                case Menu.Quit:
                    MenuHelper.Quit();
                    break;
                case Menu.ListMechanics:
                    MechanicsHelper.ListMechanics();
                    break;
                case Menu.ListServiceMechanicsForReg:
                    ServiceHelper.ListServiceMechanicsForReg();
                    break;
                case Menu.ListServicesByAMechanic:
                    ServiceHelper.ListServicesByAMechanic();
                    break;
                case Menu.ListDetailsForAService:
                    ServiceHelper.ListDetailsForAService();
                    break;
                case Menu.ListPartsReplacedInCar:
                    ServiceHelper.ListPartsReplacedInCar();
                    break;
                case Menu.ListCarsLatestServiceBill:
                    ServiceHelper.ListCarsLatestServiceBill();
                    break;
            }
        }
    }
}