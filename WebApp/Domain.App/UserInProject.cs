using Domain.App.Base;
using Domain.App.Enums;
using Domain.App.Identity;

namespace Domain.App;

public class UserInProject : IBaseItem
{
    public Guid Id { get; set; }

    public ERoleInProject RoleInProject { get; set; } = ERoleInProject.Owner;

    public Guid UserId { get; set; }
    public User? User { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}