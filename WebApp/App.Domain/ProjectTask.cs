using App.Domain.Base;

namespace App.Domain;

public class ProjectTask : IBaseItem
{
    public Guid Id { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Guid ProjectTaskStatusId { get; set; }
    public ProjectTaskStatus? ProjectTaskStatus { get; set; }
}