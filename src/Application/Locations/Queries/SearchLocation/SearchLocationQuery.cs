using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Locations.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Locations.Queries.SearchLocation
{
    public class SearchLocationQuery : IRequest<LocationsVm>
    {
        public string SearchTerm { get; set; }
    }

    public class SearchLocationQueryHandler : IRequestHandler<SearchLocationQuery, LocationsVm>
    {
        public SearchLocationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public async Task<LocationsVm> Handle(SearchLocationQuery request, CancellationToken cancellationToken)
        {
            var locations = await Context.Locations
                .Where(l => l.Name.ToLower().Contains(request.SearchTerm.ToLower()))
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
