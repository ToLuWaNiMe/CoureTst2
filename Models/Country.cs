namespace CoureTst2.Models
{
    public class Country
    {
        public int Id { get; set; }
        public string CountryCode { get; set; } // e.g., "234"
        public string Name { get; set; } // e.g., "Nigeria"
        public string CountryIso { get; set; } // e.g., "NG"
        public List<CountryDetail> CountryDetails { get; set; } = new();
    }
}
