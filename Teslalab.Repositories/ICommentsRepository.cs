using System.Collections.Generic;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public interface ICommentsRepository
    {
        Task CreateAsync(Comment comment);

        void Remove(Comment comment);

        IEnumerable<Comment> GetAllForVideo(string videoId);

        Task<Comment> GetByIdAsync(string commentId);
    }
}