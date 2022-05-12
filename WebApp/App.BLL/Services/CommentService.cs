using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using Base.BLL;
using Base.Contracts.Base;

namespace App.BLL.Services;

public class CommentService : BaseEntityService<Comment, App.DAL.DTO.Comment, ICommentRepository>, ICommentService
{
    public CommentService(ICommentRepository repository, IMapper<Comment, DAL.DTO.Comment> mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<Comment>> GetAllByUser(Guid userId)
    {
        return (await Repository.GetAllByUser(userId))
            .Select(x => Mapper.Map(x)!)
            .Select(comment =>
            {
                if (comment.CommentRatings!.Count > 0)
                {
                    foreach (var rating in comment.CommentRatings)
                    {
                        if (rating.Vote)
                        {
                            comment.Rating++;
                        }
                        else
                        {
                            comment.Rating--;
                        }
                        
                    }
                }

                return comment;
            });
    }

    public async Task<IEnumerable<Comment>> GetAllOnPost(Guid postId)
    {
        return (await Repository.GetAllOnPost(postId))
            .Select(x => Mapper.Map(x)!)
            .Select(comment =>
            {
                if (comment.CommentRatings!.Count > 0)
                {
                    foreach (var rating in comment.CommentRatings)
                    {
                        if (rating.Vote)
                        {
                            comment.Rating++;
                        }
                        else
                        {
                            comment.Rating--;
                        }
                        
                    }
                }

                return comment;
            });
    }
}