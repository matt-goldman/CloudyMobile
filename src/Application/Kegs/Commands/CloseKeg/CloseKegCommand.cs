using CloudyMobile.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Kegs.Commands.CloseKeg
{
    public class CloseKegCommand : IRequest
    {
        public int KegId { get; set; }
    }

    public class CloseKegCommandHanlder : IRequestHandler<CloseKegCommand>
    {
        public CloseKegCommandHanlder(IApplicationDbContext context)
        {
            Context = context;
        }

        public IApplicationDbContext Context { get; }

        public async Task<Unit> Handle(CloseKegCommand request, CancellationToken cancellationToken)
        {
            var keg = await Context.Kegs
                .Where(k => k.Id == request.KegId)
                .SingleOrDefaultAsync(cancellationToken);

            keg.Finished = true;
            keg.DateFinished = DateTime.Now;

            await Context.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
