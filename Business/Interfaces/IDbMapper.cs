using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Business.Interfaces
{
    public interface IDbMapper
    {
        IMapper mapper
        {
            get;
        }
    }
}
