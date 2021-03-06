using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;


namespace App.BLL.DTO;

public class IdeaTag : DomainEntityId
{
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.ProjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.TagId))]
    public Guid TagId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaTag), Name = nameof(App.Resourses.App.Domain.IdeaTag.Tag))]
    public Tag? Tag { get; set; } = default!;
}