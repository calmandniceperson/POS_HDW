using System;
using System.Collections.Generic;
using System.IO;

namespace CSHashTree
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			Console.Clear();

			List<Student> studentList = new List<Student>();

			string path = "../../../list.csv";
			if (!File.Exists(path))
			{
				Console.WriteLine("File not found");
				return;
			}

			int elemCount = 0;

			using (var fs = File.OpenRead(@path))
			using (var reader = new StreamReader(fs))
			{
				reader.ReadLine(); // Skip title line
				while (!reader.EndOfStream)
				{
					elemCount++;
					var line = reader.ReadLine();
					var values = line.Split(',');

					studentList.Add(new Student(int.Parse(values[0]), values[1], int.Parse(values[2]), values[3], values[4]));
				}
			}

			BinaryHashTree<Student> tree = new BinaryHashTree<Student>();
			tree.BulkCreate(studentList);

			int layerCount = (int)Math.Ceiling(Math.Log(elemCount, 2) + 1);
			double nodeCount = Math.Ceiling(Math.Pow(2, (layerCount+1)) - 1);
			Console.WriteLine($"Number of elements: {elemCount}\nNumber of nodes: {nodeCount}\nNumber of layers: {layerCount}");
		}
	}
}
