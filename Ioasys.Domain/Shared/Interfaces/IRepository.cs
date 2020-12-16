using Ioasys.Domain.Shared.Entities;

namespace Ioasys.Domain.Shared.Interfaces
{
    public interface IRepository<T> where T : Entity
    {
        T Create(T obj);
        T Update(T obj);
        void Delete(int id);
        T GetById(int id);
        void Inactivate(T entity);
    }
}
