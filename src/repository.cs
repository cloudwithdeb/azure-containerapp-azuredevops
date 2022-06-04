using TodoModulesNamespace;

namespace TodoRepositoryNamespace;

public static class TodoRepository
{
    public static List<TodoItems> _todoitems = new List<TodoItems>
    {
        new() 
        {
            Title="1st todo", 
            Description="My first todo"
        },
        new()
        {
            Title="2nd todo", 
            Description="My second todo"
            
        },
        new()
        {
            Title="3rd todo", 
            Description="My third todo"
        }
    };
}