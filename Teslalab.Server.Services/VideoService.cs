using System;
using System.Linq;
using System.Threading.Tasks;
using Teslalab.Repositories;
using Teslalab.Server.Infrastructure;
using Teslalab.Server.Models.Models;
using Teslalab.Server.Services.Utilities;
using Teslalab.Shared;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Services
{
    public class VideoService : IVideoService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IdentityOptions _identity;

        private readonly EnvironmentOptions _env;
        private readonly IFileStorageService _storage;

        public VideoService(IUnitOfWork unitOfWork,
                            IdentityOptions identity,
                            IFileStorageService storage,
                            EnvironmentOptions env)
        {
            _unitOfWork = unitOfWork;
            _identity = identity;
            _storage = storage;
            _env = env;
        }

        public async Task<OperationResponse<VideoDto>> CreateAsync(VideoDto model)
        {
            // Validation
            var similarVideo = await _unitOfWork.Videos.GetByTitleAsync(model.Title);
            if (similarVideo != null)
                return new OperationResponse<VideoDto>
                {
                    IsSuccess = false,
                    Message = "Failed to create the video, another one has the same title"
                };

            if (model.ThumbFile == null)
                return new OperationResponse<VideoDto>
                {
                    IsSuccess = false,
                    Message = "Thump image is required"
                };

            string thumpUrl = string.Empty;

            try
            {
                thumpUrl = await _storage.SaveFileAsync(model.ThumbFile, "Uploads");
            }
            catch (BadImageFormatException)
            {
                return new OperationResponse<VideoDto>
                {
                    IsSuccess = false,
                    Message = "Please upload a valid image file"
                };
            }

            var video = new Video
            {
                Category = model.Category,
                Description = model.Description,
                Likes = 0,
                Views = 0,
                Privacy = model.Privacy,
                ThumpUrl = thumpUrl,
                Title = model.Title,
                VideoUrl = model.VideoUrl,
                PublishedDate = model.PublishedDate,
                Tags = model.Tags?.Select(t => new Tag
                {
                    Name = t,
                }).ToList(),
            };

            await _unitOfWork.Videos.CreateAsync(video);
            await _unitOfWork.CommitChangesAsync(_identity.UserId);

            model.Id = video.Id;
            model.ThumbFile = null;
            // TODO: Get the URL of the running API and replace the hardcoded one
            model.ThumpUrl = $"{_env.ApiUrl}/{thumpUrl}";

            return new OperationResponse<VideoDto>
            {
                IsSuccess = true,
                Message = "Video has been created successfully!",
                Data = model
            };
        }

        public CollectionResponse<VideoDto> GetAllVideos(int pageNumber = 1, int pageSize = 10)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse<VideoDto>> RemoveAsync(string id)
        {
            throw new NotImplementedException();
        }

        public Task<OperationResponse<VideoDto>> UpdateAsync(VideoDto model)
        {
            throw new NotImplementedException();
        }
    }
}