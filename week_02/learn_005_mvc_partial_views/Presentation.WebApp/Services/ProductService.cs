using Presentation.WebApp.Models;

namespace Presentation.WebApp.Services;

public class ProductService
{
    private List<Product> _products =
    [
        new Product { Id = 1, ProductName = "Product 1" },
        new Product { Id = 2, ProductName = "Product 2" },
        new Product { Id = 3, ProductName = "Product 3" }
    ];

    public IEnumerable<Product> GetProducts()
    {
        return _products;
    }
}