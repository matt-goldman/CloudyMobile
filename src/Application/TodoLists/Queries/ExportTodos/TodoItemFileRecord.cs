using CloudyMobile.Application.Common.Mappings;
using CloudyMobile.Domain.Entities;

namespace CloudyMobile.Application.TodoLists.Queries.ExportTodos
{
    public class TodoItemRecord : IMapFrom<TodoItem>
    {
        public string Title { get; set; }

        public bool Done { get; set; }
    }
}
