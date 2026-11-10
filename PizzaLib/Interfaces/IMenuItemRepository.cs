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
        IMenuItem GetMostExpensiveByType(MenuType menuType);
        IMenuItem GetMostExpensiveByType(MenuType[] menuTypes);
        void PrintMenu();
        void AddMenuItem(IMenuItem menuItem);
        IMenuItem GetMenuItemByNo(int no);
        void RemoveMenuItem(int no);
        void PrintAllMenuItems();

    }
}
