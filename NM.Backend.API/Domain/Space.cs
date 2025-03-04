namespace PropertyAPI.Domain
{
    public record Space
    {
        public string SpaceId { get; set; } = string.Empty;
        public string SpaceName { get; set; } = string.Empty;

        public IEnumerable<RentRoll>? RentRoll { get; set; }
    }
}
