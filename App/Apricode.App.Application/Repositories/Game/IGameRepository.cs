using Apricode.App.Application.Repositories.Game.Dto;
using Apricode.App.Domain.Models;

namespace Apricode.App.Application.Repositories.Game;

public interface IGameRepository
{
    public List<Domain.Models.Game> Get();
    public void Insert(InsertDto model);
    public void Update(UpdateDto model);
    public List<Domain.Models.Game> GetByGenres(GetByGenresDto dto);
    public void Save();
}