using Orgoffering.Data;
using Orgoffering.Models;
using Orgoffering.Repository;
using Orgoffering.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Orgoffering.Repository
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DependencyDBContext context) : base(context)
        {
        }
    }
}
