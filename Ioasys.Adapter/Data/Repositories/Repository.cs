using System.Linq;
using Ioasys.Domain.Shared.Entities;
using Ioasys.Domain.Shared.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Ioasys.Adapter.Data.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DataContext DbContext;

        public Repository(DataContext dbContext)
        {
            DbContext = dbContext;
        }

        public T Create(T objeto)
        {
            DbContext.Set<T>().Add(objeto);
            return objeto;
        }

        public T Update(T objeto)
        {
            DbContext.Entry(objeto).State = EntityState.Modified;
            return objeto;
        }

        public void Delete(int id)
        {
            var obj = DbContext.Set<T>().FirstOrDefault(x => x.Id == id);

            if (obj == null)
                return;

            DbContext.Set<T>().Remove(obj);
        }

        public void Inactivate(T entity)
        {
            DbContext.Entry(entity).Property(x => x.Ativo).IsModified = true;
        }

        public T GetById(int id)
        {
            return DbContext.Set<T>().AsNoTracking().FirstOrDefault(x => x.Id == id);
        }
    }
}
