using Presentation.WebApp.Models;

namespace Presentation.WebApp.Services;

public class ProductService
{
    private readonly List<Product> _products =
    [
        new Product { Id = 1, Name = "Snus", Price = 300},
        new Product { Id = 2, Name = "Tuggummi", Price = 20},
        new Product { Id = 3, Name = "Fyrverkeri", Price = 1500}
    ];

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}