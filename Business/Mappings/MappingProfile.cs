using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using DataAccess.DTOs;
using DataAccess.Entities;

namespace Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<BrandDTO, Brand>()
                .ForMember(dest => dest.Name, act => act.MapFrom(src => src.Name));
            CreateMap<Brand, BrandDTO>();
                

            CreateMap<ShoeDTO, Shoe>();
            CreateMap<Shoe, ShoeDTO>();

            CreateMap<ShoeFileDTO, ShoeFile>();
            CreateMap<ShoeFile, ShoeFileDTO>();
        }
    }
}
