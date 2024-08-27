namespace clnbilling.Models
{
    public class Product
    {
        public int id { get; set; }
        public string? sku { get; set; }
        public string? name { get; set; }
        public string? description { get; set; }
        public string? country_id { get; set; }
        public string currency { get; set; }
        public decimal amount { get; set; }
        public bool is_active { get; set; }
    }
}
