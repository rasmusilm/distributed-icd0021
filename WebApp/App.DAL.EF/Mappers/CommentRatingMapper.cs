using App.DAL.DTO;
using AutoMapper;
using Base.DAL;

namespace App.DAL.EF.Mappers;

public class CommentRatingMapper : BaseMapper<CommentRating, App.Domain.CommentRating>
{
    public CommentRatingMapper(IMapper mapper) : base(mapper)
    {
    }
}