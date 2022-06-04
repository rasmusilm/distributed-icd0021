using System.ComponentModel.DataAnnotations.Schema;
using App.Base;
using Base.Domain;

namespace App.Domain;

public class TestItem : DomainEntityId
{
    [Column(TypeName = "jsonb")]
    public LangStr Name { get; set; } = new();
}