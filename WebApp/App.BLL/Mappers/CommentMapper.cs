using App.BLL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class CommentMapper : BaseMapper<Comment, DAL.DTO.Comment>
{
    public CommentMapper(IMapper mapper) : base(mapper)
    {
    }
}