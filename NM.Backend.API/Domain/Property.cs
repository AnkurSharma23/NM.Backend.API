namespace PropertyAPI.Domain
{
    public record Property
    {
        public string PropertyId { get; set; } = string.Empty;
        public string PropertyName { get; set; } = string.Empty;

        public IEnumerable<string>? Features { get; set; }
        public IEnumerable<string>? Highlights { get; set; }
        public IEnumerable<Transportation>? Transportation { get; set; }
        public IEnumerable<Space>? Spaces { get; set; }
    }
}
