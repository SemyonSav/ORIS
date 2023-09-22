using Dobor.Models;

namespace Dobor.Interfaces
{
    public interface INewsRepository
    {
        Task<IEnumerable<NewsModel>> GetAllNews();
        Task<NewsModel> GetNewsById(int id);
        bool Add(NewsModel news);
        bool Update(NewsModel news);
        bool Delete(NewsModel news);
        bool Save();
    }
}