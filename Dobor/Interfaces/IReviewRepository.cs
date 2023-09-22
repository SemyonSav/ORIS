using Dobor.Models;

namespace Dobor.Interfaces
{
    public interface IReviewRepository
    {
        Task<IEnumerable<ReviewModel>> GetAllReviews();
        Task<ReviewModel> GetReviewById(int id);
        bool Add(ReviewModel review);
        bool Update(ReviewModel review);
        bool Delete(ReviewModel review);
        bool Save();
    }
}