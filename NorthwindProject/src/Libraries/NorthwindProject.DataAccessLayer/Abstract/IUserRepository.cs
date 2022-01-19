using NorthwindProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.DataAccessLayer.Abstract
{
    public interface IUserRepository
    {
        User Login(User login);
        User Register(User register);
        
    }
}
