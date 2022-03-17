using System.ComponentModel.DataAnnotations;
using App.Domain.Base;

namespace App.Domain;

public class Team : IBaseItem
{
    public Guid Id { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Team), Name = nameof(App.Resourses.App.Domain.Team.Name))]
    public string? Name { get; set; }

    public ICollection<UserInTeam>? UserInTeams { get; set; }
    public ICollection<TeamInProject>? TeamInProjects { get; set; }
}