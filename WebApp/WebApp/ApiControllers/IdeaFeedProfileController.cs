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
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;

namespace WebApp.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class IdeaFeedProfileController : ControllerBase
    {
        private readonly AppUOW _unitOfWork;

        public IdeaFeedProfileController(ApplicationDbContext context)
        {
            _unitOfWork = new AppUOW(context);
        }

        // GET: api/IdeaFeedProfile
        [HttpGet]
        public async Task<IEnumerable<IdeaFeedProfile>> GetIdeaFeedProfiles()
        {
            return _unitOfWork.IdeaFeedProfiles.GetAllByUser(User.GetUserId());
        }

        // GET: api/IdeaFeedProfile/5
        [HttpGet("{id}")]
        public async Task<ActionResult<IdeaFeedProfile>> GetIdeaFeedProfile(Guid id)
        {
            var ideaFeedProfile = await _unitOfWork.IdeaFeedProfiles.FirstOrDefaultAsync(id);

            if (ideaFeedProfile == null || ideaFeedProfile.UserId != User.GetUserId())
            {
                return NotFound();
            }

            return ideaFeedProfile;
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

            _unitOfWork.IdeaFeedProfiles.Update(ideaFeedProfile);

            try
            {
                await _unitOfWork.SaveChangesAsync();
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
            _unitOfWork.IdeaFeedProfiles.Add(ideaFeedProfile);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetIdeaFeedProfile", new { id = ideaFeedProfile.Id }, ideaFeedProfile);
        }

        // DELETE: api/IdeaFeedProfile/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteIdeaFeedProfile(Guid id)
        {
            var ideaFeedProfile = await _unitOfWork.IdeaFeedProfiles.FirstOrDefaultAsync(id);
            if (ideaFeedProfile == null || ideaFeedProfile.UserId != User.GetUserId())
            {
                return NotFound();
            }

            _unitOfWork.IdeaFeedProfiles.Remove(ideaFeedProfile);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool IdeaFeedProfileExists(Guid id)
        {
            return _unitOfWork.IdeaFeedProfiles.Exists(id);
        }
    }
}
