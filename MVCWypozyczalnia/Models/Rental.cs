using System;
using System.Collections.Generic;
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
        public DateTime Data_wynajmu { get; set; }
        public DateTime Data_zwrotu { get; set; }
        public int Cena { get; set; }

        public virtual Customer Customer { get; set; }
        public virtual Car Car { get; set; }
    }
}