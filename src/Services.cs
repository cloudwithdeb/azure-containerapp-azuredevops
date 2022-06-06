using ITodoServiceNamespace;
namespace TodoNamespace;

public class TodoService : ITodoService
{
    public string addTodo()
    {
        return "Todo added";
    }

    public string deleteTodo()
    {
        return "Todo deleted";
    }

    public string getAllTodos()
    {
        return "Get all todos";
    }

    public string updateTodo()
    {
        return "Update todos";
    }
}