using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface ITagRepository : IEntityRepository<Tag>
{
    
}

public interface ITagRepositoryCustom<TEntity>
{
    
}