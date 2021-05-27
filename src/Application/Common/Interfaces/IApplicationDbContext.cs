using CloudyMobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Address> Addresses { get; set; }

        DbSet<CloudyMobile.Domain.Entities.Batch> Batches { get; set; }
        DbSet<BatchHopAdditions> BatchHopAdditions { get; set; }
        DbSet<BatchSample> BatchSamples { get; set; }
        DbSet<HopAddition> HopAdditions { get; set; }
        DbSet<Ingredient> Ingredients { get; set; }
        DbSet<Recipe> Recipes { get; set; }
        DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        DbSet<IngredientCategory> IngredientCategories { get; set; }


        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}