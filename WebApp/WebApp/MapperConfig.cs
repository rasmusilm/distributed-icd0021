using App.Public.DTO.v1;
using App.Public.DTO.v1.Identity;
using AutoMapper;

namespace WebApp;

public class MapperConfig: Profile
{
    public MapperConfig()
    {
        CreateMap<ProjectIdea, App.BLL.DTO.ProjectIdea>().ReverseMap();
        CreateMap<IdeaFeedProfile, App.BLL.DTO.IdeaFeedProfile>().ReverseMap();
        CreateMap<IdeaRating, App.BLL.DTO.IdeaRating>().ReverseMap();
        CreateMap<User, App.BLL.DTO.Identity.User>().ReverseMap();
        CreateMap<Tag, App.BLL.DTO.Tag>().ReverseMap();
        CreateMap<FeedTag, App.BLL.DTO.FeedTag>().ReverseMap();
        CreateMap<IdeaTag, App.BLL.DTO.IdeaTag>().ReverseMap();
        CreateMap<Comment, App.BLL.DTO.Comment>().ReverseMap();
        CreateMap<CommentRating, App.BLL.DTO.CommentRating>().ReverseMap();
        CreateMap<Difficulty, App.BLL.DTO.Difficulty>().ReverseMap();
        CreateMap<Complexity, App.BLL.DTO.Complexity>().ReverseMap();
    }
    
}