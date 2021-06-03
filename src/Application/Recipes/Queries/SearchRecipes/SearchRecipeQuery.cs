using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Helpers;
using CloudyMobile.Application.Recipes.Common;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Recipes.Queries.SearchRecipes
{
    public class SearchRecipeQuery : IRequest<RecipeSearchResultsVm>
    {
        public string Name { get; set; }
        public string Style { get; set; }
    }

    public class SearchRecipeQueryHandler : IRequestHandler<SearchRecipeQuery, RecipeSearchResultsVm>
    {
        public IApplicationDbContext _context;
        public IMapper _mapper;

        public SearchRecipeQueryHandler(
            IApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<RecipeSearchResultsVm> Handle(SearchRecipeQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Recipes
                .ConditionalWhere(() => !string.IsNullOrEmpty(request.Name),
                    r => r.Name.ToLower().Contains(request.Name.ToLower()))
                .ConditionalWhere(() => !string.IsNullOrEmpty(request.Style),
                    r => r.Style.Name.ToLower().Contains(request.Style.ToLower()))
                .ProjectTo<RecipeDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new RecipeSearchResultsVm
            {
                Recipes = entities
            };
        }
    }
}
