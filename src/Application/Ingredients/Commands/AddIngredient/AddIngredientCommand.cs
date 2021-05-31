using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Ingredients.Queries.Common;
using CloudyMobile.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Ingredients.Commands.AddIngredient
{
    public class AddIngredientCommand : IRequest<int>
    {
        public IngredientDto Ingredient { get; set; }
    }

    public class AddIngredientCommandHandler : IRequestHandler<AddIngredientCommand, int>
    {
        private IApplicationDbContext _context;

        public AddIngredientCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddIngredientCommand request, CancellationToken cancellationToken)
        {
            var ingredient = await _context.Ingredients
                .Where(i => i.Name.ToLower() == request.Ingredient.Name.ToLower())
                .SingleOrDefaultAsync(cancellationToken);

            var category = await _context.IngredientCategories
                .Where(c => c.Id == request.Ingredient.CategoryId)
                .SingleOrDefaultAsync(cancellationToken);

            if (category == null)
            {
                category = new IngredientCategory
                {
                    Name = request.Ingredient.CategoryName
                };

                await _context.IngredientCategories.AddAsync(category, cancellationToken);
            }

            if(ingredient == null)
            {
                var entity = new Ingredient
                {
                    Name = request.Ingredient.Name,
                    Category = category
                };

                await _context.Ingredients.AddAsync(entity, cancellationToken);

                await _context.SaveChangesAsync(cancellationToken);

                return entity.Id;
            }
            else
            {
                return ingredient.Id;
            }
        }
    }
}
