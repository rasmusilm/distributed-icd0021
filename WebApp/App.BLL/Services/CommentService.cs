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
        return (await Repository.GetAllByUser(userId)).Select(x => Mapper.Map(x)!);
    }
}