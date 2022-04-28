using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using App.DAL.DTO;
using Base.BLL;
using Base.Contracts.Base;
using Helpers.WebApp;
using ProjectIdea = App.BLL.DTO.ProjectIdea;

namespace App.BLL.Services;

public class ProjectIdeaService : BaseEntityService<App.BLL.DTO.ProjectIdea, App.DAL.DTO.ProjectIdea, IProjectIdeaRepository>, IProjectIdeaService
{
    public ProjectIdeaService(IProjectIdeaRepository repository, IMapper<ProjectIdea, DAL.DTO.ProjectIdea> mapper) : base(repository, mapper)
    {
    }
    
    public new async Task<IEnumerable<ProjectIdea>> GetAllAsync(bool noTracking = true)
    {
        return (await Repository.GetAllAsync()).Select(x => Mapper.Map(x)!).Select(post =>
        {
            if (post.IdeaRatings!.Count > 0)
            {
                post.Rating = post.IdeaRatings!.Average(r => r.Rating);
            }
        
            return post;
        });;
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllByUser(Guid userId)
    {
        return (await Repository.GetAllByUser(userId)).Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllWithTag(Guid tagId)
    {
        return (await Repository.GetAllWithTag(tagId)).Select(x => Mapper.Map(x)!);
    }
}