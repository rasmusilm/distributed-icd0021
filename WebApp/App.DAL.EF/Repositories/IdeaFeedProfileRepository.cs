using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using App.DAL.EF;
using App.Domain;
using Base.Contracts.Base;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAl.EF.Repositories;

public class IdeaFeedProfileRepository: BaseEntityRepository<DAL.DTO.IdeaFeedProfile, App.Domain.IdeaFeedProfile, ApplicationDbContext>, IIdeaFeedProfileRepository
{
    private ApplicationDbContext _context;

    public IdeaFeedProfileRepository(ApplicationDbContext dbContext, IMapper<DAL.DTO.IdeaFeedProfile, IdeaFeedProfile> mapper) : base(dbContext, mapper)
    {
        _context = dbContext;
    }
    
    public new async Task<DAL.DTO.IdeaFeedProfile?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {
        var query = CreateQuery(true);
        return Mapper.Map(query
            .Include(f => f.FeedTags)
            .FirstOrDefault(a => a.Id == id));
    }

    public async Task<IEnumerable<DAL.DTO.IdeaFeedProfile>> GetAllByUser(Guid userId)
    {
        var query = CreateQuery(true);
        return (await query
            .Where(a => a.UserId == userId)
            .ToListAsync())
            .Select(x => Mapper.Map(x)!);
    }
}