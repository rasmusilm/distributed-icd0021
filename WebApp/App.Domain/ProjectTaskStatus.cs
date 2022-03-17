using App.Domain.Base;

namespace App.Domain;

public class ProjectTaskStatus : IBaseItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    
    public ICollection<ProjectTask>? ProjectTasks { get; set; }
}