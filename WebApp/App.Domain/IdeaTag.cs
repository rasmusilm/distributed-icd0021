using System.ComponentModel.DataAnnotations;
using App.Domain.Base;

namespace App.Domain;

public class IdeaTag : IBaseItem
{
    public Guid Id { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.ProjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; } = default!;
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.TagId))]
    public Guid TagId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.Tag))]
    public Tag? Tag { get; set; } = default!;
}