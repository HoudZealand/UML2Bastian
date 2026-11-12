using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Exceptions
{
    public class CustomerMobileNumberExistsException : Exception
    {
        public CustomerMobileNumberExistsException(string message) : base(message)
        {
            
        }
    }
}
