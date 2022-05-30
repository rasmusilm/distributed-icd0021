using System.ComponentModel.DataAnnotations;
using App.Base;
using User = App.Public.DTO.v1.Identity.User;

namespace App.Public.DTO.v1;

public class ProjectIdea : DomainEntityId
{
    
    public string Title { get; set; } = "";
    public string Explanation { get; set; } = "";
    public DateTime PostedAt { get; set; }
    public bool Edited { get; set; } = false;
    public bool Deleted { get; set; } = false;
    
    public Guid ComplexityId { get; set; }
    public Complexity? Complexity { get; set; } = default!;
    
    public Guid DifficultyId { get; set; }
    public Difficulty? Difficulty { get; set; } = default!;

    public Guid UserId { get; set; }
    public User? User { get; set; } = default!;
    public double Rating { get; set; } = default!;
    public ICollection<IdeaTag>? IdeaTags { get; set; } = default!;
    public ICollection<Guid> TagIds { get; set; } = new List<Guid>();
    public ICollection<IdeaRating>? IdeaRatings { get; set; } = default!;
    public ICollection<IdeaInfeed>? IdeaInfeeds { get; set; } = default!;
}