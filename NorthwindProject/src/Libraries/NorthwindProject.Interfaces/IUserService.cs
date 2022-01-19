using NorthwindProject.Entities.DTOs.Users;
using NorthwindProject.Entities.IBase;
using NorthwindProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Interfaces
{
    public interface IUserService : IGenericService<User,DtoUser>
    {
        IResponse<DtoUserToken> Login(DtoLogin login);
        IResponse<DtoUser> Register(DtoUser register,bool saveChanges = true);


        
        
    }
}
