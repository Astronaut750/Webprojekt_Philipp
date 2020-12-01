using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skateshop.Models;

namespace Skateshop.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View(new User());
        }

        [HttpPost]
        public IActionResult Register(User newUser)
        {
            if (newUser == null)
            {
                return RedirectToAction("Register");
            }

            ValidateUserData(newUser);

            if(ModelState.IsValid)
            {
                return RedirectToAction("Index", "User");
            }

            return View(newUser);
        }

        public void ValidateUserData(User u)
        {
            if (u == null)
            {
                return;
            }

            if ((u.Firstname == null) || u.Firstname.Length < 3){
                ModelState.AddModelError(nameof(Models.User.Firstname), "Der Vorname muss mindestens 3 Zeichen lang sein!");
            }

            if((u.Lastname == null) || u.Lastname.Length < 3)
            {
                ModelState.AddModelError(nameof(Models.User.Lastname), "Der Nachname muss mindestens 3 Zeichen lang sein!");
            }

            if(!IsValidEmail(u.Email))
            {
                ModelState.AddModelError(nameof(Models.User.Email), "Die Email-Adresse muss das korrekte Format haben!");
            }

            if(u.Birthdate > DateTime.Now)
            {
                ModelState.AddModelError(nameof(Models.User.Birthdate), "Datum liegt in der Zukunft!");
            }
            else if(u.Birthdate < new DateTime(1900, 1, 1))
            {
                ModelState.AddModelError(nameof(Models.User.Birthdate), "Datum vor 1900!");
            }


            if(!IsAddressDataEmpty(u.Street, u.StreetNumber, u.Zipcode, u.City, u.State) && IsStringEmpty(u.Street))
            {
                ModelState.AddModelError(nameof(Models.User.Street), "Die Addresse ist unvollständig! Straße fehlt!");
            }

            if(!IsAddressDataEmpty(u.Street, u.StreetNumber, u.Zipcode, u.City, u.State) && IsStringEmpty(u.StreetNumber))
            {
                ModelState.AddModelError(nameof(Models.User.StreetNumber), "Die Addresse ist unvollständig! Hausnummer fehlt!");
            }

            if(!IsAddressDataEmpty(u.Street, u.StreetNumber, u.Zipcode, u.City, u.State) && IsStringEmpty(u.Zipcode))
            {
                ModelState.AddModelError(nameof(Models.User.Zipcode), "Die Addresse ist unvollständig! Postleitzahl fehlt!");
            }

            if(!IsAddressDataEmpty(u.Street, u.StreetNumber, u.Zipcode, u.City, u.State) && IsStringEmpty(u.City))
            {
                ModelState.AddModelError(nameof(Models.User.City), "Die Addresse ist unvollständig! Stadt fehlt!");
            }

            if(!IsAddressDataEmpty(u.Street, u.StreetNumber, u.Zipcode, u.City, u.State) && u.State == State.notSpecified)
            {
                ModelState.AddModelError(nameof(Models.User.State), "Die Addresse ist unvollständig! Staat fehlt!");
            }
        }

        static bool IsAddressDataEmpty(string street, string streetNumber, string zipcode, string city, State state)
        {
            if(IsStringEmpty(street) && IsStringEmpty(streetNumber) && IsStringEmpty(zipcode) && IsStringEmpty(city) && state == State.notSpecified)
            {
                return true;
            }
            return false;
        }

        static bool IsStringEmpty(string s)
        {
            if(s == null || s == "")
            {
                return true;
            }
            return false;
        }

        static bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}
