using ConsoleMenu.Controllers.Customers;
using ConsoleMenu.Controllers.MenuItems;
using PizzaLib.Interfaces;
using PizzaLib.Models;
using PizzaLib.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Menu
{
    public class UserMenu
    {
        private static string mainMenuChoices = "\t1.Vis Pizzamenu\n\t" +
                                                "2.Vis Kunder\n\t" +
                                                "3.Add Customer\n\t" +
                                                "4.Add Menu Item\n\t" +
                                                "5.Vis liste af klubmedlemmer\n\t" +
                                                "6.Vis liste af kunder i givent område\n\t" +
                                                "7.Vis liste af menuitems af type\n\t" +
                                                "8.Vis dyreste menuitem af type\n\t" +
                                                "9.Vis dyreste menuitem mellem flere typer\n\t" +
                                                "10.Vis menu sorteret efter type\n\t" +
                                                "11.Lav ny ordre\n\t" +
                                                "Q.Afslut\n\n\t" +
                                                "Indtast valg:";

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
                        // Print all MenuItems
                        Console.WriteLine("Valg 1");
                        _menuItemRepository.PrintAllMenuItems();
                        Console.ReadLine();
                        break;
                    case "2":
                        // Print all Customers
                        Console.WriteLine("Valg 2");
                        _customerRepository.PrintAllCustomers();
                        Console.ReadLine();
                        break;
                    case "3":
                        // Create new Customer
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

                        Console.WriteLine("Vil du være VIP y/n");
                        string vipString = Console.ReadLine().ToLower();
                        bool isVIP = (vipString[0] == 'y') ? true : false;

                        switch (isVIP)
                        {
                            case true:

                                Console.WriteLine("Indlæs discount %");
                                double discount;
                                while(!double.TryParse(Console.ReadLine(), out discount))
                                {
                                    Console.WriteLine("Invalid discount %");
                                    Console.WriteLine("Indlæs discount %");
                                }
                                ICustomer customer = new VIPCustomer(customerName, mobile, address, discount)
                                {
                                    ClubMember = isClubMember
                                };
                                _customerRepository.AddCustomer(customer);

                                break;
                            case false:

                                customer = new Customer(customerName, mobile, address)
                                {
                                    ClubMember = isClubMember
                                };
                                _customerRepository.AddCustomer(customer);
                                break;
                        }
                        break;
                    case "4":
                        // Create new MenuItem
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
                        while (!Enum.TryParse(Console.ReadLine().ToUpper(), out menuType))
                        {
                            Console.WriteLine("Indlæs menutype:");
                        }

                        switch (menuType)
                        {
                            default:

                                IMenuItem item = new MenuItem(pizzaName, price, desc, menuType);
                                _menuItemRepository.AddMenuItem(item);

                                break;
                            case MenuType.DRIKKEVARE:

                                Console.WriteLine($"Har drikkevaren alkohol y/n");
                                string alcoholString = Console.ReadLine().ToLower();
                                bool alcohol = (alcoholString[0] == 'y') ? true : false;

                                item = new Beverage(pizzaName, price, desc, alcohol);
                                _menuItemRepository.AddMenuItem(item);

                                break;
                        }
                        break;
                    case "5":
                        // Get all club members
                        Console.WriteLine("Valg 5");
                        List<ICustomer> members = _customerRepository.GetMembers();
                        foreach(ICustomer i in members)
                        {
                            Console.WriteLine(i.ToString());
                        }
                        Console.ReadLine();
                        break;
                    case "6":
                        // Get customer by area
                        Console.WriteLine("Valg 6");
                        Console.WriteLine("Indlæs område:");
                        List<ICustomer> cInArea = _customerRepository.GetByArea(Console.ReadLine());
                        foreach (ICustomer i in cInArea)
                        {
                            Console.WriteLine(i.ToString());
                        }
                        Console.ReadLine();
                        break;
                    case "7":
                        // Get items by MenuType
                        Console.WriteLine("Valg 7");
                        Console.WriteLine("Indlæs menutype:");
                        while (!Enum.TryParse(Console.ReadLine().ToUpper(), out menuType))
                        {
                            Console.WriteLine("Invalid menutype");
                            Console.WriteLine("Indlæs menutype:");
                        }
                        List<IMenuItem> itemsByType = _menuItemRepository.GetItemsByType(menuType);
                        foreach(IMenuItem i in itemsByType)
                        {
                            Console.WriteLine(i.ToString());
                        }
                        Console.ReadLine();
                        break;
                    case "8":
                        // Get most expensive by MenuType
                        Console.WriteLine("Valg 8");
                        Console.WriteLine("Indlæs menutype:");
                        while (!Enum.TryParse(Console.ReadLine().ToUpper(), out menuType))
                        {
                            Console.WriteLine("Invalid menutype");
                            Console.WriteLine("Indlæs menutype:");
                        }

                        IMenuItem expensiveByType = _menuItemRepository.GetMostExpensiveByType(menuType);
                        Console.WriteLine(expensiveByType.ToString());
                        Console.ReadLine();
                        break;
                    case "9":
                        // Get most expensive by multiple MenuTypes
                        Console.WriteLine("Valg 9");
                        Console.WriteLine("Indlæs mængde af menutyper:");
                        int amount = 0;
                        while (!int.TryParse(Console.ReadLine(), out amount))
                        {
                            Console.WriteLine("Indlæs mængde af menutyper:");
                        }

                        MenuType[] menuTypes = new MenuType[amount];

                        for (int i = 0; i < amount; i++)
                        {
                            Console.WriteLine("Indlæs menutype:");
                            while (!Enum.TryParse(Console.ReadLine(), out menuType))
                            {
                                Console.WriteLine("Invalid menutype");
                                Console.WriteLine("Indlæs menutype:");
                            }
                            menuTypes[i] = menuType;
                        }

                        expensiveByType = _menuItemRepository.GetMostExpensiveByType(menuTypes);
                        Console.WriteLine(expensiveByType.ToString());
                        Console.ReadLine();
                        break;
                    case "10":
                        // Print sorted menu
                        Console.WriteLine("Valg 10");
                        _menuItemRepository.PrintSortedMenu();
                        Console.ReadLine();
                        break;
                    case "11":
                        // Create new Order
                        Console.WriteLine("Valg 11");
                        Console.WriteLine("Tilføj item ved nummer eller tryk 'q' for at fortsætte.");
                        _menuItemRepository.PrintAllMenuItems();
                        string input = ".";
                        List<IMenuItem> items = new List<IMenuItem>();
                        while (input[0] != 'q')
                        {
                            input = Console.ReadLine();
                            if(int.TryParse(input, out int num))
                            {
                                try
                                {
                                    IMenuItem item = _menuItemRepository.GetMenuItemByNo(num);
                                    items.Add(item);
                                    Console.WriteLine($"Added {item.Name}");
                                } catch(ArgumentException e)
                                {
                                    Console.WriteLine("Item does not exist.");
                                }
                            }
                        }
                        Console.WriteLine("Vil du tilføje en kunde? y/n");
                        string addCustomerString = Console.ReadLine();
                        bool addCustomer = (addCustomerString[0] == 'y') ? true : false;
                        Order order;

                        switch (addCustomer)
                        {
                            case true:
                                {
                                    Console.WriteLine("Tilføj kunde ved ID.");
                                    _customerRepository.PrintAllCustomers();
                                    ICustomer? customerToAdd = null;
                                    while (customerToAdd == null)
                                    {
                                        int idInput;
                                        while (!int.TryParse(Console.ReadLine(), out idInput))
                                        {
                                            Console.WriteLine("Invalid input");
                                        }
                                        customerToAdd = _customerRepository.GetCustomerByID(idInput);
                                    }
                                    order = new Order(customerToAdd);
                                    break;
                                }
                            case false:
                                {
                                    order = new Order();
                                    break;
                                }
                        }

                        foreach(IMenuItem item in items)
                        {
                            order.Items.Add(item);
                        }

                        order.PrintOrder();
                        Console.ReadLine();
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
