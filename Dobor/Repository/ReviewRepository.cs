using Dobor.Data;
using Dobor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dobor.Models;

namespace Dobor.Repository
{
    public class ReviewRepository : IReviewRepository
    {
        private readonly ApplicationDbContext _context;

        public ReviewRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ReviewModel review)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ReviewModel review)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ReviewModel>> GetAllReviews()
        {
            return await _context.ReviewModels.ToListAsync();
        }

        public async Task<ReviewModel> GetReviewById(int id)
        {
            return await _context.ReviewModels.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ReviewModel review)
        {
            _context.Update(review);
            return Save();
        }
    }
}