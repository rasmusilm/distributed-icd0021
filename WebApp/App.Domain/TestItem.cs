using System.ComponentModel.DataAnnotations.Schema;
using App.Base;

namespace App.Domain;

public class TestItem : Base.IBaseItem
{
    public Guid Id { get; set; }
    [Column(TypeName = "jsonb")]
    public LangStr Name { get; set; } = new();
}