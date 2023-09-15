using Orgoffering.Models;
using System.Linq.Expressions;

namespace Orgoffering.Repository
{
    public interface IServiceRepository
    {
        /*Service GetById(int id);
        IEnumerable<Service> GetAll();
        IEnumerable<Service> Find(Expression<Func<Service, bool>> expression);
        void Add(Service entity);
        void AddRange(IEnumerable<Service> entities);
        void Remove(Service entity);
        void RemoveRange(IEnumerable<Service> entities);
        
        Service GetMostRecentService();*/

        List<Service> GetAllServices();
        Service GetServiceById(Guid serviceId);
        void AddService(Service service);
        void UpdateService(Service service);
        void DeleteService(Guid serviceId);

    }
}

