using App.DAL.DTO;
using Base.Contracts.DAL;


namespace App.Contracts.DAL;

public interface IProjectIdeaRepository : IEntityRepository<ProjectIdea>
{
    Task<IEnumerable<ProjectIdea>> GetAllByUser(Guid userid);
}

public interface IProjectIdeaRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllByUser(Guid userId);
}