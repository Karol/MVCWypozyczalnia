using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Car
    {
        public int ID { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Kolor { get; set; }
        public int Rok_produkcji {get;set;}
        public int Przebieg { get; set; }
        public bool Usuniety { get; set; }
        [DefaultValue(false)]
        public bool Wypozyczony { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}