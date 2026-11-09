using System;
using System.Collections.Generic;
using System.Text;
using PizzaLib.Models;

namespace PizzaLib.Interfaces
{
    public interface IMenuItemRepository
    {
        int Count { get; }
        List<IMenuItem> GetAll();
        List<IMenuItem> GetItemsByType(MenuType menuType);
        void AddMenuItem(IMenuItem menuItem);
        IMenuItem GetMenuItemByNo(int no);
        void RemoveMenuItem(int no);
        void PrintAllMenuItems();

    }
}
