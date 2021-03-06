using System.ComponentModel.DataAnnotations;
using App.Base;
using App.BLL.DTO.Identity;
using Base.Domain;


namespace App.BLL.DTO;

public class CommentRating : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.CommentRating), Name = nameof(App.Resourses.App.Domain.CommentRating.Vote))]
    public bool Vote { get; set; } = default!;
    [Display( ResourceType = typeof(App.Resourses.App.Domain.CommentRating), Name = nameof(App.Resourses.App.Domain.CommentRating.UserId))]
    public Guid UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.CommentRating), Name = nameof(App.Resourses.App.Domain.CommentRating.User))]
    public User? User { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.CommentRating), Name = nameof(App.Resourses.App.Domain.CommentRating.Commentid))]
    public Guid CommentId { get; set; }
    
}