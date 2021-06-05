using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Recipes.Queries.GetBeerStyles
{
    public class GetBeerStylesQuery : IRequest<BeerStylesVm>
    {
    }

    public class GetBeerStylesQueryHandler : IRequestHandler<GetBeerStylesQuery, BeerStylesVm>
    {
        private IApplicationDbContext _context;
        private readonly IMapper mapper;

        public GetBeerStylesQueryHandler(IApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            this.mapper = mapper;
        }

        public async Task<BeerStylesVm> Handle(GetBeerStylesQuery request, CancellationToken cancellationToken)
        {
            var styles = await _context.Styles
                .AsNoTracking()
                .ProjectTo<BeerStyleDto>(mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BeerStylesVm
            {
                Styles = styles
            };
        }
    }
}
