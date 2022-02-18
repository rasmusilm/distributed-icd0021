using Domain.App.Base;
using Domain.App.Identity;

namespace Domain.App;

public class RoleInTeam : IBaseItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    
    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}