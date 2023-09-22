using Dobor.Data;
using Dobor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dobor.Models;

namespace Dobor.Repository
{
    public class TagRepository : ITagRepository
    {
        private readonly ApplicationDbContext _context;

        public TagRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(TagModel tag)
        {
            throw new NotImplementedException();
        }

        public bool Delete(TagModel tag)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TagModel>> GetAllTags()
        {
            return await _context.TagModels.ToListAsync();
        }

        public async Task<TagModel> GetTagById(int id)
        {
            return await _context.TagModels.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(TagModel tag)
        {
            _context.Update(tag);
            return Save();
        }
    }
}