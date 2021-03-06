using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;
using Base.Domain;

namespace App.DAL.DTO;

public class Tag : DomainEntityId
{
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Tag), Name = nameof(Tagname))]
    [Column(TypeName = "jsonb")]
    public LangStr Tagname { get; set; } = new ();

    public ICollection<IdeaTag>? IdeaTags { get; set; }
    public ICollection<FeedTag>? FeedTags { get; set; }
}