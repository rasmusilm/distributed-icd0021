using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Identity;
using Base.Domain;
using User = App.DAL.DTO.Identity.User;

namespace App.DAL.DTO;

public class IdeaFeedProfile : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaFeedProfile), Name = nameof(App.Resourses.App.Domain.IdeaFeedProfile.Name))]
    public string Name { get; set; } = default!;
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaFeedProfile), Name = nameof(App.Resourses.App.Domain.IdeaFeedProfile.UserId))]
    public Guid UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.IdeaFeedProfile), Name = nameof(App.Resourses.App.Domain.IdeaFeedProfile.User))]
    public User? User { get; set; }
    
    public ICollection<FeedTag>? FeedTags { get; set; } = default!;

    public ICollection<IdeaInfeed>? IdeaInfeeds { get; set; } = default!;
}