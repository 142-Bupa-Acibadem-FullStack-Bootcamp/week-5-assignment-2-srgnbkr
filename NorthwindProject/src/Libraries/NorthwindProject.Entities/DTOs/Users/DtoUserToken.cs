using NorthwindProject.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NorthwindProject.Entities.DTOs.Users
{
    public class DtoUserToken
    {
        public DtoLoginUser DtoLoginUser { get; set; }
        public object AccessToken { get; set; }
    }
}
