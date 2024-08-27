namespace clnbilling.Models
{
    public class Client
    {
        public int id { get; set; }
        public string? code { get; set; }
        public string? first_name { get; set; }
        public string? middle_name { get; set; }
        public string? last_name1 { get; set; }
        public string? last_name2 { get; set; }
        public int age { get; set; }
        public string? country_id { get; set; }
        public string? state { get; set; }
        public string? address_line1 { get; set; }
        public string? address_line2 { get; set; }
        public string? email { get; set; }
        public string? phone { get; set; }
        public string? phone_extension { get; set; }
        public string? postal_code { get; set; }
        public bool is_active { get; set; }
        public DateTime created_date { get; set; }
        public DateTime last_update_date { get; set; }
    }
}
