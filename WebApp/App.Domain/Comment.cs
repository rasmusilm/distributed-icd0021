using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class Comment : IBaseItem
{
    public Guid Id { get; set; }
    public string? Text { get; set; }

    public Guid ProjectIdeaId { get; set; }
    public ProjectIdea? ProjectIdea { get; set; }

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ICollection<CommentRating>? CommentRatings { get; set; }
}