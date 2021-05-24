using CloudyMobile.Domain.Common;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Domain.Events
{
    public class TodoItemCreatedEvent : DomainEvent
    {
        public TodoItemCreatedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
