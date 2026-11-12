using System;
using System.Collections.Generic;
using System.Text;

namespace PizzaLib.Models
{
    public class CompanyInfo
    {
        private static CompanyInfo _instance;
        public double VAT { get; set; }
        public string CVR { get; set; }
        public string Name { get; set; }
        public double ClubDiscount { get; set; }
        private CompanyInfo()
        {
            
        }
        public static CompanyInfo Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new CompanyInfo();
                }
                return _instance;
            }
        }

        public override string ToString()
        {
            return $"CVR: {CVR}, Name: {Name}, VAT: {VAT}, Club Discount: {ClubDiscount}";
        }
    }
}
