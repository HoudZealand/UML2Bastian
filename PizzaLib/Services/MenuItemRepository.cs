using PizzaLib.Data;
using PizzaLib.Interfaces;
using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<IMenuItem> _menuItems;
        public int Count { get { return _menuItems.Count; } }

        public MenuItemRepository()
        {
            _menuItems = MockData.MenuItemData;
        }

        public void PrintAllMenuItems()
        {
            foreach(IMenuItem m in _menuItems)
            {
                Console.WriteLine(m.ToString());
            }
        }

        public void RemoveMenuItem(int no)
        {
            for(int i = 0; i < Count; i++)
            {
                if (_menuItems[i].No == no)
                {
                    _menuItems.RemoveAt(i);
                    return;
                }
            }
        }

        public void AddMenuItem(IMenuItem menuItem)
        {
            foreach(IMenuItem m in _menuItems)
            {
                if (m.Equals(menuItem)) return;
            }
            _menuItems.Add(menuItem);
        }

        public List<IMenuItem> GetAll()
        {
            return _menuItems;
        }
        
        public List<IMenuItem> GetItemsByType(MenuType menuType)
        {
            List<IMenuItem> items = new List<IMenuItem>();

            foreach(IMenuItem i in _menuItems)
            {
                if (i.TheMenuType == menuType) items.Add(i);
            }

            return items;
        }

        public IMenuItem GetMostExpensiveByType(MenuType menuType)
        {
            List<IMenuItem> items = GetItemsByType(menuType);
            if (items.Count < 1) throw new NullReferenceException($"No menu items of type {menuType}!");
            
            IMenuItem item = items[0];

            for(int i = 1; i < items.Count; i++)
            {
                if (items[i].Price > item.Price) item = items[i];
            }

            return item;
        }
        public IMenuItem GetMostExpensiveByType(MenuType[] menuType)
        {
            IMenuItem item = new MenuItem("dummy", double.MinValue, "dummy", menuType[0]);
            List<IMenuItem> items = new List<IMenuItem>();
            foreach(MenuType t in menuType)
            {
                List<IMenuItem> temp = GetItemsByType(t);
                foreach(IMenuItem i in temp)
                {
                    items.Add(i);
                }
            }

            foreach (IMenuItem i in items)
            {
                if (i.Price > item.Price) item = i;
            }

            return item;
        }

        public IMenuItem GetMenuItemByNo(int no)
        {
            foreach(IMenuItem m in _menuItems)
            {
                if (m.No == no) return m;
            }
            throw new NullReferenceException("Item does not exist in repo!");
        }

        public void PrintSortedMenu()
        {
            MenuType[] menuTypes =
            {
                MenuType.PIZZECLASSICHE,
                MenuType.PIZZESPECIALI,
                MenuType.PASTAALFORNO,
                MenuType.BRUCHETTA_CROSTINO,
                MenuType.SANDWICHES,
                MenuType.SALATER,
                MenuType.TILBEHØR
            };
            Console.WriteLine("---MENU---");
            foreach(MenuType m in menuTypes)
            {
                List<IMenuItem> items = GetItemsByType(m);
                Console.WriteLine($"---{m.ToString()}---");
                foreach(IMenuItem i in items)
                {
                    Console.WriteLine(i.ToString());
                }
            }
        }
    }
}
