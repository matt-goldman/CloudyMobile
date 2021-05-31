using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Batch.Commands.AddBatchHopAddition
{
    public class AddBatchHopAdditionCommand : IRequest<int>
    {
        public int BatchId { get; set; }
        public DateTime DateAdded { get; set; }
        public int? IngredientId { get; set; }
        public int Temperature { get; set; }
        public string IngredientName { get; set; }
        public int? IngredientCategoryId { get; set; }
        public string IngredientCategoryName { get; set; }
    }

    public class AddBatchHopAdditionCommandHandler : IRequestHandler<AddBatchHopAdditionCommand, int>
    {
        public AddBatchHopAdditionCommandHandler(IApplicationDbContext context)
        {
            Context = context;
        }

        public IApplicationDbContext Context { get; }

        public async Task<int> Handle(AddBatchHopAdditionCommand request, CancellationToken cancellationToken)
        {
            var entity = new BatchHopAdditions
            {
                HopAddition = new HopAddition
                {
                    DateAdded = request.DateAdded,
                    IngredientId = request.IngredientId??0,
                    Temperature = request.Temperature
                },
                BatchId = request.BatchId
            };

            if (entity.HopAddition.IngredientId == 0)
            {
                var ingredient = new Ingredient
                {
                    Name = request.IngredientName,
                    CategoryId = request.IngredientCategoryId ?? 0
                };

                if (ingredient.CategoryId == 0 && !String.IsNullOrWhiteSpace(request.IngredientCategoryName))
                {
                    var category = new IngredientCategory
                    {
                        Name = request.IngredientCategoryName
                    };

                    ingredient.Category = category;
                }

                entity.HopAddition.Ingredient = ingredient;
            }

            Context.BatchHopAdditions.Add(entity);

            await Context.SaveChangesAsync(cancellationToken);

            return entity.Id;
        }
    }
}
