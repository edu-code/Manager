using ManagerCore.Exceptions;
using ManagerDomain.Entities;
using ManagerInfra.Interfaces;
using ManagerServices.DTO;
using ManagerServices.Interfaces;
using AutoMapper;
namespace ManagerServices.Services;


public class UserServices : IUserServices
{
    private readonly IMapper _mapper;
    private readonly IUserRepository _userRepository;

    public UserServices(IMapper mapper, IUserRepository userRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
    }

    public async Task<UserDTO> Create(UserDTO userDto)
    {
        var userExists = await _userRepository.GetByEmail(userDto.Email);
        if (userExists != null)
            throw new DomainException("O email informado já está sendo usado.");
        
        var user = _mapper.Map<User>(userDto);
        user.Validate();

        var userCreated = await _userRepository.CreateAsync(user);

        return _mapper.Map<UserDTO>(userCreated);
    }

    public async Task<UserDTO> Update(UserDTO userDto)
    {
        var userExists = await _userRepository.GetAsync(userDto.Id);

        if (userExists == null)
            throw new DomainException("Não existe nenhum usuário com o id informado");

        var user = _mapper.Map<User>(userDto);

        var userUpdated = await _userRepository.UpdateAsync(user);
        return _mapper.Map<UserDTO>(userUpdated);
    }

    public async Task Remove(long id)
    {
        await _userRepository.RemoveAsync(id);
    }

    public async Task<UserDTO> Get(long id)
    {
        var user = await _userRepository.GetAsync(id);

        return _mapper.Map<UserDTO>(user);
    }

    public async Task<List<UserDTO>> Get()
    {
        var allUsers = await _userRepository.GetAllAsync();

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SearchByName(string name)
    {
        var allUsers = await _userRepository.SearchByName(name);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<List<UserDTO>> SearchByEmail(string email)
    {
        var allUsers = await _userRepository.SearchByEmail(email);

        return _mapper.Map<List<UserDTO>>(allUsers);
    }

    public async Task<UserDTO> GetByEmail(string email)
    {
        var user = await _userRepository.GetByEmail(email);

        return _mapper.Map<UserDTO>(user);
    }
}