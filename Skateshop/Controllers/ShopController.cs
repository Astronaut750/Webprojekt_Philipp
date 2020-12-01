using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Skateshop.Models;

namespace Skateshop.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View(generateItems());
        }

        public IActionResult createNewArticle()
        {
            return View();
        }

        public IActionResult Refund()
        {
            return View();
        }

        public IActionResult ItemView(Item i)
        {
            return View(i);
        }

        public List<Item> generateItems()
        {
            return new List<Item>
            {
                new Item( 0, "Flip", "8.13\"", "decks/deck1.jpg", 64.99m, "Penny Loveshroom Purple", ItemType.Deck),
                new Item( 1, "SK8DLX", "8.25\"", "decks/deck2.jpg", 54.99m, "Rose Black", ItemType.Deck),
                new Item( 2, "JART", "8\"", "decks/deck3.jpg", 49.99m, "Renaissance II Weedsuschrist Multi", ItemType.Deck),
                          
                new Item( 3, "Tensor", "6\"", "trucks/truck1.jpg", 49.99m, "Alloys Regular Truck 2er Pack RAW", ItemType.Truck),
                new Item( 4, "Tensor", "5.5\"", "trucks/truck2.jpg", 49.99m, "Alloys Regular Truck 2er Pack Black", ItemType.Truck),
                new Item( 5, "Tensor", "5.5\"", "trucks/truck3.jpg", 49.99m, "Magnesium Light Tens Truck All Terrain 2er Pack Silver", ItemType.Truck),
                                               
                new Item( 6, "SPITFIRE", "54mm 99A", "wheels/wheels1.jpg", 59.99m, "Formula Four (White Blue)", ItemType.Wheels),
                new Item( 7, "HAZE WHEELS", "52mm 85A", "wheels/wheels2.jpg", 44.99m, "Deflated Dolls (White)", ItemType.Wheels),
                new Item( 8, "BONES", "52mm 100A", "wheels/wheels3.jpg", 34.99m, "100\'S-OG #18 V4 (Black Red)", ItemType.Wheels),

                new Item( 9, "BONES", ""   , "bearings/bearings1.jpg", 115.99m, "Ceramic Super Reds", ItemType.Bearings),
                new Item(10, "BONES", "" , "bearings/bearings2.jpg", 84.99m, "Super Swiss 6 Ball", ItemType.Bearings),
                new Item(11, "BONES", "" , "bearings/bearings3.jpg", 79.99m, "Swiss 7 Ball", ItemType.Bearings),
            };
        }
    }
}
