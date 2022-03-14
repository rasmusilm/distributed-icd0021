using System.ComponentModel.DataAnnotations;
using App.Domain.Base;

namespace App.Domain;

public class Complexity : IBaseItem
{
    public Guid Id { get; set; }
    public string? Name { get; set; } = default!;

    public ICollection<ProjectIdea>? ProjectIdeas { get; set; } = default!;
}