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
    public class ProjectIdeaController : ControllerBase
    {
        private readonly AppUOW _unitOfWork;

        public ProjectIdeaController(ApplicationDbContext context)
        {
            _unitOfWork = new AppUOW(context);
        }

        // GET: api/ProjectIdea
        [HttpGet]
        public async Task<IEnumerable<ProjectIdea>> GetProjectIdeas()
        {
            return await _unitOfWork.ProjectIdeas.GetAllAsync();
        }

        // GET: api/ProjectIdea/5
        [HttpGet("{id}")]
        public async Task<ActionResult<ProjectIdea>> GetProjectIdea(Guid id)
        {
            var projectIdea = await _unitOfWork.ProjectIdeas.FirstOrDefaultAsync(id);

            if (projectIdea == null)
            {
                return NotFound();
            }

            return projectIdea;
        }

        // PUT: api/ProjectIdea/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutProjectIdea(Guid id, ProjectIdea projectIdea)
        {
            if (id != projectIdea.Id)
            {
                return BadRequest();
            }

            _unitOfWork.ProjectIdeas.Update(projectIdea);

            try
            {
                await _unitOfWork.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ProjectIdeaExists(id))
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

        // POST: api/ProjectIdea
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<ProjectIdea>> PostProjectIdea(ProjectIdea projectIdea)
        {
            _unitOfWork.ProjectIdeas.Add(projectIdea);
            await _unitOfWork.SaveChangesAsync();

            return CreatedAtAction("GetProjectIdea", new { id = projectIdea.Id }, projectIdea);
        }

        // DELETE: api/ProjectIdea/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProjectIdea(Guid id)
        {
            var projectIdea = await _unitOfWork.ProjectIdeas.FirstOrDefaultAsync(id);
            if (projectIdea == null)
            {
                return NotFound();
            }

            _unitOfWork.ProjectIdeas.Remove(projectIdea);
            await _unitOfWork.SaveChangesAsync();

            return NoContent();
        }

        private bool ProjectIdeaExists(Guid id)
        {
            return _unitOfWork.ProjectIdeas.Exists(id);
        }
    }
}
