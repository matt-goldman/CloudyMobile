using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Kegs.Commands.AddKegPour
{
    public class AddKegPourCommand : IRequest<int>
    {
        public int KegId { get; set; }
        public DateTime PouredAt { get; set; }
        public decimal VolumePoured { get; set; }
    }

    public class AddKegPourCommandHandler : IRequestHandler<AddKegPourCommand, int>
    {
        public AddKegPourCommandHandler(IApplicationDbContext context)
        {
            Context = context;
        }

        public IApplicationDbContext Context { get; }

        public async Task<int> Handle(AddKegPourCommand request, CancellationToken cancellationToken)
        {
            var entity = new KegPours
            {
                PouredAt = request.PouredAt,
                KegId = request.KegId,
                VolumePoured = request.VolumePoured
            };

            Context.KegPours.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
