using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using App.Base;
using Base.Domain;

namespace App.Public.DTO.v1;

public class Complexity : DomainEntityId
{
    
    public LangStr Name { get; set; } = new ();
}