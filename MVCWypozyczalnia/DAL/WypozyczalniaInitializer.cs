using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MVCWypozyczalnia.Models;

namespace MVCWypozyczalnia.DAL
{
    public class WypozyczalniaInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<WypozyczalniaContext>
    {
        protected override void Seed(WypozyczalniaContext context)
        {
            var customers = new List<Customer>
            {
                new Customer{ Imie="Karol",Nazwisko="Korol",Usuniety=false, E_mail="karolkorol@gmail.com",Telefon=48098890098, Nr_karty_kredytowej=0987000009870987},
                new Customer{ Imie="Baran",Nazwisko="Kowalski",Usuniety=false, E_mail="tetet@gmail.com",Telefon=48036360098, Nr_karty_kredytowej=1111000009870000}
            };
            customers.ForEach(s => context.Customer.Add(s));
            context.SaveChanges();

            var addresss = new List<Address>
            {
                new Address{CustomerID=1, Typ="Zamieszkania", Kod="78-200",Miasto="Białogard",Ulica="Kiepury 5"},
                new Address{CustomerID=1, Typ="Korespondencyjny", Kod="99-200",Miasto="Koszalin",Ulica="Błotna 5"},
                new Address{CustomerID=2, Typ="Zamieszkania", Kod="78-900",Miasto="Szczecin",Ulica="Kiepury 5"}
            };
            addresss.ForEach(s => context.Address.Add(s));
            context.SaveChanges();

            var cars = new List<Car>
            {
                new Car {Marka="Opel", Model="TIGRA",Przebieg=127,Rok_produkcji=1999,Usuniety=false,Wypozyczony=false,Kolor="Granatowy"},
                new Car {Marka="Opel", Model="ASTRA",Przebieg=227,Rok_produkcji=1996,Usuniety=false, Wypozyczony=false,Kolor="Czerwony"}
            };

            cars.ForEach(s => context.Car.Add(s));
            context.SaveChanges();

            var rentals = new List<Rental>
            {
                new Rental{customerID=1, carID=1,Usuniety=false,Cena=1000, Data_wynajmu=DateTime.Parse("2014-01-02"), Data_zwrotu=DateTime.Parse("2014-01-05")},
                new Rental{customerID=1, carID=2,Usuniety=false,Cena=1000, Data_wynajmu=DateTime.Parse("2014-01-08"), Data_zwrotu=DateTime.Parse("2014-01-10")},
            };
            rentals.ForEach(s => context.Rental.Add(s));
            context.SaveChanges();

        }
    }
}