using Vit.ShoppingCart.Domain.Products;

namespace Vit.ShoppingCart.Domain.Books
{
    public class Book : Product
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string ISBN { get; set; }
        
    }
}