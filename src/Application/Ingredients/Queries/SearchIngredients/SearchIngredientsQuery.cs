using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Ingredients.Queries.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Ingredients.Queries.SearchIngredients
{
    public class SearchIngredientsQuery : IRequest<IngredientsVm>
    {
        public string SearchTerm { get; set; }
    }

    public class SearchIngredientsQueryHandler : IRequestHandler<SearchIngredientsQuery, IngredientsVm>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public SearchIngredientsQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<IngredientsVm> Handle(SearchIngredientsQuery request, CancellationToken cancellationToken)
        {
            var ingredients = await _context.Ingredients
                .Where(i => i.Name
                    .ToLower()
                    .Contains(request
                        .SearchTerm
                        .ToLower()))
                .ProjectTo<IngredientDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new IngredientsVm
            {
                Ingredients = ingredients
            };
        }
    }
}
