using ParaPen.Models;
using System;
using System.IO;
using System.Runtime.Serialization;

namespace ParaPen.Serializers;

public static class EdgesVerticesContainerSerializer
{
	private static readonly DataContractSerializerSettings _dcss = new DataContractSerializerSettings { PreserveObjectReferences = true };
	private static readonly DataContractSerializer _serializer = new(typeof(EdgesVerticesContainer), _dcss);

	public static void SerializeXml(EdgesVerticesContainer container, string fileName)
	{
		using FileStream fs = new(fileName, FileMode.OpenOrCreate);
		_serializer.WriteObject(fs, container);
	}

	public static EdgesVerticesContainer DeserializeXml(string fileName)
	{
		using FileStream fs = new(fileName, FileMode.Open);
		EdgesVerticesContainer container = (EdgesVerticesContainer)_serializer.ReadObject(fs)!
			?? throw new Exception($"Cannot deserialize {fs}");

		return container;
	}

}
