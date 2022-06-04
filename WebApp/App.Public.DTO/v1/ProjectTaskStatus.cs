using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class ProjectTaskStatus : DomainEntityId
{
    public string Name { get; set; } = default!;
    public string? Description { get; set; }
    
    public ICollection<ProjectTask>? ProjectTasks { get; set; }
}