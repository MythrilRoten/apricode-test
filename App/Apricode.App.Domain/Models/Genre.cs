using Apricode.App.Domain.Common;

namespace Apricode.App.Domain.Models;

public class Genre: BaseModel
{
    public Guid Game { get; set; }
    public string Name { get; set; } = null!;
}