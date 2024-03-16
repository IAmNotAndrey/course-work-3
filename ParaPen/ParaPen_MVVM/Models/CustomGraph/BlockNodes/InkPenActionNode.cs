using ParaPen.Models.Enums;
using System;
using System.Runtime.Serialization;
using System.Windows.Controls;
using static ParaPen.Helpers.InkPenHelper;

namespace ParaPen.Models.CustomGraph.BlockNodes;

[DataContract]
public class InkPenActionNode : BlockNode
{
	[DataMember]
	public double StepValue { get; init; }

	[DataMember]
	public PenActions PenAction { get; init; }

	[DataMember]
	public Directions Direction { get; init; }

	[IgnoreDataMember]
	public Action? Action { get; set; }


	[Obsolete]
	public InkPenActionNode() { }

	public InkPenActionNode(double stepValue, PenActions penAction, Directions direction)
	{
		StepValue = stepValue;
		PenAction = penAction;
		Direction = direction;

		Label = $"{PenAction} - {Direction}";
		IsHighlighted = false;
	}

	public ActionNode ToActionNode(InkPen inkPen, InkCanvas inkCanvas)
	{
		Action action = GetActionOutOfPenActions(StepValue, PenAction, Direction, inkPen, inkCanvas);

		return new ActionNode(action);
	}

	public override bool Execute()
	{
		if (Action is null)
		{
			throw new NullReferenceException(nameof(Action));
		}
		Action.Invoke();
		return true;
		//throw new NotImplementedException($"{nameof(InkPenActionNode)} должно быть преобразовано в {nameof(ActionNode)} перед использованием");
		//return false;
	}

	//public override string ToString()
	//{
	//	return $"{PenAction} - {Direction}";
	//}
}
