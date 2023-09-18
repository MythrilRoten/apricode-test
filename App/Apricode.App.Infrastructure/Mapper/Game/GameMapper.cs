using Apricode.App.Domain.Common;
using Apricode.App.Domain.Models;
using Apricode.App.Infrastructure.Common;
using AutoMapper;

namespace swiftmash.Mapper.Game;

public class GameMapper: GenericMapper<Apricode.App.Infrastructure.Entities.Game, Apricode.App.Domain.Models.Game>
{
    private IMapper _mapper = null;
    private MapperConfiguration _configToModel = null;

    private MapperConfiguration _configToEntity = null;

    public GameMapper()
    {
        _configToModel = new(cfg =>
        {
            cfg.CreateMap<BaseEntity, BaseModel>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            cfg.CreateMap<Apricode.App.Infrastructure.Entities.Game, Apricode.App.Domain.Models.Game>()
                .ForMember(dest => dest.Developer, opt => opt.MapFrom(src => src.DeveloperNavigation))
                .IncludeBase<BaseEntity, BaseModel>();
            cfg.CreateMap<Apricode.App.Infrastructure.Entities.Genre, Genre>()
                .IncludeBase<BaseEntity, BaseModel>();
            cfg.CreateMap<Apricode.App.Infrastructure.Entities.GameDeveloper, GameDeveloper>()
                .IncludeBase<BaseEntity, BaseModel>();
        });
        
        _configToEntity = new(cfg =>
        {
            cfg.CreateMap<BaseModel, BaseEntity>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id));
            cfg.CreateMap<Apricode.App.Domain.Models.Game, Apricode.App.Infrastructure.Entities.Game>()
                .ForMember(dest => dest.DeveloperNavigation, opt => opt.MapFrom(src => src.Developer))
                .IncludeBase<BaseModel, BaseEntity>();
            cfg.CreateMap<Genre, Apricode.App.Infrastructure.Entities.Genre>()
                .IncludeBase<BaseModel, BaseEntity>();
            cfg.CreateMap<GameDeveloper, Apricode.App.Infrastructure.Entities.GameDeveloper>()
                .IncludeBase<BaseModel, BaseEntity>();
        });
    }
    
    public new Apricode.App.Domain.Models.Game ToModel(Apricode.App.Infrastructure.Entities.Game entity)
    {
        _mapper = _configToModel.CreateMapper();

        return _mapper.Map<Apricode.App.Domain.Models.Game>(entity);
    }
    
    public new Apricode.App.Infrastructure.Entities.Game ToEntity(Apricode.App.Domain.Models.Game model)
    {
        _mapper = _configToEntity.CreateMapper();

        return _mapper.Map<Apricode.App.Infrastructure.Entities.Game>(model);
    }

    public new List<Apricode.App.Domain.Models.Game> ToModelList(List<Apricode.App.Infrastructure.Entities.Game> entities)
    {
        _configToModel.AssertConfigurationIsValid();
        _mapper = _configToModel.CreateMapper();

        return _mapper.Map<List<Apricode.App.Domain.Models.Game>>(entities);
    }

    public new List<Apricode.App.Infrastructure.Entities.Game> ToEntityList(List<Apricode.App.Domain.Models.Game> models)
    {
        _mapper = _configToEntity.CreateMapper();

        return _mapper.Map<List<Apricode.App.Infrastructure.Entities.Game>>(models);
    }
    
}