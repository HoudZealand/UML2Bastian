using PizzaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

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
        public string Description { get; set; }
        public string Name { get; set; }

        public int No { get; }

        public double Price { get; set; }
        public MenuType TheMenuType { get; set; }

        public MenuItem(string name, double price, string description, MenuType menuType)
        {
            Name = name;
            Price = price;
            Description = description;
            TheMenuType = menuType;
            No = NewID;
        }

        public override string ToString()
        {
            return $"Number: {No}, Name: {Name}, Price: {Price}, Description: {Description}, Menu Type: {TheMenuType}";
        }

        public void UpdateItem(IMenuItem update)
        {
            Name = update.Name;
            Price = update.Price;
            Description = update.Description;
            TheMenuType = update.TheMenuType;
        }
    }
}
