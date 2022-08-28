using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;

namespace Business.Interfaces
{
    public interface IShoeService
    {
        ShoeDTO GetShoeById(int id);
        ShoeDTO GetShoeByIdWithFile(int id);

        IEnumerable<ShoeDTO> GetAllShoe();
        IEnumerable<ShoeDTO> GetAllShoeWithFile();


    }
}
