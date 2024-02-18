using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Windows;
using System.Windows.Controls;

namespace ParaPen;
//removeme?
public class ImageLoader
{
	public static void Image(Uri uri, Image image)
	{
		BitmapImage bitmap = new(uri);
		image.Source = bitmap;
	}
}
