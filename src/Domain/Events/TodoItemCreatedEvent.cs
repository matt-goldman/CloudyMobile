using _2_gt4.Domain.Common;
using _2_gt4.Domain.Entities;

namespace _2_gt4.Domain.Events
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
