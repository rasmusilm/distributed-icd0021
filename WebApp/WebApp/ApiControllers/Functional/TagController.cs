#nullable disable
using App.Public.DTO.v1;
using App.Contracts.BLL;
using AutoMapper;
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
    public class TagController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public TagController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/IdeaRating
        [HttpGet]
        public async Task<IEnumerable<Tag>> GetTags()
        {
            return (await _bll.Tags.GetAllAsync()).Select(tag => 
                _mapper.Map<Tag>(tag));
        }

        // GET: api/IdeaRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Tag>> GetTag(Guid id)
        {
            var tag = await _bll.Tags.FirstOrDefaultAsync(id);

            if (tag == null)
            {
                return NotFound();
            }

            return _mapper.Map<Tag>(tag);
        }

        // POST: api/IdeaRating
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Tag>> PostTag(Tag tag)
        {
            _bll.Tags.Add(_mapper.Map<App.BLL.DTO.Tag>(tag));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetTag", new { id = tag.Id }, tag);
        }
    }
}
