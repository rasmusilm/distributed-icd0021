using Domain.App.Base;
using Domain.App.Identity;

namespace Domain.App;

public class Project : IBaseItem
{
    public Guid Id { get; set; }
    
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