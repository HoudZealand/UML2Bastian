using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Exceptions
{
    public class EmptyOrderException : Exception
    {
        public EmptyOrderException(string message) : base(message)
        {
            
        }
    }
}
