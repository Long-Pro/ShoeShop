using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.Entities;

namespace DataAccess.Interfaces
{
    public interface IShoeRepository : IRepository<Shoe>
    {
        IEnumerable<Shoe> GetAllShoeWithFile();
        IEnumerable<Shoe> GetAllShoe();


        Shoe GetShoeById(int id);
        Shoe GetShoeByIdWithFile(int id);

    }
}
