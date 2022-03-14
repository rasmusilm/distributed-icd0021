using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class IdeaRating : IBaseItem
{
    public Guid Id { get; set; }
    public int Rating { get; set; }
    
    public Guid UserId { get; set; }
    public User? User { get; set; }
    
    public Guid ProjectIdeaId { get; set; }
    public ProjectIdea? ProjectIdea { get; set; }
}