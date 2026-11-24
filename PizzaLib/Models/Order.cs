using PizzaLib.Exceptions;
using PizzaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class Order
    {
        private static int globalId;
        private static int NewId
        {
            get
            {
                return globalId++;
            }
        }

        public int Id { get; }
        public ICustomer? Customer { get; private set; }
        public List<IMenuItem> Items { get; set; }

        public Order()
        {
            Id = NewId;
            Items = new List<IMenuItem>();
        }
        public Order(ICustomer customer)
        {
            Id = NewId;
            Customer = customer;
            Items = new List<IMenuItem>();
        }

        public double CalculatePrice()
        {
            if (Items.Count < 1) throw new EmptyOrderException("Order must contain at least 1 item.");
            double price = 0.0;

            foreach(IMenuItem i in Items)
            {
                price += i.Price;
            }

            return (Customer != null && Customer is VIPCustomer) ? 
                   price * 1 + ((VIPCustomer) Customer).Discount / 100 :
                   price;
        }

        public void PrintOrder()
        {
            string print = $"Order No.: {Id}";
            if (Customer != null) print += $"\nCustomer: {Customer.ToString()}";
            print += "\nItems:";
            foreach(IMenuItem i in Items)
            {
                print += $"\n| {i.ToString()}";
            }
            print += $"\nPrice: {CalculatePrice()} kr.";
            Console.WriteLine(print);
        }
    }
}
