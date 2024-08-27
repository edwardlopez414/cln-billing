namespace clnbilling.Models
{
    public class Transaction
    {
        public int id { get; set; }
        public string? country_id { get; set; }
        public string? code { get; set; }
        public int client_id { get; set; }
        public int product_id { get; set; }
        public int exchange_rate { get; set; }
        public DateTime registered { get; set; }
    }
}
