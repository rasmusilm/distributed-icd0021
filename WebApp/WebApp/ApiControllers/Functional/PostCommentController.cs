#nullable disable
using App.Contracts.BLL;
using App.DAL.EF;
using App.Public.DTO.v1;
using AutoMapper;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.ApiControllers.Functional
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class PostCommentController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public PostCommentController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/PostComment/5
        [HttpGet("{id}")]
        public async Task<IEnumerable<Comment>> GetComments(Guid id)
        {
            return (await _bll.Comments.GetAllOnPost(id)).Select(comment => _mapper.Map<Comment>(comment));
        }
    }
}
