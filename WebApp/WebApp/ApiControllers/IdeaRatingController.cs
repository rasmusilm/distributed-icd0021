#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using App.Domain;
using DAL.App;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IdeaRatingController : ControllerBase
    {
        private readonly AppUOW _unitOfWork;

        public IdeaRatingController(ApplicationDbContext context)
        {
            _unitOfWork = new AppUOW(context);
        }

        // GET: api/IdeaRating
        [HttpGet]
        public async Task<IEnumerable<IdeaRating>> GetIdeaRatings()
        {
            return await _unitOfWork.IdeaRatings.GetAllAsync();
        }

        // GET: api/IdeaRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaRating>> GetIdeaRating(Guid id)
        {
            var ideaRating = await _unitOfWork.IdeaRatings.FirstOrDefaultAsync(id);

            if (ideaRating == null)
            {
                return NotFound();
            }

            return ideaRating;
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

            _unitOfWork.IdeaRatings.Update(ideaRating);

            try
            {
                await _unitOfWork.SaveChangesAsync();
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
            _unitOfWork.IdeaRatings.Add(ideaRating);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetIdeaRating", new { id = ideaRating.Id }, ideaRating);
        }

        // DELETE: api/IdeaRating/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdeaRating(Guid id)
        {
            var ideaRating = await _unitOfWork.IdeaRatings.FirstOrDefaultAsync(id);
            if (ideaRating == null)
            {
                return NotFound();
            }

            _unitOfWork.IdeaRatings.Remove(ideaRating);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaRatingExists(Guid id)
        {
            return _unitOfWork.IdeaRatings.Exists(id);
        }
    }
}
