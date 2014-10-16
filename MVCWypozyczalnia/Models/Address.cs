using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Address
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }

        public string Typ { get; set; }
        public string Ulica { get; set; }
        public string Kod { get; set; }
        public string Miasto { get; set; }

        public virtual Customer Customer { get; set; }
    }
}