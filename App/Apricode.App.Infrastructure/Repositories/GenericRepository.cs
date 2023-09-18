using Apricode.App.Application.Repositories;
using Apricode.App.Application.Repositories.Generic;
using Apricode.App.Application.Repositories.Generic.Dto;
using Apricode.App.Domain.Common;
using Apricode.App.Infrastructure.Common;
using Apricode.App.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using swiftmash.Mapper;

namespace Apricode.App.Infrastructure.Repositories;

public class GenericRepository<TEntity, TModel, TMapper>: IGenericRepository<TEntity,TModel>
    where TEntity: BaseEntity
    where TModel: BaseModel
    where TMapper: GenericMapper<TEntity, TModel>, new()
{
    private readonly ApricodeContext _dbContext;
    private DbSet<TEntity> table = null;
    private readonly TMapper _mapper;
    
    public GenericRepository()
    {
        _dbContext = new ApricodeContext();
        table = _dbContext.Set<TEntity>();
        _mapper = new TMapper();
    }

    public GenericRepository(ApricodeContext dbContext)
    {
        _dbContext = dbContext;
        table = _dbContext.Set<TEntity>();
        _mapper = new TMapper();
    }
    
    public List<TModel> Get()
    {
        var entities = table.ToList();
        var models = _mapper.ToModelList(entities);
        return models;
    }

    public TModel GetById(GetByIdDto dto)
    {
        var entity = table.Find(dto.Id)!;
        return _mapper.ToModel(entity);
    }

    public void Insert(TModel model)
    {
        var entity = _mapper.ToEntity(model);
        table.Add(entity);
        Save();
    }

    public void Update(TModel model)
    {
        var entity = _mapper.ToEntity(model);
        _dbContext.Update(entity);
        Save();
    }

    public void Delete(DeleteDto dto)
    {
        var entity = table.Find(dto.Id)!;
        table.Remove(entity);
        Save();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}