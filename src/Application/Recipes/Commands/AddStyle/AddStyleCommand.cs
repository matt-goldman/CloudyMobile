using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Recipes.Queries.GetBeerStyles;
using CloudyMobile.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Recipes.Commands.AddStyle
{
    public class AddStyleCommand : IRequest<int>
    {
        public BeerStyleDto Style { get; set; }
    }

    public class AddStyleCommandHandler : IRequestHandler<AddStyleCommand, int>
    {
        private readonly IApplicationDbContext context;

        public AddStyleCommandHandler(IApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task<int> Handle(AddStyleCommand request, CancellationToken cancellationToken)
        {
            var entity = new Style
            {
                ImageUrl = request.Style.ImageUrl,
                Name = request.Style.Name,
                Notes = request.Style.Notes
            };

            context.Styles.Add(entity);

            await context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
