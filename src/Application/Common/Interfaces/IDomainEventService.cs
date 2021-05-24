using CloudyMobile.Domain.Common;
using System.Threading.Tasks;

namespace CloudyMobile.Application.Common.Interfaces
{
    public interface IDomainEventService
    {
        Task Publish(DomainEvent domainEvent);
    }
}
