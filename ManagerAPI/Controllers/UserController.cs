using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using ManagerAPI.Utilities;
using ManagerAPI.ViewModels;
using ManagerCore.Exceptions;
using ManagerServices.DTO;
using ManagerServices.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ManagerAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserServices _userServices;
        private readonly IMapper _mapper;

        public UserController(IUserServices userServices, IMapper mapper)
        {
            _userServices = userServices;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateUserViewModel userViewModel)
        {
            try
            {
                var userDto = _mapper.Map<UserDTO>(userViewModel);
                var userCreated = _userServices.Create(userDto);
                return Ok(new ResultViewModel
                {
                    Message = "Usuário criado com sucesso",
                    Success = true,
                    Data = userCreated
                });

            }
            // catch (DomainException exception)
            // {
            //     return BadRequest();
            // }
            catch (Exception)
            {
                return StatusCode(500, Responses.ApplicationErrorMessage());
            }
        }
    }
}
