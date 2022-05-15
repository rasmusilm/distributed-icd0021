using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class ComplexityMapper : BaseMapper<Complexity, Domain.Complexity>
{
    public ComplexityMapper(IMapper mapper) : base(mapper)
    {
    }
}