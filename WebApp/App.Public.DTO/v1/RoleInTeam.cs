using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Public.DTO.v1.Identity;

namespace App.Public.DTO.v1;

public class RoleInTeam : DomainEntityId
{
    public string? Name { get; set; }
    
    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}