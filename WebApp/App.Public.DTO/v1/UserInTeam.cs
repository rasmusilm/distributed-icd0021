using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Public.DTO.v1.Identity;

namespace App.Public.DTO.v1;

public class UserInTeam : DomainEntityId
{
    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid TeamId { get; set; }
    public Team? Team { get; set; }
}