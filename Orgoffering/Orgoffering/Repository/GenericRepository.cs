using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Orgoffering.Data;
using Orgoffering.Models;

namespace Orgoffering.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DependencyDBContext _context;

        public GenericRepository(DependencyDBContext context)
        {
            _context = context;
        }

        public void AddEntity(T entity)
        {
            try
            {
                _context.Set<T>().Add(entity);
                _context.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                if (ex.InnerException is SqlException sqlException)
                {
                    throw new Exception("A service with this ID already exists.");
                }
                else
                {
                    throw;
                }
            }
        }

        public void DeleteEntity(Guid entityId)
        {
            var entityToDelete = _context.Set<T>().Find(entityId);
            if (entityToDelete != null)
            {
                _context.Set<T>().Remove(entityToDelete);
                _context.SaveChanges();
            }
        }

        public IEnumerable<T> GetAllEntities()
        {
            return _context.Set<T>().ToList();
        }

        public T GetEntityById(Guid entityId)
        {
            return _context.Set<T>().Find(entityId);
        }

        public void UpdateEntity(T entity)
        {
            _context.Set<T>().Update(entity);
            _context.SaveChanges();
        }
    }
}
