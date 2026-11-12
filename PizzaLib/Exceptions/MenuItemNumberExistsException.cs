using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Exceptions
{
    public class MenuItemNumberExistsException : Exception
    {
        public MenuItemNumberExistsException(string message) : base(message)
        {
            
        }
    }
}
