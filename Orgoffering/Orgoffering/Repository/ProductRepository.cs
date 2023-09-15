using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orgoffering.Data;
using Orgoffering.Models;

namespace Orgoffering.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly DependencyDBContext _context;
        public ProductRepository(DependencyDBContext context)
        {
            _context = context;
        }

        public void DeleteProduct(Guid productId)
        {
            var productToDelete = _context.Products.Find(productId);
            if (productToDelete != null)
            {
                _context.Products.Remove(productToDelete);
                _context.SaveChanges();
            }
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(Guid productId)
        {
            return _context.Products.Find(productId);
        }

        public void UpdateProduct(Product product)
        {
            _context.Products.Update(product);
            _context.SaveChanges();
        }

        public void AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException && sqlException.Number == 2627)
                {
                    throw new Exception("A service with this ID already exists.");
                }
                else
                {
                    
                    throw; 
                }
            }
        }
    }
}
