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
    public class ComplexityController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public ComplexityController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/IdeaRating
        [HttpGet]
        public async Task<IEnumerable<Complexity>> GetComplexities()
        {
            // return await _bll.Tags.GetAllAsync();
            return (await _bll.Complexity.GetAllAsync()).Select(comp => _mapper.Map<Complexity>(comp));
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
            
            return _mapper.Map<Complexity>(complexity);
        }
    }
}
