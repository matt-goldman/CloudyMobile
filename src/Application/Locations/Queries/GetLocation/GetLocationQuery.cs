using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Locations.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Locations.Queries.GetLocation
{
    public class GetLocationQuery : IRequest<LocationDto>
    {
        public int Id { get; set; }
    }

    public class GetLocationQueryHandler : IRequestHandler<GetLocationQuery, LocationDto>
    {
        public GetLocationQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            Context = context;
            Mapper = mapper;
        }

        public IApplicationDbContext Context { get; }
        public IMapper Mapper { get; }

        public async Task<LocationDto> Handle(GetLocationQuery request, CancellationToken cancellationToken)
        {
            return await Context.Locations
                .Where(l => l.Id == request.Id)
                .ProjectTo<LocationDto>(Mapper.ConfigurationProvider)
                .AsNoTracking()
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
