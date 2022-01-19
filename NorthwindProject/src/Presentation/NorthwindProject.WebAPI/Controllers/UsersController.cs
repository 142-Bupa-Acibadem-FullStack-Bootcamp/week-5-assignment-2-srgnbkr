using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NorthwindProject.Entities.Base;
using NorthwindProject.Entities.DTOs.Users;
using NorthwindProject.Entities.IBase;
using NorthwindProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NorthwindProject.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            try
            {
                return userService.Login(login);
            }
            catch (Exception ex)
            {
                return new Response<DtoUserToken>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }

        [HttpPost("regiser")]
        [AllowAnonymous]
        public IResponse<DtoUser> Register(DtoUser register, bool saveChanges = true)
        {
            try
            {
                return userService.Register(register,saveChanges);
            }
            catch (Exception ex)
            {
                return new Response<DtoUser>
                {
                    Message = $"Error:{ex.Message}",
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Data = null
                };
            }
        }



    }
}
