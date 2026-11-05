using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Interfaces
{
    public interface IMenuItemRepository
    {
        int Count { get; }
        List<IMenuItem> GetAll();
        void AddMenuItem(IMenuItem menuItem);
        IMenuItem GetMenuItemByNo(int no);
        void RemoveMenuItem(int no);
        void PrintAllMenuItems();

    }
}
