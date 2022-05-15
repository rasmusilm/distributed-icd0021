using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using Base.BLL;
using Base.Contracts.Base;

namespace App.BLL.Services;

public class CommentRatingService: BaseEntityService<CommentRating, App.DAL.DTO.CommentRating, ICommentRatingRepository>, ICommentRatingService
{
    public CommentRatingService(ICommentRatingRepository repository, IMapper<CommentRating, DAL.DTO.CommentRating> mapper) : base(repository, mapper)
    {
    }
}