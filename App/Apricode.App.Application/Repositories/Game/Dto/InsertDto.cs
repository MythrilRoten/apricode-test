using System.Text.Json.Serialization;

namespace Apricode.App.Application.Repositories.Game.Dto;

public class InsertDto
{
    [JsonPropertyName("developer")]
    public Guid Developer { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}