using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface IIdeaFeedProfileRepository : IEntityRepository<IdeaFeedProfile>
{
    Task<IEnumerable<IdeaFeedProfile>> GetAllByUser(Guid userId);
}

public interface IIdeaFeedProfileRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllByUser(Guid id);
}