using CloudyMobile.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Recipes.Queries.GetBeerStyles
{
    public class GetBeerStylesQuery : IRequest<BeerStylesDto>
    {
    }

    public class GetBeerStylesQueryHandler : IRequestHandler<GetBeerStylesQuery, BeerStylesDto>
    {
        private IApplicationDbContext _context;

        public GetBeerStylesQueryHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<BeerStylesDto> Handle(GetBeerStylesQuery request, CancellationToken cancellationToken)
        {
            var styles = await _context.Recipes
                .Select(r => r.Style)
                .AsNoTracking()
                .ToListAsync(cancellationToken);

            return new BeerStylesDto
            {
                Styles = styles
            };
        }
    }
}
