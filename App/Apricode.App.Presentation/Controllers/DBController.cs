using System.ComponentModel;
using Apricode.App.Application.Repositories.Game.Dto;
using Apricode.App.Application.Repositories.Generic.Dto;
using Apricode.App.Infrastructure.Data;
using Apricode.App.Infrastructure.Entities;
using Apricode.App.Infrastructure.Repositories;
using Apricode.App.Infrastructure.Repositories.Game;
using Microsoft.AspNetCore.Mvc;
using swiftmash.Mapper.Game;

namespace Apricode.App.Presentation.Controllers;

[ApiController]
[Route("api/v1/db")]
public class DBController : Controller
{
    private IWebHostEnvironment Environment;
    private readonly ILogger<DBController> _logger;
    private readonly ApricodeContext _dbContext;
    private readonly GenericRepository<Game, Domain.Models.Game, GameMapper> _genericRepository;
    private readonly GameRepository _gameRepository;

    public DBController(ILogger<DBController> logger, IWebHostEnvironment _environment, ApricodeContext dbContext)
    {
        Environment = _environment;
        _logger = logger;
        _dbContext = dbContext;

        _gameRepository = new(_dbContext);
        _genericRepository = new(_dbContext);
    }

    [HttpGet("GetGames")]
    public async Task<IActionResult> GetGames()
    {
        try
        {
            _logger.LogInformation("CreateGame {DT}", DateTime.UtcNow.ToLongTimeString());
            var models = _gameRepository.Get();
            return Ok(models);
        }
        catch
        {
            _logger.LogError("Error in GetGames");
            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("CreateGame")]
    public async Task<IActionResult> CreateGame([FromBody] InsertDto dto)
    {
        try
        {
            _logger.LogInformation("CreateGame {DT}", DateTime.UtcNow.ToLongTimeString());
            _gameRepository.Insert(dto);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch
        {
            _logger.LogError("Error in CreateGame");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(dto))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(name)!;
                _logger.LogError("{0}={1}", name, value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("UpdateGame")]
    public async Task<IActionResult> UpdateGame([FromBody] UpdateDto dto)
    {
        try
        {
            _logger.LogInformation("UpdateGame {DT}", DateTime.UtcNow.ToLongTimeString());
            _gameRepository.Update(dto);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch
        {
            _logger.LogError("Error in UpdateGame");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(dto))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(name)!;
                _logger.LogError("{0}={1}", name, value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("GetGamesByGenres")]
    public async Task<IActionResult> GetGamesByGenres([FromBody] GetByGenresDto dto)
    {
        try
        {
            _logger.LogInformation("GetGamesByGenres {DT}", DateTime.UtcNow.ToLongTimeString());
            var models = _gameRepository.GetByGenres(dto);
            return Ok(models);
        }
        catch
        {
            _logger.LogError("Error in GetGamesByGenres");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(dto))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(name)!;
                _logger.LogError("{0}={1}", name, value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }

    [HttpPost("DeleteGame")]
    public async Task<IActionResult> DeleteGame([FromBody] DeleteDto dto)
    {
        try
        {
            _logger.LogInformation("DeleteGame {DT}", DateTime.UtcNow.ToLongTimeString());
            _genericRepository.Delete(dto);
            return StatusCode(StatusCodes.Status200OK);
        }
        catch
        {
            _logger.LogError("Error in DeleteGame");
            foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(dto))
            {
                string name = descriptor.Name;
                object value = descriptor.GetValue(name)!;
                _logger.LogError("{0}={1}", name, value);
            }

            return StatusCode(StatusCodes.Status500InternalServerError);
        }
    }
}