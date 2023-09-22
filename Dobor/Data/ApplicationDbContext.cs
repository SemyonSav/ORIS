using Dobor.Models;
using Microsoft.EntityFrameworkCore;

namespace Dobor.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<NewsModel> NewsModels { get; set; }
        public DbSet<TagModel> TagModels { get; set; }
        public DbSet<ProductModel> ProductModels { get; set; }
        public DbSet<ReviewModel> ReviewModels { get; set; }
    }
}
