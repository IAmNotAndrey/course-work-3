using Microsoft.Win32;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using ParaPen.ModelViews.Dialogs;
using System.Collections;
using System.Collections.Generic;
using static ParaPen.Serializers.EdgesVerticesContainerSerializer;

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

	/// <param name="parameter">null</param>
	public override void Execute(object? parameter)
    {
		OpenFileDialog dialog = new()
		{
			Filter = "PPEV files (*.ppev)|*.ppev",
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
