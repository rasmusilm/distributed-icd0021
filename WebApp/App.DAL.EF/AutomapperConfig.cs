using AutoMapper;

namespace App.DAL.EF;

public class AutomapperConfig : Profile
{
    public AutomapperConfig()
    {
        CreateMap<App.DAL.DTO.ProjectIdea, App.Domain.ProjectIdea>().ReverseMap();
        CreateMap<App.DAL.DTO.IdeaFeedProfile, App.Domain.IdeaFeedProfile>().ReverseMap();
        CreateMap<App.DAL.DTO.IdeaRating, App.Domain.IdeaRating>().ReverseMap();
        CreateMap<App.DAL.DTO.Identity.User, App.Domain.Identity.User>().ReverseMap();
        CreateMap<App.DAL.DTO.Tag, App.Domain.Tag>().ReverseMap();
        CreateMap<App.DAL.DTO.FeedTag, App.Domain.FeedTag>().ReverseMap();
        CreateMap<App.DAL.DTO.IdeaTag, App.Domain.IdeaTag>().ReverseMap();
        CreateMap<App.DAL.DTO.Comment, App.Domain.Comment>().ReverseMap();
        CreateMap<App.DAL.DTO.CommentRating, App.Domain.CommentRating>().ReverseMap();
        CreateMap<App.DAL.DTO.Difficulty, App.Domain.Difficulty>().ReverseMap();
        CreateMap<App.DAL.DTO.Complexity, App.Domain.Complexity>().ReverseMap();
    }
}
