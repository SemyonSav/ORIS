using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dobor.Models
{
    public class NewsModel
    {
        [Key]
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Views { get; set; }
        public string? PhotoPath { get; set; }
        [ForeignKey("TagModel")]
        public int? TagId { get; set; }
    }
}
