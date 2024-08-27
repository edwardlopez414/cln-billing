namespace clnbilling.Models
{
    public class Exchange_rate
    {
        public int id { get; set; }
        public string? currency { get; set; }
        public decimal sale_rate { get; set; }
        public DateTime registered { get; set; }
    }
}
