using PizzaLib.Data;
using PizzaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Services
{
    public class MenuItemRepository : IMenuItemRepository
    {
        private List<IMenuItem> _menuItems;
        public int Count => throw new NotImplementedException();

        public MenuItemRepository()
        {
            _menuItems = MockData.MenuItemData;
        }

        public void PrintAllMenuItems()
        {
            throw new NotImplementedException();
        }

        public void RemoveMenuItem(int no)
        {
            throw new NotImplementedException();
        }

        void IMenuItemRepository.AddMenuItem(IMenuItem menuItem)
        {
            throw new NotImplementedException();
        }

        List<IMenuItem> IMenuItemRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        IMenuItem IMenuItemRepository.GetMenuItemByNo(int no)
        {
            throw new NotImplementedException();
        }
    }
}
