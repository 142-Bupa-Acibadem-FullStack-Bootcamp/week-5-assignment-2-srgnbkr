using AutoMapper.Internal.Mappers;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using NorthwindProject.BusinessLogicLayer.Base;
using NorthwindProject.DataAccessLayer.Abstract;
using NorthwindProject.Entities.Base;
using NorthwindProject.Entities.DTOs.Users;
using NorthwindProject.Entities.IBase;
using NorthwindProject.Entities.Models;
using NorthwindProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using NorthwindProject.BusinessLogicLayer.Helpers.AutoMapperHelper;
using NorthwindProject.BusinessLogicLayer.Helpers.PasswordHelper;

namespace NorthwindProject.BusinessLogicLayer.Concrete
{
    public class UserManager : BusinessBase<User,DtoUser>,IUserService
    {
        public readonly IUserRepository userRepository;
        IConfiguration configuration;

        public UserManager(IServiceProvider service, IConfiguration configuration) : base(service)
        {
            userRepository = service.GetService<IUserRepository>();
            this.configuration = configuration;
        }

        public IResponse<DtoUserToken> Login(DtoLogin login)
        {
            var user = userRepository.Login(ObjectMapper.Mapper.Map<User>(login));

            if (user != null)
            {
                var dtoUser = ObjectMapper.Mapper.Map<DtoLoginUser>(user);
                var token = new TokenManager(configuration).CreateAccessToken(dtoUser);

                var userToken = new DtoUserToken()
                {
                    DtoLoginUser = dtoUser,
                    AccessToken = token
                };

                return new Response<DtoUserToken>
                {
                    Message = "Token is success!",
                    StatusCode = StatusCodes.Status200OK,
                    Data = userToken
                };
            }
            else
            {
                return new Response<DtoUserToken>
                {
                    Message = "UserCode or Password is wrong.",
                    StatusCode = StatusCodes.Status406NotAcceptable,
                    Data = null
                };
            }

        }

        public IResponse<DtoUser> Register(DtoUser register,  bool saveChanges = true)
        {
            try
            {
                var resolvedResult = "";
                var encodingPassword = PasswordHelper.MD5Hash(register.Password);

                var registerDto = new DtoUser
                {
                    UserCode = register.UserCode,
                    UserLastName = register.UserLastName,
                    UserName = register.UserName,
                    Password = encodingPassword
                };
               
                var TResult = userRepository.Register(ObjectMapper.Mapper.Map<User>(registerDto));
                
                resolvedResult = String.Join(',', TResult.GetType().GetProperties().Select(x => $" - {x.Name} : {x.GetValue(TResult) ?? ""} - "));

                if (saveChanges)
                    Save();

                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status201Created,
                    Message = "Succuess",
                    Data = ObjectMapper.Mapper.Map<User, DtoUser>(TResult)
                };
            }
            catch (Exception ex)
            {
                return new Response<DtoUser>
                {
                    StatusCode = StatusCodes.Status500InternalServerError,
                    Message = $"Error:{ex.Message}",
                    Data = null
                };
            }
        }
    }
}
