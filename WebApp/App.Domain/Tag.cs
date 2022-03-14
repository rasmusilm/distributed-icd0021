using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;

namespace App.Domain;

public class Tag : Base.IBaseItem
{
    public Guid Id { get; set; }
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Tag), Name = nameof(Tagname))]
    [Column(TypeName = "jsonb")]
    public LangStr Tagname { get; set; } = new ();

    public ICollection<IdeaTag>? IdeaTags { get; set; }
    public ICollection<FeedTag>? FeedTags { get; set; }
}