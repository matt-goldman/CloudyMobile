using CloudyMobile.Application.Batch.Common;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Batch.Commands.AddBatchSample
{
    public class AddBatchSampleCommand : IRequest<int>
    {
        public SampleDto Sample { get; set; }
    }

    public class AddBatchSampleCommandHandler : IRequestHandler<AddBatchSampleCommand, int>
    {
        private readonly IApplicationDbContext _context;

        public AddBatchSampleCommandHandler(IApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<int> Handle(AddBatchSampleCommand request, CancellationToken cancellationToken)
        {
            var entity = new BatchSample
            {
                BatchId = request.Sample.BatchId,
                Gravity = request.Sample.Gravity.Value,
                SampleDate = request.Sample.SampleDate,
                Temperature = request.Sample.Temperature.Value
            };

            await _context.BatchSamples.AddAsync(entity, cancellationToken);
            await _context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
