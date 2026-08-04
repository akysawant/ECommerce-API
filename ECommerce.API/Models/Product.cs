using ECommerce.API.Entities;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Eventing.Reader;

namespace ECommerce.API.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public double Price { get; set; }
        public int Stock { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public int CategoryId { get; set; }
        public bool IsActive { get; set; }
        public Category Category { get; set; }
        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();

        public int Version { get; set; }

        public void Update(string name, double price, int stock, int categoryId)
        {
            Name = name;
            Price = price;
            Stock = stock;
            CategoryId = CategoryId;
        }

    }
}
