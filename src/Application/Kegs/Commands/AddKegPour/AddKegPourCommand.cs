using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
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

            var keg = await Context.Kegs
                .Where(k => k.Id == request.KegId)
                .SingleOrDefaultAsync(cancellationToken);

            keg.Pours.Add(entity);

            if(keg.Pours.Sum(p => p.VolumePoured) >= keg.VolumeKegged)
            {
                keg.Finished = true;
                keg.DateFinished = DateTime.Now;
            }

            await Context.SaveChangesAsync(cancellationToken);

            // TODO: add raise event

            return entity.Id;
        }
    }
}
