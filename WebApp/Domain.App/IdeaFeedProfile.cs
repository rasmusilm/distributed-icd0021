using Domain.App.Base;
using Domain.App.Identity;

namespace Domain.App;

public class IdeaFeedProfile : IBaseItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public ICollection<IdeaInfeed>? IdeaInfeeds { get; set; } = default!;
}