namespace clnbilling.DataDTO
{
    public class SearchClientDTO
    {
        public string? country_id { get; set; }
        public string? code { get; set; }
        public string? firt_name { get; set; }
        public string? middle_name { get; set; }
        public bool search_all { get; set; }
    }
}
