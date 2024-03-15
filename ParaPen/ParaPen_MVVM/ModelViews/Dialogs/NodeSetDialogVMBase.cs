using ParaPen.Models.CustomGraph.BlockNodes;

namespace ParaPen.ModelViews.Dialogs;

public class NodeSetDialogVMBase : DialogVMBase
{
	// fixme небезопасно
	public BlockNode? CreatedNode { get; set; }

	//private BlockNode? _createdNode;
	//public BlockNode? CreatedNode
	//{
	//	get { return _createdNode; }
	//	set
	//	{
	//		if (_createdNode != value)
	//		{
	//			_createdNode = value;
	//			OnPropertyChanged(nameof(CreatedNode));
	//		}
	//	}
	//}
}
