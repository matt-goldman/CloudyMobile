using AutoMapper;
using CloudyMobile.Application.Batch.Common;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Batch.Commands.AddBatch
{
    public class AddBatchCommand : IRequest<int>
    {
        public BatchDto Batch { get; set; }
    }

    public class AddBatchCommandHandler : IRequestHandler<AddBatchCommand, int>
    {
        private IApplicationDbContext _context;
        private IMapper _mapper;

        public AddBatchCommandHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<int> Handle(AddBatchCommand request, CancellationToken cancellationToken)
        {
            var entity = new CloudyMobile.Domain.Entities.Batch
            {
                BottleOrKegDate = request.Batch.BottleOrKegDate,
                BrewDay = request.Batch.BrewDay,
                FG = request.Batch.FG,
                Notes = request.Batch.Notes,
                OG = request.Batch.OG,
                PitchTemp = request.Batch.PitchTemp,
                RecipeId = request.Batch.RecipeId,
                ServingDate = request.Batch.ServingDate
            };

            await _context.Batches.AddAsync(entity, cancellationToken);

            request.Batch.HopAdditions.ForEach(async (a) =>
            {
                var hopEntity = new HopAddition
                {
                    DateAdded = a.DateAdded,
                    IngredientId = a.IngredientId,
                    Minutes = a.Minutes,
                    Temperature = a.Temperature
                };

                await _context.HopAdditions.AddAsync(hopEntity, cancellationToken);

                var additionEntity = new BatchHopAdditions
                {
                    HopAddition = hopEntity,
                    Batch = entity
                };

                await _context.BatchHopAdditions.AddAsync(additionEntity, cancellationToken);
            });

            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
