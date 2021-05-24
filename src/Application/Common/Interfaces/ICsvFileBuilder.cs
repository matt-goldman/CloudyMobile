using CloudyMobile.Application.TodoLists.Queries.ExportTodos;
using System.Collections.Generic;

namespace CloudyMobile.Application.Common.Interfaces
{
    public interface ICsvFileBuilder
    {
        byte[] BuildTodoItemsFile(IEnumerable<TodoItemRecord> records);
    }
}
