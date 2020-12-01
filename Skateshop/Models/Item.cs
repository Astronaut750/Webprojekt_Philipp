using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Skateshop.Models
{
    public enum ItemType
    {
        Deck, Truck, Wheels, Bearings, notSpecified
    }

    public class Item
    {
        public int ID { get; set; }
        public string Manufacturer { get; set; }
        public string Size { get; set; }
        public string Image { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public ItemType ItemType { get; set; }

        public Item() : this(0, "", "", "", 0.0m, "", ItemType.notSpecified) { }

        public Item(int id, string manufacturer, string size, string image, decimal price, string description, ItemType itemType)
        {
            this.ID = id;
            this.Manufacturer = manufacturer;
            this.Size = size;
            this.Image = image;
            this.Price = price;
            this.Description = description;
            this.ItemType = itemType;
        }
    }
}
