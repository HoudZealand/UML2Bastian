using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Exceptions
{
    public class InvalidDiscountException : Exception
    {
        public InvalidDiscountException(string message) : base(message)
        {
            
        }
    }
}
