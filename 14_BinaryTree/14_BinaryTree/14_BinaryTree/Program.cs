using System;

namespace _BinaryTree
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			char ans;

			do
			{
				Console.Clear();
				Console.WriteLine("1 ... Add new node");
				Console.WriteLine("2 ... Search node");
				Console.WriteLine("3 ... Remove node");
				int menuAns = int.Parse(Console.ReadLine());

				int value;

				switch (menuAns)
				{
					case 1:
						Console.Write("Enter new value: ");
						value = int.Parse(Console.ReadLine());
						Tree.Get().Insert(value);
						break;
					case 2:
						Console.Write("Enter value: ");
						value = int.Parse(Console.ReadLine());
						Tree.Get().FindValue(value);
						break;
					case 3:
						Console.Write("Enter value: ");
						value = int.Parse(Console.ReadLine());
						Tree.Get().Remove(value);
						break;
				}

				Console.WriteLine("Continue? (y/n)");
				ans = Char.Parse(Console.ReadLine());
			} while (ans.ToString().ToLower() == "y");
		}
	}
}
