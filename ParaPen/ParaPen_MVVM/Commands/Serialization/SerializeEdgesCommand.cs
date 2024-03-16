using Microsoft.Win32;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System;
using System.Linq;
using static ParaPen.Serializers.EdgesVerticesContainerSerializer;
using static ParaPen.Models.StaticResources.StaticResources;

namespace ParaPen.Commands.Serialization;

public class SerializeEdgesCommand : CommandBase
{
    private readonly BlockDiagramGraph _graph;

    public SerializeEdgesCommand(BlockDiagramGraph graph)
    {
        _graph = graph;
    }

	/// <param name="parameter"> <see cref="BlockPenContainer"/></param>
	public override void Execute(object? parameter)
    {
        if (parameter is not BlockPenContainer bpContainer)
        {
            throw new ArgumentException(null, nameof(parameter));
        }

        SaveFileDialog dialog = new()
        {
            Filter = SUBPROGRAM_FILTER,
            DefaultExt = DEFAULT_EXT,
            FileName = FILE_NAME
        };

        // Отображаем диалоговое окно и обрабатываем результат
        bool? result = dialog.ShowDialog();
        if (result != true)
        {
            return;
        }

        // Получаем путь к выбранному файлу
        string filePath = dialog.FileName;

        // Получаем все вершины BlockPenContainer'а
        var nodes = _graph.GetAllConnectedVertices(bpContainer.StartNode);
        // Получаем все рёбра BlockPenContainer'а
        var edges = _graph.GetAllEdges(nodes);

        Serialize(edges.Cast<BlockEdge>().ToArray(), filePath);
    }
}
