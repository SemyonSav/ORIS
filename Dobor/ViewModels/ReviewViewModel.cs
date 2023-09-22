using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace Dobor.ViewModels
{
    public class ReviewViewModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public string? Content { get; set; }
        public string? AuthorName { get; set; }
        public DateTime? Date { get; set; }

        public string DateFormatted => Date.Value.ToString("MMMM dd, yyyy", new CultureInfo("en-US"));
    }
}
