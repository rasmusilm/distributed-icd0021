using App.BLL.DTO;
using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using Base.BLL;
using Base.Contracts.Base;

namespace App.BLL.Services;

public class ComplexityService : BaseEntityService<Complexity, DAL.DTO.Complexity, IComplexityRepository>, IComplexityService
{
    public ComplexityService(IComplexityRepository repository, IMapper<Complexity, DAL.DTO.Complexity> mapper) : base(repository, mapper)
    {
    }
}