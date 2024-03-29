﻿using System;
using System.Windows;

namespace ParaPen.Commands;

public class WindowCloseCommand : CommandBase
{
	/// <param name="parameter"><see cref="Window"/></param>
	public override void Execute(object? parameter)
	{
		if (parameter is not Window window)
		{
			throw new ArgumentException(null, nameof(parameter));
		}
		window.Close();
	}
}
