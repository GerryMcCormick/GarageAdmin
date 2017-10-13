using GarageAdmin.Helpers;
using System;

namespace GarageAdmin {
    class Program {

        static void Main(string[] args) {

            int selection;
            bool numberEntered;

            do {
                MenuHelper.DisplayMenu();
                numberEntered = int.TryParse(Console.ReadLine(), out selection);

                if (numberEntered) {
                    Console.Clear();

                    switch (selection) {
                        case 0:
                            MenuHelper.Quit();
                            break;
                        case 1:
                            MechanicsHelper.ListMechanics();
                            break;
                        case 2:
                            ServiceHelper.ListServiceDetailsForCar();
                            break;

                    }
                }
                
            } while (selection != 0 || !numberEntered);
        }
    }
}