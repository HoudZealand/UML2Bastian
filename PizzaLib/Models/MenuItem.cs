using PizzaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class MenuItem : IMenuItem
    {
        private static int globalId;
        private static int NewID 
        { 
            get 
            {
                globalId++;
                return globalId; 
            } 
        }
        public string Description { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public string Name { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public int No { get; }

        public double Price { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }
        public MenuType TheMenuType { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
            No = NewID;
        }
    }
}
