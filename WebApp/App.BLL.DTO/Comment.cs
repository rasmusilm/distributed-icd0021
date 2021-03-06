using System.ComponentModel.DataAnnotations;
using App.Base;
using App.BLL.DTO.Identity;
using App.Resourses;
using Base.Domain;

namespace App.BLL.DTO;

public class Comment : DomainEntityId
{
    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.Text))]
    public string? Text { get; set; }

    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.PrjectIdeaId))]
    public Guid ProjectIdeaId { get; set; }
    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.ProjectIdea))]
    public ProjectIdea? ProjectIdea { get; set; }

    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.UserId))]
    public Guid UserId { get; set; }
    [Display(ResourceType = typeof(App.Resourses.App.Domain.Comment),
        Name = nameof(App.Resourses.App.Domain.Comment.User))]
    public User? User { get; set; }
    
    public int Rating { get; set; } = 0;

    public ICollection<CommentRating>? CommentRatings { get; set; }
}