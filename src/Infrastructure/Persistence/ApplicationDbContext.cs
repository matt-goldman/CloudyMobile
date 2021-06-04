using CloudyMobile.Application.Common.Interfaces;
using CloudyMobile.Domain.Entities;
using CloudyMobile.Infrastructure.Identity;
using CloudyMobile.Infrastructure.Persistence.Interceptors;
using IdentityServer4.EntityFramework.Options;
using Microsoft.AspNetCore.ApiAuthorization.IdentityServer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;

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

        public async Task SeedInitialData()
        {
            var haveStyles = await Styles.AnyAsync();
            if (!haveStyles)
            {
                Console.WriteLine("Seeding initial data...");

                var styles = new List<Style>
                {
                    new Style
                    {
                        Name = "Saison",
                        Notes = "Saison is a pale ale that is highly carbonated, fruity, spicy, and often bottle conditioned. It was historically brewed with low alcohol levels, but modern productions of the style have moderate to high levels of alcohol. Along with several other varieties, it is generally classified as a farmhouse ale.",
                        ImageUrl = "http://www.craftbeer.com/wp-content/uploads/_SF/thumbnails/american-brett.jpg"
                    },
                    new Style
                    {
                        Name = "Stout",
                        Notes = "Dry stout is black beer with a dry-roasted character thanks to the use of roasted barley. The emphasis on coffee-like roasted barley and a moderate degree of roasted malt aromas define much of the character. Hop bitterness is medium to medium high. This beer is often dispensed via nitrogen gas taps that lend a smooth, creamy body to the palate.",
                        ImageUrl = "http://www.craftbeer.com/wp-content/uploads/_SF/thumbnails/irish-style-dry-stout.jpg"
                    },
                    new Style
                    {
                        Name = "IPA",
                        Notes = "Characterized by floral, fruity, citrus-like, piney or resinous American-variety hop character, the IPA beer style is all about hop flavor, aroma and bitterness. This has been the most-entered category at the Great American Beer Festival for more than a decade, and is the top-selling craft beer style in supermarkets and liquor stores across the U.S.",
                        ImageUrl = "http://www.craftbeer.com/wp-content/uploads/_SF/thumbnails/american-india-pale-ale.jpg"
                    },
                    new Style
                    {
                        Name = "Lager",
                        Notes = "Lager has little in the way of hop and malt character. A straw to gold, very clean and crisp, highly carbonated lager.",
                        ImageUrl = "http://www.craftbeer.com/wp-content/uploads/_SF/thumbnails/american-lager.jpg"
                    }
                };

                Styles.AddRange(styles);

                await SaveChangesAsync();
            }
        }
    }
}
