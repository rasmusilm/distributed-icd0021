using App.Domain;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IIdeaFeedProfileRepository : IEntityRepository<IdeaFeedProfile>
{
    IEnumerable<IdeaFeedProfile> GetAllByUser(Guid userId);
}