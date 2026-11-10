using PizzaLib.Data;
using PizzaLib.Interfaces;
using PizzaLib.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, ICustomer> _customers;
        public int Count { get { return _customers.Count; } }
        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }

        public void PrintAllCustomers()
        {
            foreach(ICustomer c in _customers.Values)
            {
                Console.WriteLine(c.ToString());
            }
        }

        public void RemoveCustomer(string mobile)
        {
            if (_customers.ContainsKey(mobile)) _customers.Remove(mobile);
        }

        public void AddCustomer(ICustomer customer)
        {
            if (!_customers.ContainsKey(customer.Mobile)) _customers.Add(customer.Mobile, customer);
        }

        public List<ICustomer> GetAll()
        {
            List<ICustomer> customers = new List<ICustomer>();

            foreach(ICustomer c in _customers.Values)
            {
                customers.Add(c);
            }

            return customers;
        }

        public List<ICustomer> GetMembers()
        {
            List<ICustomer> members = new List<ICustomer>();

            foreach(ICustomer c in _customers.Values)
            {
                if (c.ClubMember) members.Add(c);
            }

            return members;
        }

        public List<ICustomer> GetByArea(string area)
        {
            List<ICustomer> customers = new List<ICustomer>();

            foreach(ICustomer c in _customers.Values)
            {
                if (c.Address.Contains(area)) customers.Add(c);
            }

            return customers;
        }

        public ICustomer GetCustomerByMobile(string mobile)
        {
            if (_customers.ContainsKey(mobile)) return _customers[mobile];
            else throw new NullReferenceException("Customer does not exist in repository!");
        }
    }
}
