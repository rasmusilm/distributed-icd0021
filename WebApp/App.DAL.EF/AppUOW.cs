using App.Contracts.DAL;
using Base.DAL.EF;
using DAL.App.Repositories;

namespace DAL.App;

public class AppUOW: BaseUOW<ApplicationDbContext>, IAppUnitOfWork
{
    public AppUOW(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    private IProjectIdeaRepository? _projectIdea;

    public IProjectIdeaRepository ProjectIdeas => 
        _projectIdea ??= new ProjectIdeaRepository(UOWDbContext);
    
    private IIdeaRatingRepository? _ideaRating;

    public IIdeaRatingRepository IdeaRatings => 
        _ideaRating ??= new IdeaRatingRepository(UOWDbContext);
    
    private IIdeaFeedProfileRepository? _ideaFeedProfile;

    public IIdeaFeedProfileRepository IdeaFeedProfiles => 
        _ideaFeedProfile ??= new IdeaFeedProfileRepository(UOWDbContext);
}