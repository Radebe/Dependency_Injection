using Orgoffering.Models;

namespace Orgoffering.Repository
{
    public interface IProductRepository
    {
        List<Product> GetAllProducts();
        void AddProduct(Product product);
        void UpdateProduct(Product products);
        void DeleteProduct(Guid productId);
        Product GetProductById(Guid productId);
    }
}
