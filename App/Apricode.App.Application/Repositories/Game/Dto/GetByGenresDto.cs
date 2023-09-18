using System.Text.Json.Serialization;
using Apricode.App.Domain.Models;

namespace Apricode.App.Application.Repositories.Game.Dto;

public class GetByGenresDto
{
    [JsonPropertyName("genres")]
    public IEnumerable<string> Genres { get; set; }
}