using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Kegs.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Kegs.Queries.GetLocationKegs
{
    public class GetLocationKegsQuery : IRequest<KegListVm>
    {
        public int LocationId { get; set; }
    }

    public class GetLocationKegsQueryHandler : IRequestHandler<GetLocationKegsQuery, KegListVm>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetLocationKegsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<KegListVm> Handle(GetLocationKegsQuery request, CancellationToken cancellationToken)
        {
            var kegs = await context.Kegs
                .Where(k => k.LocationId == request.LocationId)
                .AsNoTracking()
                .ProjectTo<KegDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new KegListVm
            {
                Kegs = kegs
            };
        }
    }
}
