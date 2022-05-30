#nullable disable
using App.Contracts.BLL;
using App.DAL.EF;
using App.Public.DTO.v1;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Functional
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class CommentRatingController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public CommentRatingController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/CommentRating
        [HttpGet]
        public async Task<IEnumerable<CommentRating>> GetCommentRatings()
        {
            return (await _bll.CommentRatings.GetAllAsync()).Select(rating => _mapper.Map<CommentRating>(rating));
        }

        // GET: api/CommentRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CommentRating>> GetCommentRating(Guid id)
        {
            var commentRating = await _bll.CommentRatings.FirstOrDefaultAsync(id);

            if (commentRating == null)
            {
                return NotFound();
            }

            return _mapper.Map<CommentRating>(commentRating);
        }

        // PUT: api/CommentRating/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCommentRating(Guid id, CommentRating commentRating)
        {
            if (id != commentRating.Id)
            {
                return BadRequest();
            }

            _bll.CommentRatings.Update(_mapper.Map<App.BLL.DTO.CommentRating>(commentRating));

            try
            {
                await _bll.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CommentRatingExists(id))
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

        // POST: api/CommentRating
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CommentRating>> PostCommentRating(CommentRating commentRating)
        {
            _bll.CommentRatings.Add(_mapper.Map<App.BLL.DTO.CommentRating>(commentRating));
            await _bll.SaveChangesAsync();

            return CreatedAtAction("GetCommentRating", new { id = commentRating.Id }, commentRating);
        }

        // DELETE: api/CommentRating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCommentRating(Guid id)
        {
            var commentRating = await _bll.CommentRatings.FirstOrDefaultAsync(id);
            if (commentRating == null)
            {
                return NotFound();
            }

            _bll.CommentRatings.Remove(commentRating);
            await _bll.SaveChangesAsync();

            return NoContent();
        }

        private bool CommentRatingExists(Guid id)
        {
            return _bll.CommentRatings.Exists(id);
        }
    }
}
