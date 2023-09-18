using Apricode.App.Domain.Common;

namespace Apricode.App.Domain.Models;

public class GameDeveloper: BaseModel
{
    public string Name { get; set; } = null!;
    public List<Game> Games { get; set; }
}