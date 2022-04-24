using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using App.DAL.DTO;
using Base.BLL;
using Base.Contracts.Base;
using ProjectIdea = App.BLL.DTO.ProjectIdea;

namespace App.BLL.Services;

public class ProjectIdeaService : BaseEntityService<App.BLL.DTO.ProjectIdea, App.DAL.DTO.ProjectIdea, IProjectIdeaRepository>, IProjectIdeaService
{
    public ProjectIdeaService(IProjectIdeaRepository repository, IMapper<ProjectIdea, DAL.DTO.ProjectIdea> mapper) : base(repository, mapper)
    {
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllByUser(Guid userId)
    {
        return (await Repository.GetAllByUser(userId)).Select(x => Mapper.Map(x)!);
    }
}