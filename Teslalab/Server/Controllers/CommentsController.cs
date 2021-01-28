using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Teslalab.Server.Services;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly ICommentsService _commentsService;

        public CommentsController(ICommentsService commentsService)
        {
            _commentsService = commentsService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create([FromBody] CommentDto model)
        {
            var result = await _commentsService.CreateAsync(model);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}