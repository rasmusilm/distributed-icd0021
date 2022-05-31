using App.BLL.DTO;
using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using Base.Contracts.BLL;

namespace App.Contracts.BLL.Services;

public interface ICommentRatingService: IEntityService<CommentRating>, ICommentRatingRepositoryCustom<CommentRating>
{
    
}