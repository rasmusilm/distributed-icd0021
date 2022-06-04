using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class Tag : DomainEntityId
{
    [Column(TypeName = "jsonb")]
    public LangStr Tagname { get; set; } = new ();
}