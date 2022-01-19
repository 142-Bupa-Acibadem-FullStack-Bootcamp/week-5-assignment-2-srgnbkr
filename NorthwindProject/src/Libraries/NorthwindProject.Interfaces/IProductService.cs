using NorthwindProject.Entities.DTOs;
using NorthwindProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Interfaces
{
    public interface IProductService : IGenericService<Product,DtoProduct>
    {
    }
}
