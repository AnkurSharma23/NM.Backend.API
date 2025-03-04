namespace PropertyAPI.Models
{
    /// <summary>
    /// Ideally datastore wouldn't directly interact with DTOs but with Models. 
    /// </summary>
    public record PropertyDto
    {
        public string PropertyId { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;
        public IEnumerable<string>? Features { get; set; } = [];

        public IEnumerable<string>? Highlights { get; set; } = [];

        public IEnumerable<TransportationDto>? Transportation { get; set; }

        public IEnumerable<SpaceDto>? Spaces { get; set; }

    }
}
