using _2_gt4.Application.Common.Mappings;
using _2_gt4.Domain.Entities;

namespace _2_gt4.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
