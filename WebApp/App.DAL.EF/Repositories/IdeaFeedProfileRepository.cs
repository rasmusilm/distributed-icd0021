using App.Contracts.DAL;
using App.Domain;
using Base.DAL.EF;

namespace DAL.App.Repositories;

public class IdeaFeedProfileRepository: BaseEntityRepository<IdeaFeedProfile, ApplicationDbContext>, IIdeaFeedProfileRepository
{
    public IdeaFeedProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}