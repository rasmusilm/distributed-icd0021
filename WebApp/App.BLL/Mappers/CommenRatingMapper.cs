using App.BLL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.BLL.Mappers;

public class CommentRatingMapper: BaseMapper<CommentRating, DAL.DTO.CommentRating>
{
    public CommentRatingMapper(IMapper mapper) : base(mapper)
    {
    }
}