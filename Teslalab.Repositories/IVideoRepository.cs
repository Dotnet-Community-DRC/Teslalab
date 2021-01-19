using System.Collections.Generic;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public interface IVideoRepository
    {
        Task CreateAsync(Video video);

        void Remove(Video video);

        IEnumerable<Video> GetAll();

        Task<Video> GetByTitleAsync(string name);

        Task<Video> GetByIdAsync(string id);

        void RemoveTags(Video video);
    }
}