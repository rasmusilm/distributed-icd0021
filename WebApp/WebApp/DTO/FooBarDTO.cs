using App.Domain.Base;

namespace WebApp.DTO;

public class FooBarDTO : IBaseItem
{
    public Guid Id { get; set; }
    public string Name { get; set; } = default!;
}