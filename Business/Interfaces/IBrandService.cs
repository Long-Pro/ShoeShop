using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;

namespace Business.Interfaces
{
    public interface IBrandService
    {
        BrandDTO GetBrandById(int id);
        BrandDTO GetBrandByIdWithShoe(int id);

        IEnumerable<BrandDTO> GetAllBrand();
        IEnumerable<BrandDTO> GetAllBrandWithShoe();


    }
}
