using ParaPen.Models.EventArgs;
using ParaPen.Models.Interfaces;
using System;

namespace ParaPen.Commands;

public class MoveUserViewCommand : CommandBase
{
	private readonly IUserViewMover _userViewMover;

    public MoveUserViewCommand(IUserViewMover userViewMover)
    {
        _userViewMover = userViewMover;
    }

    public override void Execute(object parameter)
	{
		if (parameter is PositionEventArgs args)
		{
			_userViewMover.MoveUserView(args.Old, args.New);
		}
		else
		{
			throw new ArgumentException($"Expected parameter of type {typeof(PositionEventArgs).Name}, but received {parameter?.GetType().Name}", nameof(parameter));
		}
	}
}
