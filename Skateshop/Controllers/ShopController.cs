using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skateshop.Models;
using Skateshop.Models.DB;
using System.Data.Common;

namespace Skateshop.Controllers
{
    public class ShopController : Controller
    {
        private IRepositoryItems rep = new RepositoryItemsDB();

        public IActionResult Index()
        {
            try
            {
                rep.Open();
                return View(rep.GetAllItems());
            }
            catch(Exception ex)
            {
                return View("Message", new Message("Datenbankfehler",
                           ex.Message,
                           "Bitte versuchen Sie es später erneut!"));
            }
            finally
            {
                rep.Close();
            }
        }

        [HttpGet]
        public IActionResult DeleteItem(int ID)
        {
            return View(ID);
        }

        [HttpGet]
        public IActionResult CreateNewArticle()
        {
            return View(new Item());
        }

        [HttpPost]
        public IActionResult CreateNewArticle(Item newItem)
        {
            if (newItem == null)
            {
                return RedirectToAction("CreateNewArticle");
            }

            ValidateItemData(newItem);

            if (ModelState.IsValid)
            {
                try
                {
                    rep.Open();

                    if(rep.Insert(newItem))
                    {
                        return View("Message", new Message("Erfolg",
                            "Der Artikel wurde erfolgreich abgespeichert!"));
                    }
                }
                catch(DbException)
                {
                    return View("Message", new Message("Fehler",
                            "Der Artikel konnte nicht abgespeichert werden!",
                            "Bitte versuchen Sie es später erneut!"));
                }
            }

            return View(newItem);
        }

        public IActionResult Refund()
        {
            return View();
        }

        public IActionResult ItemView(Item i)
        {
            return View(i);
        }

        private void ValidateItemData(Item i)
        {
            if (i == null)
            {
                return;
            }

            if (i.Manufacturer == null || i.Manufacturer.Length < 3)
            {
                ModelState.AddModelError(nameof(Item.Manufacturer), "Der Hersteller muss mind. 3 Zeichen lang sein.");
            }

            if (i.Price <= 0.0m)
            {
                ModelState.AddModelError(nameof(Item.Price), "Der Preis muss > 0 sein.");
            }

            if (i.Description == null || i.Description.Length < 3)
            {
                ModelState.AddModelError(nameof(Item.Description), "Die Beschreibung muss mind. 3 Zeichen lang sein.");
            }

        }
    }
}
