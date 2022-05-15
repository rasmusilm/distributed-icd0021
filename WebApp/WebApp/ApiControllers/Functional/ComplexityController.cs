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
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ComplexityController : ControllerBase
    {
        private readonly IAppBLL _bll;

        public ComplexityController(IAppBLL bll)
        {
            _bll = bll;
        }

        // GET: api/IdeaRating
        [HttpGet]
        public async Task<IEnumerable<Complexity>> GetComplexities()
        {
            // return await _bll.Tags.GetAllAsync();
            return await _bll.Complexity.GetAllAsync();
        }

        // GET: api/IdeaRating/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Complexity>> GetComplexity(Guid id)
        {
            var complexity = await _bll.Complexity.FirstOrDefaultAsync(id);

            if (complexity == null)
            {
                return NotFound();
            }
            
            return complexity;
        }
    }
}
