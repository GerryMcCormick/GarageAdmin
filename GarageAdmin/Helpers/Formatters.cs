using System;

namespace GarageAdmin.Helpers {
    class Formatters {
        public static string FormatId(int id) {
            return id.ToString("D4");
        }

        public static string FormatServiceDate(DateTime serviceDate) {
            return serviceDate.ToLocalTime().ToShortDateString();
        }

        public static string FormatPrice(double price) {
            return price.ToString("N2");
        }
    }
}