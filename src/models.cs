using TodoRepositoryNamespace;

namespace TodoModulesNamespace;

public class TodoItems
{
    public string? Id {get; set;} = Guid.NewGuid().ToString();
    public string? Title {get; set;}
    public string? Description {get; set;}
    public string? Date {get; set;} = DateTime.UtcNow.ToString("D");
    public string? Time {get; set;} = DateTime.UtcNow.ToString("T");
}
