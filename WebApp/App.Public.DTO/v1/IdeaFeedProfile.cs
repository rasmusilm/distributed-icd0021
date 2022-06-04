using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;
using User = App.Public.DTO.v1.Identity.User;

namespace App.Public.DTO.v1;

public class IdeaFeedProfile : DomainEntityId
{
    public string Name { get; set; } = default!;
    
    public Guid UserId { get; set; }
    
    public User? User { get; set; }

    public ICollection<IdeaInfeed>? IdeaInfeeds { get; set; } = default!;
    
    public ICollection<FeedTag>? FeedTags { get; set; } = default!;
    
    public ICollection<Guid> TagIds { get; set; } = new List<Guid>();
}