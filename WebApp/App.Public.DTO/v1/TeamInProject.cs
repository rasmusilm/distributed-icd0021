using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class TeamInProject : DomainEntityId
{

    public Guid TeamId { get; set; }
    public Team? Team { get; set; }

    public Guid ProjectId { get; set; }
    public Project? Project { get; set; }
}