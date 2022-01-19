using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Entities.DTOs.Users
{
    public class DtoUserRegisterToken
    {
        public DtoUser DtoUser { get; set; }
        public object AccessToken { get; set; }
    }
}
