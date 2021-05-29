using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Kegs.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Kegs.Queries.GetKeg
{
    public class GetKegQuery : IRequest<KegDto>
    {
        public int Id { get; set; }
    }

    public class GetKegQueryHandler : IRequestHandler<GetKegQuery, KegDto>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetKegQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<KegDto> Handle(GetKegQuery request, CancellationToken cancellationToken)
        {
            return await context.Kegs
                .Where(k => k.Id == request.Id)
                .AsNoTracking()
                .ProjectTo<KegDto>(mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);
        }
    }
}
