using System.ComponentModel.DataAnnotations;
using App.Base;
using User = App.Public.DTO.v1.Identity.User;

namespace App.Public.DTO.v1;

public class CommentRating : DomainEntityId
{
    public bool Vote { get; set; } = default!;
    
    public Guid UserId { get; set; }
    
    public User? User { get; set; }
    
    
    public Guid CommentId { get; set; }
    
}