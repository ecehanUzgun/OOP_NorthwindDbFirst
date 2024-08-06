using OOP_NorthwindDbFirst.Abstracts.Interfaces;
using OOP_NorthwindDbFirst.Models;

namespace OOP_NorthwindDbFirst.Concretes.Services
{
    internal class ProductService : IProductRepository
    {
        private readonly NorthwindContext _db;
        public ProductService()
        {
            _db = new NorthwindContext();
        }
        public string CreateProduct(Product product)
        {
            _db.Products.Add(product);
            _db.SaveChanges();
            return "Product added!";
        }

        public string DeleteProduct(int productId)
        {
            Product deleteProduct = _db.Products.Find(productId);
            if (deleteProduct != null) 
            { 
                _db.Products.Remove(deleteProduct);
                _db.SaveChanges();
                return "Product deleted.";
            }
            else
            {
                return "Product can not find.";
            }
        }

        public Product Find(int productId)
        {
           Product findProduct = _db.Products.Find(productId);
           if (findProduct != null)
           {
                return findProduct;
           }
           else 
           {
                return findProduct; 
           }
        }

        public List<Product> GetAllProducts()
        {
            return _db.Products.ToList();
        }

        public string UpdateProduct(Product product)
        {
            Product updateProduct = Find(product.ProductId);
            if (updateProduct != null) 
            {
                updateProduct.ProductName = product.ProductName;
                updateProduct.UnitPrice = product.UnitPrice;
                updateProduct.UnitsInStock = product.UnitsInStock;
                _db.SaveChanges();
                return "Product updated.";
            }
            else
            {
                return "Update failed!";
            }
        }
    }
}
