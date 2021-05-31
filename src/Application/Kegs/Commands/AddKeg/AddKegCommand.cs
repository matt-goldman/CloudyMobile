using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Kegs.Commands.AddKeg
{
    public class AddKegCommand : IRequest<int>
    {
        public int BatchId { get; set; }
        public int LocationId { get; set; }
        public DateTime DateKegged { get; set; }
        public decimal VolumeKegged { get; set; }
    }

    public class AddKegCommandHanlder : IRequestHandler<AddKegCommand, int>
    {
        public AddKegCommandHanlder(IApplicationDbContext context)
        {
            Context = context;
        }

        public IApplicationDbContext Context { get; }

        public async Task<int> Handle(AddKegCommand request, CancellationToken cancellationToken)
        {
            var entity = new Keg
            {
                BatchId = request.BatchId,
                LocationId = request.LocationId,
                DateKegged = request.DateKegged,
                VolumeKegged = request.VolumeKegged
            };

            Context.Kegs.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
