using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orgoffering.Data;
using Orgoffering.Models;

namespace Orgoffering.Repository
{
    public class ProductRepository : GenericRepository<Product>, IProductRepository
    {
        public ProductRepository(DependencyDBContext context) : base(context)
        {
        }
    }
}
