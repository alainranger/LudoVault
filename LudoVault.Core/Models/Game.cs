using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LudoVault.Core.Models;

public class Game
{
	public Guid Id { get; init; }
	public string Title { get; set; } = string.Empty;
	public Guid PlatformId { get; set; }
	public Guid GenreId { get; set; }
	public int ReleaseYear { get; set; }
	public GameStatus Status { get; set; }

	public virtual Genre? Genre { get; set; }
	public virtual Platform? Platform { get; set; }
}
