using PizzaLib.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleMenu.Controllers.MenuItems
{
    public class ShowCustomerController
    {
        private CustomerRepository _cRepo;

        public ShowCustomerController(CustomerRepository cRepo)
        {
            _cRepo = cRepo;
        }

        public void ShowAllCustomers()
        {
            _cRepo.PrintAllCustomers();
        }
    }
}
