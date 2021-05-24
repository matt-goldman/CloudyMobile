using CloudyMobile.Domain.Common;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Domain.Events
{
    public class TodoItemCompletedEvent : DomainEvent
    {
        public TodoItemCompletedEvent(TodoItem item)
        {
            Item = item;
        }

        public TodoItem Item { get; }
    }
}
