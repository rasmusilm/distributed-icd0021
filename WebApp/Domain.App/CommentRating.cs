using Domain.App.Base;
using Domain.App.Identity;

namespace Domain.App;

public class CommentRating : IBaseItem
{
    public Guid Id { get; set; }
    public bool Vote { get; set; } = default!;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid CommentId { get; set; }
    public Comment? Comment { get; set; }
}