using OOP_NorthwindDbFirst.Models;

namespace OOP_NorthwindDbFirst.Abstracts.Interfaces
{
    internal interface IProductRepository
    {
        //CRUD
        string CreateProduct(Product product);
        List<Product> GetAllProducts();
        Product Find(int productId);
        string UpdateProduct(Product product);
        string DeleteProduct(int productId);
    }
}
