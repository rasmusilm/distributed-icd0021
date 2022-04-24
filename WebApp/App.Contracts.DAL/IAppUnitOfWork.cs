using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IAppUnitOfWork: IUnitOfWork
{
    IProjectIdeaRepository ProjectIdeas { get; }
    IIdeaRatingRepository IdeaRatings { get; }
}