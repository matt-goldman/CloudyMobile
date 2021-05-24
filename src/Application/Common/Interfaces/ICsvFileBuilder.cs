using _2_gt4.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace _2_gt4.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
