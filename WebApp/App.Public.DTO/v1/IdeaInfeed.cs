using System.ComponentModel.DataAnnotations;
using App.Base;

namespace App.Public.DTO.v1;

public class IdeaInfeed : DomainEntityId
{
    
    public IdeaFeedProfile? IdeaFeedProfile { get; set; }
    public Guid IdeaFeedProfileid { get; set; }

    
    public Guid ProjectIdeaId { get; set; }
    public ProjectIdea? ProjectIdea { get; set; }
}