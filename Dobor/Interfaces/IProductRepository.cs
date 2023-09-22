using Dobor.Models;

namespace Dobor.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<ProductModel>> GetAllProducts();
        Task<ProductModel> GetProductById(int id);
        bool Add(ProductModel product);
        bool Update(ProductModel product);
        bool Delete(ProductModel product);
        bool Save();
    }
}