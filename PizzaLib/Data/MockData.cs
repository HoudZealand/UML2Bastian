using PizzaLib.Interfaces;
using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Data
{
    public static class MockData
    {
        #region Instance fields
        private static Dictionary<string, ICustomer> _customerData =
            new Dictionary<string, ICustomer>()
            {
            { "12121212", new Customer("Mikkel", "12121212", "Street 123") },
            { "13131313", new Customer("Charlotte", "13131313", "Avenue 321") },
            { "14141414", new Customer("Carina", "14141414", "High Street 234") },
            { "15151515", new Customer("Muhammed", "15151515", "North Street 345") }
            };

        private static List<IMenuItem> _menuItemData =
            new List<IMenuItem>()
            {
            new MenuItem("Margherita", 85, "Tomat, ost", MenuType.PIZZECLASSICHE),
            new MenuItem("Vesuvio", 95, "Tomat, ost & skinke", MenuType.PIZZECLASSICHE),
            new MenuItem("Capricciosa", 98, "Tomat, ost, skinke & champignon", MenuType.PIZZECLASSICHE),
            new MenuItem("Calzone", 98, "Indbagt pizza med tomat, ost, skinke & champignon", MenuType.PIZZECLASSICHE),
            new MenuItem("Quattro Stagioni", 98, "Tomat, ost, skinke, champignon, rejer & paprika", MenuType.PIZZECLASSICHE),
            new MenuItem("Marinara", 97, "Tomat, ost, rejer, muslinger & hvidløg", MenuType.PIZZECLASSICHE),
            new MenuItem("Vegetariana", 98, "Tomat, ost & grønsager", MenuType.PIZZECLASSICHE),
            new MenuItem("Italiana", 97, "Tomat, ost, løg & kødsauce", MenuType.PIZZECLASSICHE)

            };
        #endregion

        #region Properties
        public static Dictionary<string, ICustomer> CustomerData
        {
            get { return _customerData; }
        }


        public static List<IMenuItem> MenuItemData
        {
            get { return _menuItemData; }
        }
        #endregion

    }
}
