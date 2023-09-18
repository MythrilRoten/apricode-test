using Apricode.App.Application.Repositories.Game;
using Apricode.App.Application.Repositories.Game.Dto;
using Apricode.App.Domain.Models;
using Apricode.App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using swiftmash.Mapper;
using swiftmash.Mapper.Game;
using Genre = Apricode.App.Infrastructure.Entities.Genre;

namespace Apricode.App.Infrastructure.Repositories.Game;

public class GameRepository: IGameRepository
{
    private readonly ApricodeContext _dbContext;
    private DbSet<Entities.Game> table = null;
    private readonly GameMapper _mapper;
    
    public GameRepository()
    {
        _dbContext = new ApricodeContext();
        table = _dbContext.Set<Entities.Game>();
        _mapper = new GameMapper();
    }

    public GameRepository(ApricodeContext dbContext)
    {
        _dbContext = dbContext;
        table = _dbContext.Set<Entities.Game>();
        _mapper = new GameMapper();
    }

    private Guid CreateGuid(Guid developer, string gameName)
    {
        return new Guid($"{developer.ToString()} {gameName.ToLower()}");
    }
    
    public List<Domain.Models.Game> Get()
    {
        var entities = table.Include(e => e.DeveloperNavigation).Include(e => e.Genres).ToList();
        var models = _mapper.ToModelList(entities);
        return models;
    }

    public void Insert(InsertDto dto)
    {
        var entity = new Entities.Game()
        {
            Id = Guid.NewGuid(),
            Developer = dto.Developer,
            Name = dto.Name
        };
        
        table.Add(entity);
        Save();
    }

    public void Update(UpdateDto dto)
    {
        var entity = table.Find(dto.Id)!;
        
        _dbContext.Entry(entity).CurrentValues.SetValues(dto);
        _dbContext.Update(entity);

        Save();
    }
    
    public List<Domain.Models.Game> GetByGenres(GetByGenresDto dto)
    {
        var entities = table.Include(e => e.Genres).ToList();
        var filteredEntities = entities.Where(e => e.Genres.Select(g => g.Name).Intersect(dto.Genres).SequenceEqual(dto.Genres)).ToList();
        
        var models = _mapper.ToModelList(filteredEntities);
        return models;
    }
    
    public void Save()
    {
        _dbContext.SaveChanges();
    }
}