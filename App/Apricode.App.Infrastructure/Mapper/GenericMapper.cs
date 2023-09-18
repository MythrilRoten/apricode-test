using Apricode.App.Domain.Common;
using AutoMapper;

namespace Apricode.App.Infrastructure.Common;

public class GenericMapper<TEntity, TModel>
    where TEntity : BaseEntity
    where TModel : BaseModel
{
    private IMapper _mapper = null;

    private MapperConfiguration _configToModel = null;

    private MapperConfiguration _configToEntity = null;

    public GenericMapper()
    {
        _configToModel = new(cfg => { cfg.CreateMap(typeof(TEntity), typeof(TModel)); });

        _configToEntity = new(cfg => { cfg.CreateMap(typeof(TModel), typeof(TEntity)); });
    }

    public TModel ToModel(TEntity entity)
    {
        _mapper = _configToModel.CreateMapper();

        return _mapper.Map<TModel>(entity);
    }

    public TEntity ToEntity(TModel model)
    {
        _mapper = _configToEntity.CreateMapper();

        return _mapper.Map<TEntity>(model);
    }

    public List<TModel> ToModelList(List<TEntity> entities)
    {
        _mapper = _configToModel.CreateMapper();

        return _mapper.Map<List<TModel>>(entities);
    }

    public List<TEntity> ToEntityList(List<TModel> models)
    {
        _mapper = _configToEntity.CreateMapper();

        return _mapper.Map<List<TEntity>>(models);
    }
}