namespace PropertyAPI.Domain
{
    public record RentRoll
    {
        public string Month { get; set; } = string.Empty;

        public double Rent { get;set; }

    }
}
