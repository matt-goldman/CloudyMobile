using _2_gt4.Domain.Common;
using _2_gt4.Domain.ValueObjects;
using System.Collections.Generic;

namespace _2_gt4.Domain.Entities
{
    public class TodoList : AuditableEntity
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Colour Colour { get; set; } = Colour.White;

        public IList<TodoItem> Items { get; private set; } = new List<TodoItem>();
    }
}
