using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Address
    {
        public int ID { get; set; }
        public int CustomerID { get; set; }

        [DefaultValue("Zamieszkania")]
        public string Typ { get; set; }
        public string Ulica { get; set; }
        public string Kod { get; set; }
        public string Miasto { get; set; }

        public virtual Customer Customer { get; set; }
    }
}