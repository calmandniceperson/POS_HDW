using System;
using System.Text;

namespace CSHashTree
{
	public class Node
	{
		public int ID { get; set; }
		public string Hash { get; set; }

		public Node Parent { get; set; }

		public Node LeftChild { get; set; }
		public Node RightChild { get; set; }

		public Node(int id, string value)
		{
			ID = id;
			Hash = value;
		}

		public Node(int id, string value, Node leftChild, Node rightChild)
		{
			ID = id;
			Hash = value;
			LeftChild = leftChild;
			RightChild = rightChild;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine($"ID: {ID}");
			sb.AppendLine($"Hash \"{Hash}\"");
			if (LeftChild != null && RightChild != null)
			{
				sb.AppendLine($"LeftChild: {LeftChild.ToString()}\tRightChild: {RightChild.ToString()}");
			}
			return sb.ToString();
		}
	}
}
