using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class Product
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string CategoryId { get; set; }
        public string ManufacturerId { get; set; }
        public float UnitPrice { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Picture { get; set; }

        public Product() { }

        public Product(string id, string name, string categoryId, string manufacturerId, float unitPrice, int stock, string description, string picture)
        {
            Id = id;
            Name = name;
            CategoryId = categoryId;
            ManufacturerId = manufacturerId;
            UnitPrice = unitPrice;
            Stock = stock;
            Description = description;
            Picture = picture;
        }   
    }
}
