using ParaPen.Models.CustomGraph.BlockNodes;

namespace ParaPen.ModelViews.Dialogs;

public class NodeSetDialogVMBase : DialogVMBase
{
	// fixme? небезопасно
	public BlockNode? CreatedNode { get; set; }
}
