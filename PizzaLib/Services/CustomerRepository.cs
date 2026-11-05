using PizzaLib.Data;
using PizzaLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Services
{
    public class CustomerRepository : ICustomerRepository
    {
        private Dictionary<string, ICustomer> _customers;
        public int Count => throw new NotImplementedException();
        public CustomerRepository()
        {
            _customers = MockData.CustomerData;
        }

        public void PrintAllCustomers()
        {
            throw new NotImplementedException();
        }

        public void RemoveCustomer(string mobile)
        {
            throw new NotImplementedException();
        }

        void ICustomerRepository.AddCustomer(ICustomer customer)
        {
            throw new NotImplementedException();
        }

        List<ICustomer> ICustomerRepository.GetAll()
        {
            throw new NotImplementedException();
        }

        ICustomer ICustomerRepository.GetCustomerByMobile(string mobile)
        {
            throw new NotImplementedException();
        }
    }
}
