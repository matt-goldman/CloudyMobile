using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudyMobile.Application.Batch.Common;
using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Application.Helpers;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Batch.Queries.Search
{
    public class SearchBatchQuery : IRequest<BatchListVm>
    {
        public string RecipeName { get; set; }
        public DateTime? BrewedFrom { get; set; }
        public DateTime? BrewedTo { get; set; }
        public DateTime? BottledOrKeggedOnFrom { get; set; }
        public DateTime? BottledOrKeggedOnTo { get; set; }
    }

    public class SearchBatchQueryHandler : IRequestHandler<SearchBatchQuery, BatchListVm>
    {
        private readonly IMapper _mapper;
        private readonly IApplicationDbContext _context;

        public SearchBatchQueryHandler(
            IMapper mapper,
            IApplicationDbContext context)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<BatchListVm> Handle(SearchBatchQuery request, CancellationToken cancellationToken)
        {
            var entities = await _context.Batches
                .ConditionalWhere(() => !string.IsNullOrEmpty(request.RecipeName),
                    b => EF.Functions.Like(b.Recipe.Name, $"%{request.RecipeName}%"))
                .ConditionalWhere(() => request.BrewedFrom.HasValue && request.BrewedTo.HasValue,
                    b => b.BrewDay >= request.BrewedFrom && b.BrewDay <= request.BrewedTo)
                .ConditionalWhere(() => request.BrewedFrom.HasValue && !request.BrewedTo.HasValue,
                    b => b.BrewDay == request.BrewedFrom)
                .ConditionalWhere(() => request.BottledOrKeggedOnFrom.HasValue && request.BottledOrKeggedOnTo.HasValue,
                    b => b.BottleOrKegDate >= request.BottledOrKeggedOnFrom && b.BottleOrKegDate <= request.BottledOrKeggedOnTo)
                .ConditionalWhere(() => request.BottledOrKeggedOnFrom.HasValue && !request.BottledOrKeggedOnTo.HasValue,
                    b => b.BottleOrKegDate == request.BottledOrKeggedOnFrom)
                .ProjectTo<BatchDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BatchListVm
            {
                Batches = entities
            };
        }
    }
}
