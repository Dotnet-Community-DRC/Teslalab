using AutoMapper;
using System.Linq;
using Teslalab.Server.Infrastructure;
using Teslalab.Server.Models.Models;
using Teslalab.Shared.DTOs;

namespace Teslalab.Server.Models.Profiles
{
    public class VideoProfile : Profile
    {
        public VideoProfile(EnvironmentOptions env)
        {
            CreateMap<Video, VideoDto>()
                .ForMember(dest => dest.Tags, map => map.MapFrom(v => v.Tags.Select(t => t.Name).ToList()))
                .ForMember(dest => dest.ThumpUrl, map => map.MapFrom(v => $"{env.ApiUrl}/{v.ThumpUrl}"));
        }
    }
}