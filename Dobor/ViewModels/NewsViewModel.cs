using Dobor.Interfaces;
using System.Globalization;
using Dobor.Models;

namespace Dobor.ViewModels
{
    public class NewsViewModel
    {
        private TagViewModel _tag;
        public NewsViewModel(TagViewModel tag)
        {
            _tag = tag;
        }

        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? Author { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? Views { get; set; }
        public string? PhotoPath { get; set; }
        public int? TagId { get; set; }

        public string CreatedDateFormatted => CreatedDate.Value.ToString("MMMM dd, yyyy", new CultureInfo("en-US"));
        public string ViewCategory => Category.ToUpper();
        public TagViewModel Tag => _tag;
    }
}
