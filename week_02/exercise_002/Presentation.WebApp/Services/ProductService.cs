using Presentation.WebApp.Models;

namespace Presentation.WebApp.Services;

public class ProductService
{
    private List<Product> _products = 
    [
        new Product { Id = 1, Name = "Tuggummi", Price = 20 },
        new Product { Id = 2, Name = "Tidning", Price = 30 },
        new Product { Id = 3, Name = "Snus", Price = 50 }
    ];

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}