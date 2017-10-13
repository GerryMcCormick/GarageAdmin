﻿using System;

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
            Console.Write("\n\n\t\t\t\t\tSelection: ");
        }

        public static void Quit() {
            Console.Clear();
            Console.WriteLine("\n\n\n\n\n\n\t\t\t\t\t\tGoodbye!");
        }

        public static void DisplayInvalidRegEntered() {
            Console.WriteLine("\n\tReg Number entered must be 5 - 10 alphanumeric characters");
            DisplayReturnOrTryAgain();
        }

        public static void DisplayInvalidMechanicIdEntered() {
            Console.WriteLine("\n\tMechanic's Staff ID must be 1 - 4 digits");
            DisplayReturnOrTryAgain();
        }

        public static void DisplayEnterReg() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tMechanics\n");
            Console.Write("\n\tEnter the Reg Number of the car: ");
        }

        public static void DisplayEnterMechanicId() {
            Console.Clear();
            Console.WriteLine("\n\n\t\t\t\t\tCars Serviced By Mechanic\n");
            Console.Write("\n\t\tEnter the Staff ID of the Mechanic: ");
        }

        public static void DisplayCarDoesNotExist() {
            Console.WriteLine("\n\tNo car exists that matches the Reg Number entered");
            DisplayReturnOrTryAgain();
        }

        public static void DisplayMechanicDoesNotExist() {
            Console.WriteLine("\n\tNo Mechanic exists that matches the Staff ID entered");
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