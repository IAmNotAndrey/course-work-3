using ParaPen.Models.Enums;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows;

namespace ParaPen.Models.StaticResources;

public static class StaticResources
{
	// NOTE : координаты по Y перевёрнуты 
	public static ImmutableDictionary<Directions, Vector> DirectionVectorDict { get; } = new Dictionary<Directions, Vector>
	{
		{ Directions.Up,		new Vector(0, -1) },
		{ Directions.UpLeft,	new Vector(-1, -1) },
		{ Directions.UpRight,	new Vector(1, -1) },

		{ Directions.Right,		new Vector(1, 0) },
		{ Directions.Left,		new Vector(-1, 0) },

		{ Directions.Down,		new Vector(0, 1) },
		{ Directions.DownLeft,	new Vector(-1, 1) },
		{ Directions.DownRight, new Vector(1, 1) }
	}.ToImmutableDictionary();

	public const uint BLOCK_DIAGRAM_LIMIT = 3;
}
