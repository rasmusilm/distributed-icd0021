using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface ICommentRatingRepository : IEntityRepository<CommentRating>
{
    
}

public interface ICommentRatingRepositoryCustom<TEntity>
{
    
}