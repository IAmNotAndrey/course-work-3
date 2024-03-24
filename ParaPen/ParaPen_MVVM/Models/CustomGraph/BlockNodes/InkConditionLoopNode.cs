using ParaPen.Models.Enums;

namespace ParaPen.Models.CustomGraph.BlockNodes;

public class InkConditionLoopNode : InkConditionNode
{
	public InkConditionLoopNode(double stepValue, Directions direction) : base(stepValue, direction)
	{
	}
}
