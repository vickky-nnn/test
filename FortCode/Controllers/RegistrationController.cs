using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using FortCode.Models;
namespace FortCode.Controllers
{
    public class RegistrationController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        //User Registration
        public IActionResult AddUser(User myUser)
        {
            User newUser = new User();
            newUser = myUser;
            UserDbContext obj = new UserDbContext();
            obj.User.Add(newUser);
            obj.SaveChanges();
            return RedirectToAction("Index");
        }

        //Adding Adreess
        public IActionResult AddAddress(Address myAddress)
        {
            Address Obj = new Address();
            UserDbContext dbObject = new UserDbContext();
            Obj.CityName = myAddress.CityName;
            Obj.Country = myAddress.Country;
            dbObject.Address.Add(Obj);
            dbObject.SaveChanges();
            return RedirectToAction("Address");
        }

        //Removing Address
        public IActionResult RemoveAddress(string cityName)
        {
            Address Obj = new Address();
            UserDbContext dbObject = new UserDbContext();
            Address removeAddress = dbObject.Address.Where(m => m.CityName == cityName).FirstOrDefault();
            dbObject.Address.Remove(removeAddress);
            dbObject.SaveChanges();
            return RedirectToAction("Address");
        }
    }
}
