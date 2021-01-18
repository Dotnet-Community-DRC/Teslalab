using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Teslalab.Server.Models.Models;

namespace Teslalab.Repositories
{
    public interface IPlaylistRepository
    {
        Task CreateAsync(Playlist playlist);

        void Remove(Playlist playlist);

        IEnumerable<Playlist> GetAll();

        Task<Playlist> GetPlaylistById(string id);
    }

    public class PlaylistRepository : IPlaylistRepository
    {
        private readonly ApplicationDbContext _db;

        public PlaylistRepository(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task CreateAsync(Playlist playlist)
        {
            await _db.Playlists.AddAsync(playlist);
        }

        public IEnumerable<Playlist> GetAll()
        {
            return _db.Playlists;
        }

        public async Task<Playlist> GetPlaylistById(string id)
        {
            return await _db.Playlists.FindAsync(id);
        }

        public void Remove(Playlist playlist)
        {
            _db.Playlists.Remove(playlist);
        }
    }
}