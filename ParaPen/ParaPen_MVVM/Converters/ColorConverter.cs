namespace ParaPen.Converters;

public static class ColorConverter
{
	public static System.Drawing.Color ToDrawingColor(this System.Windows.Media.Color wpfColor)
	{
		return System.Drawing.Color.FromArgb(wpfColor.A, wpfColor.R, wpfColor.G, wpfColor.B);
	}
}