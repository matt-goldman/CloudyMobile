using CloudyMobile.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        //public DbSet<TodoList> TodoLists { get; set; }

        //public DbSet<TodoItem> TodoItems { get; set; }

        public DbSet<UserProfile> UserProfiles { get; set; }

        public DbSet<Address> Addresses { get; set; }
        
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}