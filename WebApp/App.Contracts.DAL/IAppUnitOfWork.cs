using App.Contracts.DAL.Repositories;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface IAppUnitOfWork: IUnitOfWork
{
    IProjectIdeaRepository ProjectIdeas { get; }
    IIdeaRatingRepository IdeaRatings { get; }
    IIdeaFeedProfileRepository IdeaFeedProfiles { get; }
    ITagRepository Tags { get; }
    ICommentRepository Comments { get; }
    ICommentRatingRepository CommentRatings { get; }
    IComplexityRepository Complexity { get; }
}