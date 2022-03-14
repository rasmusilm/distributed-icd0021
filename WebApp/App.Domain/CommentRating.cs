using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class CommentRating : IBaseItem
{
    public Guid Id { get; set; }
    public bool Vote { get; set; } = default!;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid CommentId { get; set; }
    public Comment? Comment { get; set; }
}