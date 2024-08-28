namespace clnbilling.Models
{
    public class Product_view
    {
        public string? sku { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? country_id { get; set; }
        public string? currency { get; set; }
        public decimal amount { get; set; }
        public string? currency2 { get; set; }
        public decimal amount_2 { get; set; }
        public bool is_active { get; set; }
        public int units { get; set; }
    }
}
