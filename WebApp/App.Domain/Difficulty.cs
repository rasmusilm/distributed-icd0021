using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;
using App.Domain.Base;

namespace App.Domain;

public class Difficulty : IBaseItem
{
    public Guid Id { get; set; }
    
    [Display( ResourceType = typeof(App.Resourses.App.Domain.Difficulty), Name = nameof(App.Resourses.App.Domain.Difficulty.Name))]
    [Column(TypeName = "jsonb")]
    public LangStr Name { get; set; } = new ();

    public ICollection<ProjectIdea>? ProjectIdeas { get; set; } = default!;
}