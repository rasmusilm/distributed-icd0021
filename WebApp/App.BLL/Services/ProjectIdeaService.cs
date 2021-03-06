using App.Contracts.BLL.Services;
using App.Contracts.DAL;
using App.Contracts.DAL.Repositories;
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
            CalculateGrade(post);
                    
            ExtractTagIds(post);
        
            return post;
        });
    }

    public new async Task<ProjectIdea?> FirstOrDefaultAsync(Guid id, bool noTracking = true)
    {
        var post = Mapper.Map(await Repository.FirstOrDefaultAsync(id, noTracking));
        if (post is not null )
        {
            CalculateGrade(post);
        }
        

        return post;
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllByUser(Guid userId)
    {
        return (await Repository.GetAllByUser(userId)).Select(x => Mapper.Map(x)!);
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllWithTag(Guid tagId)
    {
        var posts = (await Repository.GetAllWithTag(tagId)).Select(x => Mapper.Map(x)!).ToList();
        posts.Sort((idea, projectIdea) => idea.PostedAt.CompareTo(projectIdea));
        return posts;
    }

    public async Task<IEnumerable<ProjectIdea>> GetAllFromFeed(List<Guid> tagIds)
    {
        var posts = new List<ProjectIdea>();
        foreach (var tagId in tagIds)
        {
            var postsWithTag = (await Repository.GetAllWithTag(tagId)).Select(x => Mapper.Map(x)!);
            foreach (var post in postsWithTag)
            {
                if (!posts.Contains(post))
                {
                    
                    CalculateGrade(post);
                    
                    ExtractTagIds(post);
                    
                    posts.Add(post);
                }
            }
        }
        posts.Sort((idea, projectIdea) => idea.PostedAt.CompareTo(projectIdea.PostedAt));
        return posts;
    }

    private static void CalculateGrade(ProjectIdea post)
    {
        if (post.IdeaRatings!.Count > 0)
        {
            post.Rating = post.IdeaRatings!.Average(r => r.Rating);
        }
    }
    
    private static void ExtractTagIds(ProjectIdea post)
    {
        if (post.IdeaTags!.Count > 0)
        {
            foreach (var tag in post.IdeaTags)
            {
                post.TagIds.Add(tag.TagId);
            }
        }
    }
}