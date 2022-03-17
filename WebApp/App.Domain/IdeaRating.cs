using System.ComponentModel.DataAnnotations;
using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class IdeaRating : IBaseItem
{
    public Guid Id { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.Rating))]
    public int Rating { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.UserId))]
    public Guid UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.User))]
    public User? User { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.ProjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; }
}