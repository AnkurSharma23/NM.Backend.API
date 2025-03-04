using PropertyAPI.Domain;
using PropertyAPI.Models;

namespace NM.Backend.API.Converters
{
    public static class Mapper
    {
        public static PropertyDto Map(Property property)
        {
            if (property == null)
                throw new ArgumentNullException(nameof(property));

            return new PropertyDto()
            {
                PropertyId = property.PropertyId,
                PropertyName = property.PropertyName,
                Features = property.Features != null ? MapFeatures(property.Features) : Enumerable.Empty<string>(),
                Highlights = property.Highlights != null ? MapHighLights(property.Highlights) : Enumerable.Empty<string>(),
                Spaces = property.Spaces != null ? MapSpaces(property.Spaces) : Enumerable.Empty<SpaceDto>(),
                Transportation = property.Transportation != null ? MapTransportation(property.Transportation) : Enumerable.Empty<TransportationDto>()
            };
        }

        private static IEnumerable<TransportationDto> MapTransportation(IEnumerable<Transportation>? transportation)
        {
            return transportation.Select(item => new TransportationDto
            {
                Distance = item.Distance,
                Line = item.Line,
                Type = item.Type
            });
        }

        private static IEnumerable<SpaceDto> MapSpaces(IEnumerable<Space>? spaces)
        {
            return spaces.Select(item => new SpaceDto
            {
                RentRoll = item.RentRoll != null ? MapRentRolls(item.RentRoll) : Enumerable.Empty<RentRollDto>(),
                SpaceId = item.SpaceId,
                SpaceName = item.SpaceName,
            });
        }

        private static IEnumerable<RentRollDto> MapRentRolls(IEnumerable<RentRoll> rentRoll)
        {
            return rentRoll.Select(item => new RentRollDto
            {
                Month = item.Month,
                Rent = item.Rent
            });
        }

        private static IEnumerable<string> MapHighLights(IEnumerable<string>? highlights)
        {
            return highlights.Select(item => item);
        }

        private static IEnumerable<string> MapFeatures(IEnumerable<string>? features)
        {
            return features.Select(item => item);
        }
    }
}
