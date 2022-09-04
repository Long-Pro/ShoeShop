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
    public class ReviewService : IReviewService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IDbMapper _dbMapper;


        public ReviewService(IUnitOfWork unitOfWork, IDbMapper dbMapper)
        {
            _unitOfWork = unitOfWork;
            _dbMapper = dbMapper;
        }

        public IEnumerable<ReviewDTO> GetReviewsByShoeId(int id, int page, out int totalPage)
        {
            var x = _unitOfWork.Review.GetReviewsByShoeId(id, page, out totalPage);
            return _dbMapper.mapper.Map<IEnumerable<ReviewDTO>>(x);
        }
    }
}
