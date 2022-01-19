using Microsoft.EntityFrameworkCore;
using NorthwindProject.DataAccessLayer.Abstract;
using NorthwindProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.DataAccessLayer.Concrete.EntityFramework.Repository
{
    public class UserRepository : EntityRepositoryBase<User>, IUserRepository
    {
        public UserRepository(DbContext context) : base(context)
        {
        }

        public User Login(User login)
        {
            var user = dbset.FirstOrDefault(x => x.UserCode == login.UserCode && x.Password == login.Password);

            

            return user;
        }

        public User Register(User register)
        {
            context.Entry(register).State = EntityState.Added;
            dbset.Add(register);
            return register;


        }
    }
}
