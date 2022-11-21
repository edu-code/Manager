using ManagerServices.DTO;

namespace ManagerServices.Interfaces;

public interface IUserServices
{
    Task<UserDTO> Create(UserDTO userDto);
    Task<UserDTO> Update(UserDTO userDto);
    Task Remove(long id);
    Task<UserDTO> Get(long id);
    Task<List<UserDTO>> Get();
    Task<List<UserDTO>> SearchByName(string name);
    Task<List<UserDTO>> SearchByEmail(string email);
    Task<UserDTO> GetByEmail(string email);

}