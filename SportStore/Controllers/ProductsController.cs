using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using SportStore.Entities;
using SportStore.Enums;

namespace SportStore.Controllers
{
    public class ProductsController : Controller
    {
        public IActionResult Index()
        {
            var products = new List<StoreItem>
            {
                new StoreItem{ItemType = ItemType.Accessory, Name = "kaki", Price = 50},
                new StoreItem{ItemType = ItemType.Accessory, Name = "kaki1", Price = 60},
                new StoreItem{ItemType = ItemType.Accessory, Name = "kaki2", Price = 70},
                new StoreItem{ItemType = ItemType.Accessory, Name = "kaki3", Price = 90},
                new StoreItem{ItemType = ItemType.Accessory, Name = "kaki4", Price = 80},
            };

            return View(products);
        }
    }
}
