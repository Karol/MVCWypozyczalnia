using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCWypozyczalnia.Models
{
    public class Rental
    {
        public int ID { get; set; }
        public int carID { get; set; }
        public int customerID { get; set; }
        public bool Usuniety { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data jest wymagana.")]
        public DateTime Data_wynajmu { get; set; }
        [DataType(DataType.Date)]
        [Required(ErrorMessage = "Data jest wymagana.")]
        public DateTime Data_zwrotu { get; set; }
        public int Cena { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
    }
}