using System;

namespace GarageAdmin.Helpers {
    public static class MenuHelper {

        public static void DisplayMenu() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tGarage Menu");
            Console.WriteLine("\n\n\t\tMake a selection then press enter:");
            Console.WriteLine("\n\n\t\t\t\t0) Quit");
            Console.WriteLine("\n\t\t\t\t1) List all Mechanics");
            Console.WriteLine("\n\t\t\t\t2) List all Mechanics That Serviced a Car");
            Console.WriteLine("\n\t\t\t\t3) List all Cars Serviced by a Mechanic");
            Console.WriteLine("\n\t\t\t\t4) List details of a Service");
            Console.WriteLine("\n\t\t\t\t5) List parts replaced during services for a Car");
            Console.WriteLine("\n\t\t\t\t6) List billing info for Car's most recent Service");
            Console.Write("\n\n\t\t\t\t\tSelection: ");
        }

        public static void Quit() {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t\tGoodbye!");
        }

        public static void DisplayEnterReg(string heading) {
            Console.Clear();
            Console.WriteLine($"\n\n\t\t\t\t\t{ heading }\n");
            Console.Write("\n\tEnter the Reg Number of the car: ");
        }

        public static void DisplayEnterMechanicId() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tCars Serviced By Mechanic\n");
            Console.Write("\n\tEnter the Staff ID of the Mechanic: ");
        }

        public static void DisplayEnterServiceId() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\t Service Details\n");
            Console.Write("\n\tEnter the Service ID: ");
        }

        public static void DisplayReturnOrTryAgain() {
            Console.WriteLine("\n\tPress 0 to return to main menu, or any other key to try again");
            Console.Write("\n\t\tSelection: ");
        }

        public static void DisplayPressKeyToReturnToMainMenu() {
            Console.WriteLine("\n\n\t\tPress any key to return to main menu...");
            Console.ReadKey();
        }

        public static void DisplayInvalidMenuOptionSelected() {
            Console.WriteLine("\n\n\t\tInvalid Menu Option entered");
            DisplayPressKeyToReturnToMainMenu();
        }

        public static void DisplayNoServicesForMechanic(Mechanic mechanic) {
            Console.WriteLine($"\n\n\t\tNo Services were carried out by {mechanic.Forename} {mechanic.Surname}");
            DisplayPressKeyToReturnToMainMenu();
        }
    }
}