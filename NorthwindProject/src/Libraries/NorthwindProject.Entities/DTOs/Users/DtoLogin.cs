using NorthwindProject.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace NorthwindProject.Entities.DTOs.Users
{
    public class DtoLogin : DtoBase 
    {
        [Required]
        public string UserCode { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
