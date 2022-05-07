using App.DAL.DTO;
using Base.Contracts.DAL;

namespace App.Contracts.DAL;

public interface ICommentRepository : IEntityRepository<Comment>
{
    Task<IEnumerable<Comment>> GetAllByUser(Guid userId);
}

public interface ICommentRepositoryCustom<TEntity>
{
    Task<IEnumerable<TEntity>> GetAllByUser(Guid userId);
}