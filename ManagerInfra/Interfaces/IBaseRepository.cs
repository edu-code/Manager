using ManagerDomain.Entities;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace ManagerInfra.Interfaces;

public interface IBaseRepository<T> where T : Base
{
    Task<T> CreateAsync(T obj);
    Task<T> UpdateAsync(T obj);
    Task<T> RemoveAsync(long id);
    Task<T> GetAsync(long id);
    Task<List<T>> GetAllAsync();

}