using ParaPen.Models.Enums;
using System;
using System.Runtime.Serialization;
using System.Windows.Controls;
using System.Xml.Serialization;
using static ParaPen.Helpers.NodeHelper;

namespace ParaPen.Models.CustomGraph.BlockNodes;

//[Serializable]
[DataContract]
public class InkPenActionNode : BlockNode
{
	[DataMember]
	public double StepValue { get; init; }

	[DataMember]
	public PenActions PenAction { get; init; }

	[DataMember]
	public Directions Direction { get; init; }

	//[XmlIgnore]
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


	///// <summary>
	///// Всегда возвращает <see langword="false">, так как сама по себе напрямую не используется а преображается в <see cref="ActionNode"/>
	///// </summary>
	///// <returns><see langword="false"/></returns>
	/// <summary>
	/// Вызывает исключение
	/// </summary>
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
