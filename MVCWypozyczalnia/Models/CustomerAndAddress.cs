using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class CustomerAndAddress
    {
        public Customer CurrentCustomer { get; set; }
        public IEnumerable<Address> Addresslist { get; set; }
    }
}