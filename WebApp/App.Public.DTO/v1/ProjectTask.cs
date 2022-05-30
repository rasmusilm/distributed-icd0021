using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.Public.DTO.v1;

public class ProjectTask : DomainEntityId
{
    
    public string? Title { get; set; }
    public string? Description { get; set; }

    public Guid ProjectTaskStatusId { get; set; }
    public ProjectTaskStatus? ProjectTaskStatus { get; set; }
}