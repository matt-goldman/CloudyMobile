using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Locations.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Locations.Queries.GetLocations
{
    public class GetLocationsQuery : IRequest<LocationsVm>
    {
        
    }

    public class GetLocationsQueryHanlder : IRequestHandler<GetLocationsQuery, LocationsVm>
    {
        public GetLocationsQueryHanlder(IApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public async Task<LocationsVm> Handle(GetLocationsQuery request, CancellationToken cancellationToken)
        {
            var locations = await Context.Locations
                .AsNoTracking()
                .ProjectTo<LocationDto>(Mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new LocationsVm
            {
                Locations = locations
            };
        }
    }
}
