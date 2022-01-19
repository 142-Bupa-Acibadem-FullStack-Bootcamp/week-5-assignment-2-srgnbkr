using NorthwindProject.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Entities.DTOs.Users
{
    public class DtoLoginUser : DtoBase
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        public string UserCode { get; set; }
    }
}
