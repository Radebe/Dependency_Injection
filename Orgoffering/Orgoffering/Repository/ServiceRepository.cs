using Orgoffering.Data;
using Orgoffering.Models;
using Orgoffering.Repository;
using Orgoffering.Controllers;

namespace Orgoffering.Repository
{
    public class ServiceRepository : GenericRepository<Service>, IServiceRepository
    {
        public ServiceRepository(DependencyDBContext context) : base(context)
        {
        }

        public Service GetMostRecentService()
        {
            return _context.Services.OrderByDescending(service => service.CreatedDate).FirstOrDefault();
        }
    }

}
