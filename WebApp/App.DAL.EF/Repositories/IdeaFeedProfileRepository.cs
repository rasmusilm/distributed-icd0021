using App.Contracts.DAL;
using App.Domain;
using Base.Contracts.Base;
using Base.DAL.EF;

namespace App.DAl.EF.Repositories;

public class IdeaFeedProfileRepository: BaseEntityRepository<DAL.DTO.IdeaFeedProfile, App.Domain.IdeaFeedProfile, ApplicationDbContext>, IIdeaFeedProfileRepository
{
    private ApplicationDbContext _context;

    public IdeaFeedProfileRepository(ApplicationDbContext dbContext, IMapper<DAL.DTO.IdeaFeedProfile, IdeaFeedProfile> mapper) : base(dbContext, mapper)
    {
        _context = dbContext;
    }

    public IEnumerable<IdeaFeedProfile> GetAllByUser(Guid userId)
    {
        var projectIdeas = _context.IdeaFeedProfiles.Where(p => p.UserId.Equals(userId));
        return projectIdeas.AsEnumerable();
    }
}