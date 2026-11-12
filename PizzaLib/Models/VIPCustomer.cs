using PizzaLib.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class VIPCustomer : Customer
    {
        public double Discount 
        { 
            get;
            set
            {
                if(value > 25 || value < 0)
                {
                    throw new InvalidDiscountException("Discount must be between 0% and 25%");
                }
                field = value;
            } 
        }
        public VIPCustomer(string name, string mobile, string address, double discount) : base(name, mobile, address)
        {
            Discount = discount;
        }

        public override string ToString()
        {
            return base.ToString() + $", Discount: {Discount}";
        }
    }
}
