using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class IdeaRating : DomainEntityId
{
    
    public int Rating { get; set; }
    
    public Guid UserId { get; set; }
    // [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.User))]
    // public User? User { get; set; }
    
    public Guid ProjectIdeaId { get; set; }
    // [Display( ResourceType = typeof(App.Resourses.App.Domain.Idearating), Name = nameof(App.Resourses.App.Domain.Idearating.ProjectIdea))]
    // public ProjectIdea? ProjectIdea { get; set; }
}