using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using CloudyMobile.Infrastructure.Identity;
using CloudyMobile.Infrastructure.Persistence.Interceptors;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Reflection;

namespace CloudyMobile.Infrastructure.Persistence
{
    public class ApplicationDbContext 
        : ApiAuthorizationDbContext<ApplicationUser>, IApplicationDbContext
    {
        private readonly AuditEntitiesSaveChangesInterceptor _auditEntitiesSaveChangesInterceptor;

        public ApplicationDbContext(
                DbContextOptions options,
                IOptions<OperationalStoreOptions> operationalStoreOptions,
                ICurrentUserService currentUserService) 
            : base(options, operationalStoreOptions)
        {
            _auditEntitiesSaveChangesInterceptor = 
                new AuditEntitiesSaveChangesInterceptor(currentUserService);
        }

        public DbSet<Batch> Batches { get; set; }
        public DbSet<BatchHopAdditions> BatchHopAdditions { get; set; }
        public DbSet<BatchSample> BatchSamples { get; set; }
        public DbSet<HopAddition> HopAdditions { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeIngredients> RecipeIngredients { get; set; }
        public DbSet<IngredientCategory> IngredientCategories { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<BatchRating> BatchRatings { get; set; }
        public DbSet<Keg> Kegs { get; set; }
        public DbSet<KegPours> KegPours { get; set; }
        public DbSet<Location> Locations { get; set; }

        public DbSet<Style> Styles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_auditEntitiesSaveChangesInterceptor);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly());

            base.OnModelCreating(builder);
        }
    }
}
