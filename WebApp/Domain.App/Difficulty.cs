using System.ComponentModel.DataAnnotations;
using Domain.App.Base;

namespace Domain.App;

public class Difficulty : IBaseItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = default!;

    public ICollection<ProjectIdea>? ProjectIdeas { get; set; } = default!;
}