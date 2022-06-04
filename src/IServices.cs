using TodoModulesNamespace;

namespace ITodoServiceNamespace;

public interface ITodoService
{
    public string addTodo(TodoItems todoitems);
    public string updateTodo(TodoItems todoitems, int id);
    public string deleteTodo(int id);
    public List<TodoItems> getAllTodos();
}