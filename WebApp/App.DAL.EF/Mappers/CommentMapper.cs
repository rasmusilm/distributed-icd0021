using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class CommentMapper : BaseMapper<Comment, App.Domain.Comment>
{
    public CommentMapper(IMapper mapper) : base(mapper)
    {
    }
}