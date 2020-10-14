using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApp_Einführung.Models;

namespace WebApp_Einführung.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            // normalerweise würden alle Artikel aus einer DB-Tabelle geladen
            return View(CreateArticleList());
        }

        public IActionResult Refund()
        {
            return View();
        }

        private List<Article> CreateArticleList()
        {
            return new List<Article>()
            {
                new Article(1, "iPhone 11", "Apple", new DateTime(2020, 3, 18), 999.90m, "Handy"),
                new Article(2, "Aspire", "Acer", new DateTime(2015, 1, 5), 499.90m, "Laptop"),
                new Article(3, "DeathAdder v2", "Razer", new DateTime(2020, 12, 14), 69.90m, "Elektrogerät"),
                new Article(4, "ASP.NET MVC", "Apres", new DateTime(2020, 10, 1), 49.90m, "Buch")
            };
        }
    }
}
