using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
using App.DAL.DTO;
using Base.Contracts.Base;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class CommentRatingRepository : BaseEntityRepository<CommentRating, App.Domain.CommentRating, ApplicationDbContext>, ICommentRatingRepository
{
    public CommentRatingRepository(ApplicationDbContext dbContext, IMapper<CommentRating, Domain.CommentRating> mapper) : base(dbContext, mapper)
    {
    }
}