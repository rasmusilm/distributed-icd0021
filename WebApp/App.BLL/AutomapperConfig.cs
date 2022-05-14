using App.BLL.DTO;
using AutoMapper;

namespace App.BLL;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<App.BLL.DTO.ProjectIdea, App.DAL.DTO.ProjectIdea>().ReverseMap();
        CreateMap<App.BLL.DTO.IdeaFeedProfile, App.DAL.DTO.IdeaFeedProfile>().ReverseMap();
        CreateMap<App.BLL.DTO.IdeaRating, App.DAL.DTO.IdeaRating>().ReverseMap();
        CreateMap<App.BLL.DTO.Identity.User, App.DAL.DTO.Identity.User>().ReverseMap();
        CreateMap<Tag, DAL.DTO.Tag>().ReverseMap();
        CreateMap<FeedTag, DAL.DTO.FeedTag>().ReverseMap();
        CreateMap<IdeaTag, DAL.DTO.IdeaTag>().ReverseMap();
        CreateMap<Comment, DAL.DTO.Comment>().ReverseMap();
        CreateMap<CommentRating, DAL.DTO.CommentRating>().ReverseMap();
        CreateMap<Difficulty, DAL.DTO.Difficulty>().ReverseMap();
        CreateMap<Complexity, DAL.DTO.Complexity>().ReverseMap();
    }
}
