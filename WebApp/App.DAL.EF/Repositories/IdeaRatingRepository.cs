using App.Contracts.DAL;
using App.Domain;
using Base.DAL.EF;

namespace DAL.App.Repositories;

public class IdeaRatingRepository: BaseEntityRepository<IdeaRating, ApplicationDbContext>, IIdeaRatingRepository
{
    public IdeaRatingRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
    public Task<IEnumerable<IdeaRating>> GetAllByUser(string username)
    {
        throw new NotImplementedException();
    }
    
    public Task<IEnumerable<IdeaRating>> GetAllOnPost(string postIdea)
    {
        throw new NotImplementedException();
    }
}