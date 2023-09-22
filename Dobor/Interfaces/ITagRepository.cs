using Dobor.Models;

namespace Dobor.Interfaces
{
    public interface ITagRepository
    {
        Task<IEnumerable<TagModel>> GetAllTags();
        Task<TagModel> GetTagById(int id);
        bool Add(TagModel tag);
        bool Update(TagModel tag);
        bool Delete(TagModel tag);
        bool Save();
    }
}