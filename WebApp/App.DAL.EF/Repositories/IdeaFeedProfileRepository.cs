using App.Contracts.DAL;
using App.Domain;
using Base.DAL.EF;

namespace DAL.App.Repositories;

public class IdeaFeedProfileRepository: BaseEntityRepository<IdeaFeedProfile, ApplicationDbContext>, IIdeaFeedProfileRepository
{
    private ApplicationDbContext _context;

    public IdeaFeedProfileRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _context = dbContext;
    }

    public IEnumerable<IdeaFeedProfile> GetAllByUser(Guid userId)
    {
        var projectIdeas = _context.IdeaFeedProfiles.Where(p => p.UserId.Equals(userId));
        return projectIdeas.AsEnumerable();
    }
}