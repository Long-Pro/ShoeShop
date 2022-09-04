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
            CreateMap<BrandDTO, Brand>();
            CreateMap<Brand, BrandDTO>();

            CreateMap<ShoeDTO, Shoe>();
            CreateMap<Shoe, ShoeDTO>();

            CreateMap<ShoeFileDTO, ShoeFile>();
            CreateMap<ShoeFile, ShoeFileDTO>();

            CreateMap<ShoeColorDTO, ShoeColor>();
            CreateMap<ShoeColor, ShoeColorDTO>();

            CreateMap<ShoeStoreDTO, ShoeStore>();
            CreateMap<ShoeStore, ShoeStoreDTO>();

            CreateMap<ReviewDTO, Review>();
            CreateMap<Review, ReviewDTO>();

            CreateMap<ReviewFileDTO, ReviewFile>();
            CreateMap<ReviewFile, ReviewFileDTO>();

            CreateMap<CustomerDTO, Customer>();
            CreateMap<Customer, CustomerDTO>();

            CreateMap<AccountDTO, Account>();
            CreateMap<Account, AccountDTO>();
        }
    }
}
