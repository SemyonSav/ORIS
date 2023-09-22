using System.ComponentModel.DataAnnotations;

namespace Dobor.Models
{
    public class TagModel
    {
        [Key]
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Color { get; set; }
    }
}
