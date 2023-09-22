using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dobor.Models
{
    public class ReviewModel
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("ProductModel")]
        public int ProductId { get; set; }
        public string? Content { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? Date { get; set; }
    }
}