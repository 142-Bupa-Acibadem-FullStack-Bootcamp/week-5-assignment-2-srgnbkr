using NorthwindProject.Entities.DTOs;
using NorthwindProject.Entities.IBase;
using NorthwindProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Interfaces
{
    public interface ICustomerService : IGenericService<Customer, DtoCustomer>
    {
        
        
    }
}
