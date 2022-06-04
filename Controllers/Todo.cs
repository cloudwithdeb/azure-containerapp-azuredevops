using ITodoServiceNamespace;
using Microsoft.AspNetCore.Mvc;
using TodoModulesNamespace;

namespace TodoControllersNamespace;

[ApiController]
public class TodoController : ControllerBase
{
    private readonly ITodoService _svc;

    public TodoController(ITodoService svc)
    {
        _svc=svc;
    }

    [HttpGet("gettodos")]
    public IActionResult GetTodos()
    {
        var _response = _svc.getAllTodos();
        return Ok(_response);
    }

    [HttpPost("addTodos")]
    public IActionResult addTodos([FromBody]TodoItems items)
    {
        var _response = _svc.addTodo(items);
        return Ok(_response);
    }
}