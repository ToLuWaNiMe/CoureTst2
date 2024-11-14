namespace CoureTst2.Models
{
    public class CountryDetail
    {
        public int Id { get; set; }
        public int CountryId { get; set; }
        public string Operator { get; set; } // e.g., "MTN Nigeria"
        public string OperatorCode { get; set; } // e.g., "MTN NG"
    }
}
