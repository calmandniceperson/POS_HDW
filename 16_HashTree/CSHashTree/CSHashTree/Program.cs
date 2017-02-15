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
			using (var fs = File.OpenRead(@path))
			using (var reader = new StreamReader(fs))
			{
				reader.ReadLine(); // Skip title line
				while (!reader.EndOfStream)
				{
					var line = reader.ReadLine();
					var values = line.Split(',');

					studentList.Add(new Student(int.Parse(values[0]), values[1], int.Parse(values[2]), values[3], values[4]));
				}
			}

			BinaryHashTree<Student> tree = new BinaryHashTree<Student>();
			tree.BulkCreate(studentList);
		}
	}
}
