using ITodoServiceNamespace;
using TodoModulesNamespace;
using TodoRepositoryNamespace;

namespace TodoNamespace;

public class TodoService : ITodoService
{
    public string addTodo(TodoItems todoitems)
    {
        TodoRepository._todoitems.Add(todoitems);
        return "Todo added";
    }

    public string deleteTodo(int id)
    {
        throw new NotImplementedException();
    }

    public List<TodoItems> getAllTodos()
    {
        return TodoRepository._todoitems;
    }

    public string updateTodo(TodoItems todoitems, int id)
    {
        throw new NotImplementedException();
    }
}