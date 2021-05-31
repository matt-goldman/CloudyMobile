using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Application.Locations.Queries.Common
{
    public class LocationDto : IMapFrom<Location>
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
