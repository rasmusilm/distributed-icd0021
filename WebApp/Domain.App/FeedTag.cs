using Domain.App.Base;

namespace Domain.App;

public class FeedTag : IBaseItem
{
    public Guid Id { get; set; }
    
    public Tag? Tag { get; set; }
    public Guid TagId { get; set; }

    public IdeaFeedProfile? IdeaFeedProfile { get; set; }
    public Guid IdeaFeedProfileId { get; set; }
}