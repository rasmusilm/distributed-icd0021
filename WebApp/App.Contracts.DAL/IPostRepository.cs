using App.Domain;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IProjectIdeaRepository : IEntityRepository<ProjectIdea>
{
    IEnumerable<ProjectIdea> GetAllByUser(Guid userid);
}