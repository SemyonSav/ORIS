using Dobor.Data;
using Dobor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dobor.Models;

namespace Dobor.Repository
{
    public class NewsRepository : INewsRepository
    {
        private readonly ApplicationDbContext _context;

        public NewsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(NewsModel news)
        {
            throw new NotImplementedException();
        }

        public bool Delete(NewsModel news)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<NewsModel>> GetAllNews()
        {
            return await _context.NewsModels.ToListAsync();
        }

        public async Task<NewsModel> GetNewsById(int id)
        {
            return await _context.NewsModels.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(NewsModel news)
        {
            _context.Update(news);
            return Save();
        }
    }
}