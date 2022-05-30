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
    [Authorize(Roles = "admin, user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdeaFeedProfileController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public IdeaFeedProfileController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/IdeaFeedProfile
        [HttpGet]
        public async Task<IEnumerable<IdeaFeedProfile>> GetIdeaFeedProfiles()
        {
            return (await _bll.IdeaFeedProfiles.GetAllByUser(User.GetUserId())).Select(profile => 
                _mapper.Map<IdeaFeedProfile>(profile));
        }

        // GET: api/IdeaFeedProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaFeedProfile>> GetIdeaFeedProfile(Guid id)
        {
            var ideaFeedProfile = await _bll.IdeaFeedProfiles.FirstOrDefaultAsync(id);
            Console.WriteLine("Owner:" + ideaFeedProfile.UserId);
            Console.WriteLine("User:" + User.GetUserId());

            if (ideaFeedProfile == null || ideaFeedProfile.UserId != User.GetUserId())
            {
                return NotFound();
            }

            return  _mapper.Map<IdeaFeedProfile>(ideaFeedProfile);
        }

        // PUT: api/IdeaFeedProfile/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaFeedProfile(Guid id, IdeaFeedProfile ideaFeedProfile)
        {
            if (id != ideaFeedProfile.Id || ideaFeedProfile.UserId != User.GetUserId())
            {
                return BadRequest();
            }

            _bll.IdeaFeedProfiles.Update(_mapper.Map<App.BLL.DTO.IdeaFeedProfile>(ideaFeedProfile));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaFeedProfileExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/IdeaFeedProfile
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdeaFeedProfile>> PostIdeaFeedProfile(IdeaFeedProfile ideaFeedProfile)
        {
            _bll.IdeaFeedProfiles.Add(_mapper.Map<App.BLL.DTO.IdeaFeedProfile>(ideaFeedProfile));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetIdeaFeedProfile", new { id = ideaFeedProfile.Id }, ideaFeedProfile);
        }

        // DELETE: api/IdeaFeedProfile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdeaFeedProfile(Guid id)
        {
            var ideaFeedProfile = await _bll.IdeaFeedProfiles.FirstOrDefaultAsync(id);
            if (ideaFeedProfile == null || ideaFeedProfile.UserId != User.GetUserId())
            {
                return NotFound();
            }

            _bll.IdeaFeedProfiles.Remove(ideaFeedProfile);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaFeedProfileExists(Guid id)
        {
            return _bll.IdeaFeedProfiles.Exists(id);
        }
    }
}
