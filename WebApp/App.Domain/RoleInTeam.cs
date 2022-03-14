using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class RoleInTeam : IBaseItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    
    public Guid? TeamId { get; set; }
    public Team? Team { get; set; }
    
    public Guid? UserId { get; set; }
    public User? User { get; set; }
}