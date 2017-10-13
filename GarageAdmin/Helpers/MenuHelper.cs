using System;

namespace GarageAdmin.Helpers {
    public static class MenuHelper {

        public static void DisplayMenu() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tGarage Menu");
            Console.WriteLine("\n\n\tMake a selection then press enter:");
            Console.WriteLine("\n\n\t\t\t0) Quit");
            Console.WriteLine("\n\t\t\t1) List all Mechanics");
            Console.WriteLine("\n\t\t\t2) List all Mechanics That Serviced a Car");
            Console.Write("\n\n\t\t\t\tSelection: ");
        }

        public static void Quit() {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t\tGoodbye!");
        }

        public static void DisplayInvalidRegEntered() {
            Console.WriteLine("\n\tReg Number entered must be 5 - 10 alphanumeric characters");
            DisplayReturnOrTryAgain();
        }

        public static void DisplayEnterReg() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tMechanics\n");
            Console.Write("\n\tEnter the Reg Number of the car: ");
        }

        public static void DisplayCarDoesNotExist() {
            Console.WriteLine("\n\tNo car exists that matches the Reg Number entered");
            DisplayReturnOrTryAgain();
        }

        public static void DisplayReturnOrTryAgain() {
            Console.WriteLine("\n\tPress 0 to return to main menu, or any other key to try again");
            Console.Write("\n\t\tSelection: ");
        }

        public static void DisplayPressKeyToReturnToMainMenu() {
            Console.WriteLine("\n\n\t\tPress any key to return to main menu...");
            Console.ReadKey();
        }
    }
}