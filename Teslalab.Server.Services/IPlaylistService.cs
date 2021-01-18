using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teslalab.Repositories;
using Teslalab.Server.Infrastructure;
using Teslalab.Server.Models.Models;
using Teslalab.Shared;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Services
{
    public interface IPlaylistService
    {
        Task<OperationResponse<PlaylistDto>> CreateAsync(PlaylistDto model);

        Task<OperationResponse<PlaylistDto>> UpdateAsync(PlaylistDto model);

        Task<OperationResponse<PlaylistDto>> RemoveAsync(string id);

        //Task<OperationResponse<PlaylistDto>> (PlaylistDto model);
    }

    public class PlaylistService : IPlaylistService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityOptions _identity;

        public PlaylistService(IUnitOfWork unitOfWork, IdentityOptions identity)
        {
            _unitOfWork = unitOfWork;
            _identity = identity;
        }

        public async Task<OperationResponse<PlaylistDto>> CreateAsync(PlaylistDto model)
        {
            var playlist = new Playlist
            {
                Name = model.Name,
                Description = model.Description
            };

            await _unitOfWork.Playlists.CreateAsync(playlist);
            await _unitOfWork.CommitChangesAsync(_identity.UserId);

            model.Id = playlist.Id;

            return new OperationResponse<PlaylistDto>
            {
                IsSuccess = true,
                Message = "Playlist create Successfully",
                Data = model
            };
        }

        public Task<OperationResponse<PlaylistDto>> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse<PlaylistDto>> UpdateAsync(PlaylistDto model)
        {
            throw new NotImplementedException();
        }
    }
}