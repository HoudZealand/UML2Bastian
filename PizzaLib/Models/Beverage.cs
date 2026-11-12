using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class Beverage : MenuItem
    {
        public bool Alcohol { get; set; }
        public Beverage(string name, double price, string description, bool alcohol) : base(name, price, description, MenuType.DRIKKEVARE)
        {
            Alcohol = alcohol;
        }
        public override string ToString()
        {
            return base.ToString() + $", Alcohol: {Alcohol}";
        }
    }
}
