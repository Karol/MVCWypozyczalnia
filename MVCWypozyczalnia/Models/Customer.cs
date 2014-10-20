using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Customer
    {
        public int ID { get; set; }
        public string Imie {get;set;}
        public string Nazwisko {get;set;}
        [Required(ErrorMessage = "Proszę podać poprawny e-mail")]
        [RegularExpression(".+\\@.+\\..+", ErrorMessage = "Adres e-mail mósi zawierać znak @ ")]
        public string E_mail {get;set;}
        public string Nr_karty_kredytowej { get; set; }

        [RegularExpression(@"[+]\d{2}[- ]?\d{3}[- ]?\d{3}[- ]?\d{3}", ErrorMessage = "Zły format numeru")]
        [Required(ErrorMessage="Numer telefonu jest wymagany.")]
        public string Telefon {get;set;}
        [DefaultValue(true)]
        public bool E_faktura { get; set; }
        public bool Usuniety { get; set; }

        public virtual ICollection<Address> Address { get; set; }
        public virtual ICollection<Rental> Rental { get; set; }

    }
}