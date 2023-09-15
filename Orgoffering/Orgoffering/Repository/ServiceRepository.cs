using Orgoffering.Data;
using Orgoffering.Models;
using Orgoffering.Repository;
using Orgoffering.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Orgoffering.Repository
{
    public class ServiceRepository /*: GenericRepository<Service>,*/: IServiceRepository
    {
        private readonly DependencyDBContext _context;
        public ServiceRepository(DependencyDBContext context)
        {
            _context = context;
        }

        public List<Service> GetAllServices()
        {
            return _context.Services.ToList();
        }

        public Service GetServiceById(Guid serviceId)
        {
            return _context.Services.Find(serviceId);
        }

        public void UpdateService(Service service)
        {
            _context.Services.Update(service);
            _context.SaveChanges();
        }

        public void DeleteService(Guid serviceId)
        {
            var serviceToDelete = _context.Services.Find(serviceId);
            if (serviceToDelete != null)
            {
                _context.Services.Remove(serviceToDelete);
                _context.SaveChanges();
            }
        }

        public void AddService(Service service)
        {
            try
            {
                _context.Services.Add(service);
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
