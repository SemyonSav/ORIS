namespace Dobor.ViewModels
{
    public class ProductViewModel
    {
        public int Id { get; set; }
        public string? Category { get; set; }
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? ShortDesc { get; set; }
        public int? OldPrice { get; set; }
        public int? Price { get; set; }
        public string? PhotoPath { get; set; }

        public string OldPriceView => OldPrice.ToString() + ".00";
        public string PriceView => Price.ToString() + ".00";
    }
}
