using PizzaLib.Services;
using ConsoleMenu.Controllers.MenuItems;
using ConsoleMenu.Controllers.Customers;
using System;
using System.Collections.Generic;
using System.Text;
using PizzaLib.Models;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t2.Vis Kunder\n\t3.Add Customer\n\t4.Add Menu Item\n\tQ.Afslut\n\n\tIndtast valg:";

        private CustomerRepository _customerRepository = new CustomerRepository();
        private MenuItemRepository _menuItemRepository = new MenuItemRepository();
        private static string ReadChoice(string choices)
        {
            Console.Clear();
            Console.Write(choices);
            string choice = Console.ReadLine();
            Console.Clear();
            return choice.ToLower();
        }
        public void ShowMenu()
        {
            string theChoice = ReadChoice(mainMenuChoices);
            while (theChoice != "q")
            {
                switch (theChoice)
                {
                    case "1":
                        Console.WriteLine("Valg 1");
                        ShowMenuItemController showMenuItemController = new ShowMenuItemController(_menuItemRepository);
                        showMenuItemController.ShowAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        Console.WriteLine("Valg 2");
                        ShowCustomerController showCustomerController = new ShowCustomerController(_customerRepository);
                        showCustomerController.ShowAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        Console.WriteLine("Valg 3");
                        Console.WriteLine("Indlæs navn:");
                        string customerName = Console.ReadLine();

                        Console.WriteLine("Indlæs mobil nr:");
                        string mobile = Console.ReadLine();

                        Console.WriteLine("Indlæs adresse:");
                        string address = Console.ReadLine();

                        Console.WriteLine("Vil du være clubmember y/n");
                        string clubMemberString = Console.ReadLine().ToLower();
                        bool isClubMember = (clubMemberString[0] == 'y') ? true : false;

                        AddCustomerController addCustomerController = new AddCustomerController(customerName, mobile, address, isClubMember, _customerRepository);
                        addCustomerController.AddCustomer();
                        break;
                    case "4":
                        Console.WriteLine("Valg 4");
                        Console.WriteLine("Indlæs navn:");
                        string pizzaName = Console.ReadLine();

                        Console.WriteLine("Indlæs pris");
                        double price;
                        while(!double.TryParse(Console.ReadLine(), out price))
                        {
                            Console.WriteLine("Indlæs pris:");
                        }

                        Console.WriteLine("Indlæs beskrivelse:");
                        string desc = Console.ReadLine();

                        Console.WriteLine("Indlæs menutype:");
                        MenuType menuType;
                        while (!Enum.TryParse(Console.ReadLine(), out menuType))
                        {
                            Console.WriteLine("Indlæs menutype:");
                        }

                        AddMenuItemController addMenuItemController = new AddMenuItemController(pizzaName, price, desc, menuType, _menuItemRepository);
                        addMenuItemController.AddMenuItem();
                        break;
                    case "5":
                        //TODO - Find alle clubmembers
                        break;
                    case "6":
                        //TODO - Find alle customers fra et givent område
                        break;
                    case "7":
                        //TODO - Find alle menu items af given menutype
                        break;
                    case "8":
                        //TODO - Find den dyreste item indenfor en given menutype
                        break;
                    case "9":
                        //TODO - Find den dyreste item bland flere givne menutyper
                        break;
                    case "10":
                        //TODO - Udskriv sorteret menukort
                        break;
                    default:
                        Console.WriteLine("Angiv et tal fra 1..4 eller q for afslut");
                        break;
                }
                theChoice = ReadChoice(mainMenuChoices);
            }
        }

    }

}
