namespace PropertyAPI.Models
{
    public record RentRollDto
    {
        public string Month { get; set; } = string.Empty;

        public double Rent { get;set; }

    }
}
