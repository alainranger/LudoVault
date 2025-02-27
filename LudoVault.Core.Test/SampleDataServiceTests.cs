using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using LudoVault.Core.Models;
using LudoVault.Core.Services;

namespace LudoVault.Core.Test;

public class SampleDataServiceTests
{
	private readonly SampleDataService _service;

	public SampleDataServiceTests() => _service = new SampleDataService();

	[Fact]
	public async Task GetPlatformsAsyncShouldReturnAllPlatforms()
	{
		var platforms = await _service.GetPlatformsAsync();
		Assert.Equal(5, platforms.Count());
	}

	[Fact]
	public async Task GetPlatformAsyncShouldReturnPlatformWhenIdIsValid()
	{
		var platform = await _service.GetPlatformAsync((await _service.GetPlatformsAsync()).First().Id);
		Assert.NotNull(platform);
	}

	[Fact]
	public async Task GetPlatformAsyncShouldThrowExceptionWhenIdIsInvalid() => await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetPlatformAsync(Guid.NewGuid()));

	[Fact]
	public async Task AddPlatformAsyncShouldAddPlatform()
	{
		var newPlatform = new Platform { Name = "Test Platform" };
		var addedPlatform = await _service.AddPlatformAsync(newPlatform);

		Assert.NotNull(addedPlatform);
		Assert.Equal("Test Platform", addedPlatform.Name);
	}

	[Fact]
	public async Task DeletePlatformAsyncShouldRemovePlatform()
	{
		var platform = await _service.GetPlatformAsync((await _service.GetPlatformsAsync()).First().Id);
		await _service.DeletePlatformAsync(platform.Id);

		await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetPlatformAsync(platform.Id));
	}

	[Fact]
	public async Task UpdatePlatformAsyncShouldUpdatePlatform()
	{
		var platform = await _service.GetPlatformAsync((await _service.GetPlatformsAsync()).First().Id);
		platform.Name = "Updated Platform";

		var updatedPlatform = await _service.UpdatePlatformAsync(platform);

		Assert.Equal("Updated Platform", updatedPlatform.Name);
	}

	[Fact]
	public async Task GetGenresAsyncShouldReturnAllGenres()
	{
		var genres = await _service.GetGenresAsync();
		Assert.Equal(5, genres.Count());
	}

	[Fact]
	public async Task GetGenreAsyncShouldReturnGenreWhenIdIsValid()
	{
		var genre = await _service.GetGenreAsync((await _service.GetGenresAsync()).First().Id);
		Assert.NotNull(genre);
	}

	[Fact]
	public async Task GetGenreAsyncShouldThrowExceptionWhenIdIsInvalid() => await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetGenreAsync(Guid.NewGuid()));

	[Fact]
	public async Task AddGenreAsyncShouldAddGenre()
	{
		var newGenre = new Genre { Name = "Test Genre" };
		var addedGenre = await _service.AddGenreAsync(newGenre);

		Assert.NotNull(addedGenre);
		Assert.Equal("Test Genre", addedGenre.Name);
	}

	[Fact]
	public async Task DeleteGenreAsyncShouldRemoveGenre()
	{
		var genre = await _service.GetGenreAsync((await _service.GetGenresAsync()).First().Id);
		await _service.DeleteGenreAsync(genre.Id);

		await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetGenreAsync(genre.Id));
	}

	[Fact]
	public async Task UpdateGenreAsyncShouldUpdateGenre()
	{
		var genre = await _service.GetGenreAsync((await _service.GetGenresAsync()).First().Id);
		genre.Name = "Updated Genre";

		var updatedGenre = await _service.UpdateGenreAsync(genre);

		Assert.Equal("Updated Genre", updatedGenre.Name);
	}

	[Fact]
	public async Task GetGamesAsyncShouldReturnAllGames()
	{
		var games = await _service.GetGamesAsync();
		Assert.Equal(5, games.Count());
	}

	[Fact]
	public async Task GetGameAsyncShouldReturnGameWhenIdIsValid()
	{
		var game = await _service.GetGameAsync((await _service.GetGamesAsync()).First().Id);
		Assert.NotNull(game);
	}

	[Fact]
	public async Task GetGameAsyncShouldThrowExceptionWhenIdIsInvalid() => await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetGameAsync(Guid.NewGuid()));

	[Fact]
	public async Task AddGameAsyncShouldAddGame()
	{
		var platform = await _service.GetPlatformAsync((await _service.GetPlatformsAsync()).First().Id);
		var genre = await _service.GetGenreAsync((await _service.GetGenresAsync()).First().Id);

		var newGame = new Game
		{
			Title = "Test Game",
			PlatformId = platform.Id,
			GenreId = genre.Id,
			ReleaseYear = 2025,
			Status = GameStatus.NotStarted
		};
		var addedGame = await _service.AddGameAsync(newGame);

		Assert.NotNull(addedGame);
		Assert.Equal("Test Game", addedGame.Title);
	}

	[Fact]
	public async Task DeleteGameAsyncShouldRemoveGame()
	{
		var game = await _service.GetGameAsync((await _service.GetGamesAsync()).First().Id);
		await _service.DeleteGameAsync(game.Id);

		await Assert.ThrowsAsync<KeyNotFoundException>(() => _service.GetGameAsync(game.Id));
	}

	[Fact]
	public async Task UpdateGameAsyncShouldUpdateGame()
	{
		var game = await _service.GetGameAsync((await _service.GetGamesAsync()).First().Id);
		game.Title = "Updated Game";

		var updatedGame = await _service.UpdateGameAsync(game);

		Assert.Equal("Updated Game", updatedGame.Title);
	}
}
