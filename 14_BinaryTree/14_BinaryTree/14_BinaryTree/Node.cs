using System;
namespace _BinaryTree
{
	public class Node
	{
		public Node LeftNode { get; set; }
		public int Value { get; set; }
		public Node RightNode { get; set; }

		public Node(Node leftNode, int val, Node rightNode)
		{
			LeftNode = leftNode;
			Value = val;
			RightNode = rightNode;
		}

		public override string ToString()
		{
			return string.Format("[Node: LeftNode={0}, Value={1}, RightNode={2}]", LeftNode, Value, RightNode);
		}
	}
}
