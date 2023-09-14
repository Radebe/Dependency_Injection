using Orgoffering.Models;

namespace Orgoffering.Repository
{
    public interface IServiceRepository : IGenericRepository<Service>
    {
        Service GetMostRecentService();
    }
}
