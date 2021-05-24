using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp_Einführung.Models
{
    public class Article
    {
        public int ID { get; set; }
        public string ArticleName { get; set; }
        public string Brand { get; set; }
        public DateTime ReleaseDate { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }

        public Article() : this(0, "", "", DateTime.MinValue, 0.0m, "") { }
        public Article(int id, string name, string brand, DateTime releaseDate, 
            decimal price, string category)
        {
            this.ID = id;
            this.ArticleName = name;
            this.Brand = brand;
            this.ReleaseDate = releaseDate;
            this.Price = price;
            this.Category = category;
        }

        public override string ToString()
        {
            return this.ID + " " + this.ArticleName + " " + this.Brand + " " + 
                this.Price + " Euro " + this.Category;
        }
    }
}
