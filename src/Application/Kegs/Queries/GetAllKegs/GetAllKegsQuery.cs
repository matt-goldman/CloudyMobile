using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Kegs.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Kegs.Queries.GetAllKegs
{
    public class GetAllKegsQuery : IRequest<KegListVm>
    {
        
    }

    public class GetAllKegsQueryHandler : IRequestHandler<GetAllKegsQuery, KegListVm>
    {
        private readonly IApplicationDbContext context;
        private readonly IMapper mapper;

        public GetAllKegsQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            this.context = context;
            this.mapper = mapper;
        }

        public async Task<KegListVm> Handle(GetAllKegsQuery request, CancellationToken cancellationToken)
        {
            var kegs = await context.Kegs
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
