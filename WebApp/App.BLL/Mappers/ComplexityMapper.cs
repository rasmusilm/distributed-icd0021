using App.BLL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class ComplexityMapper : BaseMapper<Complexity, DAL.DTO.Complexity>
{
    public ComplexityMapper(IMapper mapper) : base(mapper)
    {
    }
}