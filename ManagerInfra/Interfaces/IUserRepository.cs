using ManagerDomain.Entities;

namespace ManagerInfra.Interfaces;

public interface IUserRepository : IBaseRepository<User>
{
    Task<User> GetByEmail(string email);
    Task<List<User>> SearchByEmail(string email);
    Task<List<User>> SearchByName(string name);
     
}