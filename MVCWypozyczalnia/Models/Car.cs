using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Car
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "Proszę podać markę samochodu.")]
        public string Marka { get; set; }
        public string Model { get; set; }
        public string Kolor { get; set; }
        [Required(ErrorMessage = "Rok produkcji jest wymagany i mósi być liczbą!")]
        public int Rok_produkcji {get;set;}
        [Required(ErrorMessage = "Przebieg jest wymagany i mósi być liczbą")]
        public int Przebieg { get; set; }
        public bool Usuniety { get; set; }
        [DefaultValue(false)]
        public bool Wypozyczony { get; set; }

        public virtual ICollection<Rental> Rental { get; set; }
    }
}