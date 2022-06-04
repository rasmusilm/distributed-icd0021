using App.Base;
using Base.Domain;

namespace WebApp.DTO;

public class FooBarDTO : DomainEntityId
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}