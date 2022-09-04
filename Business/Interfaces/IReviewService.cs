using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess.DTOs;

namespace Business.Interfaces
{
    public interface IReviewService
    {
        IEnumerable<ReviewDTO> GetReviewsByShoeId(int id, int page, out int totalPage);
    }
}
