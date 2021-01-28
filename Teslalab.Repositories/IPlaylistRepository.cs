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
}