using System;

namespace ParaPen.Models.CustomGraph.BlockNodes;

// TODO
public class SubprogramNode : BlockNode
{
	private readonly Action<BlockPenContainer> _subprogramAction;

	//public SubprogramNode(string label, Action<BlockPenContainer> subprogramAction) : base(label)
	//{
	//	_subprogramAction = subprogramAction;
	//}
	public SubprogramNode(Action<BlockPenContainer> subprogramAction)
	{
		_subprogramAction = subprogramAction;
	}

	public override bool Execute()
	{
		// ADDME возможно при выполнении данной ноды стоит подменить ссылку: `this=TerminationNode` и начать выполнение уже `TerminationNode`
		throw new NotImplementedException();
		//BlockPenContainer subprogramContainer = new(); // Создаем новый контейнер
		//_subprogramAction.Invoke(subprogramContainer); // Выполняем подпрограмму
		//return true;
	}
}
// через (не-)явную типизацию класс SpecializedActionNode приводим к ActionNode. Сохранение для подпрограмм происходит в SpecializedActionNode, потом интерпретируется в ActionNode