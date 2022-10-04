using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;
using DataAccess.InputModel;

namespace Business.Interfaces
{
    public interface IShoeService
    {
        ShoeDTO GetShoeById(int id);
        ShoeDTO GetShoeByIdWithFile(int id);

        IEnumerable<ShoeDTO> GetAllShoe();
        IEnumerable<ShoeDTO> GetAllShoeWithFile();
        IEnumerable<ShoeDTO> GetAllShoeWithFileAndBrand();
        IEnumerable<ShoeDTO> FilterShoe(ShoeFilterModel filter, out int totalPage);

        IEnumerable<ReviewDTO> GetReviewsByShoeId(int id, int page, out int totalPage);
    }
}