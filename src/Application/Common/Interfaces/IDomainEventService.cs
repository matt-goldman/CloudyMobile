using _2_gt4.Domain.Common;
using System.Threading.Tasks;

namespace _2_gt4.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
