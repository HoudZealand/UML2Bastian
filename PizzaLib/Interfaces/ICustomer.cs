using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Interfaces
{
    public interface ICustomer
    {
        string Address { get; set; }
        bool ClubMember { get; set; }
        int Id { get; }
        string Mobile { get; set; }
        string Name { get; set; }

        string ToString();

    }
}
