using App.Domain.Base;
using App.Domain.Enums;
using App.Domain.Identity;

namespace App.Domain;

public class UserInProject : IBaseItem
{
    public Guid Id { get; set; }

    public ERoleInProject RoleInProject { get; set; } = ERoleInProject.Owner;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}