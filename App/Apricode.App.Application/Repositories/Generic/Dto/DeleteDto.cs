using System.Text.Json.Serialization;

namespace Apricode.App.Application.Repositories.Generic.Dto;

public class DeleteDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}