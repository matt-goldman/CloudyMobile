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

        public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<TodoList> TodoLists { get; set; }

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
