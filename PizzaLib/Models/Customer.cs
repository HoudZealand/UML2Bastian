using PizzaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class Customer : ICustomer
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
        public string Address { get; set; }
        public bool ClubMember { get; set; }

        public int Id { get; }

        public string Mobile { get; set; }
        public string Name { get; set; }

        public Customer(string name, string mobile, string address)
        {
            Name = name;
            Mobile = mobile;
            Address = address;
            Id = NewID;
        }

        public override string ToString()
        {
            return $"ID: {Id}, Name: {Name}, Mobile: {Mobile}, Address: {Address}, Club Member: {ClubMember}";
        }
    }
}
