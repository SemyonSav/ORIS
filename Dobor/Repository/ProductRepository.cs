using Dobor.Data;
using Dobor.Interfaces;
using Microsoft.EntityFrameworkCore;
using Dobor.Models;

namespace Dobor.Repository
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _context;

        public ProductRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public bool Add(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ProductModel product)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ProductModel>> GetAllProducts()
        {
            return await _context.ProductModels.ToListAsync();
        }

        public async Task<ProductModel> GetProductById(int id)
        {
            return await _context.ProductModels.FindAsync(id);
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Update(ProductModel product)
        {
            _context.Update(product);
            return Save();
        }
    }
}