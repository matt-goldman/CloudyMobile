using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Batch.Commands.AddBatchRating
{
    public class AddBatchRatingCommand : IRequest<int>
    {
        public DateTime RatedAt { get; set; }
        public int BatchId { get; set; }
        public int Rating { get; set; }
    }

    public class AddBatchRatingCommandHandler : IRequestHandler<AddBatchRatingCommand, int>
    {
        public AddBatchRatingCommandHandler(IApplicationDbContext context)
        {
            Context = context;
        }

        public IApplicationDbContext Context { get; }

        public async Task<int> Handle(AddBatchRatingCommand request, CancellationToken cancellationToken)
        {
            var entity = new BatchRating
            {
                RatedAt = request.RatedAt,
                BatchId = request.BatchId,
                Rating = request.Rating
            };

            Context.BatchRatings.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
