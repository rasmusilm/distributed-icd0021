using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Public.DTO.v1.Identity;

namespace App.Public.DTO.v1;

public class Project : DomainEntityId
{
    
    public Guid? ProjectIdeaId { get; set; }
    public ProjectIdea? ProjectIdea { get; set; }

    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    public DateTime Deadline { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public ICollection<ProjectTask>? Tasks { get; set; } 
    public ICollection<TeamInProject>? TeamInProjects { get; set; }
    public ICollection<UserInProject>? UserInProjects { get; set; }
}