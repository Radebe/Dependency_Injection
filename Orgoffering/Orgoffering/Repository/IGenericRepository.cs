namespace Orgoffering.Repository
{
    public interface IGenericRepository<T> where T: class
    {
        IEnumerable<T> GetAllEntities();
        void AddEntity(T entity);
        void UpdateEntity(T entity);
        void DeleteEntity(Guid entityId);
        T GetEntityById(Guid entityId);
    }
}
