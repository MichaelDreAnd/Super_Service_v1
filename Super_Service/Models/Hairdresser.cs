using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Super_Service.Models
{
    public class Hairdresser
    {
        //[Required]
        public string Name { get; set; }
        public int CompanyID { get; set; }
        //[Required]
        public string Address { get; set; }
        //[Required]
        //[Range(0000, 9999)]
        public int ZipCode { get; set; }
        //[Required]
        public string City { get; set; }
        public double Rating { get; set; }

    }
}
