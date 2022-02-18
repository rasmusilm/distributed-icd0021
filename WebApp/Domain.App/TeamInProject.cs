using Domain.App.Base;

namespace Domain.App;

public class TeamInProject : IBaseItem
{
    public Guid Id { get; set; }

    public Guid TeamId { get; set; }
    public Team? Team { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}