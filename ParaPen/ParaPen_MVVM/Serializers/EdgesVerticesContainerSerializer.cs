using ParaPen.Models.CustomGraph;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace ParaPen.Serializers;

public static class EdgesVerticesContainerSerializer
{
	private static readonly DataContractSerializerSettings _dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
	private static readonly DataContractSerializer _serializer = new(typeof(BlockEdge[]), _dcss);

	public static void Serialize(BlockEdge[] edges, string fileName)
	{
		using FileStream fs = new(fileName, FileMode.OpenOrCreate);
		_serializer.WriteObject(fs, edges);
	}

	public static BlockEdge[] Deserialize(string fileName)
	{
		using FileStream fs = new(fileName, FileMode.Open);
		BlockEdge[] edges = (BlockEdge[])_serializer.ReadObject(fs)!
			?? throw new Exception($"Cannot deserialize {fs}");

		return edges;
	}

	//private static readonly DataContractSerializerSettings _dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
	//private static readonly DataContractSerializer _serializer = new(typeof(EdgesVerticesContainer), _dcss);

	//public static void Serialize(EdgesVerticesContainer container, string fileName)
	//{
	//	using FileStream fs = new(fileName, FileMode.OpenOrCreate);
	//	_serializer.WriteObject(fs, container);
	//}

	//public static EdgesVerticesContainer Deserialize(string fileName)
	//{
	//	using FileStream fs = new(fileName, FileMode.Open);
	//	EdgesVerticesContainer container = (EdgesVerticesContainer)_serializer.ReadObject(fs)!
	//		?? throw new Exception($"Cannot deserialize {fs}");

	//	return container;
	//}

	//public static void Serialize<T>(T obj, string filePath)
	//{
	//	using var stream = new FileStream(filePath, FileMode.OpenOrCreate);
	//	var serializer = new DataContractSerializer(typeof(T));
	//	serializer.WriteObject(stream, obj);
	//}

	//public static T Deserialize<T>(string filePath)
	//{
	//	using var stream = new FileStream(filePath, FileMode.Open);
	//	var serializer = new DataContractSerializer(typeof(T));
	//	return (T)serializer.ReadObject(stream)!;
	//}
}
