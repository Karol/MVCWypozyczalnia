using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Imie {get;set;}
        public string Nazwisko {get;set;}
        public string E_mail {get;set;}
        public long Nr_karty_kredytowej { get; set; }
        public long Telefon {get;set;}
        [DefaultValue(true)]
        public bool E_faktura { get; set; }
        public bool Usuniety { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }

    }
}