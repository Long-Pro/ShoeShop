using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Business.Interfaces;

namespace Business.Mappings
{
    public class DbMapper:IDbMapper
    {
        public IMapper mapper
        {
            get
            {
                var config = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new MappingProfile());
                });
                return config.CreateMapper();
            }
            set { }
        }
    }
}
