using System.ComponentModel.DataAnnotations;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class FeedTag : DomainEntityId
{
    
    public Tag? Tag { get; set; }
    
    public Guid TagId { get; set; }
    
    
    public Guid IdeaFeedProfileId { get; set; }
}