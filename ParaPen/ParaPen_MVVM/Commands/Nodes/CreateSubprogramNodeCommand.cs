using Microsoft.Win32;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews.Dialogs;
using static ParaPen.Serializers.EdgesVerticesContainerSerializer;
using static ParaPen.Models.StaticResources.AppConfigs;

namespace ParaPen.Commands.Nodes;

public class CreateSubprogramNodeCommand : CommandBase
{
	private readonly NodeSetDialogVMBase _vm;
	private readonly BlockPenContainer _bpContainer;

	public CreateSubprogramNodeCommand(NodeSetDialogVMBase vm, BlockPenContainer bpContainer)
	{
		_vm = vm;
		_bpContainer = bpContainer;
	}

	/// <param name="parameter"><see langword="null"/></param>
	public override void Execute(object? parameter)
    {
		OpenFileDialog dialog = new()
		{
			Filter = SUBPROGRAM_FILTER
		};

		bool? result = dialog.ShowDialog();
		if (result != true)
		{
			return;
		}
		
		string filePath = dialog.FileName;

		BlockEdge[] edges = Deserialize(filePath);

		SubprogramNode node = new(_bpContainer, edges);
		//fixme?
		_vm.CreatedNode = node;
    }
}
