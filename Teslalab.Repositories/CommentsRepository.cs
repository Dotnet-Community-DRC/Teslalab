using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public class CommentsRepository : ICommentsRepository
    {
        private readonly ApplicationDbContext _db;

        public CommentsRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Comment comment)
        {
            await _db.Comments.AddAsync(comment);
        }

        public IEnumerable<Comment> GetAllForVideo(string videoId)
        {
            return _db.Comments
                           .Include(c => c.CreatedUser)
                           .Include(c => c.Replies)
                           .ThenInclude(r => r.CreatedUser)
                           .Where(c => c.VideoId == videoId && c.ParentComment == null);
        }

        public async Task<Comment> GetByIdAsync(string commentId)
        {
            return await _db.Comments.
                            Include(c => c.CreatedUser)
                           .Include(c => c.Replies)
                           .ThenInclude(r => r.CreatedUser)
                           .SingleOrDefaultAsync(c => c.Id == commentId);
        }

        public void Remove(Comment comment)
        {
            if (comment.Replies != null && comment.Replies.Any())
                _db.Comments.RemoveRange(comment.Replies);

            _db.Comments.Remove(comment);
        }
    }
}