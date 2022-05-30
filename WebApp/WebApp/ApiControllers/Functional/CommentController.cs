#nullable disable
using App.Contracts.BLL;
using App.Public.DTO.v1;
using AutoMapper;
using Helpers.WebApp;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace WebApp.ApiControllers.Functional
{
    /// <summary>
    /// 
    /// </summary>
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]")]
    [Authorize(Roles = "admin,user", AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class CommentController : ControllerBase
    {
        private readonly IAppBLL _bll;
        private readonly IMapper _mapper;

        public CommentController(IAppBLL bll, IMapper mapper)
        {
            _bll = bll;
            _mapper = mapper;
        }

        // GET: api/Comment
        [HttpGet]
        public async Task<IEnumerable<Comment>> GetComments()
        {
            return (await _bll.Comments.GetAllByUser(User.GetUserId())).Select(x =>
                _mapper.Map<App.BLL.DTO.Comment, App.Public.DTO.v1.Comment>(x));
        }

        // GET: api/Comment/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Comment>> GetComment(Guid id)
        {
            var comment = await _bll.Comments.FirstOrDefaultAsync(id);

            if (comment == null)
            {
                return NotFound();
            }

            return _mapper.Map<App.BLL.DTO.Comment, App.Public.DTO.v1.Comment>(comment);
        }

        // PUT: api/Comment/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPut("{id}")]
        // public async Task<IActionResult> PutComment(Guid id, Comment comment)
        // {
        //     if (id != comment.Id || comment.UserId != User.GetUserId())
        //     {
        //         return BadRequest();
        //     }
        //
        //     _bll.Comments.Update(comment);
        //
        //     try
        //     {
        //         await _bll.SaveChangesAsync();
        //     }
        //     catch (DbUpdateConcurrencyException)
        //     {
        //         if (!CommentExists(id))
        //         {
        //             return NotFound();
        //         }
        //         else
        //         {
        //             throw;
        //         }
        //     }
        //
        //     return NoContent();
        // }
        //
        // // POST: api/Comment
        // // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        // [HttpPost]
        // public async Task<ActionResult<Comment>> PostComment(Comment comment)
        // {
        //     _bll.Comments.Add(comment);
        //     await _bll.SaveChangesAsync();
        //
        //     return CreatedAtAction("GetComment", new { id = comment.Id }, comment);
        // }
        //
        // // DELETE: api/Comment/5
        // [HttpDelete("{id}")]
        // public async Task<IActionResult> DeleteComment(Guid id)
        // {
        //     var comment = await _bll.Comments.FirstOrDefaultAsync(id);
        //     if (comment == null)
        //     {
        //         return NotFound();
        //     }
        //
        //     _bll.Comments.Remove(comment);
        //     await _bll.SaveChangesAsync();
        //
        //     return NoContent();
        // }
        //
        // private bool CommentExists(Guid id)
        // {
        //     return _bll.Comments.Exists(id);
        // }
    }
}
