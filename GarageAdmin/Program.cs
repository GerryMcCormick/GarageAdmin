using GarageAdmin.Helpers;
using System;

namespace GarageAdmin {
    class Program {

        enum MenuOption {
            Quit, ListMechanics, ListServicesByReg, ListServicesByMechanic, ListDetailsForAService
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
                            MenuHelper.Quit(); break;
                        case MenuOption.ListMechanics:
                            // Q1 List(sorted on Surname) the names of all the 
                            //    Mechanics employed in the garage.
                            MechanicsHelper.ListMechanics();
                            break;
                        case MenuOption.ListServicesByReg:
                            // Q2 Given a Car “RegNumber” list the names of all the Mechanics 
                            //    (in order of service date) who have serviced that Car.
                            ServiceHelper.ListCarServiceDetailsByReg();
                            break;
                        case MenuOption.ListServicesByMechanic:
                            // Q3 Given a Mechanic’s “StaffNumber” list all the Cars (RegNumber, 
                            //    Make, Model and OwnerTelNum) that were serviced by that particular
                            //    Mechanic and the date each service took place.
                            ServiceHelper.ListCarServiceDetailsByMechanic();
                            break;
                        case MenuOption.ListDetailsForAService:
                            // Q4 Given a “ServiceWorkNum” for a particular Service, list the 
                            //    registration number of the Car involved and the “PartNumber”, 
                            //    “PartName” and “Price” of all Parts used during the Service.
                            ServiceHelper.ListDetailsForAService();
                            break;
                    }
                } else {
                    MenuHelper.DisplayInvalidMenuOptionSelected();
                } 
            } while (selection != MenuOption.Quit || !validSelection);
        }
    }
}