using Base.Contracts.Domain;

namespace Base.Domain;

public class DomainEntityId : IDomainEntityId
{
    public Guid Id { get; set; }
}