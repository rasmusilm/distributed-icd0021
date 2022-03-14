using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;
using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class ProjectIdea : IBaseItem
{
    public Guid Id { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.ProjectIdea), Name = nameof(Title))]
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

    public ICollection<IdeaTag>? IdeaTags { get; set; } = default!;
    public ICollection<IdeaRating>? IdeaRatings { get; set; } = default!;
    public ICollection<IdeaInfeed>? IdeaInfeeds { get; set; } = default!;
    public ICollection<Comment>? Comments { get; set; } = default!;
    public ICollection<Project>? Projects { get; set; } = default!;
}