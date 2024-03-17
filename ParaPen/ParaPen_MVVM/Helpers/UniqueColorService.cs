using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Media;

namespace ParaPen.Helpers;

public class UniqueColorService
{ 
	private HashSet<Color> _usedColors = new();
	private static readonly Random _random = new();

	/// <summary>
	/// Порог для контрастности цветов
	/// </summary>
	public int ContrastThreshold { get; set; }


    public UniqueColorService(int contrastThreshold)
    {
		ContrastThreshold = contrastThreshold;
	}


    public Color GetUniqueColor()
	{
		var newColor = GenerateRandomColor();
		while (_usedColors.Any(c => IsColorTooSimilar(c, newColor)))
		{
			newColor = GenerateRandomColor();
		}

		_usedColors.Add(newColor);
		return newColor;
	}

	private static Color GenerateRandomColor()
	{
		byte[] rgb = new byte[3];
		_random.NextBytes(rgb);
		return Color.FromArgb(255, rgb[0], rgb[1], rgb[2]);
	}

	private bool IsColorTooSimilar(Color color1, Color color2)
	{
		var deltaR = Math.Abs(color1.R - color2.R);
		var deltaG = Math.Abs(color1.G - color2.G);
		var deltaB = Math.Abs(color1.B - color2.B);

		return deltaR + deltaG + deltaB < ContrastThreshold;
	}
}
