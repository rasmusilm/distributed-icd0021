using System.ComponentModel.DataAnnotations;
using App.Domain.Base;
using App.Domain.Identity;

namespace App.Domain;

public class UserInTeam : IBaseItem
{
    public Guid Id { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInTeam), Name = nameof(App.Resourses.App.Domain.UserInTeam.Userid))]
    public Guid UserId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInTeam), Name = nameof(App.Resourses.App.Domain.UserInTeam.User))]
    public User? User { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInTeam), Name = nameof(App.Resourses.App.Domain.UserInTeam.TeamId))]
    public Guid TeamId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.UserInTeam), Name = nameof(App.Resourses.App.Domain.UserInTeam.Team))]
    public Team? Team { get; set; }
}