using App.Contracts.DAL;
using App.DAL.DTO;
using Base.Contracts.Base;
using Base.DAL.EF;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.EF.Repositories;

public class CommentRepository : BaseEntityRepository<DAL.DTO.Comment, App.Domain.Comment, ApplicationDbContext>, ICommentRepository
{
    public CommentRepository(ApplicationDbContext dbContext, IMapper<Comment, Domain.Comment> mapper) : base(dbContext, mapper)
    {
    }

    public async Task<IEnumerable<Comment>> GetAllByUser(Guid userId)
    {
        var query = CreateQuery(true);
        return (await query.Where(a => a.UserId == userId).Include(c => c.CommentRatings).ToListAsync()).Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<Comment>> GetAllOnPost(Guid postId)
    {
        var query = CreateQuery(true);
        return (await query.Where(a => a.ProjectIdeaId == postId).Include(c => c.CommentRatings).ToListAsync()).Select(x => Mapper.Map(x)!);
    }
}