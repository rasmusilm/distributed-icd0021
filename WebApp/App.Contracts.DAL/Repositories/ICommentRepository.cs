using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL.Repositories;

public interface ICommentRepository : IEntityRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllByUser(Guid userId);
    Task<IEnumerable<Comment>> GetAllOnPost(Guid postId);
}

public interface ICommentRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllByUser(Guid userId);
    Task<IEnumerable<TEntity>> GetAllOnPost(Guid postId);
}