using AutoMapper;
using NorthwindProject.Entities.DTOs;
using NorthwindProject.Entities.DTOs.Users;
using NorthwindProject.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindProject.Entities.Mapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, DtoProduct>().ReverseMap();
            CreateMap<Customer, DtoCustomer>().ReverseMap();
            CreateMap<User, DtoUser>().ReverseMap();
            CreateMap<User, DtoLoginUser>().ReverseMap();
            CreateMap<User, DtoLogin>().ReverseMap();
        }
    }
}
