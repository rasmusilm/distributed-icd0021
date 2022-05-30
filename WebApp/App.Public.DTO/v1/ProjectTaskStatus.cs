using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.Public.DTO.v1;

public class ProjectTaskStatus : DomainEntityId
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    
    public ICollection<ProjectTask>? ProjectTasks { get; set; }
}