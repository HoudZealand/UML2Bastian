using PizzaLib.Models;
using PizzaLib.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Controllers.Customers
{
    public class AddMenuItemController
    {
        private MenuItemRepository _menuItemRepo;
        public MenuItem TheMenuItem { get; set; }

        public AddMenuItemController(string name, double price, string description, MenuType menuType, MenuItemRepository menuItemRepo)
        {
            TheMenuItem = new MenuItem(name, price, description, menuType);
            _menuItemRepo = menuItemRepo;
        }
        
        public void AddMenuItem()
        {
            _menuItemRepo.AddMenuItem(TheMenuItem);
        }
    }
}
