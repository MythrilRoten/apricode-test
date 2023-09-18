using System.Text.Json.Serialization;

namespace Apricode.App.Application.Repositories.Game.Dto;

public class UpdateDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
    
    [JsonPropertyName("developer")]
    public Guid Developer { get; set; }
    
    [JsonPropertyName("name")]
    public string Name { get; set; }
}