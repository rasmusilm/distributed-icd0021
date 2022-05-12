#nullable disable
using App.Contracts.BLL;
using App.DAL.EF;
using App.BLL.DTO;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Functional
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostCommentController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public PostCommentController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/PostComment/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Comment>> GetComments(Guid id)
        {
            return await _bll.Comments.GetAllOnPost(id);
        }
    }
}
