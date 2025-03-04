namespace PropertyAPI.Models
{
    public record SpaceDto
    {
        public string SpaceId { get; set; } = string.Empty;
        public string SpaceName { get; set; } = string.Empty;

        public IEnumerable<RentRollDto> RentRoll { get; set; } 
    }
}
