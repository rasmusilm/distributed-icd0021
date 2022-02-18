using Domain.App.Base;
using Domain.App.Identity;

namespace Domain.App;

public class IdeaRating : IBaseItem
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ProjectIdeaId { get; set; }
    public ProjectIdea? ProjectIdea { get; set; }
}