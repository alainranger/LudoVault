using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LudoVault.Core.Models;

namespace LudoVault.Core.Contracts.Services
{
    public interface IDataService
    {
		Task<IEnumerable<Platform>> GetPlatformsAsync();
		Task<Platform> GetPlatformAsync(Guid id);
		Task<Platform> AddPlatformAsync(Platform platform);
		Task<Platform> UpdatePlatformAsync(Platform platform);
		Task DeletePlatformAsync(Guid id);

		Task<IEnumerable<Game>> GetGamesAsync();
		Task<Game> GetGameAsync(Guid id);
		Task<Game> AddGameAsync(Game game);
		Task<Game> UpdateGameAsync(Game game);
		Task DeleteGameAsync(Guid id);

		Task<IEnumerable<Genre>> GetGenresAsync();
		Task<Genre> GetGenreAsync(Guid id);
		Task<Genre> AddGenreAsync(Genre genre);
		Task<Genre> UpdateGenreAsync(Genre genre);
		Task DeleteGenreAsync(Guid id);
	}
}
