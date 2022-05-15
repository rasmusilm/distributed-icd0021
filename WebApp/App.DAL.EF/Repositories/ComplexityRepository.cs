using App.Contracts.DAL;
using App.DAL.DTO;
using Base.Contracts.Base;
using Base.DAL.EF;

namespace App.DAL.EF.Repositories;

public class ComplexityRepository : BaseEntityRepository<Complexity, Domain.Complexity, ApplicationDbContext>, IComplexityRepository
{
    public ComplexityRepository(ApplicationDbContext dbContext, IMapper<Complexity, Domain.Complexity> mapper) : base(dbContext, mapper)
    {
    }
}