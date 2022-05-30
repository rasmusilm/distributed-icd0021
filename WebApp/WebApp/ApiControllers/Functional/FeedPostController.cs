#nullable disable
using App.Public.DTO.v1;
using App.Contracts.BLL;
using AutoMapper;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Functional
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FeedPostController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public FeedPostController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/ProjectIdea/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ProjectIdea>> GetProjectIdeas(Guid id)
        {
            var ideaFeedProfile = await _bll.IdeaFeedProfiles.FirstOrDefaultAsync(id);
            Console.WriteLine(ideaFeedProfile!.Id);
            Console.WriteLine(ideaFeedProfile.FeedTags!.Count);
            Console.WriteLine(ideaFeedProfile.TagIds.Count);

            return (await _bll.ProjectIdeas.GetAllFromFeed(ideaFeedProfile!.TagIds.ToList())).Select(x =>
                _mapper.Map<App.BLL.DTO.ProjectIdea, ProjectIdea>(x));
        }

        
    }
}
