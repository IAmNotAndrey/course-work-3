using System;
using System.ComponentModel;
using static ParaPen.Helpers.NodeHelper;

namespace ParaPen.Models.CustomGraph.BlockNodes;

// TODO
[Serializable]
public class SubprogramNode : BlockNode
{
	private readonly BlockPenContainer _container;
	private readonly BlockDiagramGraph _localBlockDiagram;

	//private readonly Action<BlockPenContainer> _subprogramAction;

	//public SubprogramNode(string label, Action<BlockPenContainer> subprogramAction) : base(label)
	//{
	//	_subprogramAction = subprogramAction;
	//}
	//public SubprogramNode(Action<BlockPenContainer> subprogramAction)
	//{
	//	_subprogramAction = subprogramAction;
	//}

	[Obsolete]
	public SubprogramNode() { }

	public SubprogramNode(BlockPenContainer container, BlockDiagramGraph localBlockDiagram)
    {
		_container = container;
		_localBlockDiagram = localBlockDiagram;
	}

    public override bool Execute()
	{
		BlockNode node = _container.SelectedNode!;

		bool branchValue = node.Execute();

		BlockNode? target = ReturnNextNode(node, branchValue, _localBlockDiagram);
		_container.SelectedNode = target;

		// Если target is null, значит работа подпрограммы закончилась
		if (target is null) 
		{
			//fixme? можно прогонять ноду через цикл. reset? 
			_container.Reset();
			return true;
		}
		return false;

		// ADDME возможно при выполнении данной ноды стоит подменить ссылку: `this=TerminationNode` и начать выполнение уже `TerminationNode`
		//BlockPenContainer subprogramContainer = new(); // Создаем новый контейнер
		//_subprogramAction.Invoke(subprogramContainer); // Выполняем подпрограмму
		//return true;
	}
}
// через (не-)явную типизацию класс SpecializedActionNode приводим к ActionNode. Сохранение для подпрограмм происходит в SpecializedActionNode, потом интерпретируется в ActionNode