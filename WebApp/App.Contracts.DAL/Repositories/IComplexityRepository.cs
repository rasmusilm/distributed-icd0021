using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IComplexityRepository : IEntityRepository<Complexity>
{
    
}

public interface IComplexityRepositoryCustom<TEntity>
{
    
}