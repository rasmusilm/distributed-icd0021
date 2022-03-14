using App.Domain.Base;

namespace App.Domain;

public class Tag : IBaseItem
{
    public Guid Id { get; set; }
    public string Tagname { get; set; } = default!;

    public ICollection<IdeaTag>? IdeaTags { get; set; }
    public ICollection<FeedTag>? FeedTags { get; set; }
}