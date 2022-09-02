using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Business.Interfaces;
using DataAccess.DTOs;
using DataAccess.InputModel;
using DataAccess.Interfaces;

namespace Business.Services
{
    public class ShoeService: IShoeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbMapper _dbMapper;


        public ShoeService(IUnitOfWork unitOfWork,IDbMapper dbMapper)
        {
            _unitOfWork = unitOfWork;
            _dbMapper = dbMapper;
        }

        public ShoeDTO GetShoeById(int id)
        {
            var Shoe = _unitOfWork.Shoe.GetShoeById(id);
            return _dbMapper.mapper.Map<ShoeDTO>(Shoe);
        }

        public ShoeDTO GetShoeByIdWithFile(int id)
        {
            var Shoe = _unitOfWork.Shoe.GetShoeByIdWithFile(id);
            return _dbMapper.mapper.Map<ShoeDTO>(Shoe);
        }



        public IEnumerable<ShoeDTO> GetAllShoe()
        {
            var Shoes = _unitOfWork.Shoe.GetAllShoe();
            return _dbMapper.mapper.Map<IEnumerable<ShoeDTO>>(Shoes);
        }
        public IEnumerable<ShoeDTO> GetAllShoeWithFile()
        {
            var Shoes = _unitOfWork.Shoe.GetAllShoeWithFile();
            return _dbMapper.mapper.Map<IEnumerable<ShoeDTO>>(Shoes);
        }

        public IEnumerable<ShoeDTO> GetAllShoeWithFileAndBrand()
        {
            var Shoes = _unitOfWork.Shoe.GetAllShoeWithFileAndBrand();
            return _dbMapper.mapper.Map<IEnumerable<ShoeDTO>>(Shoes);
        }

        public IEnumerable<ShoeDTO> FilterShoe(ShoeFilter filter, out int totalPage)
        {
            int? x = null;
            var Shoes = _unitOfWork.Shoe.FilterShoe(filter, out totalPage);
            return _dbMapper.mapper.Map<IEnumerable<ShoeDTO>>(Shoes);
        }
    }
}
