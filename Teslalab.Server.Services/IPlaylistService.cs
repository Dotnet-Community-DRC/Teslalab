using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teslalab.Repositories;
using Teslalab.Server.Infrastructure;
using Teslalab.Server.Models.Mappers;
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

        CollectionResponse<PlaylistDto> GetAllPlaylists(int pageNumber = 1, int pageSize = 10);
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

        public CollectionResponse<PlaylistDto> GetAllPlaylists(int pageNumber = 1, int pageSize = 10)
        {
            //Validation

            if (pageNumber < 1)
                pageNumber = 1;

            if (pageSize < 5)
                pageSize = 5;

            if (pageSize > 50)
                pageSize = 50;

            var playlists = _unitOfWork.Playlists.GetAll();

            int playlistCount = playlists.Count();

            var playlistsInRange = playlists
                        .Skip((pageNumber - 1) * pageSize)
                        .Take(pageSize)
                        .Select(p => p.ToPlaylistDto());

            int pagesCount = playlistCount / pageSize;
            if ((playlistCount & pageSize) != 0)
                pagesCount++;

            return new CollectionResponse<PlaylistDto>
            {
                IsSuccess = true,
                Message = "Playlists retrieved successfully!",
                Records = playlistsInRange.ToArray(),
                PageNumber = pageNumber,
                PageSize = pageSize,
                PagesCount = pagesCount
            };
        }

        public async Task<OperationResponse<PlaylistDto>> RemoveAsync(string id)
        {
            var playlist = await _unitOfWork.Playlists.GetPlaylistById(id);

            if (playlist == null)
                return new OperationResponse<PlaylistDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Playlist not found"
                };

            _unitOfWork.Playlists.Remove(playlist);

            await _unitOfWork.CommitChangesAsync(_identity.UserId);

            return new OperationResponse<PlaylistDto>
            {
                IsSuccess = true,
                Message = "Playlist has been deleted successfully!",
                Data = playlist.ToPlaylistDto()
            };
        }

        public async Task<OperationResponse<PlaylistDto>> UpdateAsync(PlaylistDto model)
        {
            var playlist = await _unitOfWork.Playlists.GetPlaylistById(model.Id);

            if (playlist == null)
                return new OperationResponse<PlaylistDto>
                {
                    IsSuccess = false,
                    Data = null,
                    Message = "Playlist not found"
                };
            playlist.Name = model.Name;
            playlist.Description = model.Description;

            await _unitOfWork.CommitChangesAsync(_identity.UserId);

            return new OperationResponse<PlaylistDto>
            {
                IsSuccess = true,
                Message = "Playlist has been updated successfully!",
                Data = model,
            };
        }
    }
}