using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Public.DTO.v1.Identity;

namespace App.Public.DTO.v1;

public class Comment : DomainEntityId
{
    public string? Text { get; set; }
    
    public Guid ProjectIdeaId { get; set; }
    
    public ProjectIdea? ProjectIdea { get; set; }
    
    
    public Guid UserId { get; set; }
    
    public User? User { get; set; }
    
    
    public int Rating { get; set; } = 0;

    public ICollection<CommentRating>? CommentRatings { get; set; }
}