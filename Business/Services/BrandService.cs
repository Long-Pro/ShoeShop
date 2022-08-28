using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class BrandService: IBrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbMapper _dbMapper;


        public BrandService(IUnitOfWork unitOfWork,IDbMapper dbMapper)
        {
            _unitOfWork = unitOfWork;
            _dbMapper = dbMapper;
        }

        public BrandDTO GetBrandById(int id)
        {
            var brand = _unitOfWork.Brand.GetBrandById(id);
            return _dbMapper.mapper.Map<BrandDTO>(brand);
        }

        public BrandDTO GetBrandByIdWithShoe(int id)
        {
            var brand= _unitOfWork.Brand.GetBrandByIdWithShoe(id);
            return  _dbMapper.mapper.Map<BrandDTO>(brand);

        }

        public IEnumerable<BrandDTO> GetAllBrand()
        {
            var brands = _unitOfWork.Brand.GetAllBrand();
            return _dbMapper.mapper.Map<IEnumerable<BrandDTO>>(brands);
        }
        public IEnumerable<BrandDTO> GetAllBrandWithShoe()
        {
            var brands = _unitOfWork.Brand.GetAllBrandWithShoe();
            return _dbMapper.mapper.Map<IEnumerable<BrandDTO>>(brands);
        }
    }
}
