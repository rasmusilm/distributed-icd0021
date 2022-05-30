using System.ComponentModel.DataAnnotations;
using App.Base;
using App.Domain.Enums;
using App.Public.DTO.v1.Identity;

namespace App.Public.DTO.v1;

public class UserInProject : DomainEntityId
{

    public ERoleInProject RoleInProject { get; set; } = ERoleInProject.Owner;

    public Guid UserId { get; set; }
    
    public User? User { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}