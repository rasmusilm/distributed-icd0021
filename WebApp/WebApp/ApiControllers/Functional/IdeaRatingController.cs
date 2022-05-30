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
    public class IdeaRatingController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public IdeaRatingController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/IdeaRating
        [HttpGet]
        public async Task<IEnumerable<IdeaRating>> GetIdeaRatings()
        {
            return (await _bll.IdeaRatings.GetAllAsync()).Select(rating => 
                _mapper.Map<IdeaRating>(rating));;
        }

        // GET: api/IdeaRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaRating>> GetIdeaRating(Guid id)
        {
            var ideaRating = await _bll.IdeaRatings.FirstOrDefaultAsync(id);

            if (ideaRating == null)
            {
                return NotFound();
            }

            return _mapper.Map<IdeaRating>(ideaRating);
        }

        // PUT: api/IdeaRating/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutIdeaRating(Guid id, IdeaRating ideaRating)
        {
            if (id != ideaRating.Id)
            {
                return BadRequest();
            }

            _bll.IdeaRatings.Update(_mapper.Map<App.BLL.DTO.IdeaRating>(ideaRating));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IdeaRatingExists(id))
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

        // POST: api/IdeaRating
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<IdeaRating>> PostIdeaRating(IdeaRating ideaRating)
        {
            ideaRating.UserId = User.GetUserId();
            Console.WriteLine("AAAAAAAAAAAAAAAAAAAAAAAAAAAA" +
                              "\n\n\n\n\n\nAAAAAAAAAAAAAAAAAAAAAAAAa");
            Console.WriteLine(ideaRating.Rating + "|" + ideaRating.UserId + "==" + User.GetUserId() + "|" + ideaRating.ProjectIdeaId);
            _bll.IdeaRatings.Add(_mapper.Map<App.BLL.DTO.IdeaRating>(ideaRating));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetIdeaRating", new { id = ideaRating.Id }, ideaRating);
        }

        // DELETE: api/IdeaRating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdeaRating(Guid id)
        {
            var ideaRating = await _bll.IdeaRatings.FirstOrDefaultAsync(id);
            if (ideaRating == null)
            {
                return NotFound();
            }

            _bll.IdeaRatings.Remove(ideaRating);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaRatingExists(Guid id)
        {
            return _bll.IdeaRatings.Exists(id);
        }
    }
}
