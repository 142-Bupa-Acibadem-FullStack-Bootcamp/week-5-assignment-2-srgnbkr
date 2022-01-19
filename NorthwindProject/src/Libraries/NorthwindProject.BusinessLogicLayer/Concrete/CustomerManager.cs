using NorthwindProject.BusinessLogicLayer.Base;
using NorthwindProject.DataAccessLayer.Abstract;
using NorthwindProject.Entities.DTOs;
using NorthwindProject.Entities.IBase;
using NorthwindProject.Entities.Models;
using NorthwindProject.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.BusinessLogicLayer.Concrete
{
    public class CustomerManager : BusinessBase<Customer, DtoCustomer>, ICustomerService
    {
        public CustomerManager(IServiceProvider service) : base(service)
        {
        }
    }
}
