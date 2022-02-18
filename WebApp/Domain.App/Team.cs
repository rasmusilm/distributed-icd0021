using Domain.App.Base;

namespace Domain.App;

public class Team : IBaseItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; }

    public ICollection<UserInTeam>? UserInTeams { get; set; }
    public ICollection<TeamInProject>? TeamInProjects { get; set; }
}