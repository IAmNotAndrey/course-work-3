using Microsoft.Win32;
using ParaPen.Models;
using ParaPen.Models.CustomGraph;
using ParaPen.Models.CustomGraph.BlockNodes;
using System;
using System.Linq;
using static ParaPen.Serializers.EdgesVerticesContainerSerializer;

namespace ParaPen.Commands.Serialization;

public class SerializeEdgesCommand : CommandBase
{
    private readonly BlockDiagramGraph _graph;

    public SerializeEdgesCommand(BlockDiagramGraph graph)
    {
        _graph = graph;
    }

    /// <param name="parameter">BlockPenContainer</param>
    public override void Execute(object? parameter)
    {
        if (parameter is not BlockPenContainer bpContainer)
        {
            throw new ArgumentException(null, nameof(parameter));
        }

        SaveFileDialog dialog = new()
        {
            Filter = "PPEV files (*.ppev)|*.ppev",
            DefaultExt = ".ppev",
            FileName = "file"
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

        // NOTE можно хранить только рёбра, так как у графа есть возможность восстанавливать вершины по рёбрам
        //EdgesVerticesContainer evc = new()
        //{
        //    Vertices = nodes.Cast<BlockNode>().ToArray(),
        //    Edges = edges.Cast<BlockEdge>().ToArray()
        //};

        //Serialize(evc, filePath);

        Serialize(edges.Cast<BlockEdge>().ToArray(), filePath);
    }
}
