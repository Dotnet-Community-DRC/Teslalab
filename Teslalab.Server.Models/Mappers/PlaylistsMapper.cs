using System;
using System.Collections.Generic;
using System.Text;
using Teslalab.Server.Models.Models;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Models.Mappers
{
    public static class PlaylistsMapper
    {
        public static PlaylistDto ToPlaylistDto(this Playlist playlist)
        {
            return new PlaylistDto
            {
                Id = playlist.Id,
                Name = playlist.Name,
                Description = playlist.Description
            };
        }
    }
}