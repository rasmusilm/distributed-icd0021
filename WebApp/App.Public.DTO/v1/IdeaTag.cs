using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class IdeaTag : DomainEntityId
{
    
    public Guid ProjectIdeaId { get; set; }

    public Guid TagId { get; set; }
    public Tag? Tag { get; set; } = default!;
}