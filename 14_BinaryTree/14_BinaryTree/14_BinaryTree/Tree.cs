using System;

namespace _BinaryTree
{
	public class Tree
	{
		static Tree instance;

		public static Tree Get()
		{
			if (instance == null)
			{
				instance = new Tree();
			}
			return instance;
		}

		Node RootNode { get; set; }

		public void Insert(int val)
		{
			if (RootNode == null)
			{
				RootNode = new Node(null, val, null);
			}
			else
			{
				insertRecursive(val, RootNode);
			}
		}

		void insertRecursive(int val, Node currentNode)
		{
			Console.WriteLine($"Current node: {currentNode.Value}");
			if (val < currentNode.Value)
			{
				Console.WriteLine("Went down left subtree");
				if (currentNode.LeftNode == null)
				{
					Console.WriteLine("Inserted value");
					currentNode.LeftNode = new Node(null, val, null);
					return;
				}
				insertRecursive(val, currentNode.LeftNode);
			}
			else if (val > currentNode.Value)
			{
				Console.WriteLine("Went down right subtree");
				if (currentNode.RightNode == null)
				{
					Console.WriteLine("Inserted value");
					currentNode.RightNode = new Node(null, val, null);
					return;
				}
				insertRecursive(val, currentNode.RightNode);
			}
		}

		public void FindValue(int val)
		{
			if (RootNode == null) { return; }
			findValueRecursive(val, RootNode);
		}

		void findValueRecursive(int val, Node currentNode)
		{
			//Console.WriteLine($"Current node: {currentNode.ToString()}");
			Console.WriteLine($"Current node: {currentNode.Value}");
			if (val == currentNode.Value)
			{
				Console.WriteLine("Found it!");
			}
			else if (val < currentNode.Value)
			{
				if (currentNode.LeftNode == null)
				{
					Console.WriteLine("Value does not exist");
					return;
				}
				Console.WriteLine("Went down left subtree");
				findValueRecursive(val, currentNode.LeftNode);
			}
			else if (val > currentNode.Value)
			{
				if (currentNode.RightNode == null)
				{
					Console.WriteLine("Value does not exist");
					return;
				}
				Console.WriteLine("Went down right subtree");
				findValueRecursive(val, currentNode.RightNode);
			}
		}

		public void Remove(int val)
		{
			if (RootNode == null) { return; }
			removeRecursive(val, RootNode);
		}

		void removeRecursive(int val, Node currentNode)
		{
			if (currentNode.LeftNode != null && currentNode.LeftNode.Value == val)
			{
				if (currentNode.LeftNode.LeftNode == null && currentNode.LeftNode.RightNode == null)
				{
					currentNode.LeftNode = null;
				}
				else if (currentNode.LeftNode.LeftNode != null && currentNode.LeftNode.LeftNode != null)
				{
					currentNode.LeftNode.Value = findMin(currentNode.LeftNode).Value;
				}
				else
				{
					currentNode.LeftNode = (currentNode.LeftNode.LeftNode != null) ? currentNode.LeftNode.LeftNode : currentNode.RightNode.RightNode;
				}
			}
			else if (currentNode.RightNode != null && currentNode.RightNode.Value == val)
			{
				if (currentNode.RightNode.LeftNode == null && currentNode.RightNode.RightNode == null)
				{
					currentNode.RightNode = null;
				}
				else if (currentNode.RightNode.LeftNode != null && currentNode.RightNode.LeftNode != null)
				{
					currentNode.RightNode.Value = findMin(currentNode.RightNode).Value;
				}
				else
				{
					currentNode.RightNode = (currentNode.LeftNode != null) ? currentNode.LeftNode : currentNode.RightNode;
				}
			}
			else if (currentNode.Value > val)
			{
				removeRecursive(val, currentNode.LeftNode);
			}
			else if (currentNode.Value < val)
			{
				removeRecursive(val, currentNode.RightNode);
			}
		}

		private Node findMin(Node currentNode)
		{
			if (currentNode == null)
			{
				return null;
			}
			if (currentNode.LeftNode == null)
			{
				return currentNode;
			}
			return findMin(currentNode.LeftNode);

		}
	}
}
