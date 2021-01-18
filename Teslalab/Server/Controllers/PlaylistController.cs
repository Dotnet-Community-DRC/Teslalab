using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Teslalab.Server.Services;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PlaylistController : ControllerBase
    {
        private readonly IPlaylistService _playlistService;

        public PlaylistController(IPlaylistService playlistService)
        {
            _playlistService = playlistService;
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(PlaylistDto model)
        {
            var result = await _playlistService.CreateAsync(model);
            if (result.IsSuccess)
                return Ok(result);

            return BadRequest(result);
        }
    }
}