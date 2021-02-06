using AuthServer.Core.DTOs;
using AuthServer.Core.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuthServer.Service
{
    public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            CreateMap<ProductDTO, Product>().ReverseMap();
            CreateMap<UserAppDTO, UserApp>().ReverseMap();
        }
    }
}
