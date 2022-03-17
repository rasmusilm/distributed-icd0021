using System.ComponentModel.DataAnnotations;
using App.Domain.Base;

namespace App.Domain;

public class TeamInProject : IBaseItem
{
    public Guid Id { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.TeamInProject), Name = nameof(App.Resourses.App.Domain.TeamInProject.TeamId))]
    public Guid TeamId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.TeamInProject), Name = nameof(App.Resourses.App.Domain.TeamInProject.Team))]
    public Team? Team { get; set; }

    [Display( ResourceType = typeof(App.Resourses.App.Domain.TeamInProject), Name = nameof(App.Resourses.App.Domain.TeamInProject.ProjectId))]
    public Guid ProjectId { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.TeamInProject), Name = nameof(App.Resourses.App.Domain.TeamInProject.Project))]
    public Project? Project { get; set; }
}