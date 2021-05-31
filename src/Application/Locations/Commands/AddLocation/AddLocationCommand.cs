using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Locations.Commands.AddLocation
{
    public class AddLocationCommand : IRequest<int>
    {
        public string Name { get; set; }
    }

    public class AddLocationCommandHandler : IRequestHandler<AddLocationCommand, int>
    {
        public AddLocationCommandHandler(IApplicationDbContext context)
        {
            Context = context;
        }

        public IApplicationDbContext Context { get; }

        public async Task<int> Handle(AddLocationCommand request, CancellationToken cancellationToken)
        {
            var entity = new Location
            {
                Name = request.Name
            };

            Context.Locations.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
