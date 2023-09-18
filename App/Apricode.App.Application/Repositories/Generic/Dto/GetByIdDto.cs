using System.Text.Json.Serialization;

namespace Apricode.App.Application.Repositories.Generic.Dto;

public class GetByIdDto
{
    [JsonPropertyName("id")]
    public Guid Id { get; set; }
}