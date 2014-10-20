using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVCWypozyczalnia.DAL;
using MVCWypozyczalnia.Models;
using System.Web.UI.WebControls;

namespace MVCWypozyczalnia.Controllers
{
    public class CustomersController : Controller
    {
        private WypozyczalniaContext db = new WypozyczalniaContext();

        // GET: Customers
        public ActionResult Index()
        {
            return View(db.Customer.Where(r=>r.Usuniety!=true).ToList());
        }

        // GET: Customers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CustomerAndAddress customerAndAddress = new CustomerAndAddress();
            customerAndAddress.CurrentCustomer = db.Customer.Find(id);
            customerAndAddress.Addresslist = db.Address.ToList().Where(t => t.CustomerID == id);
            if (customerAndAddress == null)
            {
                return HttpNotFound();
            }
            //return View(customer);
            return View(customerAndAddress);
        }

        // GET: Customers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,Imie,Nazwisko,E_mail,Nr_karty_kredytowej,Telefon,Usuniety")] Customer customer)
        {
            bool newOne = true;
            foreach(Customer c in db.Customer)
            {
                if (c.Nazwisko == customer.Nazwisko && c.Imie == customer.Imie && c.Usuniety==false)
                {
                    newOne = false;
                    ModelState.Remove("Imie");
                    customer.Imie = "";
                    ModelState.Remove("Nazwisko");
                    customer.Nazwisko = "";
                    TempData["msg"] = "<script>alert('Taka osoba już istnieje!');</script>";
                    break;
                }
                else if (c.E_mail == customer.E_mail && c.Usuniety == false)
                {
                    newOne = false;
                    ModelState.Remove("E_mail");
                    customer.E_mail = "";
                    TempData["msg"] = "<script>alert('Taki e-mail podał już ktoś inny!');</script>";
                    break;
                }                 
            }
            if (ModelState.IsValid && newOne)
            {
                db.Customer.Add(customer);
                db.SaveChanges();
                int id = customer.ID;
                return RedirectToAction("Create", "Addresses", new { id = id });
            }
            return View(customer);
        }

        // GET: Customers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,Imie,Nazwisko,E_mail,Nr_karty_kredytowej,Telefon,Usuniety")] Customer customer)
        {
            bool valid = true;
            foreach (Customer c in db.Customer)
            {
                if (c.Nazwisko == customer.Nazwisko && c.Imie == customer.Imie && c.Usuniety == false && c.ID != customer.ID)
                {
                    valid = false;
                    ModelState.Remove("Imie");
                    customer.Imie = "";
                    ModelState.Remove("Nazwisko");
                    customer.Nazwisko = "";
                    TempData["msg"] = "<script>alert('Taka osoba już istnieje!');</script>";
                    break;
                }
                else if (c.E_mail == customer.E_mail && c.Usuniety == false && c.ID != customer.ID)
                {
                    valid = false;
                    ModelState.Remove("E_mail");
                    customer.E_mail = "";
                    TempData["msg"] = "<script>alert('Taki e-mail podał już ktoś inny!');</script>";
                    break;
                }
            }
            if (ModelState.IsValid && valid)
            {
                db.Entry(customer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(customer);
        }

        // GET: Customers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Customer customer = db.Customer.Find(id);
            if (customer == null)
            {
                return HttpNotFound();
            }
            return View(customer);
        }

        // POST: Customers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Customer customer = db.Customer.Find(id);
            customer.Usuniety = true;
            db.Entry(customer).State = EntityState.Modified;
            //db.Customer.Remove(customer);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Rental(int? id)
        {
            Customer customer = db.Customer.Find(id);
            Rental rental = new Rental();
            rental.customerID = customer.ID;
            ViewBag.ImieNazwisko = customer.Imie + " " + customer.Nazwisko;
            var carList = db.Car.Where(p => p.Usuniety == false && p.Wypozyczony == false).Select(c =>
                new SelectListItem
                {
                    Value = c.ID.ToString(),
                    Text = c.Marka + " " + c.Model + " Rok produkcji:" + c.Rok_produkcji.ToString()
                });

            ModelState.Remove("Data_wynajmu");
            ModelState.Remove("Data_zwrotu");
            rental.Data_wynajmu = DateTime.Now;
            rental.Data_zwrotu = DateTime.Now;

            ViewBag.carID = new SelectList(carList, "Value", "Text");
            return View(rental);
        }

        // POST: Customers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Rental([Bind(Include = "ID,carID,customerID,Usuniety,Data_wynajmu,Data_zwrotu,Cena")] Rental rental)
        {
            if (ModelState.IsValid)
            {
                rental.Car = db.Car.Find(rental.carID); 
                rental.Car.Wypozyczony = true;
                //rental.Customer = db.Customer.Find(rental.customerID);
                //db.Car.Add(rental.Car);
                db.Rental.Add(rental);
                db.SaveChanges();
                int id = rental.ID;
                return RedirectToAction("Index");
            }
            return View(rental);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
