using Apricode.App.Domain.Common;

namespace Apricode.App.Domain.Models;

public class Game: BaseModel
{
    public string Name { get; set; } = null!;
    
    public List<Genre> Genres { get; set; } = null!;

    public GameDeveloper Developer { get; set; } = null!;
}
