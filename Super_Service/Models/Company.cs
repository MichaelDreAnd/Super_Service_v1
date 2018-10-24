using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Super_Service.Models
{
    // Author Nicklas HJ
    public class Company
    {
        public string CompanyName { get; set; }
        public string Address { get; set; }
        public int ZipCode { get; set; }

        public Company(string companyName, string address, int zipCode)
        {
            CompanyName = companyName;
            Address = address;
            ZipCode = zipCode;
        }
    }
}