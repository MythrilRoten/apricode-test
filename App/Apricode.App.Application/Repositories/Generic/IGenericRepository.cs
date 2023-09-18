using Apricode.App.Application.Repositories.Generic.Dto;
using Apricode.App.Domain.Common;

namespace Apricode.App.Application.Repositories.Generic;

public interface IGenericRepository<TEntity, TModel>
    where TEntity : class
    where TModel : BaseModel
{
    public List<TModel> Get();
    public TModel GetById(GetByIdDto dto);
    public void Insert(TModel model);
    public void Update(TModel model);
    public void Delete(DeleteDto dto);
    public void Save();
}