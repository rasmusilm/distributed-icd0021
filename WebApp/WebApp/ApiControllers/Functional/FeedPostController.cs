#nullable disable
using App.BLL.DTO;
using App.Contracts.BLL;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Functional
{
    [Route("/api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FeedPostController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public FeedPostController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/ProjectIdea/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<ProjectIdea>> GetProjectIdeas(Guid id)
        {
            var ideaFeedProfile = await _bll.IdeaFeedProfiles.FirstOrDefaultAsync(id);
            Console.WriteLine(ideaFeedProfile!.Id);
            Console.WriteLine(ideaFeedProfile.FeedTags!.Count);
            Console.WriteLine(ideaFeedProfile.TagIds.Count);

            return await _bll.ProjectIdeas.GetAllFromFeed(ideaFeedProfile!.TagIds.ToList());
        }

        
    }
}
