using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

using LudoVault.Core.Contracts.Services;
using LudoVault.Core.Models;

namespace LudoVault.Core.Services;

public class SampleDataService : IDataService
{
	private static readonly List<Platform> _platforms =
		[
			new Platform { Id = Guid.NewGuid(), Name = "PC" },
			new Platform { Id = Guid.NewGuid(), Name = "PlayStation" },
			new Platform { Id = Guid.NewGuid(), Name = "Xbox" },
			new Platform { Id = Guid.NewGuid(), Name = "Nintendo" },
			new Platform { Id = Guid.NewGuid(), Name = "Mobile" },
		];

	private static readonly List<Genre> _genres =
		[
			new Genre { Id = Guid.NewGuid(), Name = "Action" },
			new Genre { Id = Guid.NewGuid(), Name = "Adventure" },
			new Genre { Id = Guid.NewGuid(), Name = "RPG" },
			new Genre { Id = Guid.NewGuid(), Name = "Simulation" },
			new Genre { Id = Guid.NewGuid(), Name = "Strategy" },
		];

	private static readonly List<Game> _games =
		[
			new Game { Id = Guid.NewGuid(), Title = "The Witcher 3: Wild Hunt", PlatformId = _platforms.First(x => x.Name == "PC").Id, GenreId = _genres.First(x => x.Name == "RPG").Id, ReleaseYear = 2015, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "The Legend of Zelda: Breath of the Wild", PlatformId = _platforms.First(x => x.Name == "Nintendo").Id, GenreId = _genres.First(x => x.Name == "RPG").Id, ReleaseYear = 2017, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "Red Dead Redemption 2", PlatformId = _platforms.First(x => x.Name == "PlayStation").Id, GenreId = _genres.First(x => x.Name == "Action").Id, ReleaseYear = 2018, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "The Elder Scrolls V: Skyrim", PlatformId = _platforms.First(x => x.Name == "PC").Id, GenreId = _genres.First(x => x.Name == "RPG").Id, ReleaseYear = 2011, Status = GameStatus.NotStarted },
			new Game { Id = Guid.NewGuid(), Title = "Grand Theft Auto V", PlatformId = _platforms.First(x => x.Name == "PC").Id, GenreId = _genres.First(x => x.Name == "Action").Id, ReleaseYear = 2013, Status = GameStatus.NotStarted },
		];

	public async Task<IEnumerable<Platform>> GetPlatformsAsync()
		=> await Task.FromResult(_platforms).ConfigureAwait(true);

	public async Task<Platform> GetPlatformAsync(Guid id)
		=> await Task.Run(() => _platforms.Find(p => p.Id == id) ?? throw new KeyNotFoundException($"Platform with Id {id} not found."))
			.ConfigureAwait(true);

	public async Task<Platform> AddPlatformAsync(Platform platform)
	{
		ArgumentNullException.ThrowIfNull(platform);

		var newPlatform = new Platform
		{
			Id = Guid.NewGuid(),
			Name = platform.Name
		};

		_platforms.Add(newPlatform);

		return await Task.FromResult(newPlatform).ConfigureAwait(true);
	}

	public Task DeletePlatformAsync(Guid id)
	{
		var platform = _platforms.Find(p => p.Id == id) ?? throw new KeyNotFoundException($"Platform with Id {id} not found.");

		_platforms.Remove(platform);

		return Task.CompletedTask;
	}

	public Task<Platform> UpdatePlatformAsync(Platform platform)
	{
		ArgumentNullException.ThrowIfNull(platform);

		var existingPlatform = _platforms.Find(p => p.Id == platform.Id) ?? throw new KeyNotFoundException($"Platform with Id {platform.Id} not found.");
		existingPlatform.Name = platform.Name;

		return Task.FromResult(existingPlatform);
	}

	public async Task<IEnumerable<Genre>> GetGenresAsync()
		=> await Task.FromResult(_genres).ConfigureAwait(true);

	public async Task<Genre> GetGenreAsync(Guid id)
		=> await Task.Run(() => _genres.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Genre with Id {id} not found."))
			.ConfigureAwait(true);

	public async Task<Genre> AddGenreAsync(Genre genre)
	{
		ArgumentNullException.ThrowIfNull(genre);

		var newGenre = new Genre
		{
			Id = Guid.NewGuid(),
			Name = genre.Name
		};

		_genres.Add(newGenre);

		return await Task.FromResult(newGenre).ConfigureAwait(true);
	}

	public Task DeleteGenreAsync(Guid id)
	{
		var genre = _genres.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Genre with Id {id} not found.");

		_genres.Remove(genre);

		return Task.CompletedTask;
	}

	public Task<Genre> UpdateGenreAsync(Genre genre)
	{
		ArgumentNullException.ThrowIfNull(genre);

		var existingGenre = _genres.Find(g => g.Id == genre.Id) ?? throw new KeyNotFoundException($"Genre with Id {genre.Id} not found.");
		existingGenre.Name = genre.Name;

		return Task.FromResult(existingGenre);
	}

	public async Task<IEnumerable<Game>> GetGamesAsync()
		=> await Task.FromResult(_games).ConfigureAwait(true);

	public async Task<Game> GetGameAsync(Guid id)
		=> await Task.Run(() =>_games.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Game with Id {id} not found."))
		.ConfigureAwait(true);

	public async Task<Game> AddGameAsync(Game game)
	{
		ArgumentNullException.ThrowIfNull(game);

		var newGame = new Game
		{
			Id = Guid.NewGuid(),
			Title = game.Title,
			PlatformId = game.PlatformId,
			GenreId = game.GenreId,
			ReleaseYear = game.ReleaseYear,
			Status = game.Status
		};

		_games.Add(newGame);

		return await Task.FromResult(newGame).ConfigureAwait(true);
	}

	public Task DeleteGameAsync(Guid id)
	{
		var game = _games.Find(g => g.Id == id) ?? throw new KeyNotFoundException($"Game with Id {id} not found.");

		_games.Remove(game);

		return Task.CompletedTask;
	}

	public Task<Game> UpdateGameAsync(Game game)
	{
		ArgumentNullException.ThrowIfNull(game);

		var existingGame = _games.Find(g => g.Id == game.Id) ?? throw new KeyNotFoundException($"Game with Id {game.Id} not found.");
		existingGame.Title = game.Title;
		existingGame.PlatformId = game.PlatformId;
		existingGame.GenreId = game.GenreId;
		existingGame.ReleaseYear = game.ReleaseYear;
		existingGame.Status = game.Status;

		return Task.FromResult(existingGame);
	}
}

