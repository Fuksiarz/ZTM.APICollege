using System.Collections.Generic;
using System.Threading.Tasks;

namespace ZTM.Infrastructure.Repository;

public interface IRepository<T>
{
    Task<IEnumerable<T>> GetAll();
    Task<T> GetById(int id);
    Task Add(T entity);
    Task Update(T entity);
    Task DeleteById(int id);
}