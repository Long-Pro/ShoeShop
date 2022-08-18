using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository Brand
        {
            get;
        }
        IShoeRepository Shoe
        {
            get;
        }
        int Save();
    }
}
