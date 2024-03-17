using ParaPen.Models.Enums;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Windows;

namespace ParaPen.Models.StaticResources;

public static class AppConfig
{
	public const double USER_VIEW_SPEED = 2;
	public const double ZOOM_FACTOR = 1.1;

	public const double PEN_STROKE_WIDTH = 3;
	public const double PEN_STROKE_HEIGHT = 3;
	public static readonly Vector PEN_START_CORDS = new(50, 50);

	public static readonly TimeSpan ACTION_DELAY_TIME = new(0, 0, 0, 0, 8);

	public const uint BLOCK_DIAGRAM_LIMIT = 3;
	public const double STEP_VALUE = 50;

	public const int CONTRAST_THRESHOLD = 200;

	// ParaPen SubProgram
	public const string SUBPROGRAM_FILTER = "ParaPen SubProgram files (*.ppsp)|*.ppsp";
	public const string DEFAULT_EXT = ".ppsp";
	public const string FILE_NAME = "file";


	// NOTE : координаты по Y перевёрнуты 
	public static ImmutableDictionary<Directions, Vector> DirectionVectorDict { get; } = new Dictionary<Directions, Vector>
	{
		{ Directions.Up,        new Vector(0, -1) },
		{ Directions.UpLeft,    new Vector(-1, -1) },
		{ Directions.UpRight,   new Vector(1, -1) },

		{ Directions.Right,     new Vector(1, 0) },
		{ Directions.Left,      new Vector(-1, 0) },

		{ Directions.Down,      new Vector(0, 1) },
		{ Directions.DownLeft,  new Vector(-1, 1) },
		{ Directions.DownRight, new Vector(1, 1) }
	}.ToImmutableDictionary();
}
