using System;

namespace Vit.ShoppingCart.Domain.Products
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public decimal Rating { get; set; }
        public bool IsBestseller { get; set; }
    }
}